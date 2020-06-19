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
    
    public partial class Competitior
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competitior()
        {
            this.ScheduleOfCompetitors = new HashSet<ScheduleOfCompetitor>();
            this.TeamCompetitions = new HashSet<TeamCompetition>();
        }
    
        public string Id { get; set; }
        public Nullable<int> CompetitionId { get; set; }
        public string UserId { get; set; }
        public int EventCompetitionId { get; set; }
        public Nullable<int> StationNumber { get; set; }
    
        public virtual Competition Competition { get; set; }
        public virtual EventCompetition EventCompetition { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleOfCompetitor> ScheduleOfCompetitors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamCompetition> TeamCompetitions { get; set; }
    }
}
