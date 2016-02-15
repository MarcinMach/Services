using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.businessLogic
{
    public partial class ServiceManager
    {
        #region Projects
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
        #endregion

        #region GetList()

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



        #region GetById()


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
        #endregion



        #region
        public static Service AddNew(int Id, string serviceName, float unitPrice, float netPrice, int VAT) {
            try
            {
                using (var context = new ServicesDBEntities())
                {

                    var newservice = new Service
                    {
                        Id = Id,
                        ServiceName = serviceName,
                        UnitPrice = unitPrice,
                        NetPrice = netPrice,
                        VAT = VAT,
                        VATAmount = ((VAT * unitPrice) / 100),
                        PretaxPrice = (unitPrice + (VAT * unitPrice) / 100),

                    };
                    context.Services.Add(newservice);
                    context.SaveChanges();

                    return newservice;
                }
                #endregion
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
                    var EditService = (context.Services
                        .Where(p => p.Id == Id)
                        .FirstOrDefault());

                    EditService.ServiceName = serviceName;
                    EditService.UnitPrice = unitPrice;
                    EditService.NetPrice = netPrice;
                    EditService.VAT = VAT;
           
                    

                    int num = context.SaveChanges();
                    return EditService;

                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
#endregion