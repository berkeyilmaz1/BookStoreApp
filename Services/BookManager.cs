using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using static Entities.Exceptions.NotFoundException;

namespace Services
{
    public class BookManager : IBookServices
    {

        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public Book CreateOneBook(Book book)
        {

            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
            {
                throw new BookNotFoundException(id);
            }
            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            var book = _manager.Book.GetOneBookById(id, trackChanges);
            if (book is null) throw new BookNotFoundException(id);
            return book;
        }

        public void UpdateOneBook(int id, BookDTtoForUpdate bookDto, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
            {
                throw new BookNotFoundException(id);
            }

            entity = _mapper.Map<Book>(bookDto);
            _manager.Book.Update(entity);
            _manager.Save();
        }
    }
}
