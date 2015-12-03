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

namespace ClientBook
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }

        #region Eventos

        private void Venda_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaVenda.xaml");
        }

        private void Servico_Click(object sender, RoutedEventArgs e)
        {
            Navigate("/ListaServico.xaml");
        }

        private void Compra_Click(object sender, RoutedEventArgs e)
        {
           // Navigate("/DollarPage.xaml");
            Navigate("/ListaCompras.xaml");
        }

        #endregion
        #region Metodos
        
        
        
        private void Navigate(string p)
        {
            NavigationService.Navigate(new Uri(p, UriKind.Relative));
        }




        #endregion

        

       
    }
}