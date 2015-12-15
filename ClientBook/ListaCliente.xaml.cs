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
    public partial class ListaCliente : PhoneApplicationPage
    {
        ClienteEntidade client;
        //Estabelecimento estabelec;

        //teste
        //Classificacao pag;


        private int id = 0;

        public ListaCliente()
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


        private void RefreshListaCliente()
        {
            //ORIGINAL
            List<ClienteEntidade> lista = Repositorio.ClienteRepositorio.Get(id);
            lstCliente.ItemsSource = lista;

            #region Rascunho lista

            //teste
            //List<Classificacao> listag = Repositorio.ClassificRepositorio.Get(id);
            //lstCompras.ItemsSource = listag;


            #endregion


        }

        //ORIGINAL
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            client = (sender as ListBox).SelectedItem as ClienteEntidade;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastroCliente page = e.Content as CadastroCliente;
            if (page != null)
                page.est = client;

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

            if (client != null)
            {
                if (MessageBox.Show("Excluir Cliente?") == MessageBoxResult.OK)
                {
                    //ORIGINAL
                    ClienteRepositorio.DeleteObject(client);

                    //ClassificRepositorio.DeleteObject(pag);
                    RefreshListaCliente();

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
            RefreshListaCliente();
            //progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        private void appBarEdit(object sender, EventArgs e)
        {

            if (client != null)
            {
                Navigate("/CadastroCliente.xaml");
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