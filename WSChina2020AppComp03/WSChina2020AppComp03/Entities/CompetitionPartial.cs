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
        public string FullCompetition
        {
            get
            {
                return $"{Id} — {Name}";
            }
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
