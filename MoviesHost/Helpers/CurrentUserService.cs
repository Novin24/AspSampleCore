using Domain.IRepositories;
using System.Security.Claims;

namespace MoviesHost.Helpers
{
    public class CurrentUserService : ICurrentUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid GetCurrentUserName()
        {
            var claimUserId = (_httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier)) ?? throw new InvalidOperationException("User ID not found in claims.");

            var userId = Guid.Parse(claimUserId);
            return userId;
        }
    }
}
