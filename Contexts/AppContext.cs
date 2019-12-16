using System;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3GraphQL.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace WebApplication3GraphQL.Contexts
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        { }
        
        public Microsoft.EntityFrameworkCore.DbSet<SensorDatas> SensorDatas { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<SensorsGroups> SensorsGroups { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Users> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity< Users >()
                .Property(r => r.EmailConfirmed)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
        }
    }
}