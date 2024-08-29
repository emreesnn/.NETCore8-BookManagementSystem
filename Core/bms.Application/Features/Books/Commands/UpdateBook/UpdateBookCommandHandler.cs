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

namespace bms.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, Unit>
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public UpdateBookCommandHandler(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var newBook = mapper.Map<Book>(request);
            await bookService.UpdateAsync(newBook);
            return Unit.Value;
        }

    }
}
