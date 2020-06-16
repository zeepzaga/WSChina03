using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class Competitior
    {
        public string FullName
        {
            get
            {
                return $"{User.Name} {User.LastName} {User.Patronymic}";
            }
            set { }
        }
        public string GenderOfCompetitior
        {
            get
            {
                return User.Gender.Name;
            }
        }
    }
}
