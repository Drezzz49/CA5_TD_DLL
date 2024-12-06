using CA5_DLL_Test;
using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA5_TD_DLL
{
    public class Level
    {
        CatmullRomPath cPathRoad;
        

        float curveCurrentPos = 0;
        float curveSpeed = 0;

        GraphicsDevice graphicsDevice;

        public static int levelnbr;

        public Level(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            levelnbr += 1;

            cPathRoad = new CatmullRomPath(graphicsDevice, 0.5f);
            cPathRoad.Clear();

            LoadPath.LoadPathFromFile(cPathRoad, "carpath1.txt");
            cPathRoad.DrawFillSetup(graphicsDevice, 30, 5, 26);

        }

        public void Update(GameTime gameTime)
        {
            curveCurrentPos += curveCurrentPos * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (curveCurrentPos < 1.0f)
            {
                curveCurrentPos = 0.0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            cPathRoad.DrawFill(graphicsDevice, AssetManager.roadTex);
        }
    }
}
