using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PembelianPoktanHistory", Schema = "dbo_point")]
public partial class PembelianPoktanHistory
{
    [Key]
    public int Id { get; set; }

    public int IdPembelian { get; set; }

    public short Status { get; set; }

    [Column(TypeName = "text")]
    public string Deskripsi { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdPembelian")]
    [InverseProperty("PembelianPoktanHistories")]
    public virtual PembelianPoktan IdPembelianNavigation { get; set; } = null!;
}
