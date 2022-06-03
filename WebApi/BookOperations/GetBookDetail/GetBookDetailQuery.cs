using AutoMapper;
using  WebApi.Common;
using  WebApi.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;


namespace  WebApi.BookOperations.GetBooks
{
    public class GetBookDetailQuery
    {
       
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book == null)
                throw new InvalidOperationException("Kitap Bulunamadı.");
            BookDetailViewModel bvm = _mapper.Map<BookDetailViewModel>(book);
            return bvm;
        }
      
        public class BookDetailViewModel
        {
            public string Title { get; set; }

            public string Genre { get; set; }

            public int PageCount { get; set; }

            public string PublishDate { get; set; }
        }
            
        }

    }

