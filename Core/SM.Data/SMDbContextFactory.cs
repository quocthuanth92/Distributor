using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SM.Data
{
    class SMDbContextFactory : IDbContextFactory<SalesManagementDatabase>
    {
        public SalesManagementDatabase Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<SalesManagementDatabase>();
            builder.UseSqlServer("Server=DMSPRO-THUANTQ-;Database=SalesManagements;User Id=sa; Password=123456789;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(SalesManagementDatabase).GetTypeInfo().Assembly.GetName().Name));
            return new SalesManagementDatabase(builder.Options);
        }
    }
}
