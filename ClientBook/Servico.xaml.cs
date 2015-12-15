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
    public partial class Servico : PhoneApplicationPage
    {

        //Classificacao classificacao;
        //Classificacao pagina;
        ServicoEntidade servico;
        // string saveNow = DateTime.Now.ToString("dd/MM/yyyy");



        public Servico()
        {
            InitializeComponent();
            List<string> lista = Repositorio.ClassificRepositorio.GetOne();
            List<string> listaCliente = Repositorio.ClienteRepositorio.GetOne();
            List<string> listaServico = Repositorio.ServicoPrestRepositorio.GetOne();


            this.lpkCliente.ItemsSource = listaCliente;
            this.lpkClassific.ItemsSource = lista;
            this.lpkServico.ItemsSource = listaServico;



        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            List<string> lista = Repositorio.ClassificRepositorio.GetOne();
            List<string> clientes = Repositorio.ClienteRepositorio.GetOne();
            List<string> servicos = Repositorio.ServicoPrestRepositorio.GetOne();

            this.lpkClassific.ItemsSource = lista;
            this.lpkCliente.ItemsSource = clientes;
            this.lpkServico.ItemsSource = servicos;

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

            if (lpkServico.SelectedItem == null)
            {
                MessageBox.Show(" A Serviço deve ser preenchido");
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

            //if (txtQtd.Text == string.Empty)
            //{
            //    MessageBox.Show("A Quantidade deve ser preenchida");
            //    return;
            //}

            Double aux = (Convert.ToDouble(txtPreco.Text));
            string resultado = string.Format("{0:00.##}", aux);

            ServicoEntidade servico = new ServicoEntidade
            {
                cliente = (Convert.ToString(lpkCliente.SelectedItem)),
                NomeServicoPrest = (Convert.ToString(lpkServico.SelectedItem)),
                classificacao = (Convert.ToString(lpkClassific.SelectedItem)),
                preco = (Convert.ToDouble(resultado)),
                Data = DateTime.Now.ToString("dd/MM/yyyy")


            };

            ServicoRepositorio.Create(servico);

            MessageBox.Show("Servico Cadastrado com Sucesso.");

            Navigate("/ListaServico.xaml");






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
            servico = (sender as ListBox).SelectedItem as ServicoEntidade;
        }

        private void lpkClassific_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Classificacao;
        }

        private void lpkServ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as Servico;
        }


        private void lpkCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object pagina = (sender as ListPicker).SelectedItem as ClienteEntidade;
        }

        //private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        //{
        //    compras = (sender as ListBox).SelectedItem as CompraEntidade;
        //}




        private void btnAcess_Classific_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaClassificacao.xaml");
            //try
            //{
            //    if (MessageBox.Show("Excluir Classificação " + lpkClassific.SelectedItem + "?") == MessageBoxResult.OK)
            //    {

            //        string nome = lpkClassific.SelectedItem.ToString();
            //        ClassificRepositorio.Delete(nome);
            //        Refresh();


            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Selecione para excluir");
            //    return;
            //}




        }

        private void btnAdd_Cliente_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroCliente.xaml");
        }

        private void btnAcess_Cliente_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaCliente.xaml");
            //try
            //{
            //    if (MessageBox.Show("Excluir Cliente " + lpkCliente.SelectedItem + "?") == MessageBoxResult.OK)
            //    {

            //        string nome = lpkCliente.SelectedItem.ToString();
            //        ClienteRepositorio.Delete(nome);
            //        Refresh();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Selecione uma Cliente para excluir");
            //    return;
            //}

        }
        
        private void btnAdd_Serv_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/CadastroServPrest.xaml");
        }

        private void btnAcess_Serv_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaPrestServico.xaml");
            //try
            //{
            //    if (MessageBox.Show("Excluir Servico " + lpkServico.SelectedItem + "?") == MessageBoxResult.OK)
            //    {

            //        string nome = lpkServico.SelectedItem.ToString();
            //        ServicoPrestRepositorio.Delete(nome);
            //        Refresh();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Selecione um Servico para excluir");
            //    return;
            //}

        }



    }
}