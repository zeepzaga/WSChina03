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

namespace WSChina2020AppComp03.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryOfWsPage.xaml
    /// </summary>
    public partial class HistoryOfWsPage : Page
    {
        public HistoryOfWsPage()
        {
            InitializeComponent();
        }

        private void ImageAlbert_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as Image).Name)
            {
                case "ImageAlbert":
                    TblDescription.Text = "\"Fill youth with enthusiasm through special action! Convince young people's parents, trainers and company chiefs that a promising future is possible only through good vocational training\".\n" +
                        "- Francisco Albert-Vidal, IVTO President 1984-1992\n\n" +
                        "It was his nephew, Juan Martínez Albert, and his friend, José Rubio, who asked for this nomination two years ago. \n\n" +
                        "Francisco Albert-Vidal was born in Pinoso in 1917 and worked in the city hall of the village of Petrer. Later, he was the " +
                        "Vocational Training General Secretary until 1977 as well as the founder of the International VET Competitions, now WorldSkills.\n\n" +
                        "He died in Madrid, in 1993, and was buried in the village of Pinoso.\n\n" +
                        "On 31 March 2015, the plenary session of the city hall of Pinoso approved, unanimously, his appointment as honorary citizen of the village, " +
                        "as recognition of his work in the field of vocational training for young people through the creation of important events like WorldSkills Competitions.\n\n" +
                        "Words from Pepe Rubio (partner and friend): \"Thanks for this recognition.Francisco Albert Vidal worked for universal values, for people and their education\"\n\n" +
                        "Words from Juan Martínez (nephew): \"I'm very excited, and I remember many family moments with him, especially together with my " +
                        "mother, the only sister of Francisco who is still alive. I want to transmit gratitude from my whole family.\"";
                    break;
                case "ImageFirst":
                    TblDescription.Text = "By the end of the 1960s, international competitions had been held in Germany, Great Britain, Ireland, the Netherlands and Switzerland.";
                    break;
                case "ImageBoard":
                    TblDescription.Text = "Chris Humphries\n " +
                        "Acting President and Chair of the Board(Board member – Strategic Development)\n\n" +
                        "Terry Cooke\n" +
                        "Board member – Treasurer\n\n" +
                        "Michael K K Fung\n" +
                        "Board member – Competitions\n\n" +
                        "Laurence Gates\n" +
                        "Board member – Strategic Development\n\n" +
                        "San-Quei Lin\n" +
                        "Board member – Strategic Development\n\n" +
                        "Ekaterina Loshkareva\n" +
                        "Board member – Strategic Development\n\n" +
                        "Stefan Praschl\n" +
                        "Board member – Competitions";
                    break;
                default:
                    break;
            }
        }
    }
}
