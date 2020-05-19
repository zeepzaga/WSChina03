using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WSChina2020AppComp03.Entities
{
    /// <summary>
    /// Класс для публичных переменных
    /// </summary>
    public static class AppData
    {
        public static Frame MainFrame; // Фрейм
        public static WSChina2020BaseComp03Entities Context = new WSChina2020BaseComp03Entities(); // Контекст базы
        public static User CurrentUser; // юзер, который выполнил вход
        public static int countLogin; // количество попыток входа 
    }
}
