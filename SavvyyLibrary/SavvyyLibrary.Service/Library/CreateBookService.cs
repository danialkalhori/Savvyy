using MediatR;

namespace SavvyyLibrary.Service.Library
{
    public class CreateBookService : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public byte[] CoverImage { get; set; }
    }
}
