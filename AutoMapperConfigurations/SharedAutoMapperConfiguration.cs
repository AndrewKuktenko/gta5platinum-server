using AutoMapper;

namespace Gta5Platinum.Server.AutoMapperConfigurations
{
    internal class SharedAutoMapperConfiguration
    {
        public SharedAutoMapperConfiguration(IMapperConfigurationExpression cfg)
        {
            RegisterToDTOMappings(cfg);
            RegisterToEFEntitiesMappings(cfg);
        }

        private void RegisterToDTOMappings(IMapperConfigurationExpression cfg)
        {           
            /*cfg.CreateMap<Payment, PaymentInfo>()
                .ForMember(dto => dto.PaidAmount, p => p.MapFrom(d => NumbersConverter.ConvertToString(d.PaidAmount)))
                .ForMember(dto => dto.Date, p => p.MapFrom(d => d.Date.ToString("dd.MM.yyyy HH:mm")))
                .ForMember(dto => dto.PaymentType, p => p.MapFrom(d => EnumHelper<PaymentType>.GetEnumName(d.Type)))
                .ForMember(dto => dto.PaymentStatus, p => p.MapFrom(d => EnumHelper<PaymentStatus>.GetEnumName(d.Status)))
                .ForMember(dto => dto.Product, p => p.MapFrom(d => d.Product.Name))
                .ForMember(dto => dto.UserName, p => p.MapFrom(d => d.User.UserName));

            cfg.CreateMap<UserExam, UserExamInfo>()
                .ForMember(dto => dto.ExamName, e => e.MapFrom(a => a.Exam.Name))
                .ForMember(dto => dto.ExamUrlName, e => e.MapFrom(a => a.Exam.UrlName))
                .ForMember(dto => dto.StartDate, e => e.MapFrom(a => a.Start.ToString("dd.MM.yyyy")))
                .ForMember(dto => dto.Duration, e => e.MapFrom(a => a.End.HasValue ? (a.End.Value - a.Start).ToString(@"hh\:mm\:ss") : "00:00:00"))
                .ForMember(dto => dto.Score, e => e.MapFrom(a => a.Score ?? 0))
                .ForMember(dto => dto.CertificateNumber, e => e.MapFrom(a => a.Certificate.UniqueNumber));*/
                        
        }

        private void RegisterToEFEntitiesMappings(IMapperConfigurationExpression cfg)
        {

        }
    }
}
