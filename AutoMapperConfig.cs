using AutoMapper;
using Gta5Platinum.Server.AutoMapperConfigurations;

namespace gta5platinum
{
    internal class AutoMapperConfig
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                    _mapper = MapperConfiguration.CreateMapper();

                return _mapper;
            }
        }

        public static MapperConfiguration MapperConfiguration
        {
            get
            {
                if (_mapperConfiguration == null)
                    RegisterMaps();

                return _mapperConfiguration;
            }
        }

        public static void RegisterMaps()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                new SharedAutoMapperConfiguration(cfg);

                //for client
                //new ConfName(cfg);

                //for admin
                //new ConfName(cfg);

            });
        }
    }
}
