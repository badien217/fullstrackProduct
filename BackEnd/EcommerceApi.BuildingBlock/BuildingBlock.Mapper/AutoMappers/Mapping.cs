using AutoMapper.Internal;
using AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlock.Mapper.AutoMappers
{
    public class Mapping : IAutoMapper
    {
        public static List<TypePair> typePairs = new();

        public IMapper _mapper;

        public TDestination Map<TDestination, TSource>(TSource soure, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return _mapper.Map<TSource, TDestination>(soure);

        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return _mapper.Map<IList<TSource>, IList<TDestination>>(sources);
        }

        public TDestination Map<TDestination>(object soure, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);
            return _mapper.Map<TDestination>(soure);
        }

        public IList<TDestination> Map<TDestination>(IList<object> sources, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore);
            return _mapper.Map<IList<TDestination>>(sources);
        }
        protected void Config<TDestionation, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestionation));

            if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ignore, x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
                }
            });

            _mapper = config.CreateMapper();
        }
    }
}