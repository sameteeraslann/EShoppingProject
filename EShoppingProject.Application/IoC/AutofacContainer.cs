using Autofac;
using EShoppingProject.Application.Services.Concrates;
using EShoppingProject.Application.Services.Interfaces;
using EShoppingProject.Domain.UnitOfWork;
using EShoppingProject.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.IoC
{
    public class AutofacContainer: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<SubCategoryService>().As<ISubCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            
        }
    }
}
