namespace equipmentManagement.domain.objectValues
{
    public record LastUpdate
    {
        public LastUpdate()
        {
            Data = DateTime.Now;
        }

        public LastUpdate(DateTime data)
        {
            if (data.Year < 2000)
                throw new ArgumentOutOfRangeException(nameof(data), data, "Language.Exception_Invalid_Date");

            Data = data;
        }

        public DateTime Data { get; init; }
    }
}
