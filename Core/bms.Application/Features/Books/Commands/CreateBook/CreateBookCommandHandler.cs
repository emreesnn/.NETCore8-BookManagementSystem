using AutoMapper;
using bms.Application.Interfaces;
using bms.Application.Services.BookServices;
using bms.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, Unit>
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public CreateBookCommandHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            Book book = mapper.Map<Book>(request);
            await bookService.AddAsync(book);

            return Unit.Value;
        }
    }
}
