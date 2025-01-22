﻿using Microsoft.AspNetCore.Mvc;
using ShortLink.Shared.Result;
using ShortLink.Shared.Extensions;

namespace ShortLink.Presentation.Extensions
{
    public static class MapToProblemDetailsExtension
    {
        public static ProblemDetails MapToProblemDetails(this Result result) 
            => new()
        {
            Status = (int)result.Error.Type,
            Type = nameof(result.Error.Type),
            Title = result.Error.Type.GetDescription(),
            Detail = result.Error.Message
        };
    }
}