using System.Text;
using System.Threading.Tasks;
using Demo.Application.Bases;
using Demo.Application.Features.Auth.Rules;
using Demo.Application.Interfaces.AutoMapper;
using Demo.Application.Interfaces.UnitOfWorks;
using Demo.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Demo.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly AuthRules authRules;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper,unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

           // User user = mapper.Map<User,RegisterCommandRequest> (request);
            User user = mapper.Map<User>(request);

            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.Email = request.Email;
            user.FullName = request.FullName; // Reques
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, "user");
            }

            return Unit.Value;

        }
    }
}
