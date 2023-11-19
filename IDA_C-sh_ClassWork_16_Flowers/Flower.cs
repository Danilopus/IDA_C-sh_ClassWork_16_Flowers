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
        public Flower()
        {
            ID_number = ID_counter++;
            Name_ = "flower_" + ID_number;
        }
        int ID_number { get; set; }
        static int ID_counter = 1;
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
            FlowerGrowthEvent(this);
        }
        public void FlowerHealth(double max_health_change)
        {
            Health_ += ServiceFunction.Get_Random(max_health_change);
        }
        public void Action_handler_soiling()
        {
            FlowerHealth(5);
        }

        void FlowerGrowthEvent_handler(bool boo)
        {
            Console.WriteLine("new Height " + Height_);
        }

        /// EVENTS ///////////////////////////
        public delegate void Action(Flower f);
        public Action action_delegate { set; get; } = delegate { };
        public event Action<Flower> FlowerGrowthEvent = delegate { };
        public override string ToString()
        {
            return Name_;
        }
        public void Action_delegeta_invoke()
        {
            action_delegate(this);
        }


    }
}
