using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("TPubersClaim")]
[Index("NoNota", Name = "TPubersClaim_NoNota_index")]
public partial class TpubersClaim
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("farmer_nik")]
    [StringLength(16)]
    [Unicode(false)]
    public string FarmerNik { get; set; } = null!;

    [Column("year")]
    public int Year { get; set; }

    [Column("pihc_code")]
    [StringLength(20)]
    [Unicode(false)]
    public string PihcCode { get; set; } = null!;

    [Column("npk")]
    public double? Npk { get; set; }

    [Column("urea")]
    public double? Urea { get; set; }

    [Column("sp36")]
    public double? Sp36 { get; set; }

    [Column("za")]
    public double? Za { get; set; }

    [Column("organic")]
    public double? Organic { get; set; }

    [Column("npk_formula")]
    public double? NpkFormula { get; set; }

    [Column("poc")]
    public double? Poc { get; set; }

    [Column("month_claimed")]
    public int MonthClaimed { get; set; }

    [Column("date_claimed")]
    public int DateClaimed { get; set; }

    [Column("year_claimed")]
    public int YearClaimed { get; set; }

    [Column("district_code")]
    [StringLength(8)]
    [Unicode(false)]
    public string? DistrictCode { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("id_tpubers")]
    [StringLength(20)]
    [Unicode(false)]
    public string? IdTpubers { get; set; }

    [Column("sts")]
    public int? Sts { get; set; }

    [Column("message")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Message { get; set; }

    [Column("poktan_id")]
    public int? PoktanId { get; set; }

    [Column("status_verval")]
    public int StatusVerval { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [Column("referensi_dokumen")]
    [StringLength(250)]
    [Unicode(false)]
    public string? ReferensiDokumen { get; set; }

    [Column("aksi")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Aksi { get; set; }

    [Column("kode_desa")]
    [StringLength(20)]
    [Unicode(false)]
    public string? KodeDesa { get; set; }

    [Column("kode_prop")]
    [StringLength(6)]
    [Unicode(false)]
    public string? KodeProp { get; set; }

    [Column("kode_kab")]
    [StringLength(6)]
    [Unicode(false)]
    public string? KodeKab { get; set; }

    [Column("tipe_penebusan")]
    public int? TipePenebusan { get; set; }

    [Column("nik_perwakilan")]
    [StringLength(20)]
    [Unicode(false)]
    public string? NikPerwakilan { get; set; }

    [Unicode(false)]
    public string? FormDataString { get; set; }

    [Column("komoditas")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Komoditas { get; set; }
}
