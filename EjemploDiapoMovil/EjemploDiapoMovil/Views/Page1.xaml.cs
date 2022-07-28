using EjemploDiapoMovil.Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EjemploDiapoMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        BlockchainHighLevel BE = new BlockchainHighLevel();
        public Page1()
        {
            InitializeComponent();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //agregar el bloque y actualizar el editor con el nuevo listado de bloques
            BE.AddBlock(txtContenido.Text);
            ActualizaListado(); //Aqui estoy yo :D 
        }
        private void ActualizaListado()
        {
            respuesta.Text = "";
            int itemNumber = 0;
            string temp = "";
            foreach (var item in BE.Blockchain)
            {

                temp += "---------------------------\n";
                temp += "Block Height: " + itemNumber+ "\n";
                temp += "Block Hash: " + item.HashR + "\n";
                temp += "Previous Hash: " + item.PreviousHashR + "\n";
                temp += "Transaction Data: " + item.Data + "\n";
                temp += "Nonce: " + item.Nonce + "\n";
                temp += "---------------------------\n";
                temp += "" + "\n";
                itemNumber++;
            }
            respuesta.Text = temp;
            txtContenido.Text = "";
        }
    }
}