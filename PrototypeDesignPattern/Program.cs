using System;

namespace PrototypeDesignPattern
{
    //Bu tasarım deseninin amacı yeni nesne oluşturmak için new operatörü kullanmak yerine var olan nesnenin bir kopyasını oluşturup onu kullanmaktır.
    //Bunun sebebi new operatörünün çok kaynak harcaması ve klonlama işleminin daha kolay olmasıdır.
    //Klonlama işleminde yeni klon tıpatıp benzer olur ama aynı referansı tutmazlar.
    //Bu yöntem pek kullanılmaz fakat özel durumlar olabilir.
    //Klonlama işlemi için temel sınıf abtract yapıldı ve klonlama işleminde (object)MemberwiseClone() yapısı kullanıldı.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer customer1 = new Customer() { FisrtName = "Şükrü", LastName = "Sonar", Id = 245, City = "İstanbul" };
            Customer customer2 = (Customer)customer1.Clone();//customer1 nesnesinin kopyası oluşturulup customer2 nesnesine atandı.

            Employee employee1 = new Employee() { FisrtName = "Adem", LastName = "Sonar", Id = 651, Salary = 3000 };
            Employee employee2 = (Employee)employee1.Clone();//employee1 nesnesinin kopyası oluşturulup employee2 nesnesine atandı.

            Console.WriteLine(customer2.FisrtName);
            Console.WriteLine(employee2.FisrtName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
