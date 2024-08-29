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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(255);
            Faker faker = new();
            builder.HasData(
                new Book { 
                    Id = 1, 
                    Title = string.Join(" ",(faker.Lorem.Words(3))), 
                    Description = faker.Lorem.Paragraph(), 
                    Price = faker.Random.Int(min:10,max:500),
                    AuthorId = 3 },
                new Book { 
                    Id = 2, 
                    Title = string.Join(" ",(faker.Lorem.Words(3))), 
                    Description = faker.Lorem.Paragraph(), 
                    Price = faker.Random.Int(min: 10, max:500),
                    AuthorId = 2 },
                new Book { 
                    Id = 3, 
                    Title = string.Join(" ",(faker.Lorem.Words(3))), 
                    Description = faker.Lorem.Paragraph(), 
                    Price = faker.Random.Int(min: 10, max:500),
                    AuthorId = 1 },
                new Book { 
                    Id = 4, 
                    Title = string.Join(" ",(faker.Lorem.Words(3))), 
                    Description = faker.Lorem.Paragraph(), 
                    Price = faker.Random.Int(min: 10, max:500),
                    AuthorId = 1 }

                );
        }
    }
}
