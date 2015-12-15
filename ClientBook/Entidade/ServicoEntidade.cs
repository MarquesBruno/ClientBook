using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBook.Entidade
{
    [Table(Name = "Servico")]
    public class ServicoEntidade
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }


        [Column(CanBeNull = true)]
        public string cliente { get; set; }

        [Column(CanBeNull = true)]
        public string NomeServicoPrest { get; set; }

        [Column(CanBeNull = true)]
        public string classificacao { get; set; }

        [Column(CanBeNull = true)]
        public double preco { get; set; }

        [Column(CanBeNull = true)]
        public string Data { get; set; }

    }
}
