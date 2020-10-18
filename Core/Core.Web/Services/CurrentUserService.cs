﻿namespace Core.Web.Services
{
    using global::Common.Application.Contracts;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    public class CurrentUserService : ICurrentUser
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            this.Roles = user
                .FindAll(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
        }

        public string UserId { get; }

        public IEnumerable<string> Roles { get; }
    }
}
