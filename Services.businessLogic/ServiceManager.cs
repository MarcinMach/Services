using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.businessLogic
{
    public partial class ServiceManager
    {
        private static List<Service> _Service = new List<Service>();

        public static List<Service> Service
        {
            get
            {
                if (_Service.Count == 0)
                {
                    _Service = GetList();
                }
                return _Service;
            }
        }

        public static List<Service> GetList()
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    return context.Services.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Service>();
            }
        }

        public static Service GetById(int id)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var record = context.Services
                        .Where(p => p.Id == id)
                        .FirstOrDefault();

                    return record;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Service> GetServiceByIds(List<int> servicesId)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var services = from c in context.Services
                                   where servicesId.Contains(c.Id)
                                   select c;
                    var allServices = services.ToList();
                    var sortedCustomers = new List<Service>();
                    foreach (int id in servicesId)
                    {
                        var service = allServices.Find(x => x.Id == id);
                        if (service != null)
                            sortedCustomers.Add(service);
                    }
                    return sortedCustomers;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Service AddNew(int Id, string serviceName, float unitPrice, float netPrice, int Vat)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var newservice = new Service
                    {
                        ServiceName = serviceName,
                        UnitPrice = unitPrice,
                        NetPrice = netPrice,
                        Vat = Vat,
                        VatAmount = ((Vat * unitPrice) / 100),
                        PretaxPrice = (unitPrice + (Vat * unitPrice) / 100),
                    };
                    context.Services.Add(newservice);
                    context.SaveChanges();

                    return newservice;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Customer Delete(int projectId)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var deleteServive = (context.Services
                    .Where(p => p.Id == projectId)
                    .FirstOrDefault());
                    context.Services.Remove(deleteServive);
                    context.SaveChanges();

                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Service Edit(int Id, string serviceName, float unitPrice, float netPrice, int VAT)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var editService = (context.Services
                        .Where(p => p.Id == Id)
                        .FirstOrDefault());
                    editService.ServiceName = serviceName;
                    editService.UnitPrice = unitPrice;
                    editService.NetPrice = netPrice;
                    editService.Vat = VAT;

                    context.SaveChanges();
                    return editService;
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
      
    }
}
