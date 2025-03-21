﻿using System.Data.Entity;
using GetPayment.Models;
using GetPayment.DTO.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetPayment.DTO.Request;

namespace GetPayment.DAL
{

    public class DB_BPM_CENTER_APP_DB : DbContext
    {
        public DB_BPM_CENTER_APP_DB() : base("Connection_BPM_CENTER_APP_DB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

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

        public async Task<GetPaymentResult> GetPaymentFromStoredProc(PaymentRequest request)
        {
             var result = await Database.SqlQuery<GetPaymentResult>(
                "EXEC [dbo].[ics_sel_GetPayment] @Ref1, @Ref2",
                new System.Data.SqlClient.SqlParameter("@Ref1", request.Ref1),
                new System.Data.SqlClient.SqlParameter("@Ref2", request.Ref2)
            ).FirstOrDefaultAsync();

            return result;
        }
    } 
}
