using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("paises")]
public class Pais
{
    [Key]
    public Guid Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string? Name { get; set; }

    [Column("createdby")]
    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [Column("createdat")]
    public DateTime? CreatedAt { get; set; }

    [Column("modifiedby")]
    [StringLength(50)]
    public string? ModifiedBy { get; set; }

    [Column("modifiedat")]
    public DateTime? ModifiedAt { get; set; }
}
