//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSChina2020AppComp03.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Volunteer
    {
        public int Id { get; set; }
        public int RepresentCountryId { get; set; }
        public int BornCountryId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public int CompetitionId { get; set; }
    
        public virtual Competition Competition { get; set; }
        public virtual Country Country { get; set; }
        public virtual Country Country1 { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
