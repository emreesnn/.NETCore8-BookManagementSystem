using bms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Domain.Entities
{
    public class Book : EntityBase
    {
        public Book()
        {
            
        }

        public Book(string title, string description, int price, int authorId)
        {
            Title = title;
            Description = description;
            Price = price;
            AuthorId = authorId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
