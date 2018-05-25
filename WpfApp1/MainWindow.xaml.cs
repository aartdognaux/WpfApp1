using GalgjeLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using GalgjeLib.Services;
using GalgjeLib.Entities;



namespace Galgje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        WoordServices WilkeurigWoord = new WoordServices();
        ControlsServices controlsServices = new ControlsServices();
        public MainWindow()
        {
            InitializeComponent();
            MaakButtons();

        }

        public string gezochtWoord;
        char verborgen = '_';
        int AantalFouten = 0;
        List<Label> labels = new List<Label>();
        List<Button> buttons = new List<Button>();


        //void AddButtons(WrapPanel doel)
        //{
        //    for (int letter = (int)'A'; letter <= (int)'Z'; letter++)
        //    {
        //        Button b = new Button();
        //        b.Content = ((char)letter).ToString();
        //        b.Height = 40;
        //        b.Width = 40;
        //        b.FontSize = 20;
        //        b.Background = Brushes.LawnGreen;
        //        doel.Children.Add(b);
        //        buttons.Add(b);
        //    }

        //    //wrpLettersWrap.IsEnabled = false;
        //}

        //public void AddLabels(WrapPanel doel)
        //{
        //    wrpGezochtWoord.Children.Clear();
        //    char[] woordChars = gezochtWoord.ToCharArray();
        //    int lengte = woordChars.Length;
        //    int refer = (int)wrpGezochtWoord.Width / lengte;
        //    for (int i = 0; i < lengte; i++)
        //    {
        //        Label l = new Label();
        //        l.FontSize = 30;
        //        l.Content = verborgen;  // <<<-------- = woordChars[i] geeft alle letters weer ipv underscores
        //        l.BringIntoView();
        //        wrpGezochtWoord.Children.Add(l);
        //        labels.Add(l);

        //    }
        //    txtWoordLengte.Text = lengte.ToString();
        //}

        public void ResetGame()
        {
            wrpGezochtWoord.Children.Clear();
            wrpLettersWrap.Children.Clear();
            AantalFouten = 0;
            lblAantalFouten.Content = "0";
            labels.Clear();
            buttons.Clear();
            
            gezochtWoord = WoordServices.RandomWoord();
            MaakLabels();
            MaakButtons();

        }

        void MaakButtons()
        {
            controlsServices.AddButtons(wrpLettersWrap);
            foreach (Button b in controlsServices.Buttons)
            {
                 b.Click += b_Click;
            }
        }

        void MaakLabels()
        {
            controlsServices.AddLabels(wrpGezochtWoord, gezochtWoord, txtWoordLengte);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            gezochtWoord = WoordServices.RandomWoord();
            MaakLabels();
            wrpLettersWrap.IsEnabled = true;
            txtInput.Text = "";
        }

        void b_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            char charClicked = Convert.ToChar(b.Content);
            b.IsEnabled = false;

            if ((gezochtWoord = gezochtWoord.ToUpper()).Contains(charClicked))
            {
                lblInfo.Content = "Juiste letter!";
                lblInfo.Background = Brushes.LawnGreen;
                char[] charArray = gezochtWoord.ToCharArray();
                for (int i = 0; i < gezochtWoord.Length - 1; i++)
                {
                    if (charArray[i] == charClicked)
                    {
                        controlsServices.Labels[i].Content = charClicked.ToString();
                    }
                    
                }

            }
            else
            {
                lblInfo.Content = "Foute letter!";
                lblInfo.Background = Brushes.Brown;
                AantalFouten++;
                lblAantalFouten.Content = AantalFouten.ToString();
            }

            if (AantalFouten > 7)
            {
                Label GameOver = new Label();
                GameOver.Height = 450;
                GameOver.Width = 800;
                GameOver.Content = "Game over!";
                GameOver.HorizontalContentAlignment = HorizontalAlignment.Center;
                GameOver.VerticalContentAlignment = VerticalAlignment.Center;
                GameOver.FontSize = 100;
                GameOver.Background = Brushes.Red;
                grdAchtergrond.Children.Add(GameOver);


            }
            // vul hier content van labels in
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }
    }
}
