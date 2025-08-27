using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// table untuk data kios yang menggunakan kartu tani digital
/// </summary>
[Table("BsiKiosKartan")]
[Index("Id", Name = "BsiKiosKartan_Id_uindex", IsUnique = true)]
[Index("KodeKios", Name = "BsiKiosKartan_KodeKios_uindex", IsUnique = true)]
public partial class BsiKiosKartan
{
    [Key]
    public int Id { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string KodeKios { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? KodeAgen { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    public int Status { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
}
