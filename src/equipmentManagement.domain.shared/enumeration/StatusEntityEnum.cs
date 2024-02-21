using equipmentManagement.domain.shared.seedWork.enumeration;

namespace equipmentManagement.domain.shared.enumeration
{
    public class StatusEntityEnum : Enumeration
    {
        public StatusEntityEnum(int id, string name) : base(id, name) { }

        public static readonly StatusEntityEnum
            Inactive = new StatusEntityEnum(0, "InActive"),
            Active = new StatusEntityEnum(1, "Active");
    }
}
