using AutoMapper;
using bms.Application.Interfaces;
using bms.Application.Services.BookServices;
using bms.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, Unit>
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public DeleteBookCommandHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            Book book = mapper.Map<Book>(request);
            await bookService.DeleteAsync(book);
            return Unit.Value;
        }
    }
}
