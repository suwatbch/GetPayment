using System.Data.Entity;
using GetPayment.Models;

namespace GetPayment.DAL
{
    public class DB_BPM_CENTER_ADT_DB : DbContext
    {
        public DB_BPM_CENTER_ADT_DB() : base("Connection_BPM_CENTER_ADT_DB") { }

        public DbSet<ICSVoidSuccessLog> ICSVoidSuccessLogs { get; set; }

        public DbSet<ICSUpdatePaymentLog> ICSUpdatePaymentLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ICSVoidSuccessLog>().ToTable("ICSVoidSuccessLog", "ta");
            modelBuilder.Entity<ICSVoidSuccessLog>().HasKey(x => x.ReceiptId);

            modelBuilder.Entity<ICSUpdatePaymentLog>().ToTable("ICSUpdatePaymentLog", "ta");
            modelBuilder.Entity<ICSUpdatePaymentLog>().HasKey(x => x.Ref1);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DB_BPM_CENTER_APP_DB : DbContext
    {
        public DB_BPM_CENTER_APP_DB() : base("Connection_BPM_CENTER_APP_DB") { }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>().ToTable("Receipt", "ta");
            modelBuilder.Entity<Receipt>().HasKey(x => x.ReceiptId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
