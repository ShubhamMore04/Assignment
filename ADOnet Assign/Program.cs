using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace CA_Customer_Data
{
    internal class Program
    {
        private static IConfiguration _configuration;
        static void Main(string[] args)
        {
            GetAppSettingsFile();
           // PrintCustomer();
            CustomerDisplay();
            PrintCustomer();

        }

        static void GetAppSettingsFile()
        {
            var bulider = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true);
            _configuration = bulider.Build();
        }

        static void PrintCustomer()
        {
            CustomerInfo obj = new CustomerInfo(_configuration);
            obj.Customers(); 
        }

        static void CustomerDisplay()
        {
            Customers p1 = new Customers {Id = 105, Name = "alpesh", Address = "Airoli", Mobile_No = "9879849849" };
            Strongly_type indata = new Strongly_type(_configuration);
            int a = indata.AddData(p1);
            Console.WriteLine("{0}",a);
        }
    }
}