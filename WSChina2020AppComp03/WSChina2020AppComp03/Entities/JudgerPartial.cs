using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSChina2020AppComp03.Entities
{
    public partial class Judger
    {
        public string FullName
        {
            get
            {
                return $"{User.Name} {User.LastName} {User.Patronymic}";
            }
            set { }
        }
    }
}
