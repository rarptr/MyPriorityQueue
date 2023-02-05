using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    internal class User : IPriority<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string City { get; set; }

        public User(int id, string name, int age, int height, string city)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = height;
            City = city;
        }

        public int GetPriority()
        {
            return Age;
        }

        public static User GetRndUser(Kit kit)
        {
            //var kit = new Kit();
            return new User(kit.LastId, kit.GetRndName(), kit.GetRndAge(), kit.GetRndHeight(), kit.GetRndCity());
        }

        public override string ToString()
        {
            return $"User = {Id}\t{Name}\t{Age}\t{Height}\t{City}";
        }
    }
}
