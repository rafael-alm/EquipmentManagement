using equipmentManagement.domain.shared.enumeration;
using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.aggregates.product.validations
{
    internal sealed class ValidateProductInactivation
    {
        internal static void Execute(StatusEntityEnum currentStatus, INotification notificacao)
            => notificacao.AddIfFalse(currentStatus == StatusEntityEnum.Active, ProductMessages.ProductIsAlreadyInactive);
    }
}