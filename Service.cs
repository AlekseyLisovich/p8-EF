using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore_EF
{
    class Service
    {
        private PhoneStoreContext db = new PhoneStoreContext();

        public ICollection<Phone> GetPhones()
        {
            return db.Phones.ToList();
        }

        public Phone GetPhoneWithMaxPrice()
        {
            return db.Phones
                .OrderByDescending(p => p.Price)
                .First();
        }
    }
}
