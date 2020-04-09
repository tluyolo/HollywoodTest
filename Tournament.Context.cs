﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HollywoodTest
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HollywoodTestEntities1 : DbContext
    {
        public HollywoodTestEntities1()
            : base("name=HollywoodTestEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventDetail> EventDetails { get; set; }
        public virtual DbSet<EventDetailStatu> EventDetailStatus { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
    
        public virtual int DeleteProcEventDetailsStatus(Nullable<short> eventDetailsStatusID)
        {
            var eventDetailsStatusIDParameter = eventDetailsStatusID.HasValue ?
                new ObjectParameter("EventDetailsStatusID", eventDetailsStatusID) :
                new ObjectParameter("EventDetailsStatusID", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProcEventDetailsStatus", eventDetailsStatusIDParameter);
        }
    
        public virtual int DeleteProcTournament(Nullable<long> tournameID)
        {
            var tournameIDParameter = tournameID.HasValue ?
                new ObjectParameter("TournameID", tournameID) :
                new ObjectParameter("TournameID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProcTournament", tournameIDParameter);
        }
    
        public virtual int ProcEventDetailsStatus(Nullable<short> eventDetailsStatusID, string eventDetailStatusName)
        {
            var eventDetailsStatusIDParameter = eventDetailsStatusID.HasValue ?
                new ObjectParameter("EventDetailsStatusID", eventDetailsStatusID) :
                new ObjectParameter("EventDetailsStatusID", typeof(short));
    
            var eventDetailStatusNameParameter = eventDetailStatusName != null ?
                new ObjectParameter("EventDetailStatusName", eventDetailStatusName) :
                new ObjectParameter("EventDetailStatusName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcEventDetailsStatus", eventDetailsStatusIDParameter, eventDetailStatusNameParameter);
        }
    
        public virtual int ProcTournament(Nullable<long> tournameID, string tournamentName)
        {
            var tournameIDParameter = tournameID.HasValue ?
                new ObjectParameter("TournameID", tournameID) :
                new ObjectParameter("TournameID", typeof(long));
    
            var tournamentNameParameter = tournamentName != null ?
                new ObjectParameter("TournamentName", tournamentName) :
                new ObjectParameter("TournamentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcTournament", tournameIDParameter, tournamentNameParameter);
        }
    
        public virtual int UpdateProcEventDetailsStatus(Nullable<short> eventDetailsStatusID, string eventDetailStatusName)
        {
            var eventDetailsStatusIDParameter = eventDetailsStatusID.HasValue ?
                new ObjectParameter("EventDetailsStatusID", eventDetailsStatusID) :
                new ObjectParameter("EventDetailsStatusID", typeof(short));
    
            var eventDetailStatusNameParameter = eventDetailStatusName != null ?
                new ObjectParameter("EventDetailStatusName", eventDetailStatusName) :
                new ObjectParameter("EventDetailStatusName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProcEventDetailsStatus", eventDetailsStatusIDParameter, eventDetailStatusNameParameter);
        }
    
        public virtual int UpdateProcTournament(Nullable<long> tournameID, string tournamentName)
        {
            var tournameIDParameter = tournameID.HasValue ?
                new ObjectParameter("TournameID", tournameID) :
                new ObjectParameter("TournameID", typeof(long));
    
            var tournamentNameParameter = tournamentName != null ?
                new ObjectParameter("TournamentName", tournamentName) :
                new ObjectParameter("TournamentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateProcTournament", tournameIDParameter, tournamentNameParameter);
        }
    }
}
