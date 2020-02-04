using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0_Bar
{
    public static class Globals
    {
        public static Dictionary<string, Manager> managers = new Dictionary<string, Manager>()
        {
            {"storage", new StorageManager() },
            {"brand", new BrandManager() },
            {"type", new TypeManager() },
            {"cassir", new Cassir() }
        };

        public static List<Brand> brands = new List<Brand>()
        {
            new Brand("Джек Дэниелс", 0),
            new Brand("Хенеси", 1),
            new Brand("Кентуки Джек", 2),
            new Brand("Триозерье", 3)
        };

        public static List<Type> types = new List<Type>()
        {
            new Type("Виски", 0),
            new Type("Джин", 1),
            new Type("Пиво", 2),
            new Type("Водка", 3),
            new Type("Коньяк", 4),
            new Type("Текила", 5),
            new Type("Абсент", 6)
        };

        public static List<Alcohol> storage = new List<Alcohol>()
        {
            new Alcohol(0, 0, 0, 40, 20)
        };
    }
}
