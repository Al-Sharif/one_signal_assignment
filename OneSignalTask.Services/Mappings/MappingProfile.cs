using AutoMapper;
using OneSignalTask.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneSignalTask.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<App, AppViewModel>();
            CreateMap<AppViewModel, App>();
            CreateMap<AppInputModel, App>();
            CreateMap<App, AppInputModel>();
            CreateMap<AppViewModel, AppInputModel>();
            CreateMap<AppInputModel, AppViewModel>();
        }
    }
}
