using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class MainGame
    {
        List<ICollide> CollisionItemList;
        List<ICollide> InvisibleObjectCollisionList;
        List<ICollide> MovingObjectsList;
        List<IMoveableObject> charactersList;
        List<IMoveableObject> HeroList;
        List<ICollide> DeathlyObjectsList;
        //GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;
        Hero hero;
        Camera2d camera;

        //public static int ScreenHeight;
        //public static int ScreenWidth;

        Level CurrentLevel;

        CollitionChecker collider;

        Background backGroundLevel1;
        SpriteFont scoreFont;

        List<IDrawObject> removeObjects;
        public MainGame(ContentManager Content)
        {
            Initialize(Content);   
        }
       public void Initialize(ContentManager Content)
        {
            //ScreenHeight = graphics.PreferredBackBufferHeight;
            //ScreenWidth = graphics.PreferredBackBufferWidth;

            CollisionItemList = new List<ICollide>();
            InvisibleObjectCollisionList = new List<ICollide>();
            MovingObjectsList = new List<ICollide>();
            charactersList = new List<IMoveableObject>();
            HeroList = new List<IMoveableObject>();
            DeathlyObjectsList = new List<ICollide>();
            removeObjects = new List<IDrawObject>();

            hero = new Hero(Content) { _Movement = new MovementArrowKeys() };

            camera = new Camera2d() { Zoom = 1.5f };

            collider = new CollitionChecker();

            CurrentLevel = new Level1(Content);
            backGroundLevel1 = new Background(Content);


            //base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            CurrentLevel.CreateLevel(CollisionItemList);
            MakeLists();
            scoreFont = Content.Load<SpriteFont>("ScoreFont");
        }
        public void Update(GameTime gameTime)
        {
            foreach (IUpdate temp2 in MovingObjectsList)
            {
                temp2.Update(gameTime);
            }
            foreach (IUpdate temp3 in charactersList)
            {
                if (!(temp3 is Hero))
                    temp3.Update(gameTime);
            }
            CheckAllCollisions();
            hero.Update(gameTime);
            camera.Follow(hero);


            //base.Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin(transformMatrix: camera.Transform);
            backGroundLevel1.Draw(spriteBatch);
            CurrentLevel.DrawLevel(spriteBatch);
            spriteBatch.DrawString(scoreFont, "Lives: " + hero.GetLives.ToString(), (hero.Position - new Vector2(400, 205)), Color.White);
            spriteBatch.DrawString(scoreFont, "Coins: " + hero.TotalCoins.ToString(), (hero.Position - new Vector2(400, 185)), Color.White);
            hero.Draw(spriteBatch);
            spriteBatch.End();


            //base.Draw(gameTime);
        }
        private void CheckAllCollisions()
        {
            collider.CheckCollitionIntersect(HeroList, DeathlyObjectsList);
            removeObjects = collider.CheckCollitionIntersect(HeroList, MovingObjectsList);
            CurrentLevel.RemoveTile(removeObjects);
            removeObjects = collider.CheckCollitionIntersect(HeroList, DeathlyObjectsList);
            CurrentLevel.RemoveTile(removeObjects);
            removeObjects = collider.CheckCollitionIntersect(hero.GetFireBalls(), DeathlyObjectsList);
            CurrentLevel.RemoveTile(removeObjects);
            collider.CheckCollision(charactersList, CollisionItemList);
            collider.CheckCollision(charactersList, InvisibleObjectCollisionList);
            collider.CheckCollision(HeroList, CollisionItemList);
            collider.CheckCollision(hero.GetFireBalls(), CollisionItemList);
        }
        private void MakeLists()
        {
            //charactersList.Add(hero);
            HeroList.Add(hero);
            //De lijst die teruggegeven wordt van een level filteren in verschillende lijsten
            foreach (ICollide temp in CollisionItemList)
            {
                if (temp is ICollideInvisible)
                {
                    InvisibleObjectCollisionList.Add(temp);
                }
                if (temp is IDeathly)
                {
                    DeathlyObjectsList.Add(temp);
                }
                if (temp is Enemy)
                {
                    charactersList.Add((IMoveableObject)temp);
                }
                else if (temp is IUpdate)
                {
                    MovingObjectsList.Add(temp);
                }
            }
            //Deze foreach verwijdert alle objecten uit de lijst van collisionItemList die niet beweegbaar zijn omdat deze later alleen gaan gecontroleerd worden of ze algemeen geraakt worden
            foreach (ICollide temp in MovingObjectsList)
            {
                if (!(temp is IMoveableObject))
                    CollisionItemList.Remove(temp);
            }
            foreach (ICollide temp in charactersList)
            {
                CollisionItemList.Remove(temp);
            }
            foreach (ICollide temp in DeathlyObjectsList)
            {
                CollisionItemList.Remove(temp);
            }
            foreach (ICollide temp in InvisibleObjectCollisionList)
            {
                CollisionItemList.Remove(temp);
            }
        }
    }
}
