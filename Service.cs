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

        public Phone GetPhoneWithMinPrice()
        {
            return db.Phones
                .OrderBy(p => p.Price)
                .First();
        }

        public ICollection<Phone> GetPhoneBoughtInLastYears()
        {
            return db.Phones
                .Where(p => p.OrderHistories
                    .Where(o => o.Date.Year == 2015 || o.Date.Year == 2016)
                    .Count() != 0)
                .OrderBy(p => p.Name).ToList();
        }

        public async Task newPhonesPrice(double coefficient)
        {
            foreach (var phone in db.Phones)
            {
                if (phone.Price < 500)
                {
                    phone.Price *= coefficient;
                }
            }

            await db.SaveChangesAsync();
        }

        public async Task DeletePhones()
        {
            db.Phones.RemoveRange(db.Phones.Where(p => p.Price < 600));
            await db.SaveChangesAsync();
        }
    }
}
