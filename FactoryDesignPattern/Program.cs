using System;

namespace FactoryDesignPattern
{
    //Bu tasarım deseni aynı işleri yapan farklı kodlar varsa yani polimorphizim varsa kullanılır.
    //Bu tasarımda amaç aynı işleri yapan farklı kodların yönetimini ve kullanılmasını bir sınıf yürütür ve bu sınıfa factory sınıf denir.
    //Bu örnek için 2 farklı loglama yapan sınıfımız var bunlardan biri DatabaseLogger diğeri ise SmsLogger'dır.
    //Bu iki sınıf direk üretilip kullanılmak yerine bu iki sınıfın ortak noktası olan bir yapı oluşturulup bu yapının yönetimini sağlayan bir sınıf oluşturulur.
    //Bu örnekte DatabaseLogger ile SmsLogger'ın ikisi de ILogger olduğundan ortak noktaları ILogger interface'sidir.
    //Bu interface ile ilgili işlemleri ise bizim fabrikamız yani ILoggerFactory interface'si üstenir.Yani işlemleri bir ILoggerFactory olan LoggerFactory yapar.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();

        }
    }

    public class CustomerManager
    {
        //Bu sınıfın loglama işlemleri için bir ILoggerFactory tanımı yaptık ve ardından factory sınıfının methodunu kullanarak loglama yaptık.
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            _loggerFactory.GetLogger().Log();
        }
    }

    public interface ILoggerFactory
    {
        ILogger GetLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger()
        {
            return new SmsLogger();
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with DatabaseLogger!");
        }
    }

    public class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with SmsLogger!");
        }
    }
}
