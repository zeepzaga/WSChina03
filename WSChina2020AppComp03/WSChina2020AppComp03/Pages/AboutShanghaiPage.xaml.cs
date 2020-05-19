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

namespace WSChina2020AppComp03.Pages
{
    /// <summary>
    /// Логика взаимодействия для AboutShanghaiPage.xaml
    /// </summary>
    public partial class AboutShanghaiPage : Page
    {
        public AboutShanghaiPage()
        {
            InitializeComponent();
            TblockHistory.Text = $"Early Shanghai\n\n " +
                $"Shanghai is one of China's great cities. By the 11th century AD Shanghai was a small market town. It " +
                $"grew steadily larger and in 1533 a wall was built around the town. Later in the 16th century Yuyuan Garden " +
                $"was created. By 1700 Shanghai had a population of about 50,000 making it a large and prosperous port.\n" +
                $"Then in 1842 by the Treaty of Nanking the British forced China to open 5 ports, including Shanghai to trade. " +
                $"In 1843 the first British consul moved into Shanghai.\n" +
                $"In the 19th century foreigners in Shanghai were lived in three settlements. From 1845 there " +
                $"was a British settlement, after 1848 an American settlement and after 1849 a French settlement." +
                $"In 1863 British and American settlement later joined and formed the International Settlement but the " +
                $"French concession remained separate.\n" +
                $"At first tea, silks and porcelain were exported from Shanghai while opium was imported. " +
                $"Later Shanghai became a major financial center and banking was an important sector.There was also a " +
                $"large textile industry in Shanghai.\n" +
                $"Meanwhile in 1866 the city gained gas light.Electricity was first generated in " +
                $"Shanghai in 1882.In 1908 the first cinema was built in Shanghai and electric trams began " +
                $"running in the streets. By 1900 Shanghai had grown enormously to be a city of 1 million.Then in 1912 the old city " +
                $"walls were demolished. Meanwhile western missionaries preached Christianity in Shanghai.St Ignatius Cathedral was " +
                $"built in 1904.\n\n" +
                $"20th Century Shanghai\n\n" +
                $"In the early 20th century many notable buildings were erected in Shanghai.The Shanghai Pudong Development " +
                $"Bank was built in 1921.The Customs House was built in 1925.The Peace Hotel was built in 1929.However all " +
                $"was not well in Shanghai.In 1925 there was labour unrest and strikes. Then in 1927 Chiang Kai Shek the Nationalist " +
                $"leader captured Shanghai.\n" +
                $"By the mid - 1930s Shanghai was a huge city with a population of about 3 million.Many foreigners lived " +
                $"there including Russians who fled from the Revolution there.However in 1937 the Japanese invaded China and in " +
                $"November they captured Shanghai.\n" +
                $"In the 1930s many Jews arrived in Shanghai fleeing persecution but in 1941 the Japanese forced them into ghettos. " +
                $"In 1943 they rounded up other foreigners in Shanghai and marched them off to prison camps. However in 1943 Britain and " +
                $"the USA signed a treaty returning their settlements in Shanghai to Chinese rule.\n" +
                $"In May 1949 the Communists entered Shanghai. Under their rule the city remained a major industrial centre and by the " +
                $"early 1980s Shanghai had a population of 13 million.In the 1990s and in the early 21st century Shanghai boomed. " +
                $"Its industries flourished and many new high rise buildings were erected. The population of Shanghai also rose rapidly " +
                $"as the city grew rich.\n" +
                $"Shanghai History Museum was founded in 1983.Oriental Pearl Tower was built in 1994 and Jin Mao Tower followed in 1999.\n\n" +
                $"21st Century Shanghai\n\n" +
                $"Shanghai World Financial Centre was built in 2008.Meanwhile Shanghai Maglev Train opened in 2004.Then in 2010 the World " +
                $"Expo was held in Shanghai.\n" +
                $"Today Shanghai is a thriving city.It is also one of the largest cities in the world. " +
                $"Shanghai has a population of 24 million.";

            TbEvent.Text = $"Start Up Summit: 4YFNS19\n\n Big event for next-generation technology (5G, IOT, AI, Big Data and beyond). 4YFN is back at Asia’s largest exhibition for the mobile industry, GSMA MWC Shanghai, supporting startups, investors and companies to connect and launch\n" +
                $"Cinco de Mayo\n\n Mexican party day, commemorating the Mexican Army's victory over the French Empire at the Battle of Puebla, celebrated, correctly, with lots of tequila and drink specials.\n" +
                $"Shanghai Auto Show 2019\n\n Cars, cars, cars.This year's Shanghai Auto Expo moves up from July to April. As in recent years, expect more cars than scantily-clad models.\n" +
                $"Qing Ming\n\n Time to dust off the ol' grave and eat some qingtuan. This year's Qingming holiday falls on April 5, with three days of holidays scheduled from April 5 - April 7.This is usually a good weekend to travel in China.\n" +
                $"Shanghai Restaurant Week(TBC)\n\n Deals deals deals as a number of the city's restaurants put on special menus for the occasion.\n" +
                $"Chinese New Year\n\n The biggest holiday of the year, when expats flee to Thailand and Chinese are stuck watching marathon TV specials on the couch with their parents. And, if you're not in downtown Shanghai, fireworks fireworks fireworks!";
        }
        /// <summary>
        /// Обработка нажатию на картинку
        /// </summary>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageBig.Source = (sender as Image).Source;
            ImageBig.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Обработка нажатия на кнопку назад именно на этой странице 
        /// </summary>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString((TCHistory.SelectedItem as TabItem).Header) != "Tourism")
            {
                AppData.MainFrame.GoBack();
            }
            else
            {
                if (ImageBig.Visibility == Visibility.Visible)
                {
                    ImageBig.Visibility = Visibility.Collapsed;
                }
                else
                {
                    AppData.MainFrame.GoBack();
                }
            }
        }
    }
}
