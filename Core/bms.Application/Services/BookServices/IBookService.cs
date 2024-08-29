using bms.Application.Interfaces;
using bms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Services.BookServices
{
    public interface IBookService : IService<Book>
    {
    }
}
