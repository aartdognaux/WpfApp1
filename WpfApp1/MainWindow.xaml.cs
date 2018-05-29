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

        public MainWindow()
        {
            InitializeComponent();
            MaakButtons();
            controlsServices.StartScherm(grdAchtergrond);
            controlsServices.StartNewGame.Click += NewGameButton_Click;
            

        }

        public GameEngine NieuwSpel;
        WoordServices WilkeurigWoord = new WoordServices();
        ControlsServices controlsServices = new ControlsServices();
        public string gezochtWoord =  "Galg ";
        List<Label> labels = new List<Label>();
        List<Button> buttons = new List<Button>();


        void NewGame()
        {
            ResetGame();
            wrpLettersWrap.IsEnabled = true;
            txtInput.Text = "";
            gezochtWoord = WoordServices.NederlandsWoord();

        }

        public void ResetGame()
        {
            wrpGezochtWoord.Children.Clear();
            wrpLettersWrap.Children.Clear();
            lblInfo.Content = "";
            lblInfo.Background = Brushes.White;
            lblAantalFouten.Content = "0";
            controlsServices.Labels.Clear();
            controlsServices.Buttons.Clear();
            MaakButtons();
            MaakLabels();
            NieuwSpel = new GameEngine(gezochtWoord);
            imgGalg.Source = NieuwSpel.GalgOpbouwen();

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


        void GameEnd(string winOrLose)
        {
            controlsServices.Winsituatie(grdAchtergrond, winOrLose);
            controlsServices.RestartNewGame.Click += RestartNewGameButton_Click;
        }

        void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            grdAchtergrond.Children.Clear(); 
        }

        void RestartNewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            grdAchtergrond.Children.Clear();
        }

        void BtnZelfgekozenWoord_Click(object sender, RoutedEventArgs e)
        {
            gezochtWoord = txtInput.Text + "A"; // <---- Deze A zet ik hier, omdat de code altijd 1 character verwijderd aan het einde, om de lijst te kunnen lezen
            txtInput.Text = "";
            ResetGame();
        }


        void BtnEngels_Click(object sender, RoutedEventArgs e)
        {
            gezochtWoord = WoordServices.RandomWoord();
            ResetGame();
        }

        void BtnNederlands_Click(object sender, RoutedEventArgs e)
        {
            gezochtWoord = WoordServices.NederlandsWoord();
            ResetGame();
        }

        void b_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string charClicked = b.Content.ToString();
            b.IsEnabled = false;

            int[] a = NieuwSpel.Character(charClicked[0], lblInfo);
            

            for (int i = 0; i < a.Length -1; i++)
            {
                if (a[i] == 1)
                {
                    controlsServices.Labels[i].Content = NieuwSpel.Word[i].ToString();
                    lblInfo.Content = "Juiste letter!";
                    lblInfo.Background = Brushes.LawnGreen;
                }



            }
            lblAantalFouten.Content = NieuwSpel.Level.ToString();
            imgGalg.Source = NieuwSpel.GalgOpbouwen();
            controlsServices.ControleerLabels();



            if (controlsServices.antwoordCorrect == false )
            {
                GameEnd("Winner"); 
            }
            else if (NieuwSpel.GameOver())
            {
                GameEnd("You hang!");
            }
            else
            {
                (sender as Button).IsEnabled = false;
            }

        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
