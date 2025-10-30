using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public sealed class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>(
            ).ForMember(
                dest => dest.CreatedBy,
                opt => opt.MapFrom(src => src.AppUser.UserName)
            );
            CreateMap<CreateCommentRequestDTO, Comment>();
        }
    }
}