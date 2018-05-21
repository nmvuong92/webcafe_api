
using AutoMapper;
using System;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.Temp;
using Web.Areas.Admin.ViewModels;
using Web.ViewModels.Admin.Form.Users;
using Web.ViewModels.Form;



namespace Web.Mappers
{
    public class EnToVm:Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            //tai khoan
          
            //tao don hang
            //AutoMapper.Mapper.CreateMap<DonHang, TaoDonHangVm>()
            //    .ForMember(dest => dest.CDaiStr, opt => opt.MapFrom(src => src.CDai.ToString()))
            //    .ForMember(dest => dest.CRongStr, opt => opt.MapFrom(src => src.CRong.ToString()));

           //     Mapper.CreateMap<DMTTVM, DMTT>()
           //.ForMember(dto => dto.DVT, opt => opt.Ignore());

            Mapper.CreateMap<EditUserVM,User>();

            //cònig
            

            Mapper.CreateMap<UserVM, User>();


            Mapper.CreateMap<RoleVM, Role>();

            Mapper.CreateMap<SliderCrud, Slider>();

        }
    }
}