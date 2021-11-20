using MediatR;
using SavvyyLibrary.Model;
using SavvyyLibrary.Repository;
using SavvyyLibrary.Service.Dto;
using SavvyyLibrary.Service.Library;

namespace SavvyyLibrary.ServiceHandler.Library
{
    public class GetBookServiceHandler : IRequestHandler<GetBookService, BookDto>
    {
        private IRepository _repository;

        public GetBookServiceHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDto> Handle(GetBookService request, CancellationToken cancellationToken)
        {
            var book = await _repository.Get<Book>(request.Id);

            if (book == null)
                throw new Exception("Book is not found");

            return new BookDto
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                CoverImage = book.CoverImage
            };
        }
    }
}
