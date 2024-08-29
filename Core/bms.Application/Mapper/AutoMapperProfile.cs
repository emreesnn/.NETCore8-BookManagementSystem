using AutoMapper;
using bms.Application.DTOs;
using bms.Application.Features.Auth.Commands.Register;
using bms.Application.Features.Books.Commands.CreateBook;
using bms.Application.Features.Books.Commands.DeleteBook;
using bms.Application.Features.Books.Commands.UpdateBook;
using bms.Application.Features.Books.Queries.GetAllBooks;
using bms.Application.Features.Books.Queries.GetBookById;
using bms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bms.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, CreateBookCommandRequest>().ReverseMap();
            CreateMap<Book, UpdateBookCommandRequest>().ReverseMap();
            CreateMap<Book, DeleteBookCommandRequest>().ReverseMap();
            
            CreateMap<Book, GetBookByIdQueryResponse>().ReverseMap();
            CreateMap<Book, GetAllBooksQueryResponse>().ReverseMap();

            CreateMap<Author, AuthorDto>().ReverseMap();

            CreateMap<User, RegisterCommandRequest>().ReverseMap();
        }
    }
}
