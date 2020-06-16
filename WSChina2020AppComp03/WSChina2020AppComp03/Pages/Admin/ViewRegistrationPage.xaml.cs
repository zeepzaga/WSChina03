using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSChina2020AppComp03.Entities;

namespace WSChina2020AppComp03.Pages.Admin
{
    /// <summary>
    /// Interaction logic for ViewRegistrationPage.xaml
    /// </summary>
    public partial class ViewRegistrationPage : Page
    {
        public ViewRegistrationPage(EventCompetition @event)
        {
            InitializeComponent();
            //Лист для хранения всех участников
            List<Competitior> competitiorsList = AppData.Context.Competitiors.ToList();
            //Лист для хранения всех членов жюри 
            List<Entities.Judger> judgerList = AppData.Context.Judgers.ToList();
            //Лист для хранения данных для DgBySkill
            List<BySkills> bySkillsList = new List<BySkills>();
            //Лист для хранения данных для DgByProvince
            List<ByProvince> byProvincesList = new List<ByProvince>();
            bool isNull = true; // переменная хранящая есть ли жюри или участники в списке
            string @string = ""; // Переменная для хранения списка стран или компетенций для участников
            int countCompetitior = 0; // Переменная для хранения кол-ва участников
            string @string1 = ""; // Переменная для хранения списка стран или компетенций для жюри
            int countJudger = 0; // Переменная для хранения кол-ва жюри
            foreach (var competition in AppData.Context.Competitions) // цикл заполняющая bySkillsList
            {
                @string = "";
                countCompetitior = 0;
                @string1 = "";
                countJudger = 0;
                isNull = true;
                int i = 0; //переменная позволяющая не ставить запятую после последнего слова в списке
                foreach (var competitor in competitiorsList.Where(p => p.EventCompetition == @event && p.Competition == competition).GroupBy(p=>p.User.Town.Name))
                {
                    if (i != 0)
                    {
                        @string += ", ";
                    }
                    @string += $"{competitor.Key}";
                    countCompetitior++;
                    isNull = false;
                    i++;
                }
                i = 0;
                foreach (var judger in judgerList.Where(p => p.EventCompetition == @event && p.Competition == competition).GroupBy(p=>p.Town.Name))
                {
                    if (i != 0)
                    {
                        @string1 += ", ";
                    }
                    @string1 += $"{judger.Key}";
                    countJudger++;
                    isNull = false;
                    i++;
                }
                if (!isNull)
                {
                    bySkillsList.Add(new BySkills
                    {
                        Skill = competition.FullCompetition,
                        CompetitiorProvinces = @string,
                        JudgerProvinces = @string1,
                        NumberOfCompetitiors = countCompetitior,
                        NumberOfJudgers = countJudger
                    });
                }
            }
            bySkillsList.Add(new BySkills
            {
                Skill = "Sub Total",
                CompetitiorProvinces = null,
                JudgerProvinces = null,
                NumberOfCompetitiors = bySkillsList.Sum(p => p.NumberOfCompetitiors),
                NumberOfJudgers = bySkillsList.Sum(p => p.NumberOfJudgers)
            });
            DgBySkills.ItemsSource = bySkillsList;
            foreach (var province in AppData.Context.Towns) // цикл для заполнения byProvincesList
            {
                @string = "";
                countCompetitior = 0;
                @string1 = "";
                countJudger = 0;
                isNull = true;
                int i = 0;
                foreach (var competitor in competitiorsList.Where(p => p.EventCompetition == @event && p.User.Town == province).GroupBy(p=>p.Competition.FullCompetition))
                {
                    if (i != 0)
                    {
                        @string += ", ";
                    }
                    @string += $"{competitor.Key}";
                    countCompetitior++;
                    isNull = false;
                    i++;
                }
                i = 0;
                foreach (var judger in judgerList.Where(p => p.EventCompetition == @event && p.Town == province).GroupBy(p => p.Competition.FullCompetition))
                {
                    if (i != 0)
                    {
                        @string1 += ", ";
                    }
                    @string1 += $"{judger.Key}";
                    countJudger++;
                    isNull = false;
                    i++;
                }
                if (!isNull)
                {
                    byProvincesList.Add(new ByProvince
                    {
                        Province = province.Name,
                        CompetitiorSkills = @string,
                        JudgerSkills = @string1,
                        NumberOfCompetitiors = countCompetitior,
                        NumberOfJudgers = countJudger
                    });
                }
            }
            byProvincesList.Add(new ByProvince
            {
                Province = "Sub Total",
                CompetitiorSkills = null,
                JudgerSkills = null,
                NumberOfCompetitiors = byProvincesList.Sum(p => p.NumberOfCompetitiors),
                NumberOfJudgers = byProvincesList.Sum(p => p.NumberOfJudgers)
            });
            DgByProvince.ItemsSource = byProvincesList;
        }
        private class BySkills // Клас для листа bySkillsList
        {
            public string Skill { get; set; }
            public string CompetitiorProvinces { get; set; }
            public int NumberOfCompetitiors { get; set; }
            public string JudgerProvinces { get; set; }
            public int NumberOfJudgers { get; set; }
        }
        private class ByProvince //Клас для листа byProvincesList
        {
            public string Province { get; set; }
            public string CompetitiorSkills { get; set; }
            public int NumberOfCompetitiors { get; set; }
            public string JudgerSkills { get; set; }
            public int NumberOfJudgers { get; set; }
        }
    }
}
