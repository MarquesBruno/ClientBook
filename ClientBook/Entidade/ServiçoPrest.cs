using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBook.Entidade
{
    [Table(Name = "ServicoPrest")]
    public class ServicoPrest
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(CanBeNull = true)]
        public string NomeServicoPrest { get; set; }

        [Column(CanBeNull = true)]
        public int referencia { get; set; }
    }
}
