using bms.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Persistance.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255);
            Faker faker = new();
            builder.HasData(
                new Author { Id = 1, Name = faker.Name.FullName()},
                new Author { Id = 2, Name = faker.Name.FullName() },
                new Author { Id = 3, Name = faker.Name.FullName() }
                );
        }
    }
}
