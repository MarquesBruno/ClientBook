using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ClientBook.Resources;
using System.Windows.Media;
using System.Windows.Input;
using ClientBook.Entidade;
using ClientBook.Repositorio;

namespace ClientBook
{
    public partial class Compra : PhoneApplicationPage
    {

        Classificacao classificacao;
        Classificacao pagina;
        CompraEntidade compras;
        public Compra()
        {
            InitializeComponent();
            List<string> lista = Repositorio.CompraRepositorio.GetOne();
            this.lpkCountry.ItemsSource = lista;



        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<String> disciplinas = Repositorio.CompraRepositorio.GetOne();
            this.lpkCountry.ItemsSource = disciplinas;



        }




        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            String _Content = String.Format("Estabelecimento: {0}\n Produto: {1}\n Tipo: {2}\n Preço: R$ {3}", txtName.Text, txtAges.Text, lpkCountry.SelectedItem, txtPreco.Text);


            MessageBox.Show(_Content);

        }

        private void btnClassificar_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroClassif.xaml");
        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }
        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            compras = (sender as ListBox).SelectedItem as CompraEntidade;
        }

        private void lpkCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Classificacao;
        }

        //private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        //{
        //    compras = (sender as ListBox).SelectedItem as CompraEntidade;
        //}




        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

                if (compras != null)
                {
                    if (MessageBox.Show("Excluir Favorito ?") == MessageBoxResult.OK)
                    {
                        CompraRepositorio.Delete(compras.id);                        
                    }

                }
                else
                {
                    MessageBox.Show("Selecione para excluir");
                    return;
                }
                
            
            

        }



    }
}