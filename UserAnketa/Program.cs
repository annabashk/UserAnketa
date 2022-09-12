using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace UserAnketa
{
    class Program
    {
        static void Main(string[] args)
        {


            InputData();
            OutputData();
            
            // Метод для ввода данных
            static (string Name, string LastName, int Age, string[] NamePet, string[] FavColors) InputData()
            {
                (string Name, string LastName, int Age, string[] NamePet, string[] FavColors) User;

                Console.WriteLine("Введите имя");
                User.Name = Console.ReadLine();

                Console.WriteLine("Введите фамилию");
                User.LastName = Console.ReadLine();

                // Ввод возраста и проверка ввода на корректность
                string age;
                int integer;
                do
                {
                    Console.WriteLine("Введите возраст");
                    age = Console.ReadLine();
                } while (CheckNum(age, out integer));

                User.Age = integer;

                // Ввод кол-ва домашних животных и проверка ввода на коррректность
                Console.WriteLine("Есть ли у Вас домашние животные? Введите Да или Нет");
                var pet = Console.ReadLine();

                if (pet == "Да")
                {
                    string sum;
                    do
                    {
                        Console.WriteLine("Введите количество домашних животных");
                        sum = Console.ReadLine();
                    } while (CheckNum(sum, out integer));

                    int SumPet = integer;

                    // Создание массива с именами животных
                    User.NamePet = new string[SumPet];
                    for (int i = 0; i < SumPet; i++)
                    {
                        Console.WriteLine($"Введите кличку питомца {i + 1}");
                        User.NamePet[i] = Console.ReadLine();
                    }
                }
                else User.NamePet = null; 

                // Ввод кол-ва любимых цветов и проверка ввода на корректность
                string col;
                do
                {
                    Console.WriteLine("Введите количество любимых цветов");
                    col = Console.ReadLine();
                } while (CheckNum(col, out integer));

                int SumColor = integer;

                // Создание массива с любимыми цветами
                User.FavColors = new string[SumColor];
                for (int i = 0; i < SumColor; i++)
                {
                    Console.WriteLine($"Введите любимый цвет {i + 1}");
                    User.FavColors[i] = Console.ReadLine();
                }
                
                return User;
            }

            // Метод для проверки введенных данных 
            static bool CheckNum (string num, out int corrnum)
            {
                if (int.TryParse(num, out int intnum))
                {
                    if (intnum > 0)
                    {
                        corrnum = intnum;
                        return false;
                    }
                }
                { 
                        corrnum = 0;
                        return true;
                }
            }

            // Метод вывода всех данных
            static void OutputData()
            {
               Console.WriteLine($"Ваше имя: {}");
               Console.WriteLine($"Ваша фамилия: {}");
            }
        }
    }
}
