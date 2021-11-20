using MediatR;
using SavvyyLibrary.Model;
using SavvyyLibrary.Repository;
using SavvyyLibrary.Service.Library;

namespace SavvyyLibrary.ServiceHandler.Library
{
    public class DeleteBookServiceHandler : IRequestHandler<DeleteBookService,Unit>
    {
        private IRepository _repository;

        public DeleteBookServiceHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBookService request, CancellationToken cancellationToken)
        {
            var book = await _repository.Get<Book>(request.Id);

            if (book == null)
                return Unit.Value;

            await _repository.Delete(book);

            return Unit.Value;
        }
    }
}
