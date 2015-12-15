using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ClientBook.Resources;
using ClientBook.Entidade;
using ClientBook.Repositorio;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ClientBook
{
    public partial class ListaEstabelecimento : PhoneApplicationPage
    {
        Estabelecimento estabelec;

        //teste
        //Classificacao pag;


        private int id = 0;

        public ListaEstabelecimento()
        {
            InitializeComponent();
        }

        #region Metodos

        //protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        //{
        //    Navigate("/MainPage.xaml");

        //}


        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));

        }


        private void RefreshListaEstabelec()
        {
            //ORIGINAL
            List<Estabelecimento> lista = Repositorio.EstabelecRepositorio.Get(id);
            lstLocal.ItemsSource = lista;

            #region Rascunho lista

            //teste
            //List<Classificacao> listag = Repositorio.ClassificRepositorio.Get(id);
            //lstCompras.ItemsSource = listag;


            #endregion


        }

        //ORIGINAL
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            estabelec = (sender as ListBox).SelectedItem as Estabelecimento;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastroEstabelec page = e.Content as CadastroEstabelec;
            if (page != null)
                page.est = estabelec;

        }

        #region Rascunho OnselectChange

        //private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        //{
        //    pag = (sender as ListBox).SelectedItem as Classificacao;
        //}


        #endregion



        #endregion

        #region Eventos

        private void appBarDelete(object sender, EventArgs e)
        {

            if (estabelec != null)
            {
                if (MessageBox.Show("Excluir Estabelecimento?") == MessageBoxResult.OK)
                {
                    //ORIGINAL
                    EstabelecRepositorio.DeleteObject(estabelec);

                    //ClassificRepositorio.DeleteObject(pag);
                    RefreshListaEstabelec();

                }

            }
            else
            {
                MessageBox.Show("Selecione para excluir");
                return;
            }



        }

        private void appBarSobre_Click(object sender, EventArgs e)
        {
            Navigate("/Informacoes.xaml");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshListaEstabelec();
            //progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        private void appBarEdit(object sender, EventArgs e)
        {

            if (estabelec != null)
            {
                Navigate("/CadastroEstabelec.xaml");
            }
            else
            {
                if (MessageBox.Show("Selecione para Editar")
                    == MessageBoxResult.OK)
                { }
            }


        }
    }
}