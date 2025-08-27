using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("ProdukRetailerGambar")]
public partial class ProdukRetailerGambar
{
    [Key]
    public int Id { get; set; }

    public int IdProdukRetailer { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string FileGambar { get; set; } = null!;

    public int StatusGambar { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdProdukRetailer")]
    [InverseProperty("ProdukRetailerGambars")]
    public virtual ProdukRetailer IdProdukRetailerNavigation { get; set; } = null!;
}
