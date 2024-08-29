using bms.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandRequest : IRequest<Unit>, IAuthentication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AuthorId { get; set; }
    }
}
