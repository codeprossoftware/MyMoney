﻿namespace MyMoney.DTO.Response.Spending.Bills
{
    #region Usings

    using MyMoney.DTO.Request.Spending.Bill;
    using MyMoney.Proxies.Spending;

    #endregion

    /// <summary>
    ///     The <see cref="GetBillResponse" /> class is the response object for a <see cref="GetBillRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class GetBillResponse : BaseResponse
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the bill.
        /// </summary>
        /// <value>
        ///     The bill.
        /// </value>
        public BillProxy Bill { get; set; }

        #endregion
    }
}