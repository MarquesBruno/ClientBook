using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ClientBook.Entidade;
using ClientBook.Repositorio;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ClientBook
{
    public partial class ListaVenda : PhoneApplicationPage
    {
        VendaEntidade pagina;

        //teste
        //Classificacao pag;


        private int id = 0;

        public ListaVenda()
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


        private void RefreshListaVendas()
        {
            //ORIGINAL
            List<VendaEntidade> lista = Repositorio.VendaRepositorio.Get(id);
            lstVendas.ItemsSource = lista;

        }

        //ORIGINAL
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pagina = (sender as ListBox).SelectedItem as VendaEntidade;
        }






        #endregion

        #region Eventos

        private void appBarDelete(object sender, EventArgs e)
        {

            if (pagina != null)
            {
                if (MessageBox.Show("Excluir Venda?") == MessageBoxResult.OK)
                {
                    //ORIGINAL
                    VendaRepositorio.DeleteObject(pagina);

                    //ClassificRepositorio.DeleteObject(pag);
                    RefreshListaVendas();

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
            RefreshListaVendas();
        }

        #endregion

        private void appBarAdd(object sender, EventArgs e)
        {
            Navigate("/Venda.xaml");
        }
    }
}