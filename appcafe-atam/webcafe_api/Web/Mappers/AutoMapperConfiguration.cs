using AutoMapper;

namespace Web.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EnToVm>();
                x.AddProfile<VmToEn>();
            });
        }
    }
}