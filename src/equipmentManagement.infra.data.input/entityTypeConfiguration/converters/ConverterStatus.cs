using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using equipmentManagement.domain.shared.enumeration;
using equipmentManagement.domain.shared.seedWork.enumeration;

namespace equipmentManagement.infra.data.input.entityTypeConfiguration.converters
{
    internal class ConverterStatus : ValueConverter<StatusEntityEnum, int>
    {
        public ConverterStatus()
            : base(
                status => status.Id,
                code => Enumeration.GetById<StatusEntityEnum>(code))
        {}
    }
}
