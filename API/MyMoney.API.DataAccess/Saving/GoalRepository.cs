﻿namespace MyMoney.API.DataAccess.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using DataModels.Saving;

    using Interfaces;

    using JetBrains.Annotations;

    using Resources;

    #endregion

    /// <summary>
    /// The <see cref="GoalRepository"/> class performs CRUD actions on the database for instances of the <see cref="GoalDataModel"/> class.
    /// </summary>
    /// <seealso cref="MyMoney.API.DataAccess.Saving.Interfaces.IGoalRepository" />
    [UsedImplicitly]
    public class GoalRepository : IGoalRepository
    {
        #region Fields

        #endregion

        #region Methods

        /// <summary>
        /// Adds a goal to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// The newly added goal.
        /// </returns>
        public async Task<GoalDataModel> AddGoal(GoalDataModel model)
        {
            using (var context = new DatabaseContext())
            {
                model.Id = Guid.NewGuid();

                model.CreationTime = DateTime.Now;
                context.Goals.Add(model);

                var rows = await context.SaveChangesAsync();

                return rows > 0 ? model : null;
            }
        }

        /// <summary>
        /// Deletes a goal from the database.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <returns>
        /// If true, deletion was successful. False if not.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Exception thrown if the requested goal cannot be found.
        /// </exception>
        public async Task<bool> DeleteGoal(Guid goalId)
        {
            using (var context = new DatabaseContext())
            {
                var toDelete = await context.Goals.FirstOrDefaultAsync(x => x.Id.Equals(goalId));

                if (toDelete == null)
                {
                    throw new Exception(Goal.Error_CouldNotFindGoal);
                }

                context.Goals.Remove(toDelete);

                var rows = await context.SaveChangesAsync();

                return rows > 0;
            }
        }

        /// <summary>
        /// Updates a goal in the database.
        /// </summary>
        /// <param name="model">The updated model.</param>
        /// <returns>
        /// The updated data model.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Exception thrown if the requested goal cannot be found.
        /// </exception>
        public async Task<GoalDataModel> EditGoal(GoalDataModel model)
        {
            using (var context = new DatabaseContext())
            {
                var toEdit = await GetGoal(model.Id);

                if (toEdit == null)
                {
                    throw new Exception(Goal.Error_CouldNotFindGoal);
                }

                model.Id = toEdit.Id;
                model.CreationTime = toEdit.CreationTime;

                context.Goals.Attach(model);
                context.Entry(model).State = EntityState.Modified;
                
                var rows = await context.SaveChangesAsync();

                return rows > 0 ? model : null;
            }
        }

        /// <summary>
        /// Obtains a goal from the database with the given identifier.
        /// </summary>
        /// <param name="goalId">The goal identifier.</param>
        /// <returns>
        /// The goal.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Exception thrown if the requested goal cannot be found.
        /// </exception>
        public async Task<GoalDataModel> GetGoal(Guid goalId)
        {
            using (var context = new DatabaseContext())
            {
                var goal = await context.Goals.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(goalId));

                if (goal == null)
                {
                    throw new Exception(Goal.Error_CouldNotFindGoal);
                }

                return goal;
            }
        }

        /// <summary>
        /// Gets all goals for a given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// The list of goals.
        /// </returns>
        public async Task<IList<GoalDataModel>> GetGoalsForUser(Guid userId)
        {
            using (var context = new DatabaseContext())
            {
                return await context.Goals.AsNoTracking().Where(x => x.UserId.Equals(userId)).ToListAsync();
            }
        }

        #endregion
    }
}