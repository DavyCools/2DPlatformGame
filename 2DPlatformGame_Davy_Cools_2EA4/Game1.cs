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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hero hero;
        Camera2d camera;
        public List<ICollide> CollisionItemList;
        Rectangle backgroundPosition;
        Texture2D background;
        public static int ScreenHeight;
        public static int ScreenWidth;

        Texture2D blockTexture;
        Level level1;

        CollitionChecker collider;

        Background test;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;
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
            backgroundPosition = new Rectangle(-ScreenWidth/2,-ScreenHeight,ScreenWidth*2,ScreenHeight*2);
            hero = new Hero(Content);
            hero._Movement = new MovementArrowKeys();
            camera = new Camera2d();
            collider = new CollitionChecker();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CollisionItemList = new List<ICollide>();
            level1 = new Level1(Content);
            test = new Background(Content);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            background = Content.Load<Texture2D>("BackgroundLevel1");
            blockTexture = Content.Load<Texture2D>("blok");
            level1.Texture = blockTexture;
            level1.CreateLevel(CollisionItemList);
            test.Initialize(backgroundPosition, new Rectangle(ScreenWidth * 2 - ScreenWidth/2, -ScreenHeight, ScreenWidth * 2, ScreenHeight * 2));
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
            collider.CheckCollition(hero, CollisionItemList);
            hero.Update(gameTime);
            camera.Follow(hero);
            test.Update(graphics);
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
            //spriteBatch.Draw(background, backgroundPosition, Color.White);
            test.Draw(spriteBatch);
            level1.DrawLevel(spriteBatch);
            hero.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
