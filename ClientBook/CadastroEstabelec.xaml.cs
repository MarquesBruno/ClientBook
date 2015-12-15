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
    public partial class CadastroEstabelec : PhoneApplicationPage
    {
        public Estabelecimento est { get; set; }
        public CadastroEstabelec()
        {
            InitializeComponent();

        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastroEstabelec page = e.Content as CadastroEstabelec;

            // if (est.referencia == 2)
            if (est != null)
            {
                TxtId.Text = est.id.ToString();
                TxtEstabelec.Text = est.nome;
                TxtEndereco.Text = est.endereco;
                TxtTelefone.Text = est.telefone;

                TxtId.IsEnabled = false;

            }

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (est != null)
            {
                TxtTitulo.Text = "Editar local";
                TxtId.Text = est.id.ToString();
                TxtEstabelec.Text = est.nome;
                TxtEndereco.Text = est.endereco;
                TxtTelefone.Text = est.telefone;

                TxtId.IsEnabled = false;

            }

        }













        private void btnEstabelec_Click(object sender, RoutedEventArgs e)
        {

            if (TxtEstabelec.Text == string.Empty)
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
                est.nome = TxtEstabelec.Text;
                est.endereco = TxtEndereco.Text;
                est.telefone = TxtTelefone.Text;

                EstabelecRepositorio.Update(est);
                MessageBox.Show("Dados Alterados com sucesso.");
            }

            if (est == null)
            {
                Estabelecimento local = new Estabelecimento
                {
                    id = int.Parse(TxtId.Text),
                    nome = TxtEstabelec.Text,
                    endereco = TxtEndereco.Text,
                    telefone = TxtTelefone.Text

                };
                // Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                EstabelecRepositorio.Create(local);
                MessageBox.Show("Estabelecimento Cadastrado com Sucesso.");
            }





            NavigationService.GoBack();

        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }
    }
}