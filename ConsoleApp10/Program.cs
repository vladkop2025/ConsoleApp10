using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp10.Program;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Модуль 10. Интерфейсы
            //10.2. Явная и неявная реализация интерфейсов
            /* 
            Что такое явная и неявная реализация интерфейсов?

            Начиная разбирать данный вопрос, хотелось бы сначала остановиться на явной реализации интерфейсов.

                Явная реализация интерфейса — это указание компилятору, что конкретный член принадлежит этому конкретному интерфейсу.

            Если класс реализуется из более чем одного интерфейса, который имеет методы с одинаковой сигнатурой, тогда вызов 
            такого метода будет реализовывать тот же метод, а не методы, специфичные для интерфейса. 

            Это разрушит всю цель использования разных интерфейсов. Вот тогда и появляется явная реализация. 

            Давайте увидим смысл явной реализации интерфейсов на примере. У нас есть следующие два интерфейса. 

                 WhatsApp

            public interface IWhatsApp
            {
            public void SendMessage(string message);
            }

                IViber

            public interface IViber
            {
            public void SendMessage(string message);
            }

            Каждый из двух интерфейсов содержит одинаковую сигнатуру метода SendMessage:

            public void SendMessage(string message);    
            
            Далее создаём класс NewMessenger и применяем к нему два наших интерфейса:

            public class NewMessenger: IWhatsApp, IViber 
            {

            }

            После явной реализации членов каждого интерфейса наш класс NewMessenger выглядит следующим образом:
            
            public class NewMessenger : IWhatsApp, IViber
            {
                    void IWhatsApp.SendMessage(string message)
                {
                    throw new NotImplementedException();
                 }

                void IViber.SendMessage(string message)
                 {
                     throw new NotImplementedException();
                 }
            }

            Давайте изменим реализацию каждого метода для отображения сообщения в консольном окне:

            public class NewMessenger : IWhatsApp, IViber
            {
                    void IWhatsApp.SendMessage(string message)
                {
                    Console.WriteLine("{0} : {1}", "WhatsApp", message);
                    throw new NotImplementedException();
                 }

                void IViber.SendMessage(string message)
                 {
                     Console.WriteLine("{0} : {1}", "Viber", message);
                     throw new NotImplementedException();
                 }
            }

            Затем в класс Main выполним создание экземпляра класс NewMessenger и поочередное выполнение методов SendMessage:

                NewMessenger newMessenger = new NewMessenger();

                ((IWhatsApp)newMessenger).SendMessage("Hello World!");
                ((IViber)newMessenger).SendMessage("Hello World!");

                Console.ReadKey()

            Обратите внимание на данные строки:

                ((IWhatsApp) newMessenger).SendMessage("Hello World!");
             ((IViber) newMessenger).SendMessage("Hello World!");

            Это особенность явной реализации интерфейса. И сделали мы так, потому что обратиться напрямую к методу SendMessage 
            класса NewMessenger невозможно, ибо данный метод не является методом класса NewMessenger.

                NewMessenger newMessenger = new NewMessenger();

                newMessenger.SendMessage("Hello World!");
                Console.ReadKey();

            Давайте посмотрим, как явная реализация интерфейса спасает от лишних часов работы при рефакторинге в следующем скринкасте:

            Вывод: всегда использовать явную реализациб интерфейса 

            С неявной реализацией интерфейсов всё намного проще.

            Неявная реализация интерфейса выглядит вот так:

            public class NewMessenger: IWhatsApp,
            IViber 
            {
                public void SendMessage(string message) 
                {
                     throw new NotImplementedException();
                }
            }

            Аналогично мы можем выполнить неявную реализацию при помощи IDE:

            Задание 10.2.1
            Определите, какой вид реализации интерфейса применен в данном коде:

            public class MyListener: IListener 
            {
                public void Listen() 
                {
      
                }
            }

            public interface IListener 
            {
                void Listen();
            }

            Ответ: В данном коде демонстрируется неявная реализация.

            Задание 10.2.2
            Используя теоретический материал из данного юнита, постарайтесь самостоятельно реализовать явную реализацию 
            следующего интерфейса:

            public interface IWriter 
            {
                void Write();
            }

            Код в пространстве имен Main

            Write writer = new Write();

            ((IWriter)writer).Write();

            Console.ReadKey();

        }

        public interface IWriter
        {
            void Write();
        }

        public class Write : IWriter
        {
            void IWriter.Write()
            {
                throw new NotImplementedException();
            }
        }

            Задание 10.2.3
            Реализуйте неявно следующий интерфейс:

            public interface IWorker 
            {
                public void Build();
            }

            Ответ:

            public class Worker: IWorker 
            {
                public void Build() 
                {
                     throw new NotImplementedException();
                 }
            }

            Задание 10.2.4
            Реализуйте явно следующий интерфейс и вызовите его метод в классе Program.

            public interface IWorker 
            {
                public void Build();
            }

            Ответ:

                namespace InterfacePracticesInCore
    {
        class Program
        {
            static void Main()
            {
                var worker = new Worker();

                ((IWorker)worker).Build();  //явная реализация
            }
        }

        public class Worker : IWorker
        {
            void IWorker.Build()
            {
                throw new NotImplementedException();
            }
        }

        public interface IWorker
        {
            public void Build();
        }
    }
            */
        }
    }
}
