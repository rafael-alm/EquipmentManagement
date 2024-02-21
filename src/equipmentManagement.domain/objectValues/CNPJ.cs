using equipmentManagement.domain.aggregates.company.validations;
using equipmentManagement.domain.seedWork.objectValues;
using equipmentManagement.domain.shared.seedWork.exceptions;
using System.Text.RegularExpressions;

namespace equipmentManagement.domain.objectValues
{
    public record struct CNPJ
    {
        private CNPJ(string number)
        {
            if (!IsValid(number))
                throw new EntityValidationException("CNPJ deve ser valido.");

            Number = onlyNumber(number);
        }

        public string Number { get; init; }

        public static bool IsValid(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;

            string cnpj = onlyNumber(number);

            if (cnpj.Length != 14)
                return false;

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";

            digitos = new int[14];

            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;

            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;

            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            for (nrDig = 0; nrDig < 14; nrDig++)
            {
                digitos[nrDig] = int.Parse(
                cnpj.Substring(nrDig, 1));

                if (nrDig <= 11)
                    soma[0] += (digitos[nrDig] *
                      int.Parse(ftmt.Substring(
                      nrDig + 1, 1)));

                if (nrDig <= 12)
                    soma[1] += (digitos[nrDig] *
                      int.Parse(ftmt.Substring(
                      nrDig, 1)));
            }

            for (nrDig = 0; nrDig < 2; nrDig++)
            {
                resultado[nrDig] = (soma[nrDig] % 11);

                if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                    CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                else
                    CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
            }

            return (CNPJOk[0] && CNPJOk[1]);
        }

        public bool IsNullOrEmpty()
            => string.IsNullOrEmpty(Number);

        private static string onlyNumber(string cnpj)
            => Regex.Replace(cnpj, "[^\\d]", string.Empty);

        public static implicit operator string(CNPJ e) => e.Number;
        public static implicit operator CNPJ(string id) => new (id);

        public override string ToString() => Number;
    }
}