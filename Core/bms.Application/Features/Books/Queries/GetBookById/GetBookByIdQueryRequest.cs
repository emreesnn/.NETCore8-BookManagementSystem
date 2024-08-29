using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQueryRequest : IRequest<GetBookByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
