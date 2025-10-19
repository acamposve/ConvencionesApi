using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("contratos")]
    public class Contrato
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("pdf_auto_acta")]
        public string PdfAutoActa { get; set; } = string.Empty;

        [Column("fecha_de_inicio")]
        public DateTime? FechaDeInicio { get; set; }

        [Column("fecha_de_termino")]
        public DateTime? FechaDeTermino { get; set; }

        [Column("duracion")]
        [StringLength(15)]
        public string Duracion { get; set; } = string.Empty;

        [Column("ambito_aplicacion")]
        [StringLength(150)]
        public string AmbitoAplicacion { get; set; } = string.Empty;

        [Column("codigo_empresa")]
        public int CodigoEmpresa { get; set; }

        [Column("status_publicacion")]
        [StringLength(2)]
        public string StatusPublicacion { get; set; } = "PE";

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
}
