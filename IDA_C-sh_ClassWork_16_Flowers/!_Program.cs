// ClassWork template 1.2 // date: 29.09.2023

using IDA_C_sh_ClassWork_16_Flowers;
using Service;
using System;
using System.Linq.Expressions;
using System.Text;



// ClassWork 16 : [C sharp] 16.11.2023 --------------------------------

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
            /*  Задание: Система контроля за ростом цветов

            Тебе предстоит разработать систему, которая будет контролировать рост и состояние различных цветов.Твоя программа должна иметь следующие возможности:

            Создание и управление цветами:

            Разработай класс "Flower" с полями для имени цветка, его высоты и уровня здоровья.
            Реализуй методы для увеличения высоты и изменения уровня здоровья цветка.
            Создай несколько цветов по умолчанию и добавь их в коллекцию.
            
        Интерфейс для отображения информации о цветках:

            Создай интерфейс с методом для отображения информации о цветке.
            Реализуй этот интерфейс в классе "Flower", чтобы можно было получать информацию о каждом цветке.
            Использование делегатов и лямбда-выражений:

            
        Создай делегат "Action" для выполнения операций с цветками, таких как полив или удобрение.
            Реализуй лямбда-выражения, чтобы выполнять эти операции над цветками.
            
        Обработка событий:

            Создай класс "Garden", который будет представлять собой сад с различными цветами.
            Реализуй событие "FlowerGrowthEvent", которое будет возникать при изменении высоты цветка.
            При возникновении события FlowerGrowthEvent, программа должна выводить сообщение о новой высоте цветка.
            
        Использование LINQ:

            Реализуй методы для фильтрации и сортировки цветов с использованием LINQ.
            Например, создай методы для отображения только цветов с высотой больше заданного значения или для сортировки цветов по уровню здоровья.
           
        Сохранение данных в формате JSON/XML:

            Реализуй методы для сохранения и загрузки информации о цветках в форматах JSON и XML.
            Данные о цветках должны сохраняться в файл и загружаться из файла при запуске программы.*/
        public static void Task_1() 
        {
            //int flowers_qua = 7;
            //List <Flower> flowers_list_ = new List <Flower>();
            //for (int i = 0; i < flowers_qua; i++) flowers_list_.Add(new Flower()); 

            // Как просили - считываем данные о цветах из файлов (если они есть)
            string JSON_filename = "flowers_list.json";
            string XML_filename = "flowers_list.xml";
            
            Garden garden_1 = new Garden();

            if (File.Exists(JSON_filename)) { garden_1.LoadFromFileJSON(JSON_filename); }
            else if (File.Exists(XML_filename)) { garden_1.LoadFromFileXML(XML_filename); }
            else garden_1.GenerateFlowerList(15);

            Console.WriteLine("\n\n *** Состав сада:");
            Console.WriteLine(garden_1);
            Console.ReadKey();

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
            foreach (Flower flower in garden_1.flowers_list)
                flower.FlowerGrowthEvent += garden_1.FlowerHeightChangeSubcriber;

            // Теперь еще раз используем список методов, которые есть у нас в делегате Action() у второй полвоины цветов
            Console.WriteLine("// Теперь используем список методов, которые теперь есть у нас в делегате Action() у второй полвоины цветов");
            Console.ReadKey();
            for (int i = garden_1.flowers_list.Count-1; i > garden_1.flowers_list.Count/2; i--)
                garden_1.flowers_list[i].Action_delegeta_invoke();
            //foreach (Flower flower in garden_1.flowers_list)
                //flower.Action_delegeta_invoke();

            // Методы сортировки
            Console.ReadKey();
            Console.WriteLine("\n\nСортируем по здоровью:");
            foreach (Flower f in garden_1.SortflowersListbyHealth())
                Console.WriteLine($"{f} health {f.Health_}");
            Console.WriteLine("\n\nФильтруем по росту выше среднего {0}:", garden_1.flowers_list.Average(s => s.Height_));
            foreach (Flower f in garden_1.FilteredbyHeight(garden_1.flowers_list.Average(s => s.Height_)).OrderByDescending(s => s.Height_))
                Console.WriteLine($"{f} height {f.Height_}");

            //Запишем в файлы всю инфу
            Console.ReadKey();
            Console.WriteLine("\n\nПоробуем записать список цветов в файлы:\n" +
                $"JSON - {JSON_filename}\n" +
                $"XML - {XML_filename}\n");
            Console.WriteLine("\nC удивлением обнаруживаем, что из-за делегата Action (который не имеет конструкторов без параметров)\n" +
                "невозможно сериализовать ни List<Flower>, ни даже просто Flower!\n" +
                "Но! Оказывается можно внести атрибуты [JsonIgnore]/[XMLIgnore] - и все работает!");

            //Console.WriteLine("\nДабы узреть вылетающие исключения ... press any key\n");
            Console.ReadKey();
            try
            {
                // NotSupportedException: Serialization and deserialization of 'IDA_C_sh_ClassWork_16_Flowers.Flower+Action' instances are not supported.
                if(garden_1.SaveToFileJSON(JSON_filename)) Console.WriteLine("\nSaved to JSON Ok");
            }
            catch (Exception ex)
            { Console.WriteLine("\nJSON Serialize error:\n" + ex.Message); }
            try
            {
                // InvalidOperationException: IDA_C_sh_ClassWork_16_Flowers.Flower.Action cannot be serialized because it does not have a parameterless constructor.
                if (garden_1.SaveToFileXML(XML_filename)) Console.WriteLine("\nSaved to XML Ok"); ;
            }
            catch (Exception ex)
            { Console.WriteLine("\nXML Serialize error:\n" + ex.Message); }


        }
        public static void Task_2() { }
        public static void Task_3() { }

    } // class Programm
}// namespace

