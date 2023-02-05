using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Kit
    {
        public int LastId { get { return ++_lastId; } private set { _lastId = value; } }
        public List<string> Names { get; private set; } = new List<string> { "Михаил", "Павел", "Влад", "Артём", "Дарья", "София", "Арина", "Ксения" };
        public List<int> Ages { get; private set; }
        public List<int> Heights { get; private set; }
        public List<string> Cities { get; private set; } = new List<string> { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Казань", "Нижний Новгород", "Челябинск", "Красноярск", "Самара", "Уфа", "Ростов-на-Дону", "Омск" };

        private static Random _rnd;
        private int _lastId;

        public Kit(int lastId = 0)
        {
            _rnd = new Random(10);
            _lastId = lastId;
        }

        public string GetRndName() => Names[_rnd.Next(Names.Count)];
        public int GetRndAge() => _rnd.Next(20, 30);
        public int GetRndHeight() => _rnd.Next(160, 200);
        public string GetRndCity() => Cities[_rnd.Next(Cities.Count)];
    }
}
