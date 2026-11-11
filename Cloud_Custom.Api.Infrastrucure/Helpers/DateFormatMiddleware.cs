using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Infrastructure.Helpers
{
    public class DateFormatMiddleware
    {
        private readonly RequestDelegate _next;

        public DateFormatMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            CultureInfo customCulture = new CultureInfo("en-US");
            customCulture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            Thread.CurrentThread.CurrentCulture = customCulture;
            Thread.CurrentThread.CurrentUICulture = customCulture;

            await _next(context);
        }
    }

}
