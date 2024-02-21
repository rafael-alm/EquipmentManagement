using System;

namespace equipmentManagement.domain.objectValues
{
    public record Telefone
    {
        public Telefone(string numero)
        {
            ArgumentNullException.ThrowIfNull(numero, nameof(numero));

            Numero = numero;
        }
        public string Numero { get; init; }
    }
}
