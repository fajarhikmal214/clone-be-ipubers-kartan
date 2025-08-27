using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// table data berisi Kabkota yang bisa multi login
/// </summary>
[Table("KabkotaMultiLogin")]
[Index("IdKab", Name = "KabkotaMultiLogin_IdKab_uindex", IsUnique = true)]
[Index("Id", Name = "KabkotaMultiLogin_Id_uindex", IsUnique = true)]
public partial class KabkotaMultiLogin
{
    [Key]
    public int Id { get; set; }

    public int IdKab { get; set; }

    public int IsAllowLogin { get; set; }
}
