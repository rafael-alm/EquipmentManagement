using equipmentManagement.domain.aggregates.company.commands;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.aggregates.company.validations
{
    internal class ValidateCompanyCreation
    {
        internal static void Execute(CreateCompanyCommand data, INotification notification)
        {
            notification.AddIfFalse(CompanyRules.RegisteredNameIsRequired(data.RegisteredName), CompanyMessages.RegisteredNameIsRequired);
            notification.AddIfFalse(CompanyRules.NameIsRequired(data.Name), CompanyMessages.NameIsRequired);
            notification.AddIfFalse(CompanyRules.CnpjIsRequired(data.CNPJ), CompanyMessages.CnpjIsRequired);
            notification.AddIfFalse(CompanyRules.TypeOfFacilityDeveSerValida(data.TypeOfFacility), CompanyMessages.TypeOfFacilityDeveSerValida);
        }
    }
}
