using AutoMapper;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
