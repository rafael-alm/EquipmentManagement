using System;

namespace equipmentManagement.domain.objectValues
{
    public record Celular
    {
        public Celular(string numero)
        {
            ArgumentNullException.ThrowIfNull(numero, nameof(numero));

            Numero = numero;
        }
        public string Numero { get; init; }
    }
}
