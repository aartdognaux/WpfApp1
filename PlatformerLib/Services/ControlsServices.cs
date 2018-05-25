using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GalgjeLib.Services
{
    public class ControlsServices
    {

        //public List<Button> buttons;
        public List<Button> Buttons { get; set; }
        public List<Label> Labels { get; set; }
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

        public void AddLabels(WrapPanel doel, string gezochtWoord, TextBox groot)
        {
            doel.Children.Clear();
            char[] woordChars = gezochtWoord.ToCharArray();
            int lengte = woordChars.Length;
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
    }
}
