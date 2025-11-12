using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecyclonicApi.Models;

public partial class RecyclingCompany
{
    [Key]
    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("phone")]
    [StringLength(50)]
    public string? Phone { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("partnership_level")]
    [StringLength(50)]
    public string PartnershipLevel { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Company")]
    public virtual ICollection<Marketplace> Marketplaces { get; set; } = new List<Marketplace>();
}
