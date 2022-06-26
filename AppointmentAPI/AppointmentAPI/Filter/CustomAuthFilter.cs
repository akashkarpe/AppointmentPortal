using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace AppointmentAPI.Filter
{
    public class CustomAuthFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            Trace.TraceInformation("Authenticate");
            System.Net.Http.Headers.AuthenticationHeaderValue authorizationHeader = context.Request.Headers.Authorization;

            // Check that the Authorization header is present in the HTTP request and that it is in the
            // format of "Authorization: Bearer <token>"
            if ((authorizationHeader == null) || (authorizationHeader.Scheme.CompareTo("Bearer") != 0) || (String.IsNullOrEmpty(authorizationHeader.Parameter)))
            {
                context.ErrorResult = new UnauthorizedResult(Enumerable.Empty<AuthenticationHeaderValue>(), context.Request);
                // return HTTP 401 Unauthorized
            }
            else
            {
                if (TokenManager.ValidateToken(authorizationHeader.Parameter) == null)
                {
                    context.ErrorResult = new UnauthorizedResult(Enumerable.Empty<AuthenticationHeaderValue>(), context.Request);
                }
            }

            //context.ErrorResult = new UnauthorizedResult(Enumerable.Empty<AuthenticationHeaderValue>(), context.Request);
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}