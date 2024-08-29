using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using bms.Application.Features.Books.Commands.CreateBook;
using bms.Application.Features.Books.Commands.UpdateBook;
using bms.Application.Features.Books.Commands.DeleteBook;
using bms.Application.Features.Books.Queries.GetAllBooks;
using bms.Application.Features.Books.Queries.GetBookById;
using Microsoft.AspNetCore.Authorization;

namespace bms.Presentation.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await mediator.Send(new GetAllBooksQueryRequest());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetBookById([FromRoute] GetBookByIdQueryRequest getBookByIdQueryRequest )
        {
            var response = await mediator.Send(getBookByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(DeleteBookCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


    }
}
