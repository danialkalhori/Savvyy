using SavvyyLibrary.Model.Model;

namespace SavvyyLibrary.Model
{
    public class Book : Entity
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Author { get; set; }
        public virtual decimal Price { get; set; }
        public virtual byte[] CoverImage { get; set; }
    }
}
