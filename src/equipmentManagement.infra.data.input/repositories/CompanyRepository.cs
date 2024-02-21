using AutoMapper;
using equipmentManagement.application.input.services.company.interfaces;
using equipmentManagement.domain.aggregates.company;
using equipmentManagement.domain.objectValues;
using equipmentManagement.domain.seedWork.objectValues;
using equipmentManagement.domain.shared.seedWork.exceptions;
using equipmentManagement.infra.data.input.entityTypeConfiguration.models;
using inspecao.administrActive.dominio.modelos.empresa.repositorios;
using Microsoft.EntityFrameworkCore;

namespace equipmentManagement.infra.data.input.aggregates
{
    public class CompanyRepository : ICompanyWriteRepository, ICompanyReadRepository
    {
        protected readonly ContextEquipmentManagement context;
        private DbSet<CompanyModel> companys;
        private readonly IMapper mapper;

        public CompanyRepository(ContextEquipmentManagement context, IMapper mapper)
        {
            this.context = context;
            this.companys = context.Set<CompanyModel>();
            this.mapper = mapper;
        }

        async Task ICompanyWriteRepository.Add(Company entity, CancellationToken cancellationToken) 
            => await companys.AddAsync(mapper.Map<CompanyModel>(entity), cancellationToken);

        async Task<Company> ICompanyReadRepository.GetById(EntityIdentity id, CancellationToken cancellationToken)
        {
            var companyModel = await companys.FirstOrDefaultAsync(x => x.Id == id.ToString(), cancellationToken);

            NotFoundException.ThrowIfNull(companyModel);

            return mapper.Map<Company>(companyModel);
        }

        void ICompanyWriteRepository.Update(Company entity)
        {
            var companyModel = companys.Single(x => x.Id == entity.Id.ToString());
            companyModel = mapper.Map(entity, companyModel);

            companys.Update(companyModel);
        }

        async Task<bool> ICompanyReadRepository.CNPJHasAlreadyBeenInformed(CNPJ cnpj, EntityIdentity companyId, CancellationToken cancellationToken)
            => await companys.AnyAsync(x => x.Active && x.CNPJ == cnpj.Number && x.Id != companyId.ToString());
    }
}
