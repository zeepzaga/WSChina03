using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class TeamCompetition
    {
       public string Names
        {
            get
            {
                List<string> resultList = new List<string>();
                string result = "";
                int count = 0;
                foreach (var item in AppData.Context.TeamCompetitions.ToList().Where(p=>p.TeamId == TeamId))
                {
                    if (resultList.Contains(item.Competitior.FullName))
                    {
                        break;
                    }
                    resultList.Add(item.Competitior.FullName);
                }
                foreach (var text in resultList)
                {
                    if (count != 0)
                    {
                        result += "; ";
                    }
                    result += $"{text}";
                    count++;
                }
                return result;
            }
        }
       public string Province
        {
            get
            {
                List<string> resultList = new List<string>();
                string result = "";
                int count = 0;
                foreach (var item in AppData.Context.TeamCompetitions.ToList().Where(p => p.TeamId == TeamId))
                {
                    if (resultList.Contains(item.Competitior.User.Town.Name))
                    {
                        break;
                    }
                    resultList.Add(item.Competitior.User.Town.Name);
                }
                foreach (var text in resultList)
                {
                    if (count != 0)
                    {
                        result += "; ";
                    }
                    result += $"{text}";
                    count++;
                }
                return result;
            }
        }
    }
}
