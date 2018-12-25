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
        List<IDrawObject> removeObjects;
        ICollide nextlevelObject;

        static int ScreenHeight;
        static int ScreenWidth;

        Hero hero;
        Camera2d camera;
        Level currentLevel;
        CollitionChecker collider;

        Background backGroundLevel;
        SpriteFont scoreFont;
        int endLevelCoins;

        Texture2D noStarsTexture, oneStarTexture, twoStarsTexture, threeStarsTexture, hearthTexture, coinTexture;
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
            currentLevel = new Level1(Content);
            backGroundLevel = new Background(Content, "BackgroundLevel1");
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            currentLevel.CreateLevel(CollisionItemList);
            MakeLists();
            scoreFont = Content.Load<SpriteFont>("ScoreFont");
            noStarsTexture = Content.Load<Texture2D>("LevelCompletedNoStars");
            oneStarTexture = Content.Load<Texture2D>("LevelCompletedOneStar");
            twoStarsTexture = Content.Load<Texture2D>("LevelCompletedTwoStars");
            threeStarsTexture = Content.Load<Texture2D>("LevelCompletedThreeStars");
            hearthTexture = Content.Load<Texture2D>("Hearth");
            coinTexture = Content.Load<Texture2D>("Coin");
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
            backGroundLevel.Draw(spriteBatch);
            currentLevel.DrawLevel(spriteBatch);
            spriteBatch.Draw(hearthTexture, (hero.Position - new Vector2(400, 205)), null, Color.AliceBlue, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
            spriteBatch.Draw(coinTexture, (hero.Position - new Vector2(400, 180)), null, Color.AliceBlue, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(scoreFont, hero.Lives.ToString(), (hero.Position - new Vector2(370, 202)), Color.White);
            spriteBatch.DrawString(scoreFont, hero.TotalCoins.ToString(), (hero.Position - new Vector2(370, 177)), Color.White);
            hero.Draw(spriteBatch);
        }
        public void DrawEndLevelStars(SpriteBatch spriteBatch)
        {
            if(endLevelCoins < 20)
                spriteBatch.Draw(noStarsTexture, new Vector2(ScreenWidth / 2 - 380, ScreenHeight / 2 - 375), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            else if (endLevelCoins >= 20 && endLevelCoins < 40)
                spriteBatch.Draw(oneStarTexture, new Vector2(ScreenWidth / 2 - 380, ScreenHeight / 2 - 375), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            else if(endLevelCoins >= 40 && endLevelCoins < 60)
                spriteBatch.Draw(twoStarsTexture, new Vector2(ScreenWidth / 2 - 380, ScreenHeight / 2 - 375), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(threeStarsTexture, new Vector2(ScreenWidth/2 - 380, ScreenHeight / 2 - 375), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
        }
        public void SetCheats(bool teleportCheat)
        {
            hero._Movement.TeleportCheat = teleportCheat;
        }
        public void ResetCurrentLevel()
        {
            currentLevel.TilesList.Clear();
            CollisionItemList.Clear();
            HeroList.Clear();
            InvisibleObjectCollisionList.Clear();
            DeathlyObjectsList.Clear();
            charactersList.Clear();
            MovingObjectsList.Clear();
            currentLevel.CreateLevel(CollisionItemList);
            MakeLists();
            hero.ChangePosition(70, 770);
            endLevelCoins = hero.TotalCoins;
            hero.TotalCoins = 0;
            hero.Lives = 3;
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
            if (!(currentLevel is Level2))
            {
                currentLevel = new Level2(content);
                backGroundLevel = new Background(content, "BackgroundLevel2");
                ResetCurrentLevel();
            }
        }
        private void CheckAllCollisions()
        {
            removeObjects = collider.CheckCollition(charactersList, CollisionItemList);
            currentLevel.RemoveTile(removeObjects);
            removeObjects = collider.CheckCollition(hero.GetFireBalls(), CollisionItemList);
            currentLevel.RemoveTile(removeObjects);
        }
        private void MakeLists()
        {
            charactersList.Add(hero);
            foreach (ICollide temp in CollisionItemList.ToList())
            {
                if (temp is Enemy)
                {
                    charactersList.Add((IMoveableObject)temp);
                }
                else if (temp is IUpdate && !(temp is Enemy))
                {
                    MovingObjectsList.Add(temp);
                }
                else if (temp is INextLevelTile)
                {
                    nextlevelObject = temp;
                    CollisionItemList.Remove(temp);
                }
            }
        }
    }
}
