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
    public partial class ListaServico : PhoneApplicationPage
    {
        ServicoEntidade pagina;

        //teste
        //Classificacao pag;


        private int id = 0;

        public ListaServico()
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


        private void RefreshListaServico()
        {
            //ORIGINAL
            List<ServicoEntidade> lista = Repositorio.ServicoRepositorio.Get(id);
            lstServicos.ItemsSource = lista;

        }

        //ORIGINAL
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pagina = (sender as ListBox).SelectedItem as ServicoEntidade;
        }






        #endregion

        #region Eventos

        private void appBarDelete(object sender, EventArgs e)
        {

            if (pagina != null)
            {
                if (MessageBox.Show("Excluir Servico?") == MessageBoxResult.OK)
                {
                    //ORIGINAL
                    ServicoRepositorio.DeleteObject(pagina);

                    //ClassificRepositorio.DeleteObject(pag);
                    RefreshListaServico();

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
            RefreshListaServico();
        }

        #endregion

        private void appBarAdd(object sender, EventArgs e)
        {
            Navigate("/Servico.xaml");
        }
    }
}