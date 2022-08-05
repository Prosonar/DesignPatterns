using System;

namespace SingletonDesingPattern
{
    //Singleton tasarım deseninde mantık yeni bir nesne üretilip kullanmak yerine var olan nesneyi kullanmaktır.
    //Singleton deseni oluşturmak için sınıfın tüm constructorları private olmalıdır ki yeni nesne new operatörü ile oluşturulamasın.
    //Sadece tek bir nesne oluşturup kullanmak için bu nesnenin sadece işlem yapması gereklidir.Eğer ki bu nesne veri tutan bir nesne ise kesinlikle singleton yapılmamalıdır.
    //Eğer ki veri tutan bir sınıfı singleton desenine göre tasarlarsak sadece tek bir nesne olur ve bunun içindeki verileri herkes kullanır.Bu yanlıştır çünkü veriler değişkenlik gösterir.
    //Sadece işlem yapan bir sınıf olsa bile eğer ki çok kullanılan bir sınıf değilse singleton yapmak kötü olur çünkü sadece birkaç kere kullanılacak olan bir nesnenin örneği sistem kapanana kadar bellekte yer kaplar.
    //Çünkü Singleton deseninde nesne örneği statictir ve bu nesne örneği bellekte tutulur. Fakat eğer ki çok kullanılmayan bir sınıfı singleton yaparsak gereksiz yere bellekte yer kaplar onun yerine new operatörü ile
    //nesne örneği oluşturulup kullanılır ardından bellekten silinir.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //new operatörü kullanılamıyor çünkü nesnenin public Constructor'ı yok.
            //var _customerManager = new CustomerManager();

            //Bellekte var olan tek nesne örneği kullanılıyor.
            CustomerManager customerManager = CustomerManager.GetSingletonObject();
        }
    }

    public class CustomerManager
    {
        //Bellekte sadece bir tane nesne üretiliyor
        //private olmasının sebebi nesnenin boş olma ihtimalini ortadan kaldırmaktır
        private static CustomerManager _customerManager;

        //Thread kullanımı varsa anyı anda farklı threadler yeni bir nesne örneği oluşturabilir.
        //Bunu engellemek için yani birden fazla thread varsa bu threadlerin aynı anda nesne üretimini durdurmak için lock operatörü kullanılıyor.
        //Bu lock operatörü birden fazla threadin aynı anda bir kodu çalıştırmasını engeller yani biri lock operatörü içindeki kodu çalıştırırken diğeri çalıştıramaz.
        //Lock operatörüne aşağıdaki gibi bir nesne ataması yapmak gerekir.
        private static object _lock = new object();

        //Constructor'ın private olmasının sebebi bu sınıftan herhangi bir nesnenin new lenmesini engellemektir. 
        //Böylece bu nesne örneği lazım olunca new lemek yerine bellekte var olan tek örnek kullanılmış olur.
        private CustomerManager() { }

        //Üretilen tek nesne örneği eğer ki boşsa yeni bir tane üretip gönderiyoruz fakat eğer ki doluysa kendisini yolluyoruz.
        //Böylece bellekte sadece bir tane nesne örneği oluyor ve hep o örnek kullanılıyor.
        public static CustomerManager GetSingletonObject ()
        {

            //Lock bloğunun içindeki kodları aynı anda sadece bir thread çalıştırabilir. Böylece singleton desenine sahip sınıftan birden fazla nesne üretilmez.
            lock(_lock)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }
    }
}
