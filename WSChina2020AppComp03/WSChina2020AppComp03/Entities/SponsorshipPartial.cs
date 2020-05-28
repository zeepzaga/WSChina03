using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class Sponsorship
    {

        public string AllCategoryList // Список категорий для спонсоров на все компетенции
        {
            get
            {
                List<string> resultList = new List<string>();
                string result = "";
                int count = 0;
                foreach (var category in Sponsor.Sponsorships)
                {
                    if (resultList.Contains(category.CategoryOfSponsorship.Name))
                    {
                        break;
                    }
                    resultList.Add(category.CategoryOfSponsorship.Name);
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
        public string AllSponsorList // Список спонсоров для категорий на все компетенции
        {
            get
            {
                List<string> resultList = new List<string>();
                string result = "";
                int count = 0;
                foreach (var sponsor in CategoryOfSponsorship.Sponsorships)
                {
                    if (resultList.Contains(sponsor.Sponsor.Name))
                    {
                        break;
                    }
                    resultList.Add(sponsor.Sponsor.Name);
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
        public string SponsorList //список спонсоров для определённой компетенции
        {
            get
            {
                List<string> resultList = new List<string>();
                string result = "";
                int count = 0;
                foreach (var sponsor in CategoryOfSponsorship.Sponsorships.Where(p => p.EventCompetition == EventCompetition))
                {
                    if (resultList.Contains(sponsor.Sponsor.Name))
                    {
                        break;
                    }
                    resultList.Add(sponsor.Sponsor.Name);
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
        public string CategoryList //Список категорий для спонсора 
        {
            get
            {
                List<string> resultList = new List<string>();
                string result = "";
                int count = 0;
                foreach (var category in Sponsor.Sponsorships.Where(p => p.EventCompetition == EventCompetition))
                {
                    if (resultList.Contains(category.CategoryOfSponsorship.Name))
                    {
                        break;
                    }
                    resultList.Add(category.CategoryOfSponsorship.Name);
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
        public decimal FullPriceSponsor //Цена для спонсоров
        {
            get
            {
                decimal result = 0;
                foreach (var category in Sponsor.Sponsorships.Where(p => p.EventId == EventId))
                {
                    result += category.Count * category.UnitPrice;
                }
                return result;
            }
        }
        public decimal AllFullPriceSponsor // цена для спонсоров во всех компеетцниях
        {
            get
            {
                decimal result = 0;
                foreach (var category in Sponsor.Sponsorships)
                {
                    result += category.Count * category.UnitPrice;
                }
                return result;
            }
        }
        public decimal FullPriceCategory // цена для категорий
        {
            get
            {
                decimal result = 0;
                foreach (var category in CategoryOfSponsorship.Sponsorships.Where(p => p.EventId == EventId))
                {
                    result += category.Count * category.UnitPrice;
                }
                return result;
            }
        }
        public decimal AllFullPriceCategory// цена для категорий во всех компетециях
        {
            get
            {
                decimal result = 0;
                foreach (var category in CategoryOfSponsorship.Sponsorships)
                {
                    result += category.Count * category.UnitPrice;
                }
                return result;
            }
        }
    }
}
