//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSChina2020AppComp03.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Judger
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int UserId { get; set; }
        public int CompetitionId { get; set; }
    
        public virtual Competition Competition { get; set; }
        public virtual Country Country { get; set; }
        public virtual User User { get; set; }
    }
}
