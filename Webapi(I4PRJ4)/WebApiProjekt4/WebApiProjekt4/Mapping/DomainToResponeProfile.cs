using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Mappers;
using AutoMapper;
using WebApiProjekt4.Controllers.Requests;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data;

namespace WebApiProjekt4.Mapping
{
    public class DomainToResponeProfile : Profile
    {
        public DomainToResponeProfile()
        {
            CreateMap<Queue, QueueResponse>();
            
            CreateMap<LeaderBoard, LeaderBoardResponse>();

            CreateMap<Game, GameResponse>();

            CreateMap<Stats, StatsResponse>();

            CreateMap<Player, PlayerResponse>();

            CreateMap<StatsRequest, Stats>();
            // customeize mapping =
            //.Formeber(Dest => dest.(domain), opt => opt.MapFrom(src => src.(domain).Select( o => new (Response{Attributes = o.Name})))
        }
    }
}
