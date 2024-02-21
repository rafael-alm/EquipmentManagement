namespace equipmentManagement.domain.seedWork.objectValues
{
    public record struct EntityIdentity
    {
        string _formattedGuid;
        Guid _guid;

        private EntityIdentity(string guid)
        {
            ArgumentNullException.ThrowIfNull(guid, nameof(guid));

            _guid = new Guid(guid);
            _formattedGuid = formatGuid();
        }

        private EntityIdentity(Guid guid)
        {
            ArgumentNullException.ThrowIfNull(guid, nameof(guid));

            _guid = guid;
            _formattedGuid = formatGuid();
        }

        public string Value => _formattedGuid;

        public static EntityIdentity New() => new EntityIdentity(Guid.NewGuid());

        private string formatGuid() => _guid.ToString("N");

        public static implicit operator string(EntityIdentity e) => e.Value;
        public static implicit operator EntityIdentity(string id) => new (id);
        public static implicit operator EntityIdentity(Guid guid) => new (guid);

    }
}
