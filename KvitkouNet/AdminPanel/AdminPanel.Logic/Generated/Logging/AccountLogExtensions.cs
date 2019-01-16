// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Swagger
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for AccountLog.
    /// </summary>
    public static partial class AccountLogExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userName'>
            /// </param>
            public static object GetAccountLogs(this IAccountLog operations, string userName = default(string))
            {
                return operations.GetAccountLogsAsync(userName).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userName'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetAccountLogsAsync(this IAccountLog operations, string userName = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAccountLogsWithHttpMessagesAsync(userName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
