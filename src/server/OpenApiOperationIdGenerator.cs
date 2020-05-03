using System;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace FMBQ.Hub
{
    internal class OpenApiOperationIdGenerator : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            string methodName = context.MethodInfo.Name;
            string camelCase = Char.ToLowerInvariant(methodName[0]) + methodName.Substring(1);
            context.OperationDescription.Operation.OperationId = camelCase;

            return true;
        }
    }
}
