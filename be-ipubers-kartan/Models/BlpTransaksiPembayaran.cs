using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// tabel untuk log flagging pembayaran dari sisi bank
/// </summary>
[Table("BlpTransaksiPembayaran")]
[Index("IdBilling", "CreatedAt", Name = "BlpTransaksiPembayaran_IdBilling_CreatedAt_index")]
public partial class BlpTransaksiPembayaran
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string IdBilling { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalPayment { get; set; }

    public int StatusPayment { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string DescPayment { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string BankReference { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;
}
