using AutoMapper;
using CleanArchitectureNetCore.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitectureNetCore.Application.Dtos.Videos;
using CleanArchitectureNetCore.Domain.Entities;
using CleanArchitectureNetCore.Application.Features.Directors.Commands.CreateDirector;

namespace CleanArchitectureNetCore.Application.Mappings
{
    public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Video, VideosDto>();
      CreateMap<CreateStreamerCommand, Streamer>();
      CreateMap<CreateDirectorCommand, Director>();
    }
  }
}
