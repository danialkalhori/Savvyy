using MediatR;
using SavvyyLibrary.Model;
using SavvyyLibrary.Repository;
using SavvyyLibrary.Service.Dto;
using SavvyyLibrary.Service.Library;

namespace SavvyyLibrary.ServiceHandler.Library
{
    public class EditBookServiceHandler : IRequestHandler<EditBookService, BookDto>
    {
        private IRepository _repository;

        public EditBookServiceHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDto> Handle(EditBookService request, CancellationToken cancellationToken)
        {
            var book = await _repository.Get<Book>(request.Id);

            if (book == null)
                if (book == null)
                    throw new Exception("Book is not found");

            book.Author = request.Author;
            book.Title = request.Title;
            book.Description = request.Description;
            book.Price = request.Price;
            book.CoverImage = request.CoverImage;

            await _repository.Save(book);

            book = await _repository.Get<Book>(request.Id);

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
