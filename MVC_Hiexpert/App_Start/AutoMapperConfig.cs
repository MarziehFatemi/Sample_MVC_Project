using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Project_Model.Model;
using MVC_Hiexpert.Models.ViewModel;
using MVC_Hiexpert.Models.ViewModel.Customer_ViewModels;
using MVC_Hiexpert.Models.ViewModel.Group_ViewModel;
using MVC_Hiexpert.Models.ViewModel.Appointment_ViewModel;
using MVC_Hiexpert.Models.ViewModel.Payment_ViewModel;
//using MVC_Hiexpert.Models.ViewModels;


namespace MVC_Hiexpert.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;
        public static void ConfigureMapping()
        {
            MapperConfiguration config = new MapperConfiguration(t => {
               t.CreateMap<Doctor, Dr_abs_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Dr_abs_ViewModel, Doctor>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Doctor, Dr_Create_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Dr_Create_ViewModel, Doctor>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Doctor, Dr_DetailsViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Dr_DetailsViewModel, Doctor>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Doctor, Dr_Edit_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Dr_Edit_ViewModel, Doctor>().IgnoreAllPropertiesWithAnInaccessibleSetter();


                t.CreateMap<Customer, C_List_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<C_List_ViewModel, Customer>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Customer, C_Create_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<C_Create_ViewModel, Customer>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Customer, C_Details_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<C_Details_ViewModel, Customer>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Customer, C_Edit_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<C_Edit_ViewModel, Customer>().IgnoreAllPropertiesWithAnInaccessibleSetter();


                t.CreateMap<Group, Group_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Group_ViewModel, Group>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Appointment, Appointment_List_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Appointment_List_ViewModel, Appointment>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Appointment, Appointment_Detail_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Appointment_Detail_ViewModel, Appointment>().IgnoreAllPropertiesWithAnInaccessibleSetter();


                t.CreateMap<Payment, Payment_ViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Payment_ViewModel, Payment>().IgnoreAllPropertiesWithAnInaccessibleSetter();


            });
            mapper = config.CreateMapper();
        }

    }
}