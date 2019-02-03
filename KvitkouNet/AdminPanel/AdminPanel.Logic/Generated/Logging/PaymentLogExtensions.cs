// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Swagger3
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for PaymentLog.
    /// </summary>
    public static partial class PaymentLogExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='senderId'>
            /// </param>
            /// <param name='recieverId'>
            /// </param>
            /// <param name='minTransfer'>
            /// </param>
            /// <param name='maxTransfer'>
            /// </param>
            /// <param name='dateFrom'>
            /// </param>
            /// <param name='dateTo'>
            /// </param>
            public static object GetPaymentLogs(this IPaymentLog operations, string senderId = default(string), string recieverId = default(string), double? minTransfer = default(double?), double? maxTransfer = default(double?), System.DateTime? dateFrom = default(System.DateTime?), System.DateTime? dateTo = default(System.DateTime?))
            {
                return operations.GetPaymentLogsAsync(senderId, recieverId, minTransfer, maxTransfer, dateFrom, dateTo).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='senderId'>
            /// </param>
            /// <param name='recieverId'>
            /// </param>
            /// <param name='minTransfer'>
            /// </param>
            /// <param name='maxTransfer'>
            /// </param>
            /// <param name='dateFrom'>
            /// </param>
            /// <param name='dateTo'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetPaymentLogsAsync(this IPaymentLog operations, string senderId = default(string), string recieverId = default(string), double? minTransfer = default(double?), double? maxTransfer = default(double?), System.DateTime? dateFrom = default(System.DateTime?), System.DateTime? dateTo = default(System.DateTime?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetPaymentLogsWithHttpMessagesAsync(senderId, recieverId, minTransfer, maxTransfer, dateFrom, dateTo, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
