using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.businessLogic
{
    public partial class SellerManager
    {       
        private static List<Seller> _Seller = new List<Seller>();

        public static List<Seller> Seller
        {
            get
            {
                if (_Seller.Count == 0)
                {
                    _Seller = GetList();
                }

                return _Seller;
            }
        }

        public static List<Seller> GetList()
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    return context.Sellers.ToList();
                }
            }
            catch (Exception ex)
            {

                return new List<Seller>();
            }
        }
        public static Seller GetById(int id)
        {
            try
            {
                using (var context = new ServicesDBEntities())
                {
                    var record = context.Sellers
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

    }
}

    
