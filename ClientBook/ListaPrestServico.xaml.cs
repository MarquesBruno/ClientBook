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
    public partial class ListaPrestServico : PhoneApplicationPage
    {
        ServicoPrest servPrest;
        //Produto prod;
        //  Estabelecimento estabelec;

        //teste
        //Classificacao pag;


        private int id = 0;

        public ListaPrestServico()
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


        private void RefreshListaPrestServico()
        {
            //ORIGINAL
            List<ServicoPrest> lista = Repositorio.ServicoPrestRepositorio.Get(id);
            lstPrestServico.ItemsSource = lista;

            #region Rascunho lista

            //teste
            //List<Classificacao> listag = Repositorio.ClassificRepositorio.Get(id);
            //lstCompras.ItemsSource = listag;


            #endregion


        }

        //ORIGINAL
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            servPrest = (sender as ListBox).SelectedItem as ServicoPrest;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastroServPrest page = e.Content as CadastroServPrest;
            if (page != null)
                page.servPrest = servPrest;

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

            if (servPrest != null)
            {
                if (MessageBox.Show("Excluir Prestação de Serviço?") == MessageBoxResult.OK)
                {
                    //ORIGINAL
                    ServicoPrestRepositorio.DeleteObject(servPrest);

                    //ClassificRepositorio.DeleteObject(pag);
                    RefreshListaPrestServico();

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
            RefreshListaPrestServico();
            //progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        private void appBarEdit(object sender, EventArgs e)
        {

            if (servPrest != null)
            {
                Navigate("/CadastroServPrest.xaml");
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