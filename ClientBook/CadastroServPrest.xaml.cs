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
    public partial class CadastroServPrest : PhoneApplicationPage
    {
        public ServicoPrest servPrest { get; set; }
        public CadastroServPrest()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (servPrest != null)
            {
                TxtId.Text = servPrest.id.ToString();

                TxtTitulo.Text = "Editar local";
                TxtNomeServ.Text = servPrest.NomeServicoPrest;               

                TxtId.IsEnabled = false;

            }

        }



        private void btnServ_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNomeServ.Text == string.Empty)
            {
                MessageBox.Show(" O Serviço deve ser preenchido");
                return;
            }



            if (servPrest != null)
            {
                servPrest.id = int.Parse(TxtId.Text);
                servPrest.NomeServicoPrest = TxtNomeServ.Text;

                ServicoPrestRepositorio.Update(servPrest);
                MessageBox.Show("Dados Alterados com sucesso.");
            }

            if (servPrest == null)
            {
                ServicoPrest servicoPrestado = new ServicoPrest
                {
                    id = int.Parse(TxtId.Text),
                    NomeServicoPrest = TxtNomeServ.Text,

                };
                // Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                ServicoPrestRepositorio.Create(servicoPrestado);





                //ServicoPrestRepositorio.Create(servicoPrest);

                if (servicoPrestado.referencia != 1)
                {
                    MessageBox.Show("Cadastrado com Sucesso.");
                }
                else
                {
                    MessageBox.Show("Esta informação já consta no banco de dados");
                }              

            }
            NavigationService.GoBack();
        }

        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }
    }
}