using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_ClassWork_16_Flowers
{
    internal class Garden
    {
        List<Flower> flowers_list = new List<Flower>();

        public void AddFlower(Flower flower)
        {
            flowers_list.Add(flower);
        }

        public List<Flower> SortflowersListbyHealth()
        {
            var temp_view = from i in flowers_list
                            orderby i.Health_
                            select i;
            return temp_view.ToList();
        }
        public List<Flower> FilteredbyHeight(double height)
        {
            var temp_view = from i in flowers_list
                            where i.Height_> height
                            select i;
            return temp_view.ToList();
        }
        public void SaveToFile(string fileName)
        {

        }
        public void LoadFromFile(string fileName)
        {
            string read_result;
            FileStream str_1 = new(fileName, FileMode.Open);
            {
                StreamReader streamReader_1 = new StreamReader(str_1);
                read_result = streamReader_1.ReadToEnd();
                read_result ??= string.Empty;
            }
            str_1.Close();
        }
    }
}
