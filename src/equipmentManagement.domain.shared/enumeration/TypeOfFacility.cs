using equipmentManagement.domain.shared.seedWork.enumeration;

namespace equipmentManagement.domain.shared.enumeration
{
    public class TypeOfFacility : Enumeration
    {
        private TypeOfFacility(int id, string Name) : base(id, Name) { }


        public static readonly TypeOfFacility
            Residencial = new TypeOfFacility(0, "Language.Enum_TypeOfFacility_Residencial"),
            Comercial = new TypeOfFacility(1, "Language.Enum_TypeOfFacility_Comercial"),
            Industrial = new TypeOfFacility(2, "Language.Enum_TypeOfFacility_Industrial"),
            Igreja = new TypeOfFacility(3, "Language.Enum_TypeOfFacility_Industrial"),
            Forum = new TypeOfFacility(4, "Language.Enum_TypeOfFacility_Industrial");


        public static implicit operator int(TypeOfFacility e) => e.Id;
        public static implicit operator TypeOfFacility(int id) => GetById<TypeOfFacility>(id);
        public static implicit operator TypeOfFacility(string name) => GetByName<TypeOfFacility>(name);
    }
}
