using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class Competitior
    {
        public string FullName
        {
            get
            {
                return $"{User.Name} {User.LastName} {User.Patronymic}";
            }
            set { }
        }
        public string GenderOfCompetitior
        {
            get
            {
                return User.Gender.Name;
            }
        }
        public List<ScheduleOfCompetitor> Modules
        {
            get
            {
                return ScheduleOfCompetitors.ToList();
            }
            set { }
        }

        public string Rank
        {
            get;
            set;
        }
        public string TotalScore
        {
            get { return (ScheduleOfCompetitors.Sum(p => p.Points).ToString("f2")); }
            set { }
        }
    }
}
