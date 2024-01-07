using System;

namespace ConsoleApp561itog
{
    class Program
    {

        static (string Name, string LastName, double Age, bool HasPets, int NumPets, string[] NamePets, int NumFavcolors, string[] Favcolors) User;

        static void Main(string[] args)
        {

            
            // имя
            Console.WriteLine("Введите ваше имя");
            User.Name = Console.ReadLine();
            // фамилия
            Console.WriteLine("Введите вашу фамилию");
            User.LastName = Console.ReadLine();
            // возраст
            User.Age = GetNum("Введите ваш возраст");
            // наличие питомца
            User.HasPets = IsYes("Есть ли у вас животные? Да или Нет");
            // клички
            if (User.HasPets)
            {
                User.NumPets = GetNum("Введите количество питомцев");
                User.NamePets = GetArrayFromConsole(User.NumPets);
            }
            
            // кол-во любимых цветов
            User.NumFavcolors = GetNum("Введите количество любимых цветов");
            User.Favcolors = GetArrayFromConsoleFavcolors(User.NumFavcolors);            
            
            // view User
            Console.WriteLine("Ваши введенные данные");
            ViewDataUser();

        }

        static void ViewDataUser()
        {
            string ss = "";

            Console.WriteLine("Имя - {0}", User.Name);
            Console.WriteLine("Фамилия - {0}", User.LastName);
            Console.WriteLine("Возраст - {0}", User.Age);
            string s = User.HasPets ? "Да" : "Нет";
            Console.WriteLine("Наличие питомцев - {0}", s);
            if (User.HasPets)
            {
                Console.WriteLine("Количество питомцев - {0}", User.NumPets);
                ss = "";
                foreach (string NamePet in User.NamePets)
                    ss = ss + " " + NamePet;
                Console.WriteLine("Клички питомцев - {0}", ss);
            }
            Console.WriteLine("Количество любимых цветов - {0}", User.NumFavcolors);
            ss = "";
            foreach (string color in User.Favcolors)
                ss = ss + " " + color;
            Console.WriteLine("Любимые цыета - {0}", ss);

        }

 
        static string[] GetArrayFromConsoleFavcolors(int num)
        {
            string[] result = new string[ num ];

            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            string scolor = "Введите " + num.ToString() + " любимых цвета";
            string ss = "";
            foreach (var color in colors)
                ss = ss + " " + color.ToString();

            bool IsColor;
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите цыет номер {0} из набора - {1}", i + 1, ss);
                result[ i ] = Console.ReadLine();
                IsColor = ValidColor(result[ i ], ref colors );
                if (!IsColor)
                {
                    Console.WriteLine("Ввод не корректен, введите данные снова ...");
                    i--;
                    continue;
                }                    
            }
            return result;
        }

        static bool ValidColor(string Color, ref ConsoleColor[] Colors)
        {
            bool ret = false;

            foreach (var color in Colors)
            {
                if (Color == color.ToString())
                {
                    ret = true;
                    break;
                }
            }                
            return ret;
        }

        static string[] GetArrayFromConsole(int num)
        {
            var result = new string[num];
            Console.WriteLine("Введите клички своих питомцев");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент номер {0}", i + 1);
                result[ i ] = Console.ReadLine();
            }
            return result;
        }

        static bool IsYes(string answer)
        {
            bool ret;
            string yesno;
            while (true)
            {
                Console.WriteLine(answer);
                yesno = Console.ReadLine();
                if (yesno == "Да")
                {
                    ret = true;
                    break;
                }
                else if (yesno == "Нет")
                {
                    ret = false;
                    break;
                }
                else
                    Console.WriteLine("Ввод не корректен, введите данные снова ...");
            }
            return ret;
        }

        static int GetNum(string answer)
        {
            Console.WriteLine(answer);
            string input = Console.ReadLine();
            int inputValue;
            bool success = int.TryParse(input, out inputValue);
            while (!success)
            {
                Console.WriteLine("Ввод не корректен, введите данные снова ...");
                Console.WriteLine(answer);
                input = Console.ReadLine();
                success = int.TryParse(input, out inputValue);
                if (inputValue == 0)
                    success = false;
            }            
            return inputValue;
        }



    }
}
