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
        public Classificacao classific { get; set; }
        public CadastroClassif()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (classific != null)
            {
                TxtTitulo.Text = "Editar local";          
                TxtId.Text = classific.id.ToString();
                TxtClassif.Text = classific.nome;

                TxtId.IsEnabled = false;

            }

        }



        private void btnClassif_Click(object sender, RoutedEventArgs e)
        {
            if (TxtClassif.Text == string.Empty)
            {
                MessageBox.Show(" A Classificação deve ser preenchida");
                return;
            }


            if (classific != null)
            {
                classific.id = int.Parse(TxtId.Text);
                classific.nome = TxtClassif.Text;


                ClassificRepositorio.Update(classific);
                MessageBox.Show("Dados Alterados com sucesso.");
            }

            if (classific == null)
            {
                Classificacao classificacao = new Classificacao
                {
                    id = int.Parse(TxtId.Text),
                    nome = TxtClassif.Text
                };
                // Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                ClassificRepositorio.Create(classificacao);


                if (classificacao.referencia != 1)
                {
                    MessageBox.Show("Cadastrado com Sucesso.");
                }
                else
                {
                    MessageBox.Show("Esta informação já consta no banco de dados");
                }
            }















            //Classificacao classificacao = new Classificacao
            //{
            //    nome = TxtClassif.Text
            //};

            //ClassificRepositorio.Create(classificacao);

            //if (classificacao.referencia != 1)
            //{
                               
            //    MessageBox.Show("Cadastrada com Sucesso.");
            //    NavigationService.GoBack();
            //   // Navigate("/Compra.xaml"); 

            //}
            //else
            //{
            //    MessageBox.Show("Esta informação já consta no banco de dados");
            //}

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