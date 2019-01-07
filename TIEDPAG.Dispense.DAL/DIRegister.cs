using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TIEDPAG.Dispense.IDAL;

namespace TIEDPAG.Dispense.DAL
{
    public class DIRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);
            Console.WriteLine("DI DAL");
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.IsAssignableTo<IBaseDAL>())
                .AsSelf();
        }
    }
}
