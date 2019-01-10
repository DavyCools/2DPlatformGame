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
    /// <summary>
    /// Deze klasse (GamePlay) is verantwoordelijk voor
    /// het gedrag van de game zelf
    /// </summary>
    class GamePlay
    {
        List<ICollide> CollisionItemList;
        List<IMoveableObject> charactersList;
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
        public GamePlay()
        {

        }

        /// <summary>
        /// Initialiseert alles voor de game
        /// </summary>
        public void Initialize(ContentManager Content, int screenHeight, int screenWidth)
        {
            content = Content;
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;

            CollisionItemList = new List<ICollide>();
            charactersList = new List<IMoveableObject>();
            removeObjects = new List<IDrawObject>();

            hero = new Hero(Content) { _Movement = new MovementArrowKeys() };
            camera = new Camera2d() { Zoom = 1.5f };
            collider = new CollitionChecker();
            currentLevel = new Level1(Content);
            backGroundLevel = new Background(Content, "BackgroundLevel1",ScreenWidth,ScreenHeight);
        }

        /// <summary>
        /// Laad alle content voor de game
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            currentLevel.CreateLevel(CollisionItemList);
            MakeLists();
            scoreFont = Content.Load<SpriteFont>("ScoreFont");
            noStarsTexture = Content.Load<Texture2D>("LevelCompletedNoStars");
            oneStarTexture = Content.Load<Texture2D>("LevelCompletedOneStar");
            twoStarsTexture = Content.Load<Texture2D>("LevelCompletedTwoStars");
            threeStarsTexture = Content.Load<Texture2D>("LevelCompletedThreeStars");
            hearthTexture = Content.Load<Texture2D>("Hearth");
            coinTexture = Content.Load<Texture2D>("Coin");
        }

        /// <summary>
        /// Update de game
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            foreach(ICollide temp in CollisionItemList)
            {
                if(temp is IUpdate)
                    ((IUpdate)temp).Update(gameTime);
            }
            CheckAllCollisions();
            hero.Update(gameTime);
            camera.Follow(hero,ScreenWidth,ScreenHeight);
        }

        /// <summary>
        /// Tekent de game
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: camera.Transform);
            backGroundLevel.Draw(spriteBatch);
            currentLevel.DrawLevel(spriteBatch);
            spriteBatch.Draw(hearthTexture, (hero.Position - new Vector2(400, 205)), null, Color.AliceBlue, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
            spriteBatch.Draw(coinTexture, (hero.Position - new Vector2(400, 180)), null, Color.AliceBlue, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(scoreFont, hero.Lives.ToString(), (hero.Position - new Vector2(370, 202)), Color.White);
            spriteBatch.DrawString(scoreFont, hero.TotalCoins.ToString(), (hero.Position - new Vector2(370, 177)), Color.White);
            if(hero.Lives == 0)
                spriteBatch.DrawString(scoreFont, "You died! Press escape to continue ...", (hero.Position - new Vector2(125, 50)), Color.White);
            hero.Draw(spriteBatch);
        }
        /// <summary>
        /// Tekent het aantal sterren op het einde van een level
        /// </summary>
        /// <param name="spriteBatch"></param>
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
        /// <summary>
        /// Zet de cheats van de game aan/af
        /// </summary>
        /// <param name="teleportCheat"></param>
        public void SetCheats(bool teleportCheat)
        {
            hero._Movement.TeleportCheat = teleportCheat;
        }
        /// <summary>
        /// Reset het huidige level
        /// </summary>
        public void ResetCurrentLevel()
        {
            currentLevel.TilesList.Clear();
            CollisionItemList.Clear();
            charactersList.Clear();
            currentLevel.CreateLevel(CollisionItemList);
            MakeLists();
            hero.ChangePosition(70, 770);
            hero.TotalCoins = 0;
            hero.Lives = 3;
        }
        /// <summary>
        /// Controleert of je op het einde van het level zit
        /// </summary>
        /// <returns></returns>
        public bool CheckEndOfLevel()
        {
            if (hero.CollisionRectangle.Intersects(nextlevelObject.CollisionRectangle))
            {
                NextLevel();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Inladen van het volgende level
        /// </summary>
        private void NextLevel()
        {
            endLevelCoins = hero.TotalCoins;
            if (!(currentLevel is Level2))
            {
                currentLevel = new Level2(content);
                backGroundLevel = new Background(content, "BackgroundLevel2",ScreenWidth,ScreenHeight);
                ResetCurrentLevel();
            }
        }
        /// <summary>
        /// Controleren van collision
        /// </summary>
        private void CheckAllCollisions()
        {
            removeObjects = collider.CheckCollition(charactersList, CollisionItemList);
            currentLevel.RemoveTile(removeObjects);
            removeObjects = collider.CheckCollition(hero.GetFireBalls(), CollisionItemList);
            currentLevel.RemoveTile(removeObjects);
        }
        /// <summary>
        /// Maken van een lijst van beweegbare objecten uit de collisionlijst
        /// </summary>
        private void MakeLists()
        {
            charactersList.Add(hero);
            foreach (ICollide temp in CollisionItemList.ToList())
            {
                if (temp is Enemy)
                {
                    charactersList.Add((IMoveableObject)temp);
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
