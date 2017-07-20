namespace WiFiData_Data_Update.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SurveyModel : DbContext
    {
        public SurveyModel()
            : base("name=SurveyModel")
        {
        }

        public virtual DbSet<wifi_list> wifi_list { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<wifi_list>()
                .Property(e => e.floor)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
