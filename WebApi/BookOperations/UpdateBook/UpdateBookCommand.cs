using AutoMapper;
using  WebApi.DBOperations;
using System;
using System.Linq;


namespace  WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public UpdateBookViewModel Model { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı!");
            book = _mapper.Map<Book>(Model);
            _dbContext.SaveChanges();
        }

        public class UpdateBookViewModel
        {
            public string Title { get; set; }

            public int GenreId { get; set; }
        }
    }
}