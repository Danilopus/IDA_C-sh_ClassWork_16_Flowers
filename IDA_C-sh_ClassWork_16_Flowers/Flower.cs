using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_ClassWork_16_Flowers
{
    internal class Flower : IFlowerInfo
    {
        public string Name_ { get; set; } = "default flower";
        public double Height_ { get; set; } = 10;
        public double Health_ { get; set; } = 100;
        public void FlowerInfo()
        {
            Console.WriteLine("Name " + Name_);
            Console.WriteLine("Height " + Height_);
            Console.WriteLine("Health " + Health_);
        }

        public void FlowerGrow(double max_grow_change)
        {
            Height_ += ServiceFunction.Get_Random(max_grow_change);
            FlowerGrowthEvent(true);
        }
        public void FlowerHealth(double max_health_change)
        {
            Health_ += ServiceFunction.Get_Random(max_health_change);
        }

        public delegate void Action();
        public void Action_handler_watering()
        {
            FlowerGrow(5);
        }
        public void Action_handler_soiling()
        {
            FlowerHealth(5);
        }

        public event Action<bool> FlowerGrowthEvent;

        void FlowerGrowthEvent_handler(bool boo)
        {
            Console.WriteLine("new Height " + Height_);
        }
        public Flower()
        {
            FlowerGrowthEvent += FlowerGrowthEvent_handler;
        }
    }
}
