using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => {
                Operations();
            }).Wait();
            Console.ReadLine();
        }

        static async Task Operations()
        {
            Service dbService = new Service();

            var phonesName = dbService.GetPhones();
            foreach (var p in phonesName)
                Console.WriteLine(p.Name);

            Console.WriteLine("\n-------------------------------");
            var phoneMinPrice = dbService.GetPhoneWithMinPrice();
            Console.WriteLine("The most expensive phone: {0}", phoneMinPrice.Name);

            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("Phone bought from 2015 to 2016");
            var phoneBoughtInYear = dbService.GetPhoneBoughtInLastYears();
            foreach (var phone in phoneBoughtInYear)
                Console.WriteLine(phone.Name);

            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("List of phones after updating and deleting");
            await dbService.newPhonesPrice(2);
            await dbService.DeletePhones();

            var phones = dbService.GetPhones();
            foreach (var p in phones)
                Console.WriteLine("{0}, price: {1}", p.Name, p.Price);
            Console.ReadLine();
        }
    }
}
