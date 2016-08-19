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
            Service dbService = new Service();
            var phone = dbService.GetPhoneWithMinPrice();
            Console.WriteLine("The most expensive phone: {0}", phone.Name);
            Console.ReadLine();
        }
    }
}
