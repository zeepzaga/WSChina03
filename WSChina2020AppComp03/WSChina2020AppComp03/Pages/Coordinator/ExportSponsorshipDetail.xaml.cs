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

namespace WSChina2020AppComp03.Pages.Competitor
{
    /// <summary>
    /// Interaction logic for ExportSponsorshipDetail.xaml
    /// </summary>
    public partial class ExportSponsorshipDetail : Page
    {
        public ExportSponsorshipDetail(List<Sponsorship> sponsorshipsList)
        {
            InitializeComponent();
        }
    }
}
