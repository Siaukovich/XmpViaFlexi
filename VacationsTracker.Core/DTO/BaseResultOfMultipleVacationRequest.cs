using System.Collections.Generic;
using Newtonsoft.Json;

namespace VacationsTracker.Core.DTO
{
    internal class BaseResultOfMultipleVacationRequest
    {
        [JsonProperty("code")]
        public BaseClassCode Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public IEnumerable<VacationDto> Result { get; set; }
    }
}