using laba_10;

namespace Laba_12
{
    class Program  
    {

        ///// <summary>
        ///// Главное меню
        ///// </summary>
        static void PrintMenu()
        {
            Console.WriteLine("\n1 - формирование двуноправленного списка");
            Console.WriteLine("2 - Формирование хеш-таблицы");
            Console.WriteLine("3 - работа с MyCollection");
            Console.WriteLine("4 - выход из программы\n");
        }


        /// <summary>
        /// Проверка на введенные целочисленные числа
        /// </summary>
        /// <param name="sms1">Сообщение, которое приглашает ввест и символ</param>
        /// <param name="smsError1">Сообщение, которое выводит ошибку, если число меньше 0</param>
        /// <param name="smsError2">Сообщение, когда введен неверный формат числа</param>
        /// <returns></returns>
        static int CheckNumbersMenu(string sms1, string smsError1, string smsError2)
        {
            bool isValid;
            int result = 0;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(sms1);
                    result = Convert.ToInt32(Console.ReadLine());

                    if (result < 0 || result > 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(smsError1);
                        isValid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        isValid = true;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(smsError2);
                    isValid = false;
                }
            } while (!isValid);

            return result;
        }

        static void Main()
        {
            do
            {
                PrintMenu();

                var size = CheckNumbersMenu("\nВыбирите дейтвие:",
                    "\nОшибка... Число должно быть корректны",
                    "\nОшибка... Число должно быть корректным");

                switch (size)
                {
                    case 1:
                    {
                        WorkListMenu();
                        break;
                    }

                    case 2:
                    {
                        WorkHTableMenu();
                        break;
                    }

                    case 3:
                    {
                       WorkWithMyCollectionMenu();
                        return;
                    }

                    case 4:
                    {
                        Console.WriteLine("\nДо свидания!");
                        return;
                    }

                    default:
                    {
                        Console.WriteLine("Введите корректное число...\n");
                        break;
                    }
                }
            } while (true);


            void WorkListMenu()
            {
                // Создаем экземпляр MyCollection<Transport>
                List<Transport> myCollection = new List<Transport>();

                // Добавляем элементы в коллекцию
                myCollection.AddLast(new Car("Car", 1998, 220, 5, "Toyota", "Hatchback"));
                myCollection.AddLast(new Aircraft("Aircraft", 1999, 600, 50, "Passenger", 700));
                myCollection.AddLast(new Train("Train", 2020, 700, 99, "passenger train", "passenger train"));
                myCollection.PrintList(); 

                // Удаление элемента
                var size = CheckNumbersMenu("Введите номер удаляемого элемента: ",
                    "\nОшибка... Число должно быть корректным",
                    "\nОшибка... Число должно быть корректным");
                myCollection.RemoveAt(size);
                myCollection.PrintList();

                // Добавление элемента
                Console.WriteLine("Добавить элементы после 1 номера:");
                myCollection.AddEllementList( 1, new Car("Car", 2000, 250, 3, "BMW", "Coupe"));
                Console.WriteLine("Элемент добавили");
                myCollection.PrintList();

                // Очистка списка
                Console.WriteLine("Очистка списка...");
                myCollection.Clear();
                myCollection.PrintList();
            }

            void WorkHTableMenu()
            {
                string[] arr = new string[22];
                arr[0] = "abc";
                arr[1] = "def";
                arr[2] = "ghi";
                arr[3] = "jkl";
                arr[4] = "mno";
                arr[5] = "pqr";
                arr[6] = "stu";
                arr[7] = "vwx";
                arr[8] = "yz";
                arr[9] = "123";
                arr[10] = "456";
                arr[11] = "789";
                arr[12] = "!@#";
                arr[13] = "$%^";
                arr[14] = "&*(";
                arr[15] = ")(*";
                arr[16] = "abcde";
                arr[17] = "fghij";
                arr[18] = "klmno";
                arr[19] = "pqrst";
                arr[20] = "uvwxy";
                arr[21] = "z1234";

                HTable ht = new HTable();
                foreach (var s in arr)
                {
                    ht.Add(s);
                }
                ht.Print();
                string findStr;

                do
                {
                    Console.Write("\nВведите строку для поиска: ");
                    findStr = Console.ReadLine();
                    if (findStr == "end")
                    {
                        continue;
                    }
                    if (ht.FindPoint(findStr))
                    {
                        Console.WriteLine("Строка найдена");
                        ht.DelPoint(findStr);
                        Console.WriteLine("Строка удалена. Попробуйте ее раз её удалить...");
                    }
                    else
                    {
                        Console.WriteLine("Строка не найдена");
                    }
                } while (findStr != "end");

                var newElement = "C1";
                if (!ht.IsFull()) 
                {
                    ht.Add(newElement);
                    Console.WriteLine($"Элемент '{newElement}' добавлен.");
                }
                else
                {
                    Console.WriteLine("Хеш-таблица заполнена. Невозможно добавить новый элемент.");
                }
                ht.Print();
            }


            void WorkWithMyCollectionMenu()
            {
                MyCollection<Transport> myCollection = new MyCollection<Transport>();

                // Добавление элементов в коллекцию
                myCollection.Add(new Car("Car", 2001, 180, 4, "Honda", "Sedan"));
                myCollection.Add(new Aircraft("Aircraft", 2020, 500, 50, "Jet", 333));
                myCollection.Add(new Train("Train", 2015, 500,88, "Express", "Passenger"));

                Console.WriteLine("Коллекция после добавления элементов:");
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item);
                }

                // Удаление элемента по индексу
                Console.WriteLine("\nУдаление элемента по индексу 1...");
                myCollection.RemoveAt(1);
                Console.WriteLine("Коллекция после удаления:");
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item);
                }

                // Поверхностное копирование
                Console.WriteLine("\nПоверхностное копирование коллекции...");
                var shallowCopyCollection = myCollection.ShallowCopy();
                Console.WriteLine("Коллекция после поверхностного копирования:");
                foreach (var item in shallowCopyCollection)
                {
                    Console.WriteLine(item);
                }

                // Очистка коллекции
                Console.WriteLine("\nОчистка коллекции...");
                myCollection.Clear();
                Console.WriteLine("Коллекция после очистки:");
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
 