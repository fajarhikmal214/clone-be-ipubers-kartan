using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("ERDKKDetail")]
public partial class Erdkkdetail
{
    [Key]
    public int Id { get; set; }

    [Column("IdERDKK")]
    public int IdErdkk { get; set; }

    public int? IdPetani { get; set; }

    [Column("NoKTPPetani")]
    [StringLength(16)]
    [Unicode(false)]
    public string? NoKtppetani { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NamaPetani { get; set; }

    public double? LuasTanam { get; set; }

    public double Urea1 { get; set; }

    public double Urea2 { get; set; }

    public double Urea3 { get; set; }

    public double? Urea4 { get; set; }

    public double? Urea5 { get; set; }

    [Column("SP361")]
    public double Sp361 { get; set; }

    [Column("SP362")]
    public double Sp362 { get; set; }

    [Column("SP363")]
    public double Sp363 { get; set; }

    [Column("SP364")]
    public double? Sp364 { get; set; }

    [Column("SP365")]
    public double? Sp365 { get; set; }

    [Column("ZA1")]
    public double Za1 { get; set; }

    [Column("ZA2")]
    public double Za2 { get; set; }

    [Column("ZA3")]
    public double Za3 { get; set; }

    [Column("ZA4")]
    public double? Za4 { get; set; }

    [Column("ZA5")]
    public double? Za5 { get; set; }

    [Column("NPK1")]
    public double Npk1 { get; set; }

    [Column("NPK2")]
    public double Npk2 { get; set; }

    [Column("NPK3")]
    public double Npk3 { get; set; }

    [Column("NPK4")]
    public double? Npk4 { get; set; }

    [Column("NPK5")]
    public double? Npk5 { get; set; }

    public double Organik1 { get; set; }

    public double Organik2 { get; set; }

    public double Organik3 { get; set; }

    public double? Organik4 { get; set; }

    public double? Organik5 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("IdErdkk")]
    [InverseProperty("Erdkkdetails")]
    public virtual Rdkk IdErdkkNavigation { get; set; } = null!;
}
