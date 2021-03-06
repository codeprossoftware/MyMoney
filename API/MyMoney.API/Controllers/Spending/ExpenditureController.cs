﻿namespace MyMoney.API.Controllers.Spending
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DTO.Request.Spending.Expenditure;

    using Helpers.Benchmarking.Interfaces;

    using Orchestrators.Spending.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="ExpenditureController" /> class handles HTTP requests in the "spending/expenditure" route.
    /// </summary>
    /// <seealso cref="MyMoney.API.Controllers.BaseController" />
    [RoutePrefix("spending/expenditures")]
    public class ExpenditureController : BaseController
    {
        #region Fields

        /// <summary>
        ///     The orchestrator
        /// </summary>
        private readonly IExpenditureOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenditureController"/> class.
        /// </summary>
        /// <param name="orchestrator">
        /// The orchestrator.
        /// </param>
        /// <param name="benchmarkHelper">
        /// The benchmark helper.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown when the orchestrator is null.
        /// </exception>
        public ExpenditureController(IExpenditureOrchestrator orchestrator, IBenchmarkHelper benchmarkHelper) : base(benchmarkHelper)
        {
            if (orchestrator == null)
            {
                throw new ArgumentNullException(nameof(orchestrator));
            }

            this.orchestrator = orchestrator;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles an HTTP POST request to add a expenditure to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddExpenditure([FromBody] AddExpenditureRequest request)
        {
            var response = await orchestrator.AddExpenditure(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP DELETE request to remove a expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpDelete]
        [Route("delete/{expenditureId:Guid}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> DeleteExpenditure([FromUri] DeleteExpenditureRequest request)
        {
            var response = await orchestrator.DeleteExpenditure(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP POST request to edit a expenditure in the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpPost]
        [Route("edit")]
        public async Task<IHttpActionResult> EditExpenditure([FromBody] EditExpenditureRequest request)
        {
            var response = await orchestrator.EditExpenditure(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP GET request to obtain a expenditure from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("get/{expenditureId:Guid}/{requestReference:Guid}")]
        public async Task<IHttpActionResult> GetExpenditure([FromUri] GetExpenditureRequest request)
        {
            var response = await orchestrator.GetExpenditure(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP GET request for obtaining the expenditures for a given user from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("user/{userId:Guid}/{requestReference:Guid}/")]
        public async Task<IHttpActionResult> GetExpendituresForUser([FromUri] GetExpenditureForUserRequest request)
        {
            var response = await orchestrator.GetExpenditureForUser(request);

            return Ok(response);
        }

        /// <summary>
        ///     Handles an HTTP GET request for obtaining the expenditures for a given user in a given month.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response object. Wrapped in a 200 response.</returns>
        [HttpGet]
        [Route("get/{userId:Guid}/month/{monthNumber:int}/{requestReference:Guid}/")]
        public async Task<IHttpActionResult> GetExpendituresForUserForMonth(
            [FromUri] GetExpenditureForUserForMonthRequest request)
        {
            var response = await orchestrator.GetExpenditureForUserForMonth(request);

            return Ok(response);
        }

        #endregion
    }
}