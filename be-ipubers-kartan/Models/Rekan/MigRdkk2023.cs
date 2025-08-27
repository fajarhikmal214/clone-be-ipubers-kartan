using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Keyless]
[Table("_migRdkk2023")]
public partial class MigRdkk2023
{
    [Column("ID_Pengajuan")]
    public int? IdPengajuan { get; set; }

    [Column("Waktu_pengesahan", TypeName = "datetime")]
    public DateTime? WaktuPengesahan { get; set; }

    [StringLength(255)]
    public string? Provinsi { get; set; }

    [Column("Kota_Kabupaten")]
    [StringLength(255)]
    public string? KotaKabupaten { get; set; }

    [StringLength(255)]
    public string? Kecamatan { get; set; }

    [StringLength(255)]
    public string? Kelurahan { get; set; }

    [StringLength(255)]
    public string? KodeDesa { get; set; }

    [Column("IDPengecer")]
    public int? Idpengecer { get; set; }

    [Column("KodePIHCPengecer")]
    [StringLength(255)]
    public string? KodePihcpengecer { get; set; }

    [Column("Nama_Pengecer")]
    [StringLength(255)]
    public string? NamaPengecer { get; set; }

    [Column("IDKelompokTani")]
    public int? IdkelompokTani { get; set; }

    [StringLength(255)]
    public string? NamaKelompokTani { get; set; }

    [Column("Nama Petani")]
    [StringLength(255)]
    public string? NamaPetani { get; set; }

    [Column("KTPPetani")]
    [StringLength(255)]
    public string? Ktppetani { get; set; }

    [StringLength(255)]
    public string? TempatLahirPetani { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalLahirPetani { get; set; }

    [StringLength(255)]
    public string? NamaIbuPetani { get; set; }

    [StringLength(255)]
    public string? AlamatPetani { get; set; }

    [StringLength(255)]
    public string? Subsektor { get; set; }

    [Column("KomoditasMT1")]
    [StringLength(255)]
    public string? KomoditasMt1 { get; set; }

    [Column("LuasTanamMT1")]
    public double? LuasTanamMt1 { get; set; }

    [Column("UreaMT1")]
    public double? UreaMt1 { get; set; }

    [Column("Sp36MT1")]
    public double? Sp36Mt1 { get; set; }

    [Column("ZaMT1")]
    public double? ZaMt1 { get; set; }

    [Column("NPKMT1")]
    public double? Npkmt1 { get; set; }

    [Column("NpkFormulaKhususMT1")]
    public double? NpkFormulaKhususMt1 { get; set; }

    [Column("OrganikGranulMT1")]
    public double? OrganikGranulMt1 { get; set; }

    [Column("OrganikCairMT1")]
    public double? OrganikCairMt1 { get; set; }

    [Column("KomoditasMT2")]
    [StringLength(255)]
    public string? KomoditasMt2 { get; set; }

    [Column("LuasTanamMT2")]
    public double? LuasTanamMt2 { get; set; }

    [Column("UreaMT2")]
    public double? UreaMt2 { get; set; }

    [Column("Sp36MT2")]
    public double? Sp36Mt2 { get; set; }

    [Column("ZaMT2")]
    public double? ZaMt2 { get; set; }

    [Column("NPKMT2")]
    public double? Npkmt2 { get; set; }

    [Column("NpkFormulaKhususMT2")]
    public double? NpkFormulaKhususMt2 { get; set; }

    [Column("OrganikGranulMT2")]
    public double? OrganikGranulMt2 { get; set; }

    [Column("OrganikCairMT2")]
    public double? OrganikCairMt2 { get; set; }

    [Column("KomoditasMT3")]
    [StringLength(255)]
    public string? KomoditasMt3 { get; set; }

    [Column("LuasTanamMT3")]
    public double? LuasTanamMt3 { get; set; }

    [Column("UreaMT3")]
    public double? UreaMt3 { get; set; }

    [Column("Sp36MT3")]
    public double? Sp36Mt3 { get; set; }

    [Column("ZaMT3")]
    public double? ZaMt3 { get; set; }

    [Column("NPKMT3")]
    public double? Npkmt3 { get; set; }

    [Column("NpkFormulaKhususMT3")]
    public double? NpkFormulaKhususMt3 { get; set; }

    [Column("OrganikGranulMT3")]
    public double? OrganikGranulMt3 { get; set; }

    [Column("OrganikCairMT3")]
    public double? OrganikCairMt3 { get; set; }

    [Column("tahun")]
    public int? Tahun { get; set; }

    [Column("fromfile")]
    [StringLength(255)]
    public string? Fromfile { get; set; }

    [Column("NO_REKENING_COREBSI")]
    [StringLength(255)]
    public string? NoRekeningCorebsi { get; set; }

    [Column("NAMA_REKENING_COREBSI")]
    [StringLength(255)]
    public string? NamaRekeningCorebsi { get; set; }

    [Column("NAMA_CABANG")]
    [StringLength(255)]
    public string? NamaCabang { get; set; }

    [Column("STATUS_BUREKOL")]
    [StringLength(255)]
    public string? StatusBurekol { get; set; }

    [Column("KETERANGAN_BUREKOL")]
    [StringLength(255)]
    public string? KeteranganBurekol { get; set; }
}
