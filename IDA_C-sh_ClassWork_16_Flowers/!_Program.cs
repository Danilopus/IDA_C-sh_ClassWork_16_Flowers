// ClassWork template 1.2 // date: 29.09.2023

using IDA_C_sh_ClassWork_16_Flowers;
using Service;
using System;
using System.Linq.Expressions;
using System.Text;



// ClassWork XX : [C sharp] 16.11.2023 --------------------------------

namespace IDA_C_sh_ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

             Task_1();
            // Task_2();
            // Task_3();


             Console.ReadKey();

        }

        public static void Task_1() 
        {
            //int flowers_qua = 7;
            //List <Flower> flowers_list_ = new List <Flower>();
            //for (int i = 0; i < flowers_qua; i++) flowers_list_.Add(new Flower()); 

            
            Garden garden_1 = new Garden(15);
            Console.WriteLine("\n\n *** Состав сада:");
            Console.WriteLine(garden_1);
            //Console.ReadKey();


            // Подпишем каждый цветок в саду на метод Watering() через делегат Action() в классе Flower
            Console.WriteLine("\n\n// Подпишем каждый цветок в саду на метод Watering() через делегат Action() в классе Flower");
            foreach (Flower flower in garden_1.flowers_list)
                flower.action_delegate += garden_1.Watering;

            // А теперь используем метод полива через делегат у только у половины цветов
            Console.WriteLine("// А теперь используем метод полива через делегат у только у половины цветов");
            Console.ReadKey();
            for (int i = 0; i < garden_1.flowers_list.Count / 2; i++)
            {
                // вот эта возможность вызвать делегат извне класса,
                // где он содержится и привела к созданию event,
                // которые уже не вызовешь откуда попало
                garden_1.flowers_list[i].action_delegate(garden_1.flowers_list[i]);  
                //garden_1.flowers_list[i].Action_delegeta_invoke();
            }

            // А теперь подпишем каждый цветок в саду еще и на метод Soiling() через тот же делегат  Action() в классе Flower
            Console.WriteLine("\n\n// А теперь подпишем каждый цветок в саду еще и на метод Soiling() через тот же делегат  Action() в классе Flower");
            foreach (Flower flower in garden_1.flowers_list)
                flower.action_delegate += garden_1.Soiling;

            // Теперь используем список методов, которые теперь есть у нас в делегате Action() у первых 5 цветов
            Console.WriteLine("// Теперь используем список методов, которые теперь есть у нас в делегате Action() у первых 5 цветов");
            Console.ReadKey();
            for (int i = 0; i < 5; i++)
                garden_1.flowers_list[i].Action_delegeta_invoke();


            // Используем событие FlowerGrowthEvent() чтобы получать информацию о росте цветка 
            Console.WriteLine("\n\n// Используем событие FlowerGrowthEvent() чтобы получать информацию о росте цветка");
            Console.ReadKey();
            foreach (Flower flower in garden_1.flowers_list)
                flower.FlowerGrowthEvent += garden_1.FlowerHeightChangeSubcriber;


            // Теперь еще раз используем список методов, которые есть у нас в делегате Action() у всех цветов
            Console.WriteLine("// Теперь используем список методов, которые теперь есть у нас в делегате Action() у всех цветов");
            Console.ReadKey();
            //for (int i = 0; i < 3; i++)
            foreach (Flower flower in garden_1.flowers_list)
                flower.Action_delegeta_invoke();







            // Методы сортировки
            Console.ReadKey();
            Console.WriteLine("\n\nСортируем по здоровью:");
            foreach (Flower f in garden_1.SortflowersListbyHealth())
                Console.WriteLine($"{f} health {f.Health_}");
            Console.WriteLine("\n\nФильтруем по росту выше среднего:");
            foreach (Flower f in garden_1.FilteredbyHeight(garden_1.flowers_list.Average(s => s.Height_)))
                Console.WriteLine($"{f} health {f.Height_}");



        }
        public static void Task_2() { }
        public static void Task_3() { }

    } // class Programm
}// namespace

