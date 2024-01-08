﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace equipmentManagement.infra.data.input.entityTypeConfiguration.converters
{
    internal class ConverterDateOnly : ValueConverter<DateOnly, DateTime>
    {
        public ConverterDateOnly()
            : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.Parse("00:00")),
                DateTime => DateOnly.FromDateTime(DateTime))
        {}
    }
}
