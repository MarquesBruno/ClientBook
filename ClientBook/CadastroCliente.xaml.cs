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
    public partial class CadastroCliente : PhoneApplicationPage
    {
        public ClienteEntidade est { get; set; }
        public CadastroCliente()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (est != null)
            {
                TxtTitulo.Text = "Editar Local";
                TxtId.Text = est.id.ToString();
                TxtCliente.Text = est.nomeCliente; 
                TxtEndereco.Text = est.nomeCliente;
                TxtTelefone.Text = est.telefone;

                TxtId.IsEnabled = false;

            }

        }



        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {

            if (TxtCliente.Text == string.Empty)
            {
                MessageBox.Show(" O Nome deve ser preenchido");
                return;
            }

            if (TxtEndereco.Text == string.Empty)
            {
                MessageBox.Show(" O Endereço deve ser preenchido");
                return;
            }

            if (TxtTelefone.Text == string.Empty)
            {
                MessageBox.Show(" O Telefone deve ser preenchido");
                return;
            }



            if (est != null)
            {
                est.id = int.Parse(TxtId.Text);
                est.nomeCliente = TxtCliente.Text;
                est.endereco = TxtEndereco.Text;
                est.telefone = TxtTelefone.Text;

                ClienteRepositorio.Update(est);
                MessageBox.Show("Dados Alterados com sucesso.");
            }

            if (est == null)
            {
                ClienteEntidade clientes = new ClienteEntidade
                {
                    id = int.Parse(TxtId.Text),
                    nomeCliente = TxtCliente.Text,
                    endereco = TxtEndereco.Text,
                    telefone = TxtTelefone.Text

                };
                // Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                ClienteRepositorio.Create(clientes);
                MessageBox.Show("Cliente Cadastrado com Sucesso.");
            }



            NavigationService.GoBack();

        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }
    }
}