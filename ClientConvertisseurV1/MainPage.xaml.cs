using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ActionGetData();
            
        }

        void Conv_Click(object sender, RoutedEventArgs e)
        {
            if (this.ComboDevise.SelectedIndex > -1 && this.TextEuro.Text != "")
            {
                var devise = (Devise)this.ComboDevise.SelectedItem;
                var tauxDevise = devise.Taux;

                var euros = Double.Parse(this.TextEuro.Text);

                this.TextDevise.Text = Convert.ToString(tauxDevise * euros);
            }            
        }
    
        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void ActionGetData()
        {
            var result = await WSService.getAllDevisesAsync();
            this.ComboDevise.DataContext = new List<Devise>(result);
        }
        
    }
}
