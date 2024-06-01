using Autofac;
using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<EfReservationDal>().As<IReservationDal>().SingleInstance();
            builder.RegisterType<ReservationManager>().As<IReservationService>().SingleInstance();

            builder.RegisterType<EfServiceDal>().As<IServiceDal>().SingleInstance();
            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();


        }
    }
}
