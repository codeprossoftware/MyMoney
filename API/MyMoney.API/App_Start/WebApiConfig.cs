﻿namespace MyMoney.API
{
    #region Usings

    using System.Diagnostics;
    using System.Web.Http;

    using Attributes;

    using WebApiThrottle;

    #endregion

    /// <summary>
    ///     The configuration class for the web API.
    /// </summary>
    public static class WebApiConfig
    {
        #region Methods

        /// <summary>
        ///     Registers routes to specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            config.MessageHandlers.Add(
                new ThrottlingHandler
                    {
                        Policy =
                            new ThrottlePolicy(1, 30, 200)
                                {
                                    IpThrottling = true,
                                    EndpointThrottling = true
                                },
                        Repository = new CacheRepository()
                    });

            if (!Debugger.IsAttached)
            {
                config.Filters.Add(new ValidateApiKeyAttribute());
            }
        }

        #endregion
    }
}