using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenjualanBatch")]
[Index("BatchId", Name = "IX_PenjualanBatch", IsUnique = true)]
[Index("IdRetailer", Name = "IX_PenjualanBatch_1")]
[Index("BatchId", Name = "UQ__Penjuala__5D55CE598ABBDD2C", IsUnique = true)]
public partial class PenjualanBatch
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? BatchId { get; set; }

    [Unicode(false)]
    public string SuratKuasa { get; set; } = null!;

    [Unicode(false)]
    public string SwaFotoPerwakilan { get; set; } = null!;

    [Unicode(false)]
    public string KtpPerwakilan { get; set; } = null!;

    [Column("NIKPerwakilan")]
    [StringLength(16)]
    [Unicode(false)]
    public string Nikperwakilan { get; set; } = null!;

    public byte Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LockAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NamaPerwakilan { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string PoktanId { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string PoktanNama { get; set; } = null!;

    [Unicode(false)]
    public string TandaTangan { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string KodeDesa { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string NamaDesa { get; set; } = null!;

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? NomorPesanan { get; set; }

    [ForeignKey("IdRetailer")]
    [InverseProperty("PenjualanBatches")]
    public virtual Retailer IdRetailerNavigation { get; set; } = null!;

    [InverseProperty("IdPenjualanBatchNavigation")]
    public virtual ICollection<PenjualanBatchAddInfo> PenjualanBatchAddInfos { get; set; } = new List<PenjualanBatchAddInfo>();

    [InverseProperty("IdBatchNavigation")]
    public virtual ICollection<PenjualanBatchLog> PenjualanBatchLogs { get; set; } = new List<PenjualanBatchLog>();
}
