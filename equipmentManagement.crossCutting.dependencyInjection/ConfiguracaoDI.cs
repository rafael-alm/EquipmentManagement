//using AutoMapper;
//using equipmentManagement.application.input.seedWork.repository;
//using equipmentManagement.application.input.services.company;
//using equipmentManagement.application.input.services.company.interfaces;
//using equipmentManagement.domain.shared.seedWork.factory;
//using equipmentManagement.infra.data.input;
//using equipmentManagement.infra.data.input.aggregates;
//using inspecao.administrActive.dominio.modelos.empresa.repositorios;
//using Microsoft.EntityFrameworkCore;
//using SimpleInjector;
//using SimpleInjector.Lifestyles;

//namespace equipmentManagement.crossCutting.dependencyInjection
//{
//    public class ConfiguracaoDI: IDependencyInjection
//    {
//        private readonly Container container;

//        public ConfiguracaoDI(Container container) 
//            => this.container = container;

//        public static IDependencyInjection Execute()
//        {
//            var container = new Container();
//            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
//            var configDI = new ConfiguracaoDI(container);
            

//            // Crie uma nova instância de MapperConfiguration
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile<YourMappingProfile>();
//            });

//            // Registre a instância de MapperConfiguration no seu contêiner
//            container.RegisterInstance(config);
//            // Registre IMapper usando a instância de MapperConfiguration
//            container.Register(() => config.CreateMapper(container.GetInstance));
//            configDI.registerAll();

//            return configDI;
//        }

//        TService IDependencyInjection.GetInstance<TService>() 
//            where TService : class
//        {
//            return container.GetInstance<TService>();
//        }

//        private void registerAll()
//        {
//            registerContext();
//            registerCompany();
//        }

//        private void registerContext()
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ContextEquipmentManagement>();
//            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbEquipmentManag;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

//            container.RegisterInstance<ContextEquipmentManagement>(new ContextEquipmentManagement(optionsBuilder.Options));
//            container.Register<IDbContext, UnitOfWork>();
//        }

//        private void registerCompany()
//        {
//            container.Register<ICreateCompanyService, CreateCompanyService>();
//            container.Register<IModifyCompanyService, ModifyCompanyService>();
//            container.Register<IDeactivateCompanyService, DeactivateCompanyService>();
//            container.Register<ICompanyWriteRepository, CompanyRepository>();
//            container.Register<ICompanyReadRepository, CompanyRepository>();
//        }
//    }
//}