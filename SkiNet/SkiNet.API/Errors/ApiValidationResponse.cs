﻿using System.Collections.Generic;

namespace SkiNet.API.Errors
{
    public class ApiValidationResponse : ApiResponse
    {
        public ApiValidationResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
