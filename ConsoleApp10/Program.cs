using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            //10.3. Множественная реализация интерфейсов
            /* 
            В предыдущем юните мы уже рассмотрели в примере множественную реализацию интерфейсов, а именно, когда наш класс NewMessenger определял сразу два интерфейса: IViber и IWhatsApp.
        
        public class NewMessenger : IWhatsApp,
````````IViber
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

            Но для более глубокого закрепления множественной реализации нам понадобятся следующие три интерфейса:

        public interface IWriter
        {
            void Write();
        }

        public interface IReader
        {
            void Read();
        }

        public interface IMailer
        {
            void SendEmail();
        }

            Из данных интерфейсов мы определяем три контракт
            
                IWriter обязательно должен выполнять функцию Write.
                IReader обязательно должен выполнять функцию Read.
                IMailer обязательно должен выполнять функцию SendMail.
            
            Далее создаём класс FileManager и выполняем в нём множественную реализацию интерфейсов. Особенности применения 
            множественной реализации интерфейсов разберём в скринкасте (код приведен в реализации):

            Задание 10.3.1
            Создайте класс FileManager и выполните в нём множественную реализацию интерфейсов, указанных в примере выше.

            Ответ:

        public class FileManager : IWriter,
                                   IReader,
                                   IMailer
        {
            public void Read()
            {
                throw new NotImplementedException();
            }

            public void SendMail()
            {
                throw new NotImplementedException();
            }

            public void Write()
            {
                throw new NotImplementedException();
            }
        }

            Благодаря такому свойству интерфейса, как множественная реализация, мы смогли создать класс FileManager, 
            который определяет сразу три интерфейса и успешно выполняет наши контракты.

            Даны три интерфейса:


            Создайте класс Entity и выполните в нём множественную неявную реализацию данных интерфе

         public interface ICreatable
        {
            void Create();
        }

        public interface IDeletable
        {
            void Delete();
        }

        public interface IUpdatable
        {
            void Update();
        }

            Ответ:
            
            public class Entity : ICreatable,
                                  IDeletable,
                                  IUpdatable
        {
            public void Create()
            {
                throw new NotImplementedException();
            }

            public void Delete()
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                throw new NotImplementedException();
            }
        }

            Задание 10.3.3
            Даны два интерфейса:

            
        public interface IBook
        {
            void Read();
        }
                        
            Создайте класс ElectronicBook и выполните в нём множественную явную реализацию данных интерфейсов

            Ответ:

        public class ElectronicBook : IBook,
                                      IDevice
        {
            void IDevice.TurnOff()
            {
                throw new NotImplementedException();
            }
            void IDevice.TurnOn()
            {
                throw new NotImplementedException();
            }

            void IBook.Read()
            {
                throw new NotImplementedException();
            }
        }

            */

        public interface IDevice
        {
            void TurnOn();
            void TurnOff();
        }

        IFile file = new FileInfo();
            IBinaryFile binaryfile = new FileInfo();
            FileInfo fileinfo = new FileInfo();

            file.ReadFile();

            binaryfile.ReadFile();
            binaryfile.OpenBinaryFile();

            fileinfo.Search("Строка для поиска");

            Console.ReadKey();

        }

        public interface IFile
        {
            void ReadFile();
        }

        public interface IBinaryFile
        {
            void ReadFile();
            void OpenBinaryFile();
        }

        public class FileInfo : IFile, IBinaryFile
        {
            //public void OpenBinaryFile() - неявная реализация
            void IBinaryFile.OpenBinaryFile()
            {
                Console.WriteLine("Открывается бинарный файл ...");
                //throw new NotImplementedException();
            }

            //public void ReadFile() - неявная реализация
            void IFile.ReadFile() 

            {
                Console.WriteLine("Читаем текстовый файл ...");
                //throw new NotImplementedException();
            }

            void IBinaryFile.ReadFile()

            {
                Console.WriteLine("Читаем бинарный файл ...");
                //throw new NotImplementedException();
            }

            public void Search(string text)
            {
                Console.WriteLine("Начался поиск текста в файле ...");
            }
        }
    }
}
