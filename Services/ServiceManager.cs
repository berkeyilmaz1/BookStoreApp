﻿using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookServices> _bookService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger)
        {
            _bookService = new Lazy<IBookServices>(() => new BookManager(repositoryManager,logger));
        }

        public IBookServices BookServices => _bookService.Value;
    }
}