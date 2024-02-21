using System;

namespace equipmentManagement.domain.objectValues
{
    public record CEP
    {
        public CEP(string numero)
        {
            ArgumentNullException.ThrowIfNull(numero, nameof(numero));

            Numero = numero;
        }

        public string Numero { get; init; }
    }
}