using AutoMapper;
using bms.Application.Interfaces;
using bms.Application.Services.BookServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQueryRequest, GetBookByIdQueryResponse>
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public GetBookByIdQueryHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
        public async Task<GetBookByIdQueryResponse> Handle(GetBookByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var book = await bookService.GetAsync(predicate: b => b.Id == request.Id, include: x => x.Include(b => b.Author));
            var response = mapper.Map<GetBookByIdQueryResponse>(book);
            return response;
        }
    }
}
