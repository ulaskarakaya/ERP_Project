using AutoMapper;
using ERP_Project.Entity.Concrete.CalisanEntities;
using ERP_Project.Model.DTO.CalisanDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Business.Concrete.Utilities.AutoMapperProfiles.CalisanProfiles
{
    public class CalisanProfile : Profile
    {
        public CalisanProfile()
        {
            CreateMap<Calisan, CalisanDTO>().ReverseMap();
        }
    }
}
