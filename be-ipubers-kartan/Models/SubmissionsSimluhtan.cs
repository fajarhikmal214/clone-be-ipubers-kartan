using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("submissions_simluhtan")]
public partial class SubmissionsSimluhtan
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("year")]
    public int? Year { get; set; }

    [Column("sub_district_code")]
    [StringLength(30)]
    [Unicode(false)]
    public string? SubDistrictCode { get; set; }

    [Column("district_code")]
    [StringLength(18)]
    [Unicode(false)]
    public string? DistrictCode { get; set; }

    [Column("city_code")]
    [StringLength(12)]
    [Unicode(false)]
    public string? CityCode { get; set; }

    [Column("province_code")]
    [StringLength(6)]
    [Unicode(false)]
    public string? ProvinceCode { get; set; }

    [Column("status")]
    public int? Status { get; set; }

    [Column("rejection_message")]
    [StringLength(765)]
    [Unicode(false)]
    public string? RejectionMessage { get; set; }

    [Column("instructor_name")]
    [StringLength(765)]
    [Unicode(false)]
    public string? InstructorName { get; set; }

    [Column("retailer_id")]
    public int? RetailerId { get; set; }

    [Column("farmer_group_id")]
    public int? FarmerGroupId { get; set; }

    [Column("farmer_group_union_name")]
    [StringLength(765)]
    [Unicode(false)]
    public string? FarmerGroupUnionName { get; set; }

    [Column("farmer_name")]
    [StringLength(765)]
    [Unicode(false)]
    public string? FarmerName { get; set; }

    [Column("farmer_nik")]
    [StringLength(48)]
    [Unicode(false)]
    public string? FarmerNik { get; set; }

    [Column("farmer_address")]
    [StringLength(765)]
    [Unicode(false)]
    public string? FarmerAddress { get; set; }

    [Column("farmer_mother_name")]
    [StringLength(765)]
    [Unicode(false)]
    public string? FarmerMotherName { get; set; }

    [Column("farmer_born_place")]
    [StringLength(765)]
    [Unicode(false)]
    public string? FarmerBornPlace { get; set; }

    [Column("farmer_born_date")]
    public DateOnly? FarmerBornDate { get; set; }

    [Column("subsector")]
    [StringLength(765)]
    [Unicode(false)]
    public string? Subsector { get; set; }

    [Column("mt1_planting_area", TypeName = "decimal(12, 0)")]
    public decimal? Mt1PlantingArea { get; set; }

    [Column("mt2_planting_area", TypeName = "decimal(12, 0)")]
    public decimal? Mt2PlantingArea { get; set; }

    [Column("mt3_planting_area", TypeName = "decimal(12, 0)")]
    public decimal? Mt3PlantingArea { get; set; }

    [Column("mt1_commodity")]
    [StringLength(765)]
    [Unicode(false)]
    public string? Mt1Commodity { get; set; }

    [Column("mt2_commodity")]
    [StringLength(765)]
    [Unicode(false)]
    public string? Mt2Commodity { get; set; }

    [Column("mt3_commodity")]
    [StringLength(765)]
    [Unicode(false)]
    public string? Mt3Commodity { get; set; }

    [Column("mt1_urea")]
    public int? Mt1Urea { get; set; }

    [Column("mt2_urea")]
    public int? Mt2Urea { get; set; }

    [Column("mt3_urea")]
    public int? Mt3Urea { get; set; }

    [Column("mt1_sp36")]
    public int? Mt1Sp36 { get; set; }

    [Column("mt2_sp36")]
    public int? Mt2Sp36 { get; set; }

    [Column("mt3_sp36")]
    public int? Mt3Sp36 { get; set; }

    [Column("mt1_za")]
    public int? Mt1Za { get; set; }

    [Column("mt2_za")]
    public int? Mt2Za { get; set; }

    [Column("mt3_za")]
    public int? Mt3Za { get; set; }

    [Column("mt1_npk")]
    public int? Mt1Npk { get; set; }

    [Column("mt2_npk")]
    public int? Mt2Npk { get; set; }

    [Column("mt3_npk")]
    public int? Mt3Npk { get; set; }

    [Column("mt1_organic")]
    public int? Mt1Organic { get; set; }

    [Column("mt2_organic")]
    public int? Mt2Organic { get; set; }

    [Column("mt3_organic")]
    public int? Mt3Organic { get; set; }

    [Column("mt1_npk_formula")]
    public int? Mt1NpkFormula { get; set; }

    [Column("mt2_npk_formula")]
    public int? Mt2NpkFormula { get; set; }

    [Column("mt3_npk_formula")]
    public int? Mt3NpkFormula { get; set; }

    [Column("mt1_poc")]
    public int? Mt1Poc { get; set; }

    [Column("mt2_poc")]
    public int? Mt2Poc { get; set; }

    [Column("mt3_poc")]
    public int? Mt3Poc { get; set; }

    [Column("field_coordinate")]
    [StringLength(675)]
    [Unicode(false)]
    public string? FieldCoordinate { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("farmer_group_name")]
    [StringLength(765)]
    [Unicode(false)]
    public string? FarmerGroupName { get; set; }

    [Column("farmer_phone_number")]
    [StringLength(60)]
    [Unicode(false)]
    public string? FarmerPhoneNumber { get; set; }

    [ForeignKey("RetailerId")]
    [InverseProperty("SubmissionsSimluhtans")]
    public virtual KementanRetailer? Retailer { get; set; }
}
