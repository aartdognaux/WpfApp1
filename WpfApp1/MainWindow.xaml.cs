using PlatformerLib.Entities;
using PlatformerLib.Services;
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
using WpfApp1.GameObjects;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WriteableBitmap writeableBmp;
        Gameworld world;

        public MainWindow()
        {
            InitializeComponent();

        }



        public void ViewPort_Loaded(object sender, RoutedEventArgs e)
        {
            int height = (int)this.ViewPortContainer.ActualHeight;
            int width = (int)this.ViewPortContainer.ActualWidth;
            writeableBmp = BitmapFactory.New(width, height);
            ViewPort.Source = writeableBmp;
            CreateWorld();
            world.StartTimer();

            
            CompositionTarget.Rendering += CompositionTarget_Rendering; 

        }

        public void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            world.GameTick();

            writeableBmp.Clear();
            foreach(GameEntity entity in world.GameEntities)
            {
                entity.Draw(writeableBmp);
            }
        }



        public void CreateWorld()
        {
            world = new Gameworld();
            var player1 = new Player1()
            {
                Radius = 10,
                Plaats = new System.Numerics.Vector2(200, 400),
                Beweging = new System.Numerics.Vector2(60, -60)

            };

            var grond = new Grond();


            world.AddEntity(player1);
            world.AddEntity(grond);

        }


    }
}
