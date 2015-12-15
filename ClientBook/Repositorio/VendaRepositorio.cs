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
    public class VendaRepositorio
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
            var query = from ven in db.Venda orderby ven.id descending select ven.produto;

            List<string> lista = query.ToList<string>();

            return lista;
        }

        public static List<VendaEntidade> Get(int pVenda)
        {
            DataBase db = GetDataBase();
            var query = from ven in db.Venda orderby ven.id descending select ven;

            List<VendaEntidade> lista = new List<VendaEntidade>(query.AsEnumerable());
            return lista;
        }

        public static void Create(VendaEntidade pVenda)
        {
            int ponto = 0;

            DataBase db = GetDataBase();
            var query = from ven in db.Venda orderby ven.id descending select ven;

            List<VendaEntidade> lista = new List<VendaEntidade>(query.AsEnumerable());

            db.Venda.InsertOnSubmit(pVenda);
            db.SubmitChanges();

        }

        public static void Delete(int pVenda)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Venda
                        where c.id == pVenda
                        select c;

            db.Venda.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void DeleteObject(VendaEntidade pVenda)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Venda
                        where c.id == pVenda.id
                        select c;

            db.Venda.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }



    }
}
