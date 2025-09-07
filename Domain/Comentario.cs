using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{



    public class Comentario
    {
        public int Id { get; set; }
        public int NoticiaId { get; set; }
        public int UsuarioId { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}
