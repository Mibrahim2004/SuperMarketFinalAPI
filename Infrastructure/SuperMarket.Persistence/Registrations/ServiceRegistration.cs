using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperMarket.Application.Interfaces.IRepositories.IBranchRepos;
using SuperMarket.Application.Interfaces.IRepositories.ICategoryRepos;
using SuperMarket.Application.Interfaces.IRepositories.ICustomerRepos;
using SuperMarket.Application.Interfaces.IRepositories.IInventoryRepos;
using SuperMarket.Application.Interfaces.IRepositories.IOrderDetailsRepos;
using SuperMarket.Application.Interfaces.IRepositories.IOrderRepos;
using SuperMarket.Application.Interfaces.IRepositories.IPaymentRepos;
using SuperMarket.Application.Interfaces.IRepositories.IProductRepos;
using SuperMarket.Application.Interfaces.IServices;
using SuperMarket.Application.Interfaces.IUnitOfWorks;
using SuperMarket.Domain.Entities.Identity;
using SuperMarket.Persistence.Contexts;
using SuperMarket.Persistence.Implementations.Repositories;
using SuperMarket.Persistence.Implementations.Services;
using SuperMarket.Persistence.Implementations.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("FinalProject")));
         
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            //repositories registration
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();         
            //services registration
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
