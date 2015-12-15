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
    public class ClienteRepositorio
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
            var query = from cli in db.Cliente orderby cli.id descending select cli.nomeCliente;

            List<string> lista = query.ToList<string>();

            return lista;
        }

        public static List<ClienteEntidade> Get(int pCliente)
        {
            DataBase db = GetDataBase();
            var query = from cli in db.Cliente orderby cli.id descending select cli;

            List<ClienteEntidade> lista = new List<ClienteEntidade>(query.AsEnumerable());
            return lista;
        }

        public static void Create(ClienteEntidade pCliente)
        {
            int ponto = 0;
            DataBase db = GetDataBase();
            var query = from cli in db.Cliente orderby cli.nomeCliente descending select cli;
            List<ClienteEntidade> lista = new List<ClienteEntidade>(query.AsEnumerable());

            foreach (var item in lista)
            {
                if (item.nomeCliente.Equals(pCliente.nomeCliente, StringComparison.OrdinalIgnoreCase))
                {
                    ponto = 1;
                }
            }
            if (ponto == 0)
            {
                db.Cliente.InsertOnSubmit(pCliente);
                db.SubmitChanges();
            }
            else
            {
                pCliente.referencia = 1;
            }

        }

        public static void Delete(string pCliente)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Cliente
                        where c.nomeCliente == pCliente
                        select c;

            db.Cliente.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void DeleteObject(ClienteEntidade pCliente)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Cliente
                        where c.id == pCliente.id
                        select c;

            db.Cliente.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(ClienteEntidade pCliente)
        {
            DataBase db = GetDataBase();

            ClienteEntidade est = (from c in db.Cliente
                                   where c.id == pCliente.id
                                   select c).First();

            est.nomeCliente = pCliente.nomeCliente;
            est.endereco = pCliente.endereco;
            est.telefone = pCliente.telefone;

            db.SubmitChanges();
        }




    }
}
