using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("JadwalInput")]
[Index("Id", Name = "IX_JadwalInput", IsUnique = true)]
public partial class JadwalInput
{
    [Key]
    public int Id { get; set; }

    public int Bulan { get; set; }

    public int Tahun { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Keterangan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TglMaksimalInput { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SyncAlokasiMax { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Message { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Title { get; set; }
}
