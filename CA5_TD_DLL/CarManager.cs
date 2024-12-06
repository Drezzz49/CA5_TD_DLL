using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CA5_TD_DLL
{
    public class CarManager
    {
        List<Car> cars;
        GraphicsDevice graphicsDevice;

        int timeSinceLastCar = 0;
        int millisecondsBetweenCreation = 400;
        int numberOfCarsInCurrentWave = 5;

        public CarManager(GraphicsDevice graphicsDevice)
        {
            cars = new List<Car>();
            this.graphicsDevice = graphicsDevice;

        }

        public void LoadWave(GameTime gameTime)
        {
            timeSinceLastCar += gameTime.ElapsedGameTime.Milliseconds;

            if (numberOfCarsInCurrentWave > 0 && timeSinceLastCar > millisecondsBetweenCreation)
            {
                timeSinceLastCar -= millisecondsBetweenCreation;
                Car car = new Car(graphicsDevice);
                cars.Add(car);

                numberOfCarsInCurrentWave -=1;
            }

        }

        public void Update(GameTime gameTime)
        {
            LoadWave(gameTime);

            foreach (Car car in cars)
            {
                car.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Car car in cars)
            {
                if (!car.isHit)
                {
                    car.Draw(spriteBatch);
                }
            }
        }
    }
}
