using equipmentManagement.domain.objectValues;
using equipmentManagement.domain.seedWork.objectValues;
using equipmentManagement.domain.shared.enumeration;
using equipmentManagement.domain.shared.seedWork.enumeration;
using equipmentManagement.domain.shared.seedWork.factory;
using inspecao.administrActive.dominio.modelos.empresa.repositorios;
using System;

namespace equipmentManagement.domain.aggregates.company.validations
{
    internal class CompanyRules
    {
        internal static bool RegisteredNameIsRequired(string RegisteredName)
        {
            return !string.IsNullOrWhiteSpace(RegisteredName);
        }
        internal static bool NameIsRequired(string? Name)
              => !string.IsNullOrWhiteSpace(Name);
        internal static bool CnpjIsRequired(CNPJ cnpj)
              => !cnpj.IsNullOrEmpty();
        internal static bool TypeOfFacilityDeveSerValida(int type)
              => Enumeration.GetById<TypeOfFacility>(type) is not null;
        internal static bool CanActivate(bool alreadyActive)
            => !alreadyActive;
        internal static bool CanDeactivate(bool alreadyDeactivated)
            => !alreadyDeactivated;
        internal static bool CNPJHasAlreadyBeenInformed(CNPJ cnpj, EntityIdentity companyId)
            => !ServiceFactory.GetInstance<ICompanyReadRepository>().CNPJHasAlreadyBeenInformed(cnpj, companyId).Result;
    }
}
