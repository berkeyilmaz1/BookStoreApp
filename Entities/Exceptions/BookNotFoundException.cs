namespace Entities.Exceptions
{
    public abstract partial class NotFoundException
    {
        public sealed class BookNotFoundException : NotFoundException
        {
            public BookNotFoundException(int id) : base($"This book with id: {id} could not found.")
            {
            }
        }
    }
}
