using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Services.businessLogic
{
    public partial class CustomerManager
    {
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

        public static Customer AddNew(string name, string surname, string companyName, string street, string city, int code, int? phoneNumber, int NIP)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {

                    var newPerson = new Customer
                    {


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

        public static Customer Edit(int Id, string name, string surname, string companyName, string street, string city, int code, int? phoneNumber, int NIP)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var editPerson = (context.Customers
                        .Where(p => p.Id == Id)
                        .FirstOrDefault());

                    editPerson.Name = name;
                    editPerson.Surname = surname;
                    editPerson.CompanyName = companyName;
                    editPerson.Street = street;
                    editPerson.City = city;
                    editPerson.Code = code;
                    editPerson.PhoneNumber = phoneNumber;
                    editPerson.NIP = NIP;

                    context.SaveChanges();
                    return editPerson;

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
