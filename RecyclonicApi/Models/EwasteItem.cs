using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecyclonicApi.Models;

[Table("EWasteItems")]
public partial class EwasteItem
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("item_name")]
    [StringLength(255)]
    public string ItemName { get; set; } = null!;

    [Column("category")]
    [StringLength(50)]
    public string Category { get; set; } = null!;

    [Column("condition")]
    [StringLength(50)]
    public string Condition { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("image_url")]
    [StringLength(500)]
    public string? ImageUrl { get; set; }

    [Column("submission_date")]
    public DateTime SubmissionDate { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string Status { get; set; } = null!;

    [InverseProperty("Item")]
    public virtual ICollection<Marketplace> Marketplaces { get; set; } = new List<Marketplace>();

    [ForeignKey("UserId")]
    [InverseProperty("EwasteItems")]
    public virtual User User { get; set; } = null!;
}
