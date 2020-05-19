using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class EventCompetition
    {
        /// <summary>
        /// Возращает порядковый номер соревнований в нужном формате
        /// </summary>
        public string Ordinal
        {
            get
            {
                if (Id == 1) return $"{Id}st";
                if (Id == 2) return $"{Id}nd";
                if (Id == 3) return $"{Id}rd";
                
                switch (Convert.ToString(Id).Substring(Convert.ToString(Id).Length - 1))
                {
                    case "1":
                        if (Convert.ToString(Id).Substring(Convert.ToString(Id).Length - 2) == "11")
                        {
                            return $"{Id}th";
                        }
                        else
                        {
                            return $"{Id}st";
                        }
                    case "2":
                        if (Convert.ToString(Id).Substring(Convert.ToString(Id).Length - 2) == "12")
                        {
                            return $"{Id}th";
                        }
                        else
                        {
                            return $"{Id}nd";
                        }
                    case "3":
                        if (Convert.ToString(Id).Substring(Convert.ToString(Id).Length - 2) == "13")
                        {
                            return $"{Id}th";
                        }
                        else
                        {
                            return $"{Id}rd";
                        }
                    default:
                        return $"{Id}th";
                }
            }
            set { }
        }
        /// <summary>
        /// Возращает данные в формате "{Название города, Название страны}"
        /// </summary>
        public string TownPartial
        {
            get
            {
                return $"{Town.Name}, {Town.Country.Name}";
            }
            set { }
        }
    }
}
