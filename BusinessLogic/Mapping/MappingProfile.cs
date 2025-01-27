using AutoMapper;
using Domain.Entities.Nodes;
using Domain.Entities.Trees;

namespace BusinessLogic.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Node, Tree>();
        }
    }
}
