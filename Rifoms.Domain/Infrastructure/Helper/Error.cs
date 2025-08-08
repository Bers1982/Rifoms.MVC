using System;

using Newtonsoft.Json;

namespace Rifoms.Domain.Infrastructure.Helper
{
    [Serializable]
    public class Error
    {
        //[JsonConstructor]
        //public Error(string message)
        //{
        //    this.Message = message;
        //}
        [JsonProperty(PropertyName ="message")]
        public string Message { get; set; }
    }
}
