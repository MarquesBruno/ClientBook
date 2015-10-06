using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClientBook.Banco;
using ClientBook.Entidade;

namespace ClientBook.Repositorio
{
    public class ProdutoRepositorio
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        public static List<string> GetOne()
        {
            DataBase db = GetDataBase();
            var query = from prod in db.Produto orderby prod.NomeProduto descending select prod.NomeProduto;

            List<string> lista = query.ToList<string>();
            return lista;
        }

        public static List<Produto> Get(int pProd)
        {
            DataBase db = GetDataBase();
            var query = from prod in db.Produto orderby prod.id descending select prod;

            List<Produto> lista = new List<Produto>(query.AsEnumerable());
            return lista;
        }

        public static void Create(Produto pProd)
        {
            int ponto = 0;
            DataBase db = GetDataBase();
            var query = from prod in db.Produto orderby prod.id descending select prod;
            List<Produto> lista = new List<Produto>(query.AsEnumerable());

            foreach (var item in lista)
            {
                if ((item.NomeProduto.Equals(pProd.NomeProduto, StringComparison.OrdinalIgnoreCase)) || (item.marca.Equals(pProd.marca, StringComparison.OrdinalIgnoreCase)))
                {
                    ponto = 1;
                }
            }
            if (ponto == 0)
            {
                db.Produto.InsertOnSubmit(pProd);
                db.SubmitChanges();
            }
            else
            {
                pProd.referencia = 1;
            }
        }

        public static void Delete(string pProd)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Produto
                        where c.NomeProduto == pProd || c.marca == pProd
                        select c;

            db.Produto.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }



    }
}
