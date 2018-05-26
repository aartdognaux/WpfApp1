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



namespace Galgje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddButtons();
        }
        string gezochtWoord;
        char verborgen = '_';
        int AantalFouten = 0;


        void AddButtons()
        {
            for (int letter = (int)'A'; letter <= (int)'Z'; letter++)
            {
                Button b = new Button();
                b.Content = ((char)letter).ToString();
                b.Height = 40;
                b.Width = 40;
                b.FontSize = 20;
                b.Background = Brushes.LawnGreen;
                wrpLettersWrap.Children.Add(b);


                b.Click += b_Click; 
            }

            wrpLettersWrap.IsEnabled = false;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            gezochtWoord = txtInput.Text;
            //AddLabels();
            wrpLettersWrap.IsEnabled = true;
            txtInput.Text = "";
            vulTextBox();
        }

        void vulTextBox()
        {
            txbOplossing.Text = gezochtWoord;
        }
        //public void AddLabels()
        //{
        //    wrpGezochtWoord.Children.Clear();
        //    char[] woordChars = gezochtWoord.ToCharArray();
        //    int lengte = woordChars.Length;
        //    int refer = (int)wrpGezochtWoord.Width / lengte;
        //    for (int i = 0; i < lengte; i++)
        //    {
        //        Label l = new Label();
        //        l.FontSize = 30;
        //        l.Content = verborgen;
        //        l.BringIntoView();
        //        l.Name = "characterLabel" + i.ToString();
        //        wrpGezochtWoord.Children.Add(l);
                
        //    }
        //    txtWoordLengte.Text = lengte.ToString();
        //}

        public void b_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            char charClicked = Convert.ToChar(b.Content);
            b.IsEnabled = false;

            if ((gezochtWoord = gezochtWoord.ToUpper()).Contains(charClicked))
            {
                lblInfo.Content = "Juiste letter!";
                lblInfo.Background = Brushes.LawnGreen;
                char[] charArray = gezochtWoord.ToCharArray();
                for (int i = 0; i < gezochtWoord.Length; i++)
                {
                    if (charArray[i] == charClicked)
                    {
                      
                        
                        // <<----- HIER MOETEN WE EEN MANIER VINDEN OM DE LETTERS TE VOORSCHIJN TE LATEN KOMEN

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

        }

        
    }
}
