﻿using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using RC.Discovery.Client.Abstractions;

namespace Rabbit.Cloud.Facade.Internal
{
    public class RequestMessageBuilderContext
    {
        public RequestMessageBuilderContext(MethodInfo method, object[] arguments, RabbitContext rabbitContext)
        {
            Method = method;
            RequestMessage = rabbitContext.Request.RequestMessage;
            RabbitContext = rabbitContext;
            Arguments = new Dictionary<string, object>();

            var index = 0;
            foreach (var parameterInfo in method.GetParameters())
            {
                Arguments[parameterInfo.Name] = arguments[index];
                index = index + 1;
            }
        }

        public IDictionary<string, object> Arguments { get; }
        public MethodInfo Method { get; set; }
        public HttpRequestMessage RequestMessage { get; }
        public RabbitContext RabbitContext { get; }
        public bool Canceled { get; set; }

        public object GetArgument(string parameterName)
        {
            Arguments.TryGetValue(parameterName, out var value);
            return value;
        }
    }
}