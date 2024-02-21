using equipmentManagement.domain.objectValues;
using equipmentManagement.domain.seedWork.objectValues;
using equipmentManagement.domain.shared.seedWork.notification;
using System;

namespace equipmentManagement.domain.aggregates.company.validations
{
    internal class ValidateCompanyActivate
    {
        internal static void Execute(bool alreadyActive, EntityIdentity companyId, CNPJ cnpj, INotification notification)
        {
            notification.AddIfFalse(CompanyRules.CanActivate(alreadyActive), CompanyMessages.CompanyAlreadyActive);
            notification.AddIfFalse(CompanyRules.CNPJHasAlreadyBeenInformed(cnpj, companyId), CompanyMessages.CompanyAlreadyActive);
        }
    }
}
