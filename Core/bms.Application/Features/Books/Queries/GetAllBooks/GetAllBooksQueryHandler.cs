using AutoMapper;
using bms.Application.DTOs;
using bms.Application.Interfaces;
using bms.Application.Pipelines.Authorization;
using bms.Application.Services.BookServices;
using bms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQueryRequest, IList<GetAllBooksQueryResponse>>

    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public GetAllBooksQueryHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllBooksQueryResponse>> Handle(GetAllBooksQueryRequest request, CancellationToken cancellationToken)
        {
            var books = await bookService.GetAllAsync(include: x => x.Include(b => b.Author));

            List<GetAllBooksQueryResponse> response = new();
            var map = mapper.Map<IList<GetAllBooksQueryResponse>>(books);
            return map;

        }
    }
}
