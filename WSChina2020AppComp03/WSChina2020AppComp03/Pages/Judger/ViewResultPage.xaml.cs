using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSChina2020AppComp03.Entities;

namespace WSChina2020AppComp03.Pages.Judger
{
    /// <summary>
    /// Interaction logic for ViewResultPage.xaml
    /// </summary>
    public partial class ViewResultPage : Page
    {
        Entities.Judger judger;
        List<Competitior> competitiorsList = new List<Competitior>();
        public ViewResultPage()
        {
            InitializeComponent();
            judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            TblEvent.Text = judger.EventCompetition.YearCountryTown;
            TblSkill.Text = judger.Competition.FullCompetition;
            CreateDataGridColumns();
        }
        private void CreateDataGridColumns()
        {
            competitiorsList = AppData.Context.Competitiors.ToList().Where
                 (p => p.CompetitionId == judger.CompetitionId && p.EventCompetitionId ==
                 judger.EventCompetitionId).ToList();
            int index = 0;
            int indexColumn = 4;
            foreach (var item in competitiorsList)
            {
                DgResults.Columns.Insert(indexColumn, new DataGridTextColumn
                {
                    Binding = new System.Windows.Data.Binding($"Modules[{index}].Points"),
                    Header = item.ScheduleOfCompetitors.ToList()[index].Schedule.Name,
                });
                index++;
                indexColumn++;
            }
            var ListForRank = competitiorsList;
            int rank = 1;
            Competitior _competitor = null;
            var _item = new Competitior();
            ListForRank.Add(_item);
            foreach (var item in ListForRank)
            {
                if (_competitor != null)
                {
                    if (_competitor.TotalScore == item.TotalScore && _competitor.TotalScore != "--")
                    {
                        _competitor.Rank = rank.ToString();
                        _competitor = item;
                    }
                    else if (_competitor.TotalScore == "--")
                    {
                        _competitor.Rank = "--";
                        _competitor = item;
                    }
                    else
                    {
                        _competitor.Rank = rank.ToString();
                        _competitor = item;
                        rank++;
                    }
                }
                else
                {
                    item.Rank = rank.ToString();
                    _competitor = item;
                }
            }
            ListForRank.Remove(_item);
            DgResults.ItemsSource = competitiorsList;
        }
    }
}
