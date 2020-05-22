using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class Competition
    {
        public string FullCompetition
        {
            get
            {
                return $"{Id} — {Name}";
            }
        }
    }
}
