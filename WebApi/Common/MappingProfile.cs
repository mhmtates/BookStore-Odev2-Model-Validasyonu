using AutoMapper;
using static  WebApi.BookOperations.CreateBook.CreateBookCommand;
using static  WebApi.BookOperations.GetBooks.GetBookDetailQuery;
using static  WebApi.BookOperations.GetBooks.GetBooksQuery;

namespace  WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookViewModel,Book>();//CreateBookViewModel objesi Book objesine maplenebilir olsun.
            CreateMap<Book,BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((Genre)src.GenreId).ToString())); 
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((Genre)src.GenreId).ToString()));
        }
    }
}
