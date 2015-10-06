using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBook.Entidade
{
    [Table(Name = "Estabelecimento")]
    public class Estabelecimento
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(CanBeNull = true)]
        public int referencia { get; set; }

        [Column(CanBeNull = true)]
        public string nome { get; set; }

        [Column(CanBeNull = true)]
        public string telefone { get; set; }

        [Column(CanBeNull = true)]
        public string endereco { get; set; }





    }
}








