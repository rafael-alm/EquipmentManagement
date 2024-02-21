namespace equipmentManagement.domain.shared.seedWork.factory
{
    public interface IDependencyInjection
    {
        TService GetInstance<TService>() where TService : class;
    }
}
