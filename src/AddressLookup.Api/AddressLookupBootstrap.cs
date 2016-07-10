using System;
using AddressLookup.Api.Logging;
using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using Nancy.Responses.Negotiation;

namespace AddressLookup.Api
{
    class AddressLookupBootstrap : AutofacNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(c =>
                {
                    c.ResponseProcessors.Clear();
                    c.ResponseProcessors.Add(typeof(JsonProcessor));
                });
            }
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            ConfigureCors(pipelines);
            ConfigureErrorHandling(pipelines);
            ConfigureCallContext(pipelines);
            ConfigureAcceptHeaderValidation(pipelines);
        }

        private static void ConfigureCallContext(IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline(context =>
            {
                CallContextSink.NancyContext = context;
                CallContextSink.TraceId = Guid.NewGuid();

                return null;
            });

            pipelines.AfterRequest.AddItemToEndOfPipeline(context => CallContextSink.FreeCallContext());
        }

        protected override ILifetimeScope GetApplicationContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(GetType().Assembly);

            return builder.Build();
        }

        private static void ConfigureCors(IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(x => AddCorsHeaders(x.Response));
        }

        private static void ConfigureErrorHandling(IPipelines pipelines)
        {
            pipelines.OnError.AddItemToEndOfPipeline((context, ex) =>
            {
                var response = ErrorProcessor.Process(context, ex);
                return AddCorsHeaders(response);
            });
        }

        private static void ConfigureAcceptHeaderValidation(IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToStartOfPipeline(ctx =>
            {
                var headers = ctx.Request.Headers;
                foreach (var header in headers.Accept)
                {
                    try
                    {
                        new MediaRange(header.Item1);
                    }
                    catch (Exception)
                    {
                        return HttpStatusCode.BadRequest;
                    }
                }

                return null;
            });
        }

        private static Response AddCorsHeaders(Response response)
        {
            response.WithHeader("Access-Control-Allow-Origin", "*");
            response.WithHeader("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTIONS");
            response.WithHeader("Access-Control-Allow-Headers", "Origin,X-Requested-With,X-Api-SessionToken,X-Api-Key,X-Project-Id,Content-Type,Accept,Authorization,Accept-Encoding");
            response.WithHeader("Access-Control-Expose-Headers", "Location,Content-Type,Content-Encoding,Content-Length,X-Api-SessionToken");

            return response;
        }
    }
}
