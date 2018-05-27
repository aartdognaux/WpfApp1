using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GalgjeLib.Services
{
    public class GameEngine
    {
        public string Word { get; private set; }
        public int Lenght { get; private set; }
        public int Level { get; set; }

        public GameEngine(string word)
        {
            Word = word;
            Lenght = Word.Length;
            Level = 0;

        }

        public bool GameOver()
        {
            return Level == 9 ? true : false;
            
        }

        public BitmapImage GalgOpbouwen()
        {
            return new BitmapImage(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory,"Images", Level + ".png")));
        }

        public int[] Character(char ch,Label info)
        {
            int[] WoordLengte = new int[Word.Length];

            for (int i = 0; i < Word.Length; i++)
            {
                if (Word.ToUpper()[i] == ch)
                {
                    WoordLengte[i] = 1;
                }
                else
                {
                    WoordLengte[i] = 0;
                }
            }

            if (WoordLengte.Count(i => i == 1) == 0)
            {
                Level++;
                info.Content = "Foute letter!";
                info.Background = Brushes.Brown;
            }
            else
            {
                info.Content = "Juiste letter!";
                info.Background = Brushes.LawnGreen;
            }

            return WoordLengte;
        }






    }
}
