#region Usings

using DomainLayer;
using DomainLayer.Common.BaseEntities;
using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using InfrastructureLayer.Convention;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

#endregion

namespace InfrastructureLayer.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        #region Constructors

        #endregion Constructors

        #region ModelCreating & OnConfiguring

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Ignore<BaseInformationLocalizationProperty>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<>).Assembly);
            modelBuilder.SetGlobalConvention();
            modelBuilder.AddAuditableShadowProperties();

            SetGlobalFilter.ApplyQueryFilters(modelBuilder);
        }

        #endregion ModelCreating & OnConfiguring
    }
}