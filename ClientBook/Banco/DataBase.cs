using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientBook.Entidade;


namespace ClientBook.Banco
{
    public class DataBase : DataContext
    {
        public static string DBConnectionString =
            "Data Source = 'isostore:clientDB.sdf'";
        public DataBase()
            : base(DBConnectionString)
        {
        }

        public Table<CompraEntidade> Compra
        {
            get { return this.GetTable<CompraEntidade>();}
        }

        public Table<Classificacao> Classificacao
        {
            get { return this.GetTable<Classificacao>(); }
        }

        public Table<Estabelecimento> Estabelecimento
        {
            get { return this.GetTable<Estabelecimento>(); }
        }

        public Table<Produto> Produto
        {
            get { return this.GetTable<Produto>(); }
        }
    }
}
