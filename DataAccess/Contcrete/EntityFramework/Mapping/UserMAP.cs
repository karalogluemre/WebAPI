using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contcrete.EntityFramework.Mapping
{
    public class UserMAP : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", @"dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.SurName)
            .HasColumnName("SurName")
            .HasMaxLength(50)
            .IsRequired();
            builder.Property(x => x.Password)
            .HasColumnName("Password")
            .HasMaxLength(50)
            .IsRequired();
            builder.Property(x => x.Gender)
                .HasColumnName("Gender")
                .IsRequired();
            builder.Property(x => x.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .IsRequired();
            builder.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Emre",
                SurName = "KARALOĞLU",
                Password = "1e2m3r4e++",
                Gender = true,
                DateOfBirth = Convert.ToDateTime("12-01-1993"),
                CreatedDate = DateTime.Now,
                Address = "ISTANBUL",
                CreatedUserId = 1,
                Email = "emrekaraloglu@teknohub.com.tr",
                UserName = "emrekaraloglu"
            });
        }
    }
}
