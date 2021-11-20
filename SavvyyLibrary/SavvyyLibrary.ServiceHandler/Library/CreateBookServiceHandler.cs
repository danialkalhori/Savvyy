using MediatR;
using SavvyyLibrary.Model;
using SavvyyLibrary.Repository;
using SavvyyLibrary.Service.Library;

namespace SavvyyLibrary.ServiceHandler.Library
{
    public class CreateBookServiceHandler : IRequestHandler<CreateBookService, int>
    {
        private IRepository _repository;

        public CreateBookServiceHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBookService request, CancellationToken cancellationToken)
        {
            Book book = new Book
            {
                Author = request.Author,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                CoverImage = request.CoverImage
            };

            return await _repository.Save<Book>(book);
        }
    }
}
