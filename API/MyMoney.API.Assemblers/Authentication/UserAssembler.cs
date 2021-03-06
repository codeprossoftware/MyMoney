﻿namespace MyMoney.API.Assemblers.Authentication
{
    #region Usings

    using System;

    using DataModels.Authentication;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using Helpers.Security.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    using Proxies.Authentication;

    #endregion

    /// <summary>
    ///     Assembles objects regarding users.
    /// </summary>
    /// <seealso cref="MyMoney.API.Assemblers.Authentication.Interfaces.IUserAssembler" />
    [UsedImplicitly]
    public class UserAssembler : IUserAssembler
    {
        #region Fields

        /// <summary>
        ///     The encryption helper
        /// </summary>
        private readonly IEncryptionHelper encryptionHelper;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserAssembler" /> class.
        /// </summary>
        /// <param name="encryptionHelper">The encryption helper.</param>
        public UserAssembler(IEncryptionHelper encryptionHelper)
        {
            if (encryptionHelper == null)
            {
                throw new ArgumentNullException(nameof(encryptionHelper));
            }

            this.encryptionHelper = encryptionHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates a new instance of the <see cref="RegisterUserResponse" /> class.
        /// </summary>
        /// <param name="registerResult">The register result.</param>
        /// <param name="reqReference">The request reference.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public RegisterUserResponse NewRegisterUserResponse(UserDataModel registerResult, Guid reqReference)
        {
            return new RegisterUserResponse
                       {
                           RegisterSuccess = registerResult != null,
                           RequestReference = reqReference
                       };
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="UserDataModel" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///     The user data model.
        /// </returns>
        public UserDataModel NewUserDataModel(RegisterUserRequest request)
        {
            var encryptionModel = encryptionHelper.EncryptPassword(request.Password);

            return new UserDataModel
                       {
                           DateOfBirth = request.DateOfBirth,
                           EmailAddress = request.EmailAddress,
                           FirstName = request.FirstName,
                           LastName = request.LastName,
                           Salt = encryptionModel.Salt,
                           Hash = encryptionModel.Hash,
                           Iterations = encryptionModel.Iterations
                       };
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="ValidateUserResponse" /> class.
        /// </summary>
        /// <param name="userDataModel">The user data model.</param>
        /// <param name="reqReference">The request reference.</param>
        /// <returns>
        ///     The response object.
        /// </returns>
        public ValidateUserResponse NewValidateUserResponse(UserDataModel userDataModel, Guid reqReference)
        {
            var success = userDataModel != null;

            return new ValidateUserResponse
                       {
                           LoginSuccess = success,
                           User =
                               new UserProxy
                                   {
                                       FirstName = userDataModel?.FirstName,
                                       LastName = userDataModel?.LastName,
                                       EmailAddress = userDataModel?.EmailAddress,
                                       DateOfBirth =
                                           userDataModel?.DateOfBirth
                                           ?? DateTime.MinValue,
                                       Id = userDataModel?.Id ?? Guid.Empty
                                   },
                           RequestReference = reqReference
                       };
        }

        #endregion
    }
}