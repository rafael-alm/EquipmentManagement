using equipmentManagement.domain.aggregates.company.commands;
using equipmentManagement.domain.aggregates.company.validations;
using equipmentManagement.domain.objectValues;
using equipmentManagement.domain.seedWork.entities;
using equipmentManagement.domain.seedWork.entities.interfaces;
using equipmentManagement.domain.seedWork.objectValues;
using equipmentManagement.domain.shared.enumeration;
using equipmentManagement.domain.shared.seedWork.enumeration;
using equipmentManagement.domain.shared.seedWork.notification;


namespace equipmentManagement.domain.aggregates.company
{
    public sealed partial class Company : EntityWithGuid, IAggregateRoot<Company>
    {

        private Company()
        {
            Id = EntityIdentity.New();
            Active = true;
            lastUpdate = new LastUpdate();
        }

        private Company(CreateCompanyCommand data) : this()
        {
            RegisteredName = data.RegisteredName;
            Name = data.Name;
            TypeOfFacility = (TypeOfFacility)data.TypeOfFacility;
            CNPJ = data.CNPJ;
            lastUpdate = new LastUpdate();
        }

        private LastUpdate lastUpdate;

        public string RegisteredName { get; private set; }
        public string Name { get; private set; }
        public TypeOfFacility TypeOfFacility { get; private set; }
        public CNPJ CNPJ { get; private set; }
        public bool Active { get; private set; }

        public static Company? Create(CreateCompanyCommand data, INotification notification)
        {
            ValidateCompanyCreation.Execute(data, notification);

            if (notification.HasError)
                return null;

            return new(data);
        }

        public Company Modify(ModifyCompanyCommand data, INotification notification)
        {
            ValidateCompanyModification.Execute(data, notification);

            if (!notification.HasError)
            {
                RegisteredName = data.RegisteredName;
                Name = data.Name;
                TypeOfFacility = Enumeration.GetById<TypeOfFacility>(data.TypeOfFacility);
                CNPJ = data.CNPJ;
                lastUpdate = new LastUpdate();
            }

            return this;
        }

        public void Activate(INotification notification)
        {
            ValidateCompanyActivate.Execute(Active, Id, CNPJ, notification);

            Active = true;
            lastUpdate = new LastUpdate();
        }

        public void Deactivate(INotification notification)
        {
            ValidateCompanyDeactivation.Execute(this.Active, notification);

            Active = false;
            lastUpdate = new LastUpdate();
        }
    }
}