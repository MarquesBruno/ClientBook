using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBook.Entidade
{
    [Table(Name = "Produto")]
    public class Produto
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(CanBeNull = true)]
        public string NomeProduto { get; set; }

        [Column(CanBeNull = true)]
        public string marca { get; set; }

        [Column(CanBeNull = true)]
        public int referencia { get; set; }
    }
}
