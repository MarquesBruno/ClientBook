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
    public partial class ListaClassificacao : PhoneApplicationPage
    {
        Classificacao classific;
        //Produto prod;
        //  Estabelecimento estabelec;

        //teste
        //Classificacao pag;


        private int id = 0;

        public ListaClassificacao()
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


        private void RefreshListaClassificacao()
        {
            //ORIGINAL
            List<Classificacao> lista = Repositorio.ClassificRepositorio.Get(id);
            lstClassific.ItemsSource = lista;

            #region Rascunho lista

            //teste
            //List<Classificacao> listag = Repositorio.ClassificRepositorio.Get(id);
            //lstCompras.ItemsSource = listag;


            #endregion


        }

        //ORIGINAL
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            classific = (sender as ListBox).SelectedItem as Classificacao;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastroClassif page = e.Content as CadastroClassif;
            if (page != null)
                page.classific = classific;

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

            if (classific != null)
            {
                if (MessageBox.Show("Excluir Classificação?") == MessageBoxResult.OK)
                {
                    //ORIGINAL
                    ClassificRepositorio.DeleteObject(classific);

                    //ClassificRepositorio.DeleteObject(pag);
                    RefreshListaClassificacao();

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
            RefreshListaClassificacao();
            //progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        private void appBarEdit(object sender, EventArgs e)
        {

            if (classific != null)
            {
                Navigate("/CadastroClassif.xaml");
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