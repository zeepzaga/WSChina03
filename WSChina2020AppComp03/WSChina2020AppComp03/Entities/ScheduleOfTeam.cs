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
    
    public partial class ScheduleOfTeam
    {
        public int Id { get; set; }
        public decimal Points { get; set; }
        public int ScheduleId { get; set; }
        public int TeamId { get; set; }
    
        public virtual Schedule Schedule { get; set; }
    }
}