using MemeGame.Application.UsersInfo;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace MemeGame.Infrastructure.UsersInfo
{
    public class UserInfo : IUserInfo
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserInfo(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public int GetCurrentUserId()
        {
            var user = _httpContext.HttpContext.User;
            if (user?.Identity?.IsAuthenticated == false)
            {
                throw new Exception("Unauthorized user");
            }

            var userIdentity = user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            return int.Parse(userIdentity.Value);
        }
    }
}
