﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClientBook.Banco;
using ClientBook.Entidade;

namespace ClientBook.Repositorio
{
    public class ClassificRepositorio
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
            var query = from clas in db.Classificacao orderby clas.id descending select clas.nome;

            List<string> lista = query.ToList<string>();
            //  List<Classificacao> lista = new List<Classificacao>(lista);

            //  List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
            return lista;
        }

        public static List<Classificacao> Get(int pClassific)
        {
            DataBase db = GetDataBase();
            var query = from clas in db.Classificacao orderby clas.id descending select clas;

            List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());
            return lista;
        }

        public static void Create(Classificacao pClassific)
        {
            int ponto = 0;

            DataBase db = GetDataBase();
            var query = from clas in db.Classificacao orderby clas.nome descending select clas;

            List<Classificacao> lista = new List<Classificacao>(query.AsEnumerable());


            foreach (var item in lista)
            {

                // if (item.nome.Equals(pClassific.nome))
                if (item.nome.Equals(pClassific.nome, StringComparison.OrdinalIgnoreCase))
                {
                    ponto = 1;

                }

            }


            if (ponto == 0)
            {
                db.Classificacao.InsertOnSubmit(pClassific);
                db.SubmitChanges();
            }
            else
            {
                pClassific.referencia = 1;

            }



        }

        public static void Delete(string pClassific)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Classificacao
                        where c.nome == pClassific
                        select c;

            db.Classificacao.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }



        public static void DeleteObject(Classificacao pClassific)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Classificacao
                        where c.id == pClassific.id
                        select c;

            db.Classificacao.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(Classificacao pClassific)
        {
            DataBase db = GetDataBase();

            Classificacao classf = (from c in db.Classificacao
                            where c.id == pClassific.id
                            select c).First();

            classf.nome = pClassific.nome;

            db.SubmitChanges();
        }




    }
}
