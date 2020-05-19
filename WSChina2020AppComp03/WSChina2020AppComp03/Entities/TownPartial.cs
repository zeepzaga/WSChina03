using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class Town
    {
        public string TownOfCountry { get { return $"{Name}, {Country.Name}"; } set { } }  // Возращает данные в формате "{Название города, Название страны}"
    }
}
