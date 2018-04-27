using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.EF;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            //kernel.Bind<IAccountStorage>().To<BinaryAccountStorage>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountStorage>().To<Repository>();
            kernel.Bind<IAccountNumberCreator>().To<AccountNumberCreator>().InSingletonScope();
        }
    }
}
