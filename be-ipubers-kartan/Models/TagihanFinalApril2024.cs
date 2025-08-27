using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Keyless]
[Table("TagihanFinal_April_2024")]
public partial class TagihanFinalApril2024
{
    [Column("\"province\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Province { get; set; }

    [Column("\"city\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? City { get; set; }

    [Column("\"district\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? District { get; set; }

    [Column("\"district_code\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DistrictCode { get; set; }

    [Column("\"tahun\"", TypeName = "numeric(18, 0)")]
    public decimal? Tahun { get; set; }

    [Column("\"bulan\"", TypeName = "numeric(18, 0)")]
    public decimal? Bulan { get; set; }

    [Column("\"kodetrx\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Kodetrx { get; set; }

    [Column("\"nik\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Nik { get; set; }

    [Column("\"nama_petani\"")]
    [StringLength(5000)]
    [Unicode(false)]
    public string? NamaPetani { get; set; }

    [Column("\"urea\"")]
    public float? Urea { get; set; }

    [Column("\"urea_price\"")]
    public float? UreaPrice { get; set; }

    [Column("\"urea_rupiah\"")]
    public float? UreaRupiah { get; set; }

    [Column("\"urea_anper\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UreaAnper { get; set; }

    [Column("\"npk\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Npk { get; set; }

    [Column("\"npk_price\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NpkPrice { get; set; }

    [Column("\"npk_rupiah\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NpkRupiah { get; set; }

    [Column("\"npk_anper\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NpkAnper { get; set; }

    [Column("\"npk_formula\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NpkFormula { get; set; }

    [Column("\"npk_formula_price\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NpkFormulaPrice { get; set; }

    [Column("\"npk_formula_rupiah\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NpkFormulaRupiah { get; set; }

    [Column("\"npk_formula_anper\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? NpkFormulaAnper { get; set; }

    [Column("\"sumber\"")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Sumber { get; set; }
}
