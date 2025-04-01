using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Модуль 10. Интерфейсы
            //10.4. Ковариантные и контравариантные интерфейсы
            /* 
            Понятия ковариантность и контравариантность в языке C#, думаю, для вас уже знакомы. Но на всякий случай давайте 
            повторим данные определения.

            Задание 10.4.1
            Позволяет ли ковариантность использовать более универсальный тип, чем тип, который задан изначально?
            
            Ответ: нет Ковариантность не позволяет использовать более универсальный тип, чем тип, который задан изначально

                * Ковариантность позволяет использовать более конкретный тип, чем тип, который задан изначально.
                * Контравариантность позволяет использовать более универсальный тип, чем тип, который задан изначально.
            
            Аналогично данные свойства встречаются и в интерфейсах, но только в обобщённых. Обощенные интерфейсы могут быть 
            как ковариантными, так и контравариантными. Реализуются они через переменную T. 

            Например, создадим обобщенный интерфейс IMessenger, который при вызове функции DeviceInfo, будет возвращать объект T:

                public interface IMessenger <T> 
                {
                 T DeviceInfo();
                }

            В качестве параметра T будет выступать либо класс, либо параметр, который мы укажем при реализации. 

            Далее мы создаём два класса: Phone и Computer.

                public class Phone {}
                public class Computer {}

            А теперь реализуем наш интерфейс IMessenger<T> через класс Phone:

            Обобщенный интерфейс IMessenger реализован через класс Phone и при вызове функции DeviceInfo возвращает объект Phone, 
            который указан в качестве параметра T.

        public class Viber : IMessenger<Phone>
        {
            public Phone DeviceInfo()
            {
                return null;
            }
        }

        public class Phone { }
        public class Computer { }

            При реализации обобщенных интерфейсов IDE успешно подскажет, что для определения обобщенного интерфейса необходимо 
            указать параметр T, иначе ничего не скомпилируется.

            Обобщённые интерфейсы проявляют свою ковариантность, когда к параметру T применяется ключевое слово out.

            Изменим наш интерфейс IMessenger следующим образом:

                public interface IMessenger <out T>
                {
                    T DeviceInfo();
                }

            Слово out указывает, что интерфейс IMessenger теперь является ковариантным.

            Давайте проверим, правда ли мы можем использовать ковариантность у данного интерфейса?

            Для начала создаём класс Phone и IPhone.  IPhone наследуем от класса Phone:

                    public class Phone { }

                    public class IPhone : Phone { }

            Далее необходимо сделать класс Viber обобщённым и определить его следующим образом:

        public class Viber<T> : IMessenger<T> where T : Phone,
        new()
        {
            public T DeviceInfo()
            {
                T device = new T();
                Console.WriteLine(device);
                return new T();
            }
        }

            Далее переходим в класс Main и выполняем реализацию обобщенного интерфейса IMessenger двух типов: Phone и IPhone.

                IMessenger<Phone> viberInPhone = new Viber<Phone>();
                IMessenger<IPhone> viberInIPhone = new Viber<IPhone>();

                viberInPhone.DeviceInfo();
                viberInIPhone.DeviceInfo();

                Console.Read();

            И вот теперь можем посмотреть на ковариацию.

            Объект интерфейса более универсального типа Phone мы можем привести к объекту интерфейса более конкретного типа 
            IPhone следующей строкой:

                IMessenger<Phone> viberInIphone = new Viber<IPhone>();

            Обобщённый делегат с параметром out реализовал нашу ковариацию. Низкий поклон.

            Контрвариация в интерфейсах реализуется через слово in. Для демонстрации контравариации воспользуемся тем же самым 
            кодом и изменим наш интерфейс IMessenger следующим образом:

                public interface IMessenger<in T>
                {
                   void T DeviceInfo();
                }

            Далее выполняем похожую реализацию интерфейсов, что и в примере выше:

                IMessenger<Phone> viberInPhone = new Viber<Phone>();
                IMessenger<IPhone> viberInIPhone = new Viber<IPhone>();

                viberInPhone.DeviceInfo();
                viberInIPhone.DeviceInfo();

                Console.Read();

            И снова магия контравариции. Данной строкой мы выполняем приведение объекта интерфейса более универсального 
            типа Phone к объекту интерфейса более конкретного типа IPhone.

                IMessenger<IPhone> viberInIphone = new Viber<Phone>();

            Обобщенный интерфейс может быть как ковариантным, так и контравариантным одновременно. Разбираем данный случай в скринкасте:

            Задание 10.4.2
            Какое ключевое слово используется в обобщенном интерфейсе для определения в нём ковариации?

            Ответ: Ключевое слово out в обобщенном интерфейсе означает, что он ковариантен

            Задание 10.4.3
            Какое ключевое слово используется в обобщенном интерфейсе для определения в нём контравариации?

            Ответ: Ключевое слово in в обобщенном интерфейсе означает, что он контравариантен.

            Задание 10.4.4
            Определены два класса:

        public class User
        {

        }

        public class Account : User
        {

        }

            Определён обобщённый интерфейс:

        public interface IUpdater<in T>
        {
            void Update(T entity);
        }

            Реализуйте данный интерфейс в классе UserService, и продемонстрируйте контравариацию интерфейса в базовом классе Program.

            Ответ:

            var user = new User();
            var account = new Account();

            IUpdater<Account> updater = new UserService();

            var userService = new UserService();
            userService.Update(user);            //контрвариация 

        public interface IUpdater<in T>
        {
            void Update(T entity);
        }

        public class UserService : IUpdater<User>
        {
            public void Update(User entity)
            {
                throw new NotImplementedException();
            }
        }

        public class User
        {

        }

        public class Account : User
        {

        }

            */

            IGarageManager<Car, Garage> garageManager1 = new GarageMAnagerBase();
           
            IGarageManager<Bike, Garage> garageManager2 = new GarageMAnagerBase(); //без in в интерфейсе контравариация не работает

            IGarageManager<Bike, House> garageManager3 = new GarageMAnagerBase();  //без out в интерфейсе ковариация не работает
        }

        public class Car 
        { 
        }

        public class Bike : Car
        {
        }

        public class House 
        { 
        }

        public class Garage : House
        {
        }

        public interface IGarageManager <in T, out Z> //применение и контравариантрного и ковариантного параметров
        {
            Z GetGarageInfo(); //возвращает объект гаража

            void Add(T car);       //параметр - автомобиль
        
        }

        public class GarageMAnagerBase : IGarageManager<Car, Garage>
        {
            public void Add(Car car)
            {
                throw new NotImplementedException();
            }

            public Garage GetGarageInfo()
            {
                throw new NotImplementedException();
            }
        }
    }
}
