// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Swagger2
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ErrorLog.
    /// </summary>
    public static partial class ErrorLogExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='serviceName'>
            /// </param>
            /// <param name='exceptionTypeName'>
            /// </param>
            /// <param name='message'>
            /// </param>
            /// <param name='dateFrom'>
            /// </param>
            /// <param name='dateTo'>
            /// </param>
            public static object GetErrorLogs(this IErrorLog operations, string serviceName = default(string), string exceptionTypeName = default(string), string message = default(string), System.DateTime? dateFrom = default(System.DateTime?), System.DateTime? dateTo = default(System.DateTime?))
            {
                return operations.GetErrorLogsAsync(serviceName, exceptionTypeName, message, dateFrom, dateTo).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='serviceName'>
            /// </param>
            /// <param name='exceptionTypeName'>
            /// </param>
            /// <param name='message'>
            /// </param>
            /// <param name='dateFrom'>
            /// </param>
            /// <param name='dateTo'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetErrorLogsAsync(this IErrorLog operations, string serviceName = default(string), string exceptionTypeName = default(string), string message = default(string), System.DateTime? dateFrom = default(System.DateTime?), System.DateTime? dateTo = default(System.DateTime?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetErrorLogsWithHttpMessagesAsync(serviceName, exceptionTypeName, message, dateFrom, dateTo, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
