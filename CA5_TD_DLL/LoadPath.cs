using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA5_DLL_Test;
using CatmullRom;
using Microsoft.Xna.Framework;


namespace CA5_TD_DLL
{
    public static class LoadPath
    {
        public static void LoadPathFromFile(CatmullRomPath path, string textfile)
        {
            string[] lines = System.IO.File.ReadAllLines(textfile);
            foreach (string line in lines)
            {
                path.AddPoint(InputParser.pa)
            }
        }
    }
}
