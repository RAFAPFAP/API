using CMS.infraestructure.Repositories.Categories.Interfaces;
using CMS.infraestructure.Repositories.Categories;
using CMS.infraestructure.Repositories.Comments.Interfaces;
using CMS.infraestructure.Repositories.Comments;
using CMS.infraestructure.Repositories.Posts.Interfaces;
using CMS.infraestructure.Repositories.Posts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CMS.infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Data;
using CMS.infraestructure.Repositories.Security.Interfaces;
using CMS.infraestructure.Repositories.Security;

namespace CMS.infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CMSContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<IdentityUser<Guid>>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<CMSContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            return services;
        }
    }
}
