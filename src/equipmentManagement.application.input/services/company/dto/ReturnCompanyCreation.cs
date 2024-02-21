namespace equipmentManagement.application.input.services.company.dto
{
    public readonly struct ReturnCompanyCreation
    {
        public ReturnCompanyCreation(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
