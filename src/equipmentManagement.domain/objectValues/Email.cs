using System;

namespace equipmentManagement.domain.objectValues
{
    public record Email
    {
        public Email(string descricao)
        {
            ArgumentNullException.ThrowIfNull(descricao, nameof(descricao));

            Descricao = descricao;
        }

        public string Descricao { get; init; }
    }
}
