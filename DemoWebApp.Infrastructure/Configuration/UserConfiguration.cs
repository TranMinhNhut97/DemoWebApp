using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DemoWebApp.Application.Common.Entities;
using DemoWebApp.Domain.Entities.Mssql;

namespace DemoWebApp.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
        }
    }
}
