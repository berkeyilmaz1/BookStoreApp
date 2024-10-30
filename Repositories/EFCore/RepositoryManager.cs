using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly RepositoryContext _context;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IBookRepository Book => new BookRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
