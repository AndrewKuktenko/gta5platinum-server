using AutoMapper;
using gta5platinum;
using Gta5Platinum.DataAccess.UnitOfWork;

namespace Gta5Platinum.Server.Services
{
    public abstract class ServiceBase
    {
        protected IGta5PlatinumUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper = AutoMapperConfig.Mapper;

        public ServiceBase(IGta5PlatinumUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
