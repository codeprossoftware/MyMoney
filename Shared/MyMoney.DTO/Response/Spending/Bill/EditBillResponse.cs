﻿namespace MyMoney.DTO.Response.Spending.Bill
{
    #region Usings

    using Proxies.Spending;

    using Request.Spending.Bill;

    #endregion

    /// <summary>
    ///     The <see cref="EditBillResponse" /> class is the response object for a <see cref="EditBillRequest" /> request.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Response.BaseResponse" />
    public class EditBillResponse : BaseResponse
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