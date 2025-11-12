using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecyclonicApi.Models;

[Table("Marketplace")]
public partial class Marketplace
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    [Column("image_url")]
    [StringLength(500)]
    public string? ImageUrl { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Marketplaces")]
    public virtual RecyclingCompany Company { get; set; } = null!;

    [ForeignKey("ItemId")]
    [InverseProperty("Marketplaces")]
    public virtual EwasteItem Item { get; set; } = null!;
}
