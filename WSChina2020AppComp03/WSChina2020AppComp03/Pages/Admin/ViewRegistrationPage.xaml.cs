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
            List<Competitior> competitiorsList = AppData.Context.Competitiors.ToList();
            List<Entities.Judger> judgerList = AppData.Context.Judgers.ToList();
            List<BySkills> bySkillsList = new List<BySkills>();
            bool isNull = true;
            string countryCompetitiorList = "";
            int countCompetitior = 0;
            string countryJudgerList = "";
            int countJudger = 0;
            foreach (var competition in AppData.Context.Competitions)
            {
                countryCompetitiorList = "";
                countCompetitior = 0;
                countryJudgerList = "";
                countJudger = 0;
                isNull = true;
                foreach (var competitor in competitiorsList.Where(p => p.EventCompetition == @event && p.Competition == competition).ToList())
                {
                    countryCompetitiorList += $"{competitor.Country.Name},";
                    countCompetitior++;
                    isNull = false;
                }
                foreach (var judger in judgerList.Where(p => p.EventCompetition == @event && p.Competition == competition).ToList())
                {
                    countryJudgerList += $"{judger.Country.Name},";
                    countJudger++;
                    isNull = false;
                }
                if (!isNull)
                {
                    bySkillsList.Add(new BySkills
                    {
                        Skill = competition.FullCompetition,
                        CompetitiorProvinces = countryCompetitiorList,
                        JudgerProvinces = countryJudgerList,
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
        }
        public class BySkills
        {
            public string Skill { get; set; }
            public string CompetitiorProvinces { get; set; }
            public int NumberOfCompetitiors { get; set; }
            public string JudgerProvinces { get; set; }
            public int NumberOfJudgers { get; set; }
        }
    }
}
