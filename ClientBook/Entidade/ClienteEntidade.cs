using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBook.Entidade
{
    [Table(Name = "Cliente")]
    public class ClienteEntidade
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(CanBeNull = true)]
        public int referencia { get; set; }

        [Column(CanBeNull = true)]
        public string nomeCliente { get; set; }

        [Column(CanBeNull = true)]
        public string endereco { get; set; }

        [Column(CanBeNull = true)]
        public string telefone { get; set; }

    }
}
