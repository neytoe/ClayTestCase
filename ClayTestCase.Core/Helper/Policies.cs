using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Policy
{
    /// <summary>
    /// Policies according to roles
    /// </summary>
    public static class Policies
    {
        /// <summary>
        /// Admin role for our policy
        /// </summary>
        public const string Admin = "admin";
        /// <summary>
        /// Default User role for our policy
        /// </summary>
        public const string User = "user";
        /// <summary>
        /// SuperUser role for our policy
        /// </summary>
        public const string SuperUser = "superUser";

        /// <summary>
        /// Grants Admin Access to a User
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }

        /// <summary>
        /// Grants Normal Access to a User
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(User).Build();
        }

        /// <summary>
        /// Grants addiitonal Access to a User
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy SuperUserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(SuperUser).Build();
        }
    }
}