using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalgjeLib.Entities;
using System.Windows;
using System.IO;
using System.Net;

namespace GalgjeLib.Services
{
    public class WoordServices
    {
        public static List<Woord> woorden;

        static public string RandomWoord()
        {
            WebClient wc = new WebClient();
            string woordLijst = wc.DownloadString("http://www.buildingjavaprograms.com/code_files/3ed/ch13/words.txt");
            string[] woorden = woordLijst.Split('\n');
            Random wilkeur = new Random();
            return woorden[wilkeur.Next(0, woorden.Length - 1)];
        }


    }
    

}
