using System;
using System.Runtime.Remoting.Messaging;
using Nancy;

namespace AddressLookup.Api.Logging
{
    public static class CallContextSink
    {
        private const string NancyContextKey = "NancyContext";
        private const string TraceIdKey = "TraceId";

        public static NancyContext NancyContext
        {
            get { return CallContext.LogicalGetData(NancyContextKey) as NancyContext; }
            set { CallContext.LogicalSetData(NancyContextKey, value); }
        }

        public static Guid? TraceId
        {
            get { return CallContext.LogicalGetData(TraceIdKey) as Guid?; }
            set { CallContext.LogicalSetData(TraceIdKey, value); }
        }

        public static void FreeCallContext()
        {
            CallContext.FreeNamedDataSlot(NancyContextKey);
            CallContext.FreeNamedDataSlot(TraceIdKey);
        }
    }
}