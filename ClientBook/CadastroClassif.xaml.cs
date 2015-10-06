using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ClientBook.Repositorio;
using ClientBook.Entidade;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ClientBook
{
    public partial class CadastroClassif : PhoneApplicationPage
    {
        public CadastroClassif()
        {
            InitializeComponent();
        }

        private void btnClassif_Click(object sender, RoutedEventArgs e)
        {
            if (TxtClassif.Text == string.Empty)
            {
                MessageBox.Show(" A Classificação deve ser preenchida");
                return;
            }



            Classificacao classificacao = new Classificacao
            {
                nome = TxtClassif.Text
            };

            ClassificRepositorio.Create(classificacao);

            if (classificacao.referencia != 1)
            {
                               
                MessageBox.Show("Cadastrada com Sucesso.");
                NavigationService.GoBack();
               // Navigate("/Compra.xaml"); 

            }
            else
            {
                MessageBox.Show("Esta informação já consta no banco de dados");
            }

            //ClassificRepositorio.Create(classificacao);
            //MessageBox.Show("Cadastrada com Sucesso.");


            NavigationService.GoBack();
        }

        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));

        }
    }
}