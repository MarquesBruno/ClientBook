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

        public Table<VendaEntidade> Venda
        {
            get { return this.GetTable<VendaEntidade>(); }
        }

        public Table<ServicoEntidade> Servico
        {
            get { return this.GetTable<ServicoEntidade>(); }
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

        public Table<ServicoPrest> ServicoPrest
        {
            get { return this.GetTable<ServicoPrest>(); }
        }

        public Table<ClienteEntidade> Cliente
        {
            get { return this.GetTable<ClienteEntidade>(); }
        }
    }
}
