using MediatR;
using SavvyyLibrary.Service.Dto;

namespace SavvyyLibrary.Service.Library
{
    public class GetBookService : IRequest<BookDto>
    {
        public int Id { get; set; }
    }
}
