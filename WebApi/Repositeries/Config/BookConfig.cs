using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

namespace WebApi.Repositeries.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
             new Book { Id = 1, Title = "Kitap 1", Price=12},
             new Book { Id = 2, Title = "Kitap 2", Price = 22 },
             new Book { Id = 3, Title = "Kitap 3", Price = 33 },
             new Book { Id = 4, Title = "Kitap 4", Price = 33 }
             );
        }
    }
}
