using System.Security.Claims;

using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string? UserName => "";
    public string? Role => "";
    public string? GivenName => "";

    public int? UserId => 1;

    public IEnumerable<Claim> Claims => new List<Claim>();

    public bool? IsAuthenticated => false;
}
