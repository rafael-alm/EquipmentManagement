using AutoMapper;
using equipmentManagement.domain.aggregates.company;
using equipmentManagement.infra.data.input.entityTypeConfiguration.models;

namespace equipmentManagement.infra.data.input.autoMapper
{
    public class CompanyToCompanyModel : Profile
    {
        public CompanyToCompanyModel()
            => CreateMap<Company, CompanyModel>()
                .ForMember(to => to.Id, from => from.MapFrom(x => x.Id.Value));
    }
}