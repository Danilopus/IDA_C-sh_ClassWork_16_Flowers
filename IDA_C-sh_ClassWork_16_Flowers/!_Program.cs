// ClassWork template 1.2 // date: 29.09.2023

using IDA_C_sh_ClassWork_16_Flowers;
using Service;
using System;
using System.Linq.Expressions;
using System.Text;



// ClassWork XX : [C sharp] DD.MM.YYYY --------------------------------

namespace IDA_C_sh_ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

             Task_1();
            // Task_2();
            // Task_3();


            // Console.ReadKey();

        }

        public static void Task_1() 
        {
            int flowers_qua = 7;
            List <Flower> flowers_list = new List <Flower>();
            for (int i = 0; i < flowers_qua; i++)
            { flowers_list.Add(new Flower()); }

            Garden garden_1 = new Garden();
            
            for (int i = 0; i < flowers_qua; i++) 
            { garden_1.AddFlower(new Flower()); }

        }
        public static void Task_2() { }
        public static void Task_3() { }

    } // class Programm
}// namespace

