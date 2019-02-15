﻿using Newtonsoft.Json;

namespace VacationsTracker.Core.DTO
{
    internal class BaseResultOfVacationRequest
    {
        [JsonProperty("code")]
        public BaseClassCode Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public VacationDto Result { get; set; }
    }
}