// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Swagger3
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// TicketDealLog operations.
    /// </summary>
    public partial interface ITicketDealLog
    {
        /// <param name='ticketId'>
        /// </param>
        /// <param name='ownerId'>
        /// </param>
        /// <param name='recieverId'>
        /// </param>
        /// <param name='minPrice'>
        /// </param>
        /// <param name='maxPrice'>
        /// </param>
        /// <param name='type'>
        /// </param>
        /// <param name='dateFrom'>
        /// </param>
        /// <param name='dateTo'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        Task<HttpOperationResponse<object>> GetTicketDealLogsWithHttpMessagesAsync(string ticketId = default(string), string ownerId = default(string), string recieverId = default(string), double? minPrice = default(double?), double? maxPrice = default(double?), int type = default(int), System.DateTime? dateFrom = default(System.DateTime?), System.DateTime? dateTo = default(System.DateTime?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
