using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace FMBQ.Hub.Auth
{
    public class AuthFilter : IAsyncResourceFilter
    {
        private readonly ApiTokenService apiTokenService;
        private readonly UserService userService;
        private readonly ILogger logger;

        public AuthFilter(
            ApiTokenService apiTokenService,
            UserService userService,
            ILogger<AuthFilter> logger
        )
        {
            this.apiTokenService = apiTokenService;
            this.userService = userService;
            this.logger = logger;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (!await Validate(context.HttpContext))
            {
                context.Result = new JsonResult(new Error
                {
                    Message = "User not authorized"
                })
                {
                    StatusCode = 403
                };
            }
            else {
                await next();
            }
        }

        private async Task<bool> Validate(HttpContext context)
        {
            try
            {
                // Check for login session.
                await context.Session.LoadAsync();
                if (context.Session.IsAvailable)
                {
                    if (context.Session.GetString("userId") != null)
                    {
                        return await userService.IsValidUser(context.Session.GetString("userId"));
                    }
                }

                // Check for API token auth.
                if (context.Request.Headers.ContainsKey(HeaderNames.Authorization))
                {
                    var auth = AuthenticationHeaderValue.Parse(context.Request.Headers[HeaderNames.Authorization]);

                    if (auth.Scheme.Equals("bearer", StringComparison.OrdinalIgnoreCase))
                    {
                        if (await apiTokenService.Validate(auth.Parameter))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogWarning(e, "Exception when validating auth.");
            }

            return false;
        }
    }
}
