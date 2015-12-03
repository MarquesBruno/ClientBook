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
    public class EstabelecRepositorio
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
            var query = from est in db.Estabelecimento orderby est.nome descending select est.nome;

            List<string> lista = query.ToList<string>();
            return lista;
        }

        #region teste de busca com get
        //public static List<Estabelecimento> GetOne()
        //{
        //    DataBase db = GetDataBase();
        //    var query = from est in db.Estabelecimento select est;

        //    List<Estabelecimento> lista = query.ToList<Estabelecimento>();
        //    return lista;
        //}

        #endregion






        public static List<Estabelecimento> Get(int pEstabelec)
        {
            DataBase db = GetDataBase();
            var query = from est in db.Estabelecimento orderby est.id descending select est;

            List<Estabelecimento> lista = new List<Estabelecimento>(query.AsEnumerable());


            // aqui deve-se criar um for para inserir os dados da linha em um objeto
            return lista;
        }


        public static void Create(Estabelecimento pEstabelec)
        {
            int ponto = 0;
            DataBase db = GetDataBase();
            var query = from est in db.Estabelecimento orderby est.nome descending select est;
            List<Estabelecimento> lista = new List<Estabelecimento>(query.AsEnumerable());

            foreach (var item in lista)
            {
                if (item.nome.Equals(pEstabelec.nome, StringComparison.OrdinalIgnoreCase))
                {
                    ponto = 1;
                }
            }
            if (ponto == 0)
            {
                db.Estabelecimento.InsertOnSubmit(pEstabelec);
                db.SubmitChanges();
            }
            else
            {
                pEstabelec.referencia = 1;
            }
        }

        public static void Delete(string pEstabelec)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Estabelecimento
                        where c.nome == pEstabelec
                        select c;

            db.Estabelecimento.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void DeleteObject(Estabelecimento pEstabelec)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Estabelecimento
                        where c.id == pEstabelec.id
                        select c;

            db.Estabelecimento.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }



        public static void Update(Estabelecimento pEstabelec)
        {
            DataBase db = GetDataBase();

            Estabelecimento est = (from c in db.Estabelecimento
                                   where c.id == pEstabelec.id
                                   select c).First();

            est.nome = pEstabelec.nome;
            est.endereco = pEstabelec.endereco;
            est.telefone = pEstabelec.telefone;

            db.SubmitChanges();
        }




    }
}
