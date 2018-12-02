﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        List<ICollide> CollisionItemList;
        List<ICollide> MovingObjectsList;
        List<IMoveableObject> charactersList;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hero hero;
        Camera2d camera;
        
        public static int ScreenHeight;
        public static int ScreenWidth;

        Level level1;

        CollitionChecker collider;

        Background backGroundLevel1;
        SpriteFont scoreFont;

        List<Tiles> removeObjects = new List<Tiles>();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720
            };
            //this.graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;

            CollisionItemList = new List<ICollide>();
            MovingObjectsList = new List<ICollide>();
            charactersList = new List<IMoveableObject>();

            hero = new Hero(Content);
            hero._Movement = new MovementArrowKeys();

            camera = new Camera2d() {Zoom = 1.5f };

            collider = new CollitionChecker();

            level1 = new Level1(Content);
            backGroundLevel1 = new Background(Content);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            level1.CreateLevel(CollisionItemList);
            charactersList.Add(hero);
            //De lijst die teruggegeven wordt van een level filteren in verschillende lijsten
            foreach (ICollide temp in CollisionItemList)
            {
                if (temp is Enemy)
                    charactersList.Add((IMoveableObject)temp);
                else if (temp is IUpdate)
                {
                        MovingObjectsList.Add(temp);
                }
            }
            //Deze foreach verwijdert alle objecten uit de lijst van collisionItemList die niet beweegbaar zijn omdat deze later alleen gaan gecontroleerd worden of ze algemeen geraakt worden
            foreach(ICollide temp in MovingObjectsList)
            {
                if (!(temp is IMoveableObject))
                    CollisionItemList.Remove(temp);
            }
            foreach (ICollide temp in charactersList)
            {
                CollisionItemList.Remove(temp);
            }

            scoreFont = Content.Load<SpriteFont>("ScoreFont");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            foreach(IUpdate temp2 in MovingObjectsList)
            {
                temp2.Update(gameTime);
            }
            foreach (IUpdate temp3 in charactersList)
            {
                if(!(temp3 is Hero))
                temp3.Update(gameTime);
            }
            collider.CheckCollision(charactersList, CollisionItemList);
            removeObjects = collider.CheckCollitionIntersect(hero, MovingObjectsList);
            level1.RemoveTile(removeObjects);
            hero.Update(gameTime);
            camera.Follow(hero);
            backGroundLevel1.Update(hero.Position.X);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: camera.Transform);
            backGroundLevel1.Draw(spriteBatch);
            level1.DrawLevel(spriteBatch);
            /*foreach (IUpdate temp2 in collectAblesList)
            {
                temp2.Draw(spriteBatch);
            }*/
            spriteBatch.DrawString(scoreFont, "Coins: " + hero.TotalCoins.ToString(), (hero.Position - new Vector2(400,205)), Color.White);
            hero.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
