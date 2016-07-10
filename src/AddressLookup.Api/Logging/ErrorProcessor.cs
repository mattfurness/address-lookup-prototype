using System;
using Nancy;
using Serilog;

namespace AddressLookup.Api.Logging
{
    public static class ErrorProcessor
    {
        public static Response Process(NancyContext context, Exception ex)
        {
            Log.Logger.Error(ex, "Error occured processing the request.");

            return HttpStatusCode.InternalServerError;
        }
    }
}