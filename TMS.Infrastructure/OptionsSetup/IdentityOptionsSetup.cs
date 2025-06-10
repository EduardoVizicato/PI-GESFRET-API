using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace TMS.Infrastructure.OptionsSetup;

public class IdentityOptionsSetup : IConfigureOptions<IdentityOptions>
{
    public void Configure(IdentityOptions options)
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.User.RequireUniqueEmail = true;
    }
}