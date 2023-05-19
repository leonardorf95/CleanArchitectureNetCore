using AutoMapper;
using CleanArchitectureNetCore.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitectureNetCore.Domain.Dtos.Videos;
using CleanArchitectureNetCore.Domain.Entities;

namespace CleanArchitectureNetCore.Application.Mappings
{
    public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Video, VideosDto>();
      CreateMap<CreateStreamerCommand, Streamer>();
    }
  }
}
