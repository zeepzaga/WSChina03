﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WSChina2020BaseComp03Entities : DbContext
    {
        public WSChina2020BaseComp03Entities()
            : base("name=WSChina2020BaseComp03Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoryOfCompetition> CategoryOfCompetitions { get; set; }
        public virtual DbSet<CategoryOfSponsorship> CategoryOfSponsorships { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionService> CompetitionServices { get; set; }
        public virtual DbSet<Competitior> Competitiors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<EventCompetition> EventCompetitions { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Judger> Judgers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleOfCompetitor> ScheduleOfCompetitors { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }
        public virtual DbSet<Sponsorship> Sponsorships { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TeamCompetition> TeamCompetitions { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
    }
}
