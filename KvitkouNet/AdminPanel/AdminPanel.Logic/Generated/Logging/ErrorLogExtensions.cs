// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace AdminPanel.Logic.Generated.Logging
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
            /// <param name='exceptionTypeName'>
            /// </param>
            public static object GetErrorLogs(this IErrorLog operations, string exceptionTypeName = default(string))
            {
                return operations.GetErrorLogsAsync(exceptionTypeName).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='exceptionTypeName'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetErrorLogsAsync(this IErrorLog operations, string exceptionTypeName = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetErrorLogsWithHttpMessagesAsync(exceptionTypeName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
