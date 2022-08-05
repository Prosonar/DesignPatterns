using System;

namespace AbstractFactoryDesingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public class ProductManager
    {
        private CrossCuttingCorcernsFactory _crossCuttingCorcernsFactory;
        private Logging _logging;
        private Caching _caching;
        public ProductManager(CrossCuttingCorcernsFactory crossCuttingCorcernsFactory)
        {
            _crossCuttingCorcernsFactory = crossCuttingCorcernsFactory;
            _logging = _crossCuttingCorcernsFactory.GetLogging();
            _caching = _crossCuttingCorcernsFactory.GetCaching();
        }

        public void GetAll()
        {
            Console.WriteLine("All items listed!");
            _logging.Log();
            _caching.Cache();
        }
    }

    public interface  CrossCuttingCorcernsFactory//Ana fabriba abstract sınıfı
    {
        public  Logging GetLogging();
        public  Caching GetCaching();
    }
    public interface  Logging//loglama işlemleri için abstract fabrika sınıfı
    {
        public  void Log();
    }
    public interface  Caching//cacheleme işlemleri için abtract fabrika sınıfı
    {
        public  void Cache();
    }
    public class DatabaseLogger : Logging
    {
        public  void Log()
        {
            Console.WriteLine("Log with DatabaseLogger!");
        }
    }
    public class SmsLogger : Logging
    {
        public  void Log()
        {
            Console.WriteLine("Log with SmsLogger!");
        }
    }
    public class MemoryCache : Caching
    {
        public  void Cache()
        {
            Console.WriteLine("Cache with MemoryCache!");
        }
    }
    public class RedisCahce : Caching
    {
        public  void Cache()
        {
            Console.WriteLine("Cache with RedisCache!");
        }
    }

    public class Factory1 : CrossCuttingCorcernsFactory//Ana fabrika sınıfı hem loglama hem de cacheleme işlemleri için ortak fabrika
    {
        public  Caching GetCaching()
        {
            return new MemoryCache();
        }

        public  Logging GetLogging()
        {
            return new DatabaseLogger();
        }
    }

    public class Factory2 : CrossCuttingCorcernsFactory//Farklı ana fabrika sınıfı hem loglama hem de cacheleme işlemleri için ortak fabrika
    {
        public  Caching GetCaching()
        {
            return new RedisCahce();
        }

        public  Logging GetLogging()
        {
            return new SmsLogger();
        }
    }
}
