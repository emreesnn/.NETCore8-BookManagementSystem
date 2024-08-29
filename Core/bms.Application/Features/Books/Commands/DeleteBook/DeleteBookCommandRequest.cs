using bms.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandRequest : IRequest<Unit>, IAuthentication
    {
        public int Id { get; set; }
    }
}
