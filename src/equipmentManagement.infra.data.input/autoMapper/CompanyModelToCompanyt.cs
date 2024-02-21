using AutoMapper;
using equipmentManagement.domain.aggregates.company;
using equipmentManagement.domain.shared.enumeration;
using equipmentManagement.infra.data.input.entityTypeConfiguration.models;

namespace equipmentManagement.infra.data.input.autoMapper
{
    public class CompanyModelToCompany : Profile
    {
        public CompanyModelToCompany()
            => CreateMap<CompanyModel, Company>()
                .ForMember(to => to.TypeOfFacility, from => from.MapFrom(x => (TypeOfFacility)x.TypeOfFacility))
                .ForMember(to => to.Id, from => from.MapFrom(x => x.Id));
    }
}
