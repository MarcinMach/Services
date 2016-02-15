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

        public static List<Customer> GetList()
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
     

        public static Customer GetById(int id)
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
        #endregion



        public static Customer AddNew(int Id, string name, string surname, string companyName, string street, string city, string code, int phoneNumber, string NIP)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {

                    var newPerson = new Customer
                    {
                        Id = Id,
                        Name = name,
                        Surname = surname,
                        CompanyName = companyName,
                        Street = street,
                        City = city,
                        Code = code,
                        PhoneNumber = phoneNumber,
                        NIP = NIP
                    };
                    context.Customers.Add(newPerson
                        );

                    context.SaveChanges();

                    return newPerson;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

     
        public static Customer Edit(int Id, string name, string surname, string companyName, string street, string city, string code, int phoneNumber, string NIP)

        {
            try
            {
                using(var context = new ServicesDBEntities())
                {
                    var EditPerson = (context.Customers
                        .Where(p => p.Id == Id)
                        .FirstOrDefault());

                    EditPerson.Name = name;                    
                    EditPerson.Surname = surname;
                    EditPerson.CompanyName = companyName;
                    EditPerson.Street = street;
                    EditPerson.City = city;
                    EditPerson.Code = code;
                    EditPerson.PhoneNumber = phoneNumber;
                    EditPerson.NIP = NIP;

                    int num = context.SaveChanges();
                    return EditPerson;
                        
                };
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
                    var deletePerson = (context.Customers
                    .Where(p => p.Id == projectId)
                    .FirstOrDefault());                   
                    context.Customers.Remove(deletePerson);

                   
                    context.SaveChanges();

                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
          


    }
}
