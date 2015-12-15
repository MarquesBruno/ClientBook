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
    public class ServicoPrestRepositorio
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
            var query = from servPrest in db.ServicoPrest orderby servPrest.NomeServicoPrest descending select servPrest.NomeServicoPrest;

            List<string> lista = query.ToList<string>();
            return lista;
        }

        public static List<ServicoPrest> Get(int pServPrest)
        {
            DataBase db = GetDataBase();
            var query = from servPrest in db.ServicoPrest orderby servPrest.id descending select servPrest;

            List<ServicoPrest> lista = new List<ServicoPrest>(query.AsEnumerable());
            return lista;
        }

        public static void Create(ServicoPrest pServPrest)
        {
            int ponto = 0;
            DataBase db = GetDataBase();
            var query = from servPrest in db.ServicoPrest orderby servPrest.id descending select servPrest;
            List<ServicoPrest> lista = new List<ServicoPrest>(query.AsEnumerable());

            foreach (var item in lista)
            {
                if ((item.NomeServicoPrest.Equals(pServPrest.NomeServicoPrest, StringComparison.OrdinalIgnoreCase)))
                {
                    ponto = 1;
                }
            }
            if (ponto == 0)
            {
                db.ServicoPrest.InsertOnSubmit(pServPrest);
                db.SubmitChanges();
            }
            else
            {
                pServPrest.referencia = 1;
            }
        }

        public static void Delete(string pServPrest)
        {
            DataBase db = GetDataBase();
            var query = from c in db.ServicoPrest
                        where c.NomeServicoPrest == pServPrest 
                        select c;

            db.ServicoPrest.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void DeleteObject(ServicoPrest pPrestServ)
        {
            DataBase db = GetDataBase();
            var query = from c in db.ServicoPrest
                        where c.id == pPrestServ.id
                        select c;

            db.ServicoPrest.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(ServicoPrest pServPrest)
        {
            DataBase db = GetDataBase();

            ServicoPrest servPrest = (from c in db.ServicoPrest
                            where c.id == pServPrest.id
                            select c).First();

            servPrest.NomeServicoPrest = pServPrest.NomeServicoPrest;
            

            db.SubmitChanges();
        }


    }
}
