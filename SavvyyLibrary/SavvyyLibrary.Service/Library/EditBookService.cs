﻿using MediatR;
using SavvyyLibrary.Service.Dto;

namespace SavvyyLibrary.Service.Library
{
    public class EditBookService : IRequest<BookDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public byte[] CoverImage { get; set; }
    }
}
