using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA5_DLL_Test;
using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CA5_TD_DLL
{
    public class Car
    {
        CatmullRomPath CPathMoving;
        public Rectangle hitBox;
        public bool isHit = false;
        float curveCurrentpos;
        float curveSpeed = 0.2f;
        GraphicsDevice graphicsDevice;

        public Car(GraphicsDevice graphicsDevice) 
        {
            this.graphicsDevice = graphicsDevice;
            float tensionCarPath = 0.5f;

            CPathMoving = new CatmullRomPath(graphicsDevice, tensionCarPath);
            CPathMoving.Clear();

            LoadPath.LoadPathFromFile(CPathMoving, "carpath1.txt");
            CPathMoving.DrawFillSetup(graphicsDevice, 2, 1, 256);

            hitBox = new Rectangle(0,0,50,50);
        }

        public void Update(GameTime gameTime)
        {
            curveCurrentpos += curveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (curveCurrentpos < 1 & curveCurrentpos > 0)
            {
                Vector2 vec = CPathMoving.EvaluateAt(curveCurrentpos);
                hitBox.X = (int)vec.X;
                hitBox.Y = (int)vec.Y;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(curveCurrentpos < 1 & curveCurrentpos > 0)
            {
                if (!isHit)
                {
                    CPathMoving.DrawMovingObject(curveCurrentpos, spriteBatch, AssetManager.carTex);
                }
            }
        }
    }
}
