using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class Competition
    {
        public int CountVolunteer
        {
            get
            {
                int count = 0;
                foreach (var item in Volunteers)
                {
                    count++;
                }
                return count;
            }
        }
        public string IsTeam
        {
            get
            {
                if (IsIndividual == false)
                {
                    return "YES";
                }
                else
                {
                    return "NO";
                }
            }
        }
        public string FullCompetition
        {
            get
            {
                if(Id.ToString().Length<2)
                {
                return $"0{Id} — {Name}";
                }
                else
                {
                    return $"{Id} — {Name}";
                }
            }
            set { }
        }
        //public int CompetitiorCount
        //{
        //    get
        //    {
        //        return Competitiors.Count;
        //    }
        //}
        //public int JudgersCount
        //{
        //    get
        //    {
        //        return Judgers.Count;
        //    }
        //}
    }
}
