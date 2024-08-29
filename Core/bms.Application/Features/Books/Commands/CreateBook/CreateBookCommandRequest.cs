using bms.Application.Pipelines.Authorization;
using bms.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandRequest : IRequest<Unit>, IAuthentication
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
    }
}
