using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace WSChina2020AppComp03.Controls
{
    /// <summary>
    /// Interaction logic for RegistrationSuccessfulyControl.xaml
    /// </summary>
    public partial class RegistrationSuccessfulyControl : UserControl
    {
        public RegistrationSuccessfulyControl()
        {
            InitializeComponent();
        }

        private void TblDownloadPhoto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Save as",
                Filter = "jpg Files (*.jpg,)|*.jpg;",
                OverwritePrompt = true,
                CheckPathExists = true
            };

        }
    }
}
