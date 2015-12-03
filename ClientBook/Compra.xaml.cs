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
       // string saveNow = DateTime.Now.ToString("dd/MM/yyyy");



        public Compra()
        {
            InitializeComponent();
            List<string> lista = Repositorio.ClassificRepositorio.GetOne();
            List<string> listaEstabelec = Repositorio.EstabelecRepositorio.GetOne();
            List<string> listaProduto = Repositorio.ProdutoRepositorio.GetOne();


            this.lpkEstabelecimento.ItemsSource = listaEstabelec;
            this.lpkClassific.ItemsSource = lista;
            this.lpkProduto.ItemsSource = listaProduto;



        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<String> lista = Repositorio.ClassificRepositorio.GetOne();
            List<string> estabelecimentos = Repositorio.EstabelecRepositorio.GetOne();
            List<string> produtos = Repositorio.ProdutoRepositorio.GetOne();

            this.lpkClassific.ItemsSource = lista;
            this.lpkEstabelecimento.ItemsSource = estabelecimentos;
            this.lpkProduto.ItemsSource = produtos;




        }




        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //String _Content = String.Format("Estabelecimento: {0}\n Produto: {1}\n Tipo: {2}\n Preço: R$ {3}", txtName.Text, txtProduto.Text, lpkCountry.SelectedItem, txtPreco.Text);
            //MessageBox.Show(_Content);


            if (lpkEstabelecimento.SelectedItem == null)
            {
                MessageBox.Show(" A Estabelecimento deve ser preenchido");
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

            CompraEntidade compra = new CompraEntidade
            {
                estabelecimento = (Convert.ToString(lpkEstabelecimento.SelectedItem)),
                produto = (Convert.ToString(lpkProduto.SelectedItem)),
                classificacao = (Convert.ToString(lpkClassific.SelectedItem)),
                preco = (Convert.ToDouble(resultado)),       
                Data = DateTime.Now.ToString("dd/MM/yyyy"),
                qtd = (Convert.ToInt16(txtQtd.Text))
                

            };

            CompraRepositorio.Create(compra);

            MessageBox.Show("Compra Cadastrada com Sucesso.");

            Navigate("/ListaCompras.xaml");






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

        private void lpkClassific_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Classificacao;
        }

        private void lpkProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Produto;
        }


        private void lpkEstabelec_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void btnAdd_Estabelec_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroEstabelec.xaml");
        }

        private void btnAcess_Estabelec_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaEstabelecimento.xaml");
            //try
            //{
            //    if (MessageBox.Show("Excluir Estabelecimento " + lpkEstabelecimento.SelectedItem + "?") == MessageBoxResult.OK)
            //    {
            //        string nome = lpkEstabelecimento.SelectedItem.ToString();
            //        EstabelecRepositorio.Delete(nome);
            //        Refresh();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Selecione uma Estabelecimento para excluir");
            //    return;
            //}

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