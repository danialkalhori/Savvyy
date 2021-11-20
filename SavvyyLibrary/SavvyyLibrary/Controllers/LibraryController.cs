using MediatR;
using Microsoft.AspNetCore.Mvc;
using SavvyyLibrary.Service.Dto;
using SavvyyLibrary.Service.Library;

namespace SavvyyLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILogger<LibraryController> _logger;
        private MediatR.IMediator _mediator;

        public LibraryController(ILogger<LibraryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetBook")]
        public async Task<BookDto> GetBook(int id)
        {
            return await _mediator.Send(new GetBookService
            {
                Id = id
            });
        }

        [HttpPut(Name = "Createbook")]
        public async Task<int> Createbook(CreateBookService service)
        {
            return await _mediator.Send(service);
        }

        [HttpPost(Name = "EditBook")]
        public async Task<BookDto> EditBook(EditBookService service)
        {
            return await _mediator.Send(service);
        }

        [HttpDelete(Name = "DeleteBook")]
        public async Task<Unit> DeleteBook(DeleteBookService service)
        {
            return await _mediator.Send(service);
        }
    }
}