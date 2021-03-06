﻿namespace MyMoney.Web.DataAccess.Saving
{
    #region Usings

    using System.Threading.Tasks;

    using DTO.Request.Saving.Goal;
    using DTO.Response.Saving.Goal;

    using Helpers.Benchmarking.Interfaces;
    using Helpers.Error.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    #endregion

    /// <summary>
    /// The <see cref="GoalDataAccess"/> class sends HTTP requests to perform actions on goals.
    /// </summary>
    /// <seealso cref="MyMoney.Web.DataAccess.BaseDataAccess" />
    /// <seealso cref="MyMoney.Web.DataAccess.Saving.Interfaces.IGoalDataAccess" />
    [UsedImplicitly]
    public class GoalDataAccess : BaseDataAccess, IGoalDataAccess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoalDataAccess"/> class.
        /// </summary>
        /// <param name="errorHelper">
        /// The error helper.
        /// </param>
        /// <param name="benchmarkHelper">
        /// The benchmark helper.
        /// </param>
        public GoalDataAccess(IErrorHelper errorHelper, IBenchmarkHelper benchmarkHelper)
            : base(errorHelper, benchmarkHelper)
        {
        }

        #region Methods

        /// <summary>
        /// Sends an HTTP DELETE request to remove a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<DeleteGoalResponse> DeleteGoal(DeleteGoalRequest request)
        {
            return await Delete<DeleteGoalResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        /// Sends an HTTP POST request to modify a goal in the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<EditGoalResponse> EditGoal(EditGoalRequest request)
        {
            return await Post<EditGoalResponse>(request);
        }

        /// <summary>
        /// Sends an HTTP POST request to add a goal to the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<AddGoalResponse> AddGoal(AddGoalRequest request)
        {
            return await Post<AddGoalResponse>(request);
        }

        /// <summary>
        /// Sends an HTTP GET request to obtain a goal from the database.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<GetGoalResponse> GetGoal(GetGoalRequest request)
        {
            return await Get<GetGoalResponse>(request.FormatRequestUri(), request.Username);
        }

        /// <summary>
        /// Sends an HTTP GET request to obtain all the goals for a given user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The response object.
        /// </returns>
        public async Task<GetGoalsForUserResponse> GetGoalsForUser(GetGoalsForUserRequest request)
        {
            return await Get<GetGoalsForUserResponse>(request.FormatRequestUri(), request.Username);
        }

        #endregion
    }
}