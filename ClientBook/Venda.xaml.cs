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
    public partial class Venda : PhoneApplicationPage
    {

        //Classificacao classificacao;
        //Classificacao pagina;
        VendaEntidade vendas;
        // string saveNow = DateTime.Now.ToString("dd/MM/yyyy");



        public Venda()
        {
            InitializeComponent();
            List<string> lista = Repositorio.ClassificRepositorio.GetOne();
            List<string> listaCliente = Repositorio.ClienteRepositorio.GetOne();
            List<string> listaProduto = Repositorio.ProdutoRepositorio.GetOne();


            this.lpkCliente.ItemsSource = listaCliente;
            this.lpkClassific.ItemsSource = lista;
            this.lpkProduto.ItemsSource = listaProduto;



        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<string> lista = Repositorio.ClassificRepositorio.GetOne();
            List<string> clientes = Repositorio.ClienteRepositorio.GetOne();
            List<string> produtos = Repositorio.ProdutoRepositorio.GetOne();

            this.lpkClassific.ItemsSource = lista;
            this.lpkCliente.ItemsSource = clientes;
            this.lpkProduto.ItemsSource = produtos;

        }




        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //String _Content = String.Format("Estabelecimento: {0}\n Produto: {1}\n Tipo: {2}\n Preço: R$ {3}", txtName.Text, txtProduto.Text, lpkCountry.SelectedItem, txtPreco.Text);
            //MessageBox.Show(_Content);


            if (lpkCliente.SelectedItem == null)
            {
                MessageBox.Show(" O Cliente deve ser preenchido");
                return;
            }

            if (lpkProduto.SelectedItem == null)
            {
                MessageBox.Show(" A Produto deve ser preenchido");
                return;
            }

            if (lpkClassific.SelectedItem == null)
            {
                MessageBox.Show(" A Classificação deve ser preenchida");
                return;
            }

            if (txtPreco.Text == string.Empty)
            {
                MessageBox.Show("O Preço deve ser preenchido");
                return;
            }

            if (txtQtd.Text == string.Empty)
            {
                MessageBox.Show("A Quantidade deve ser preenchida");
                return;
            }

            Double aux = (Convert.ToDouble(txtPreco.Text));
            string resultado = string.Format("{0:00.##}", aux);

            VendaEntidade cliente = new VendaEntidade
            {
                cliente = (Convert.ToString(lpkCliente.SelectedItem)),
                produto = (Convert.ToString(lpkProduto.SelectedItem)),
                classificacao = (Convert.ToString(lpkClassific.SelectedItem)),
                preco = (Convert.ToDouble(resultado)),
                Data = DateTime.Now.ToString("dd/MM/yyyy"),
                qtd = (Convert.ToInt16(txtQtd.Text))


            };

            VendaRepositorio.Create(cliente);

            MessageBox.Show("Venda Cadastrada com Sucesso.");

            Navigate("/ListaVenda.xaml");






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
            vendas = (sender as ListBox).SelectedItem as VendaEntidade;
        }

        private void lpkClassific_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Classificacao;
        }

        private void lpkProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Produto;
        }


        private void lpkCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Estabelecimento;
        }

        //private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        //{
        //    compras = (sender as ListBox).SelectedItem as CompraEntidade;
        //}




        private void btnAcess_Classific_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaClassificacao.xaml");             
        }

        private void btnAdd_Cliente_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroCliente.xaml");
        }

        private void btnAcess_Cliente_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaCliente.xaml");           

        }

        private void btnAdd_Prod_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroProd.xaml");
        }

        private void btnAcess_Prod_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaProduto.xaml");
        }



    }
}