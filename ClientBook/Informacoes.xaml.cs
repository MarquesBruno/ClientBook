using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace ClientBook
{
    public partial class Informacoes : PhoneApplicationPage
    {
        public Informacoes()
        {
            InitializeComponent();
        }

        #region Pagina1


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            #region Sobre
            TxtSobre.Text = null;
            TxtSobre.Text = "A ClientBook é um aplicativo móvel que tem como foco proporcionar ao usuário um controle de seus serviços prestados e de suas vendas.";

            #endregion

            #region Ajuda
            TxtInfo1.Text = "Com este aplicativo é possível controlar de forma mais eficiente os serviços/ vendas prestados pelos trabalhadores autônomos. ";
            TxtInfo.Text = "Abaixo segue os principais comandos :";
            TxtAdd.Text = "  Adiciona novo item;";
            TxtEdit.Text = "  Editar item;";
            TxtDelete.Text = "  Excluir item;";
            TxtCheck.Text = "  Acessar item;";
           // TxtFavorito.Text = "  Adiciona Favorito;";
            //TxtHelp.Text = "Informações do App;";
            TxtAvalia.Text = "  Avalia o App;";
            TxtEquip.Text = "  Equipe;";
           //TxtAcesFav.Text = "  Acessar Favorito.";
            #endregion

            #region Equipe
            TxtDes.Text = "DESENVOLVEDOR";
            TxtBruno.Text = "Bruno Marques";
            TxtApoio.Text = "COORDENADOR";
            TxtApoio1.Text = "Vinicius Magnus";
            #endregion


        }

        #endregion

        private void appBarLike_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }




    }
}