using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ClientBook.Entidade;
using ClientBook.Repositorio;

namespace ClientBook
{
    public partial class CadastroProd : PhoneApplicationPage
    {
        public Produto prod { get; set; }
        public CadastroProd()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (prod != null)
            {
                

                TxtTitulo.Text = "Editar local";
                TxtId.Text = prod.id.ToString();
                TxtNomeProd.Text = prod.NomeProduto;
                TxtMarca.Text = prod.marca;

                TxtId.IsEnabled = false;

            }

        }


        private void btnProd_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNomeProd.Text == string.Empty)
            {
                MessageBox.Show(" O Nome deve ser preenchido");
                return;
            }

            if (TxtMarca.Text == string.Empty)
            {
                MessageBox.Show(" A Marca deve ser preenchida");
                return;
            }



            if (prod != null)
            {
                prod.id = int.Parse(TxtId.Text);
                prod.NomeProduto = TxtNomeProd.Text;
                prod.marca = TxtMarca.Text;

                ProdutoRepositorio.Update(prod);
                MessageBox.Show("Dados Alterados com sucesso.");
            }

            if (prod == null)
            {
                Produto produtos = new Produto
                {
                    id = int.Parse(TxtId.Text),
                    NomeProduto = TxtNomeProd.Text,
                    marca = TxtMarca.Text

                };
                // Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                ProdutoRepositorio.Create(produtos);


                if (produtos.referencia != 1)
                {
                    MessageBox.Show("Cadastrado com Sucesso.");
                }
                else
                {
                    MessageBox.Show("Esta informação já consta no banco de dados");
                }
            }


            //Produto produto = new Produto
            //{
            //    NomeProduto = TxtNomeProd.Text,
            //    marca = TxtMarca.Text

            //};

            //ProdutoRepositorio.Create(produto);

            //if (produto.referencia != 1)
            //{
            //    MessageBox.Show("Cadastrado com Sucesso.");
            //}
            //else
            //{
            //    MessageBox.Show("Esta informação já consta no banco de dados");
            //}

            NavigationService.GoBack();

        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }
    }
}