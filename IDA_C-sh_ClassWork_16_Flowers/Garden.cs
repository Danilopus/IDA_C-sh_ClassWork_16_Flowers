using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IDA_C_sh_ClassWork_16_Flowers
{
    internal class Garden
    {
        public Garden(int qua)
        { for (int i = 0; i < qua; i++)
            flowers_list.Add(new Flower());
        }
        public List<Flower> flowers_list = new List<Flower>();

        public void AddFlower(Flower flower)
        {
            flowers_list.Add(flower);
        }

        public List<Flower> SortflowersListbyHealth()
        {
            var temp_view = from i in flowers_list
                            orderby i.Health_ descending
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
        public void SaveToFileJSON(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.WriteLine(JsonSerializer.Serialize(flowers_list));
                //writer.WriteLine(JsonSerializer.Serialize(flowers_list[0]));
            }
        }
        public void LoadFromFileJSON(string fileName)
        {
            string read_result;
            using (StreamReader streamReader_1 = new StreamReader(fileName))
            {
                read_result = streamReader_1.ReadToEnd();
                read_result ??= string.Empty;
            }
            flowers_list = JsonSerializer.Deserialize<List<Flower>>(read_result);
        }
        public void SaveToFileXML(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List <Flower>));

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                xmlSerializer.Serialize(writer, flowers_list);
                //xmlSerializer.Serialize(writer, flowers_list[0]);
            }

        }
        public void LoadFromFileXML(string fileName)
        {
            string read_result;
            using (StreamReader streamReader_1 = new StreamReader(fileName))
            {
                read_result = streamReader_1.ReadToEnd();
                read_result ??= string.Empty;
            }
            flowers_list = JsonSerializer.Deserialize<List<Flower>>(read_result);
        }

        public void Watering(Flower f)
        {
            Console.WriteLine($"Message from Garden: Watering {f} in progress");
            f.FlowerGrow(5);
        }
        public void Soiling(Flower f)
        {
            Console.WriteLine($"Message from Garden: Soiling {f} in progress");
            f.FlowerHealth(5);
        }
        public void FlowerHeightChangeSubcriber(Flower f)
        {
            Console.WriteLine($"Message from Garden: {f} in growing!!! Height: {f.Height_}");
        }


        public override string ToString()
        {
            string result = string.Empty;
            foreach (Flower f in flowers_list)
                result += f.ToString() + "\n";
            return result;
        }
    }
}
