using equipmentManagement.domain.shared.seedWork.notification;

namespace equipmentManagement.domain.aggregates.company.validations
{
    public class CompanyMessages : IMessageNotification
    {
        public CompanyMessages(string code, string text)
        {
            Code = code;
            Text = text;
        }

        public string Code { get; }
        public string Text { get; }

        public static readonly CompanyMessages
            RegisteredNameIsRequired = new CompanyMessages("RegisteredNameIsRequired", "Razão Social é obrigatorio."),
            NameIsRequired = new CompanyMessages("NameIsRequired", "Name é obrigatorio."),
            CnpjIsRequired = new CompanyMessages("CnpjIsRequired", "CNPJ é obrigatorio."),
            TypeOfFacilityDeveSerValida = new CompanyMessages("TypeOfFacilityDeveSerValida", "Tipo de Instalacao não é valido."),
            CNPJHasAlreadyBeenInformed = new CompanyMessages("CNPJHasAlreadyBeenInformed", "CNPJ Já Foi Informado Para Outra Empresa."),
            CompanyAlreadyActive = new CompanyMessages("CompanyAlreadyActive", "Empresa já está ativa."),
            CompanyAlreadyDeactivated = new CompanyMessages("CompanyAlreadyDeactivated", "Empresa já está desativada.");
    }
}
