﻿namespace MyMoney.DTO.Response.Spending.Bills
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using MyMoney.DTO.Request.Spending.Bill;

    #endregion

    /// <summary>
    ///     The response object for the <see cref="GetBillsForUserForMonthRequest" /> class.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetBillsForUserForMonthResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public IList<KeyValuePair<DateTime, double>> Data { get; set; }

        #endregion
    }
}