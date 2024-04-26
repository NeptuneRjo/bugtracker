using BugTracker.DAL.Data;
using BugTracker.DAL.Repositories;
using BugTracker.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.DAL
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddDbContext<DataContext>(options =>
            {
                string? defaultConnectionString = Configuration.GetConnectionString("DefaultConnection");

                if (defaultConnectionString is null)
                {
                    throw new Exception("ConnectionStrings.DefaultConnection is null");
                }

                options.UseNpgsql(defaultConnectionString);
            });
        }
    }
}
