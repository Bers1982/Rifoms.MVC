using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Rifoms.Web.Infrastructure.Routing
{
    public class FromRouteUnsafeModelBinder : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata is not DefaultModelMetadata metadata) return null;
            var attribs = metadata.Attributes.ParameterAttributes;
            return attribs == null
              ? null
              // handle all [FromRoute] string parameters
              : attribs.Any(pa => pa.GetType() == typeof(FromRouteAttribute))
                  && metadata.ModelType == typeof(string)
                ? new BinderTypeModelBinder(typeof(RouteUnsafeBinder))
                : null;
        }
    }
}
