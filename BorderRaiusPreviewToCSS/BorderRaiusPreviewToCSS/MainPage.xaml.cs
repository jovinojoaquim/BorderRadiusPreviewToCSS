using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BorderRaiusPreviewToCSS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        double SE = 0;
        double SD = 0;
        double IE = 0;
        double ID = 0;
        CornerRadius cr;

        public MainPage()
        {
            InitializeComponent();
            SE = box.CornerRadius.TopLeft;
            SD = box.CornerRadius.TopRight;
            IE = box.CornerRadius.BottomLeft;
            ID = box.CornerRadius.BottomRight;
        }

        private void OnTextBSE(object sender, TextChangedEventArgs e)
        {
            Entry campo = (Entry)sender;
            try
            {
                double.Parse(campo.Text);

                if (campo.Text != "" && campo.Placeholder.Contains("Superior Esquerda") == true)
                    SE = double.Parse(campo.Text);
                else if (campo.Text == "" && campo.Placeholder.Contains("Superior Esquerda") == true)
                    SE = 0;


                if (campo.Text != "" && campo.Placeholder.Contains("Superior Direita") == true)
                    SD = double.Parse(campo.Text);
                else if (campo.Text == "" && campo.Placeholder.Contains("Superior Direita") == true)
                    SD = 0;

                if (campo.Text != "" && campo.Placeholder.Contains("Inferior Esquerda") == true)
                    IE = double.Parse(campo.Text);
                else if (campo.Text == "" && campo.Placeholder.Contains("Inferior Esquerda") == true)
                    IE = 0;


                if (campo.Text != "" && campo.Placeholder.Contains("Inferior Direita") == true)
                    ID = double.Parse(campo.Text);
                else if (campo.Text == "" && campo.Placeholder.Contains("Inferior Direita") == true)
                    ID = 0;

                box.CornerRadius = new CornerRadius(SE, SD, IE, ID);
            }
            catch (Exception ex) {
                campo.Text = campo.Text.Replace(campo.Text.LastOrDefault(), ' ').Trim();
                DisplayAlert("ERRO", "Digite apenas caractere numérico", "OK");
            };

        }

        private async void CopiarParaCSS(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("border-top-left-radius: " + box.CornerRadius.TopLeft.ToString().Trim() + "px;\n");
            sb.Append("border-top-rigth-radius: " + box.CornerRadius.TopRight.ToString().Trim() + "px;\n");
            sb.Append("border-bottom-left-radius: " + box.CornerRadius.BottomLeft.ToString().Trim() + "px;\n");
            sb.Append("border-bottom-rigth-radius: " + box.CornerRadius.BottomRight.ToString().Trim() + "px;\n");

            await Clipboard.SetTextAsync(sb.ToString());
        }
    }
}
