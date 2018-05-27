using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace GalgjeLib.Services
{
    public class ControlsServices
    {

        //public List<Button> buttons;
        public List<Button> Buttons { get; set; }
        public Button StartNewGame { get; set; }
        public Button RestartNewGame { get; set; }
        public List<Label> Labels { get; set; }
        public bool antwoordCorrect { get; set; }
        public ControlsServices()
        {
            Buttons = new List<Button>();
            Labels = new List<Label>();
        }
        public void AddButtons(WrapPanel doel)
        {
            for (int letter = (int)'A'; letter <= (int)'Z'; letter++)
            {
                Button b = new Button();
                b.Content = ((char)letter).ToString();
                b.Height = 40;
                b.Width = 40;
                b.FontSize = 20;
                b.Background = Brushes.LawnGreen;
                doel.Children.Add(b);
                Buttons.Add(b);
            }
            //wrpLettersWrap.IsEnabled = false;
        }

        public bool ControleerLabels()
        {
            antwoordCorrect = true;
            foreach (Label label in Labels)
            {
                if ((string)label.Content == "_")
                {
                    antwoordCorrect = true;
                    break;
                }
                else
                {
                    antwoordCorrect = false;
                }   
            }
            return antwoordCorrect;



        }

        public void AddLabels(WrapPanel doel, string gezochtWoord, TextBox groot)
        {
            doel.Children.Clear();
            char[] woordChars = gezochtWoord.ToCharArray();

            int lengte = woordChars.Length -1;

            for (int i = 0; i < lengte; i++)
            {
                Label l = new Label();
                l.FontSize = 30;
                l.Content = "_";  // <<<-------- = woordChars[i] geeft alle letters weer ipv underscores
                l.BringIntoView();
                doel.Children.Add(l);
                Labels.Add(l);

            }
            groot.Text = lengte.ToString();

        }

        public void StartScherm(Grid gridDoel)
        {
            Label StartLabel = new Label();
            StartLabel.Height = 450;
            StartLabel.Width = 800;
            StartLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            StartLabel.VerticalContentAlignment = VerticalAlignment.Center; 
            StartLabel.Background = Brushes.Green;
            gridDoel.Children.Add(StartLabel);

            Label Galgje = new Label();
            Galgje.Height = 200;
            Galgje.Width = 400;
            Galgje.Content = "Galgje";
            Galgje.VerticalAlignment = VerticalAlignment.Top;
            Galgje.Margin = new Thickness(0, 20, 0, 0);
            Galgje.HorizontalContentAlignment = HorizontalAlignment.Center;
            Galgje.VerticalContentAlignment = VerticalAlignment.Center;
            Galgje.FontSize = 100;
            gridDoel.Children.Add(Galgje);

            Button StartSpel = new Button();
           
            StartSpel.Height = 50;
            StartSpel.Width = 200;
            StartSpel.Content = "New Game";
            StartSpel.HorizontalAlignment = HorizontalAlignment.Center;
            StartSpel.VerticalAlignment = VerticalAlignment.Top;
            StartSpel.FontSize = 30;
            StartSpel.Margin = new Thickness(0, 220, 0, 0);
            StartSpel.HorizontalContentAlignment = HorizontalAlignment.Center;
            StartSpel.VerticalContentAlignment = VerticalAlignment.Center;
            gridDoel.Children.Add(StartSpel);
            StartNewGame = StartSpel;
    
            
        }

        public void Winsituatie(Grid gridDoel,string winOrLose)
        {
            Label StartLabel = new Label();
            StartLabel.Height = 450;
            StartLabel.Width = 800;
            StartLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            StartLabel.VerticalContentAlignment = VerticalAlignment.Center;
            StartLabel.Background = Brushes.Green;
            gridDoel.Children.Add(StartLabel);

            Label Galgje = new Label();
            Galgje.Height = 200;
            Galgje.Width = 800;
            Galgje.Content = winOrLose;
            Galgje.VerticalAlignment = VerticalAlignment.Top;
            Galgje.Margin = new Thickness(0, 20, 0, 0);
            Galgje.HorizontalContentAlignment = HorizontalAlignment.Center;
            Galgje.VerticalContentAlignment = VerticalAlignment.Center;
            Galgje.FontSize = 100;
            gridDoel.Children.Add(Galgje);

            Button StartSpel = new Button();

            StartSpel.Height = 50;
            StartSpel.Width = 300;
            StartSpel.Content = "Restart New Game";
            StartSpel.HorizontalAlignment = HorizontalAlignment.Center;
            StartSpel.VerticalAlignment = VerticalAlignment.Top;
            StartSpel.FontSize = 30;
            StartSpel.Margin = new Thickness(0, 220, 0, 0);
            StartSpel.HorizontalContentAlignment = HorizontalAlignment.Center;
            StartSpel.VerticalContentAlignment = VerticalAlignment.Center;
            gridDoel.Children.Add(StartSpel);
            RestartNewGame = StartSpel;
        }

    }
}
