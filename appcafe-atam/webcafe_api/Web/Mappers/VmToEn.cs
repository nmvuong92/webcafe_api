using AutoMapper;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.Temp;
using Web.Areas.Admin.ViewModels;
using Web.ViewModels.Admin.Form.Users;
using Web.ViewModels.Form;
using UserVM = VD.Data.Temp.UserVM;


namespace Web.Mappers
{
    public class VmToEn : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            //tai khoan
            //AutoMapper.Mapper.CreateMap<ThemSuaTaiKhoanVm, TaiKhoan>();


            /*
            //san pham
            AutoMapper.Mapper.CreateMap<ThemSuaSanPhamVm,SanPham>()
                  .ForMember(dest => dest.GiaGoc, opt => opt.MapFrom(src => decimal.Parse(src.GiaGoc_str)))
                  .ForMember(dest => dest.GiaSi, opt => opt.MapFrom(src => decimal.Parse(src.GiaSi_str)))
                  .ForMember(dest => dest.GiaLe, opt => opt.MapFrom(src => decimal.Parse(src.GiaLe_str)));
            */
            Mapper.CreateMap<User, EditUserVM>();
            //cònig
         
         

            Mapper.CreateMap<User,UserVM>();
          

          
            Mapper.CreateMap<Role, RoleVM>();
      

            //admin: sFrmCreateUserVM
            Mapper.CreateMap<User, FrmCreateUserVM>();


            Mapper.CreateMap<Slider,SliderCrud>();

        }
    }

}
