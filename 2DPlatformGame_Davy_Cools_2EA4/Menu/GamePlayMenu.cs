using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class GamePlayMenu
    {
        List<ICollide> CollisionItemList;
        List<ICollide> InvisibleObjectCollisionList;
        List<ICollide> MovingObjectsList;
        List<IMoveableObject> charactersList;
        List<IMoveableObject> HeroList;
        List<ICollide> DeathlyObjectsList;
        ICollide nextlevelObject;
        Hero hero;
        Camera2d camera;

        static int ScreenHeight;
        static int ScreenWidth;

        Level CurrentLevel;

        CollitionChecker collider;

        Background backGroundLevel1;
        SpriteFont scoreFont;

        List<IDrawObject> removeObjects;

        int endLevelCoins;
        Texture2D noStarsTexture, oneStarTexture, twoStarsTexture, threeStarsTexture;

        ContentManager content;
        public GamePlayMenu()
        {

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public void Initialize(ContentManager Content, int screenHeight, int screenWidth)
        {
            content = Content;
            // TODO: Add your initialization logic here
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;

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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            CurrentLevel.CreateLevel(CollisionItemList);
            MakeLists();
            scoreFont = Content.Load<SpriteFont>("ScoreFont");
            noStarsTexture = Content.Load<Texture2D>("LevelCompletedNoStars");
            oneStarTexture = Content.Load<Texture2D>("LevelCompletedOneStar");
            twoStarsTexture = Content.Load<Texture2D>("LevelCompletedTwoStars");
            threeStarsTexture = Content.Load<Texture2D>("LevelCompletedThreeStars");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
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
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: camera.Transform);
            backGroundLevel1.Draw(spriteBatch);
            CurrentLevel.DrawLevel(spriteBatch);
            spriteBatch.DrawString(scoreFont, "Lives: " + hero.Lives.ToString(), (hero.Position - new Vector2(400, 205)), Color.White);
            spriteBatch.DrawString(scoreFont, "Coins: " + hero.TotalCoins.ToString(), (hero.Position - new Vector2(400, 185)), Color.White);
            hero.Draw(spriteBatch);
        }
        public void DrawInbetweenLevels(SpriteBatch spriteBatch)
        {
            if(endLevelCoins < 20)
            {
                spriteBatch.Draw(noStarsTexture, new Vector2(ScreenWidth / 2 - 380, ScreenHeight / 2 - 375), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
            else if (endLevelCoins >= 20 && endLevelCoins < 40)
            {
                spriteBatch.Draw(oneStarTexture, new Vector2(ScreenWidth / 2 - 380, ScreenHeight / 2 - 375), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
            else if(endLevelCoins >= 40 && endLevelCoins < 60)
            {
                spriteBatch.Draw(twoStarsTexture, new Vector2(ScreenWidth / 2 - 380, ScreenHeight / 2 - 375), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(threeStarsTexture, new Vector2(ScreenWidth/2 - 380, ScreenHeight / 2 - 375), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
        }
        public bool CheckEndOfLevel()
        {
            if (hero.CollisionRectangle.Intersects(nextlevelObject.CollisionRectangle))
            {
                NextLevel();
                return true;
            }
            return false;
        }
        private void NextLevel()
        {
            CollisionItemList.Clear();
            HeroList.Clear();
            InvisibleObjectCollisionList.Clear();
            DeathlyObjectsList.Clear();
            charactersList.Clear();
            MovingObjectsList.Clear();
            CurrentLevel = new Level2(content);
            CurrentLevel.CreateLevel(CollisionItemList);
            MakeLists();
            hero.ChangePosition(70, 350);
            endLevelCoins = hero.TotalCoins;
            hero.TotalCoins = 0;
            hero.Lives = 3;
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
            foreach (ICollide temp in CollisionItemList.ToList())
            {
                if( temp is INextLevelTile)
                {
                    nextlevelObject = temp;
                    CollisionItemList.Remove(temp);
                }
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
