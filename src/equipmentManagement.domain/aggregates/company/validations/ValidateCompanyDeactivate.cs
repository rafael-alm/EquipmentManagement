using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.aggregates.company.validations
{
    internal class ValidateCompanyDeactivation
    {
        internal static void Execute(bool alreadyDeactivated, INotification notification)
        {
            notification.AddIfFalse(CompanyRules.CanDeactivate(alreadyDeactivated), CompanyMessages.CompanyAlreadyDeactivated);
        }
    }
}
