using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] Sities = { "Moscow,ru", "Orel,ru", "Volgograd,ru","London,uk" };
            Console.WriteLine("Ввыберите город из списка");
            for (int i = 0; i < Sities.Length; i++)
            {
                Console.WriteLine($"{i}.){Sities[i]}");
            }
            try
            {
                int a = int.Parse(Console.ReadLine());
                HttpClient client = new HttpClient() { BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather") };
                var ans = client.GetAsync($"?q={Sities[a]}&APPID=0d3690ee5490e8e63b5d97cd3b63a257");
                var json = ans.Result.Content.ReadAsStringAsync().Result;
                var ansver = JsonConvert.DeserializeObject<Root>(json.ToString());

                Console.WriteLine($"В городе {ansver.name}\r\nTemp:{ansver.main.temp};TempMax:{ansver.main.temp_max};TempMin:{ansver.main.temp_min}");
            }
            catch (Exception)
            {// вывы
                Console.WriteLine("Для выбора города необходимо указать его число!\r\nПовторите попытку еще раз!");
            }
        }
    }
}
