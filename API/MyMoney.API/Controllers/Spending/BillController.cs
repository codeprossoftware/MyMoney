﻿namespace MyMoney.API.Controllers.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DTO.Request.Spending;

    using Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     Handles all API requests regarding bills.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("spending/bills")]
    public class BillController : ApiController
    {
        #region Fields

        /// <summary>
        ///     The orchestrator
        /// </summary>
        private readonly IBillOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BillController" /> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Exception thrown when the orchestrator is null.
        /// </exception>
        public BillController(IBillOrchestrator orchestrator)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        #endregion

        #region  Public Methods

        /// <summary>
        /// Handles an HTTP POST request to add a bill to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddBill([FromBody] AddBillRequest request)
        {
            var response = await orchestrator.AddBill(request, request.Username);

            return Ok(response);
        }

        /// <summary>
        /// Handles an HTTP DELETE request to remove a bill from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpDelete]
        [Route("delete/{billId:Guid}/{requestReference:Guid}/{username}")]
        public async Task<IHttpActionResult> DeleteBill([FromUri] DeleteBillRequest request)
        {
            var response = await orchestrator.DeleteBill(request);

            return Ok(response);
        }

        /// <summary>
        /// Handles an HTTP POST request to edit a bill in the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpPost]
        [Route("edit")]
        public async Task<IHttpActionResult> EditBill([FromBody] EditBillRequest request)
        {
            var response = await orchestrator.EditBill(request);

            return Ok(response);
        }

        /// <summary>
        /// Handles an HTTP GET request to obtain a bill from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("get/{billId:Guid}/{requestReference:Guid}/{username}")]
        public async Task<IHttpActionResult> GetBill([FromUri] GetBillRequest request)
        {
            var response = await orchestrator.GetBill(request);

            return Ok(response);
        }

        /// <summary>
        /// Handles an HTTP GET request for obtaining the bills for a given user from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("user/{userId:Guid}/{requestReference:Guid}/{username}")]
        public async Task<IHttpActionResult> GetBillsForUser([FromUri] GetBillsForUserRequest request)
        {
            var response = await orchestrator.GetBillsForUser(request);

            return Ok(response);
        }

        #endregion
    }
}