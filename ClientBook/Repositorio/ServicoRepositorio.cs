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
    public class ServicoRepositorio
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
            var query = from serv in db.Servico orderby serv.id descending select serv.NomeServicoPrest;

            List<string> lista = query.ToList<string>();

            return lista;
        }

        public static List<ServicoEntidade> Get(int pServico)
        {
            DataBase db = GetDataBase();
            var query = from serv in db.Servico orderby serv.id descending select serv;

            List<ServicoEntidade> lista = new List<ServicoEntidade>(query.AsEnumerable());
            return lista;
        }

        public static void Create(ServicoEntidade pServico)
        {
            int ponto = 0;

            DataBase db = GetDataBase();
            var query = from serv in db.Servico orderby serv.id descending select serv;

            List<ServicoEntidade> lista = new List<ServicoEntidade>(query.AsEnumerable());

            db.Servico.InsertOnSubmit(pServico);
            db.SubmitChanges();

        }

        public static void Delete(int pServico)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Servico
                        where c.id == pServico
                        select c;

            db.Servico.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void DeleteObject(ServicoEntidade pServico)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Servico
                        where c.id == pServico.id
                        select c;

            db.Servico.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }



    }
}
