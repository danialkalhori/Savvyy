using MediatR;

namespace SavvyyLibrary.Service.Library
{
    public class DeleteBookService : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
