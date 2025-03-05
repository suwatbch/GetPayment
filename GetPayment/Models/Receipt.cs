using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetPayment.Models
{
    [Table("Receipt", Schema = "ta")]
    public class Receipt
    {
        // 1
        [Key]
        [Column(TypeName = "char")]
        [StringLength(16)]
        public string ReceiptId { get; set; }

        // 2
        [Column(TypeName = "char")]
        [StringLength(22)]
        public string PaymentId { get; set; }

        // 3
        public short? PrintingSequence { get; set; }

        // 4
        public short? TotalReceipt { get; set; }

        // 5
        [Column(TypeName = "char")]
        [StringLength(12)]
        public string CaId { get; set; }

        // 6
        [Column(TypeName = "varchar")]
        [StringLength(150)]
        public string Name { get; set; }

        // 7
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Address { get; set; }

        // 8
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string IsNameAddrModified { get; set; }

        // 9
        public int? NoOfPrinting { get; set; }

        // 10
        public DateTime? CancelDt { get; set; }

        // 11
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string CancelReason { get; set; }

        // 12
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string ReceiptType { get; set; }

        // 13
        [Column(TypeName = "char")]
        [StringLength(16)]
        public string ExtReceiptId { get; set; }

        // 14
        public DateTime? ExtReceiptDt { get; set; }

        // 15
        [Column(TypeName = "char")]
        [StringLength(16)]
        public string CaDoc { get; set; }

        // 16
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Description { get; set; }

        // 17
        [Column(TypeName = "char")]
        [StringLength(22)]
        public string InvoiceNo { get; set; }

        // 18
        public DateTime? InvoiceDt { get; set; }

        // 19
        [Column(TypeName = "char")]
        [StringLength(22)]
        public string OriginalInvoiceNo { get; set; }

        // 20
        public DateTime? OriginalInvoiceDt { get; set; }

        // 21
        public int? InstallmentPeriod { get; set; }

        // 22
        public int? InstallmentTotalPeriod { get; set; }

        // 23
        [Column(TypeName = "char")]
        [StringLength(4)]
        public string MruId { get; set; }

        // 24
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string MeterId { get; set; }

        // 25
        [Column(TypeName = "char")]
        [StringLength(10)]
        public string RateTypeId { get; set; }

        // 26
        [Column(TypeName = "char")]
        [StringLength(6)]
        public string BranchId { get; set; }

        // 27
        [Column(TypeName = "varchar")]
        [StringLength(80)]
        public string TechBranchName { get; set; }

        // 28
        [Column(TypeName = "char")]
        [StringLength(6)]
        public string CommBranchId { get; set; }

        // 29
        [Column(TypeName = "varchar")]
        [StringLength(80)]
        public string CommBranchName { get; set; }

        // 30
        [Column(TypeName = "char")]
        [StringLength(6)]
        public string Period { get; set; }

        // 31
        [Column(TypeName = "varchar")]
        [StringLength(35)]
        public string GroupInvoiceNo { get; set; }

        // 32
        [Column(TypeName = "char")]
        [StringLength(15)]
        public string BillBookId { get; set; }

        // 33
        [Column(TypeName = "char")]
        [StringLength(22)]
        public string SpotBillInvoiceNo { get; set; }

        // 34
        public DateTime? MeterReadDt { get; set; }

        // 35-50 (Amounts)
        [Column(TypeName = "decimal(18,2)")] public decimal? ReadUnit { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? LastUnit { get; set; }
        [Column(TypeName = "money")] public decimal? FullBaseAmount { get; set; }
        [Column(TypeName = "money")] public decimal? FullFTAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? FullQty { get; set; }
        [Column(TypeName = "money")] public decimal? FullAmount { get; set; }
        [Column(TypeName = "money")] public decimal? FullVatAmount { get; set; }
        [Column(TypeName = "money")] public decimal? FullGAmount { get; set; }
        [Column(TypeName = "money")] public decimal? BaseAmount { get; set; }
        [Column(TypeName = "money")] public decimal? FTUnitPrice { get; set; }
        [Column(TypeName = "money")] public decimal? FTAmount { get; set; }
        [Column(TypeName = "money")] public decimal? UnitPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal? Qty { get; set; }
        [Column(TypeName = "money")] public decimal? Amount { get; set; }
        [Column(TypeName = "money")] public decimal? VatAmount { get; set; }
        [Column(TypeName = "money")] public decimal? GAmount { get; set; }

        // 51-54 (Installments)
        [Column(TypeName = "decimal(18,2)")] public decimal? QtyInstallment { get; set; }
        [Column(TypeName = "money")] public decimal? AmountInstallment { get; set; }
        [Column(TypeName = "money")] public decimal? VatAmountInstallment { get; set; }
        [Column(TypeName = "money")] public decimal? GAmountInstallment { get; set; }

        // 55-60 (Tax & Controller)
        [Column(TypeName = "char")][StringLength(9)] public string DtId { get; set; }
        [Column(TypeName = "varchar")][StringLength(100)] public string DtName { get; set; }
        [Column(TypeName = "char")][StringLength(8)] public string ControllerId { get; set; }
        [Column(TypeName = "varchar")][StringLength(100)] public string ControllerName { get; set; }
        [Column(TypeName = "char")][StringLength(2)] public string TaxCode { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal? TaxRate { get; set; }

        // 61-70 (Flags & Status)
        public byte? PartialPayment { get; set; }
        [Column(TypeName = "char")][StringLength(1)] public string GroupIvReceiptType { get; set; }
        [Column(TypeName = "char")][StringLength(1)] public string SyncFlag { get; set; }
        public DateTime? PostDt { get; set; }
        [Column(TypeName = "char")][StringLength(7)] public string PostBranchServerId { get; set; }
        public DateTime? ModifiedDt { get; set; }
        [Column(TypeName = "char")][StringLength(8)] public string ModifiedBy { get; set; }
        [Column(TypeName = "char")][StringLength(1)] public string Active { get; set; }
        [Column(TypeName = "char")][StringLength(13)] public string CaTaxId { get; set; }
        [Column(TypeName = "varchar")][StringLength(20)] public string CaTaxBranch { get; set; }
    }

}
