﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainApi
{
    public class PreflightRequestMiddleware
    {
        private readonly RequestDelegate Next;

        public PreflightRequestMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }

        private Task BeginInvoke(HttpContext context)
        {
            // Do stuff here
            return Next.Invoke(context);
        }
    }

    public static class PreflightRequestExtensions
    {
        public static IApplicationBuilder UsePreflightRequestHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PreflightRequestMiddleware>();
        }
    }
}
