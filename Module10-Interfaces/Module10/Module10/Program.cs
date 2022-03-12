using Module10.ExcersiseTasks;
using Module10.ExcersiseTasks.Interfaces;

namespace Module10
{
    class Program
    {
        // Ковариантность позволяет использовать более конкретный тип,
        // чем тип, который задан изначально.
        // Контравариантность позволяет использовать более универсальный тип,
        // чем тип, который задан изначально.

        static ILogger Logger { get; set; }
        static void Main()
        {
            //IGarageManager<Car, Garage> garageManager = new GarageManagerBase();
            //IGarageManager<Honda, Garage> garageManager1 = new GarageManagerBase();
            //IGarageManager<Honda, CarStorage> garageManager2 = new GarageManagerBase();

            /* Контрвариация */

            //var mobilePhone = new Phone();
            //mobilePhone.Type = "smart phone";
            //var iPhone = new ApplePhone();
            //iPhone.Type = "iPhone X";

            //IMessenger<Phone> viberInPhone = new Viber<Phone>();
            //viberInPhone.GetDeviceInfo(mobilePhone);

            //IMessenger<ApplePhone> viberInApplePhone = new Viber<Phone>();
            //viberInApplePhone.GetDeviceInfo(iPhone);

            /* Ковариация */

            //IMessenger<Phone> viberInPhone = new Viber<Phone>();
            //IMessenger<Phone> viberInApplePhone = new Viber<ApplePhone>();

            //viberInPhone.GetDeviceInfo();
            //viberInApplePhone.GetDeviceInfo();

            /***/
            //IFile file = new FileInformation();
            //IBinaryFile binaryFile = new FileInformation();
            //var fileInfo = new FileInformation();

            //file.ReadFile();
            //binaryFile.OpenBinaryFile();
            //binaryFile.ReadFile();
            //fileInfo.Search("Строка для поиска");            

            //var newMessanger = new NewMessenger();
            //((IWhatsApp)newMessanger).SendMessage("Hello WhatsApp!");
            //((IViber)newMessanger).SendMessage("Hello Viber!");

            Logger = new Logger();
            var worker1 = new Worker1(Logger);
            var worker2 = new Worker2(Logger);
            var worker3 = new Worker3(Logger);

            worker1.Work();
            worker2.Work();
            worker3.Work();

            Console.ReadKey();
        }
    }
}
