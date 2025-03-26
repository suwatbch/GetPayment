using System.Data.Entity;
using GetPayment.Models;
using GetPayment.DTO.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetPayment.DTO.Request;
using System;

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
            var result = new GetPaymentResult();
            
            using (var command = Database.Connection.CreateCommand())
            {
                command.CommandText = "EXEC [dbo].[ics_sel_GetPayment] @Ref1, @Ref2";
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Ref1", request.Ref1));
                command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Ref2", request.Ref2));

                await Database.Connection.OpenAsync();
                
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        if (HasColumn(reader, "Status"))
                        {
                            result.Status = reader["Status"].ToString();
                        }
                    }

                    if (await reader.NextResultAsync() && await reader.ReadAsync())
                    {
                        if (HasColumn(reader, "Ref1"))
                            result.Ref1 = reader["Ref1"].ToString();
                        if (HasColumn(reader, "NotificationNo"))
                            result.NotificationNo = reader["NotificationNo"].ToString();
                        if (HasColumn(reader, "InvoiceNo"))
                            result.InvoiceNo = reader["InvoiceNo"].ToString();
                        if (HasColumn(reader, "ReceiptId"))
                            result.ReceiptId = reader["ReceiptId"].ToString();
                        if (HasColumn(reader, "DebtId"))
                            result.DebtId = reader["DebtId"].ToString();
                        if (HasColumn(reader, "UpdateStatus"))
                            result.UpdateStatus = reader["UpdateStatus"].ToString();
                        if (HasColumn(reader, "CreatedDate"))
                            result.CreatedDate = reader["CreatedDate"] != DBNull.Value ? (DateTime?)reader["CreatedDate"] : null;
                    }
                }
            }

            if (string.IsNullOrEmpty(result.Status) && string.IsNullOrEmpty(result.Ref1))
            {
                return null;
            }

            return result;
        }

        private bool HasColumn(System.Data.IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    } 
}
