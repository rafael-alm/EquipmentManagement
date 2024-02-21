namespace equipmentManagement.domain.shared.seedWork.factory
{
    public static class ServiceFactory
    {
        private static IDependencyInjection _dependencyInjection;

        public static void Configure(IDependencyInjection dependencyInjection) 
        {
            _dependencyInjection = dependencyInjection;
        }

        public static TService GetInstance<TService>() 
            where TService: class
            => _dependencyInjection.GetInstance<TService>();
    }
}
