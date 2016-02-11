using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.businessLogic
{
    public partial class CustomerManager
    {
        
        #region Projects
        private static List<Customer> _Customers = new List<Customer>();
        public static List<Customer> Customers
        {
            get
            {
                if (_Customers.Count == 0)
                {
                    _Customers = GetList();
                }

                return _Customers;
            }
        }
        #endregion

        #region GetList()

        private static List<Customer> GetList()
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    return context.Customers.ToList();
                }
            }
            catch (Exception ex)
            {

                return new List<Customer>();
            }
        }

        #endregion


        #region GetById()
        public static Customer GetById(int id, bool loadReferences = false)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    if (loadReferences)
                    {
                        return context.Customers
                            .Where(p => p.Id == id)
                            .FirstOrDefault();
                    }
                    else
                    {
                        return context.Customers
                            .Where(p => p.Id == id)
                            .FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static Customer GetById(int projectId, int id)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var record = context.Customers
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

        public static Customer GetById(int projectId)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var record = context.Customers
                        .Where(p => p.Id == projectId)
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

        public static Customer Add(int projectId)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    List<Customer> create = context.Customers
                      .OrderByDescending(x => x.Id == projectId)
                      .ToList<Customer>();

                    return create
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        
    }
}
