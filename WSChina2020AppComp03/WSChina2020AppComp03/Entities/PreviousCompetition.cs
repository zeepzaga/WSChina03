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
    
    public partial class PreviousCompetition
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int TownId { get; set; }
        public int MemberNumber { get; set; }
    
        public virtual Town Town { get; set; }
    }
}
