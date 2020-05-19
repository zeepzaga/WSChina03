using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class User
    {
        /// <summary>
        /// Возращает то как нужно приветствовать юзера.
        /// </summary>
        public string HelloPerson
        {
            get
            {
                int hour = DateTime.Now.Hour;
                string timeDay = "";
                string GenderUser = "";
                if (hour >= 0 && hour < 5) timeDay = "Night";
                else if (hour >= 5 && hour < 12) timeDay = "Morning";
                else if (hour >= 12 && hour < 17) timeDay = "Afternoon";
                else if (hour >= 18) timeDay = "Afternoon";
                switch (GenderId)
                {
                    case 1:
                        GenderUser = "Mr.";
                        break;
                    case 2:
                        GenderUser = "Mrs.";
                        break;
                    default:
                        break;
                }
                return $"Good {timeDay}!\n {GenderUser} {Name}";
            }
            set { }
        }
    }
}
