using AutoMapper;
using  WebApi.Common;
using  WebApi.DBOperations;
using System.Collections.Generic;
using System.Linq;


namespace  WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> bvm = _mapper.Map<List<BooksViewModel>>(bookList);
           
            return bvm;
        }
        public class BooksViewModel
        {
            public string Title { get; set; }

            public int PageCount { get; set; }

            public string PublishDate{ get; set; }

            public string Genre { get; set; }
        }

    }
}
