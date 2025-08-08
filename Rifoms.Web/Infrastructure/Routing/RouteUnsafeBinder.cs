﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Rifoms.Web.Infrastructure.Routing
{
    public class RouteUnsafeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //ArgumentNullException.ThrowIfNull(bindingContext);

            var modelName = bindingContext.ModelName;

            // make sure the param we want was extracted in the standard method
            // this will be the partially-decoded value that we're looking to avoid using here
            if (!bindingContext.ActionContext.RouteData.Values.ContainsKey(modelName))
                throw new NotSupportedException();

            // wrap the param in curly braces so we can look for it in the [Route(...)] path
            var templateToMatch = $"{{{modelName}}}";

            // if this is null then the developer forgot the [Route(...)] attribute
            var request = bindingContext.HttpContext.Request;
            var template = (bindingContext.ActionContext.ActionDescriptor.AttributeRouteInfo?.Template)
              ?? throw new NotSupportedException();

            // get the raw url that was called
            var rawTarget = bindingContext.HttpContext.Features.Get<IHttpRequestFeature>()?.RawTarget
              ?? throw new NotSupportedException();
            // strip the query string
            var path = new Uri($"{request.Scheme}://{request.Host}{rawTarget}").AbsolutePath;

            // go through route template and find which segment we need to extract by index
            var index = template
              .Split('/', StringSplitOptions.RemoveEmptyEntries)
              .Select((segment, index) => new { segment, index })
              .SingleOrDefault(iter =>
                  iter.segment.Equals(templateToMatch, StringComparison.OrdinalIgnoreCase))
              ?.index;

            var segments = path.ToString().Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (index.HasValue)
            {
                // extract and decode the target path segment
                var rawUrlSegment = segments[index.Value];
                var decoded = Uri.UnescapeDataString(rawUrlSegment);
                bindingContext.Result = ModelBindingResult.Success(decoded);
            }
            else
            {
                // can't think of any scenarios where we'd hit this
                throw new NotSupportedException();
            }

            return Task.CompletedTask;
        }
    }
}
