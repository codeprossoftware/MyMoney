﻿namespace MyMoney.API.Controllers.Authentication
{
    #region Usings

    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using DTO.Request.Authentication;

    using Helpers.Benchmarking.Interfaces;

    using Orchestrators.Authentication.Interfaces;

    #endregion

    /// <summary>
    ///     Handles all API requests regarding user authentication.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("auth/user")]
    [AllowAnonymous]
    public class UserController : BaseController
    {
        #region Fields

        /// <summary>
        ///     The orchestrator
        /// </summary>
        private readonly IUserOrchestrator orchestrator;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="orchestrator">The orchestrator.</param>
        /// <param name="benchmarkHelper">The benchmark helper</param>
        /// <exception cref="System.ArgumentNullException">Exception thrown if the orchestrator is null.</exception>
        public UserController(IUserOrchestrator orchestrator, IBenchmarkHelper benchmarkHelper)
            : base(benchmarkHelper)
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
        ///     Registers a user.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <returns>The response object.</returns>
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var response = await orchestrator.RegisterUser(request);

            return Ok(response);
        }

        /// <summary>
        ///     Gets a claim for the given user.
        /// </summary>
        /// <param name="request">
        ///     The request.
        /// </param>
        /// <returns>
        ///     The response object.
        /// </returns>
        [HttpPost]
        [Route("validate")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> ValidateUser([FromBody] ValidateUserRequest request)
        {
            var response = await orchestrator.ValidateUser(request);

            return Ok(response);
        }

        #endregion
    }
}