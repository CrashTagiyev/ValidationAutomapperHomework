using AutoMapper;
using ValidationAutomapperHomework.Models;
using ValidationAutomapperHomework.View_Models;

namespace ValidationAutomapperHomework.AutoMapperProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<RegistrationViewModel, User>();
        }
    }
}
