using CA5_DLL_Test;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;
using CatmullRom;

namespace CA5_TD_DLL
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        //private SimplePath simplePath;
        //float posTex;

        CatmullRomPath cPathRoad;
        CatmullRomPath cPathMoving;

        float curveCurrentPos = 0;
        float curveCarCurrentPos = 0;
        float curveSpeed = 0;
        float curveCarSpeed = 0.2f;
        float tensionRoad = 0.5f;
        float tensionCarPath = 0.5f;

        Level level;
        //Car car;
        CarManager carManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();

            Window.Title = "NEED FOR SPEED";


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AssetManager.LoadTextures(Content, GraphicsDevice);


            //simplePath = new SimplePath(GraphicsDevice);
            //simplePath.generateDefaultPath();
            //posTex = simplePath.beginT;

            CreatePath();
            //cPathMoving = cPathRoad;

            carManager = new CarManager(GraphicsDevice);
            level = new Level(GraphicsDevice);
            //car = new Car(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
        }

        public void CreatePath()
        {
            cPathRoad = new CatmullRomPath(GraphicsDevice, tensionRoad);
            cPathRoad.Clear();
            cPathRoad.AddPoint(new Vector2(0,0));
            cPathRoad.AddPoint(new Vector2(300,100));
            cPathRoad.AddPoint(new Vector2(400,200));
            cPathRoad.AddPoint(new Vector2(600,350));
            cPathRoad.AddPoint(new Vector2(800,600));

            cPathRoad.DrawFillSetup(GraphicsDevice, 30, 5, 26);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            car.Update(gameTime);
            //level.Update(gameTime);
            //posTex += 5;
            //pathUpdate(gameTime);

            
            base.Update(gameTime);
        }
        public void pathUpdate(GameTime gameTime)
        {
            curveCarCurrentPos += curveCarSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //simplePath.Draw(spriteBatch);
            //simplePath.DrawPoints(spriteBatch);
            //if(posTex < simplePath.endT)
            //{
            //    spriteBatch.Draw(AssetManager.carTex, simplePath.GetPos(posTex), Color.White);
            //}

            spriteBatch.End();

            level.Draw(spriteBatch);
            car.Draw(spriteBatch);

            //cPathRoad.DrawFill(GraphicsDevice, AssetManager.roadTex);
            //if (curveCarCurrentPos < 1 && curveCarCurrentPos > 0)
            //{
            //    cPathMoving.DrawMovingObject(curveCarCurrentPos, spriteBatch, AssetManager.carTex);
            //}
            

            base.Draw(gameTime);
        }
    }
}
