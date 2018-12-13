using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2DPlatformGame_Davy_Cools_2EA4
{
    class GameMenuScreen : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int ScreenHeight;
        public static int ScreenWidth;
        public static int MiddleScreenWidth;
        public static int MiddleScreenHeight;
        MouseState mouseState;
        Game currentgame;
        enum Menu { MENU, PLAY, INFO, CONTROLS, CREDITS, EXIT, PAUSE };
        int currentMenu = (int)Menu.MENU;
        Button playButton, infoButton,controlsButton, creditsButton, exitButton, resumeButton, restartButton, quitButton, backButton;

        IMenu mainMenuBackground,controlsMenu;

        public GameMenuScreen()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720
            };
            MiddleScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
            MiddleScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;
            Window.Position = new Point(
                MiddleScreenWidth - (graphics.PreferredBackBufferWidth / 2),
                MiddleScreenHeight - (graphics.PreferredBackBufferHeight / 2));
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
            playButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 - 200)) { Scale = 0.4f };
            infoButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 - 100)) { Scale = 0.4f };
            controlsButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178)) { Scale = 0.4f };
            creditsButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 100)) { Scale = 0.4f };
            exitButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            resumeButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 - 200)) { Scale = 0.4f };
            restartButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 - 100)) { Scale = 0.4f };
            quitButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 )) { Scale = 0.4f };
            backButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            mainMenuBackground = new MainMenu(Content);
            controlsMenu = new ControlsMenu(Content);
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            playButton.ButtonTexture = Content.Load<Texture2D>("PlayButton");
            infoButton.ButtonTexture = Content.Load<Texture2D>("InfoButton");
            controlsButton.ButtonTexture = Content.Load<Texture2D>("controlsButton");
            creditsButton.ButtonTexture = Content.Load<Texture2D>("CreditsButton");
            exitButton.ButtonTexture = Content.Load<Texture2D>("ExitButton");
            //restartButton.ButtonTexture = Content.Load<Texture2D>("RestartButton");
            quitButton.ButtonTexture = Content.Load<Texture2D>("QuitButton");
            backButton.ButtonTexture = Content.Load<Texture2D>("BackButton");
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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            mainMenuBackground.Update(gameTime);
            switch (currentMenu)
            {
                case (int)Menu.MENU:
                    if (playButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.PLAY;
                        currentgame = new Game1();
                        currentgame.Run();
                    }
                    if (infoButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.INFO;
                    }
                    if (controlsButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.CONTROLS;
                    }
                    if (creditsButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.CREDITS;
                    }
                    if (exitButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.EXIT;
                        Exit();
                    }
                    break;
                case (int)Menu.PLAY:
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                       Exit();
                    break;
                case (int)Menu.INFO:
                    if (backButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.MENU;
                        Thread.Sleep(100);
                    }     
                    break;
                case (int)Menu.CONTROLS:
                    controlsMenu.Update(gameTime);
                    if (backButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.MENU;
                        Thread.Sleep(100);
                    }     
                    break;
                case (int)Menu.CREDITS:
                    if (backButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.MENU;
                        Thread.Sleep(100);
                    }    
                    break;
            }
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
            spriteBatch.Begin();
            if(currentMenu != (int)Menu.PLAY)
            mainMenuBackground.Draw(spriteBatch, MiddleScreenWidth);
            switch (currentMenu)
            {
                case (int)Menu.MENU:
                    playButton.Draw(spriteBatch);
                    infoButton.Draw(spriteBatch);
                    controlsButton.Draw(spriteBatch);
                    creditsButton.Draw(spriteBatch);
                    exitButton.Draw(spriteBatch);
                    break;
                case (int)Menu.PLAY:
                    break;
                case (int)Menu.INFO:
                    backButton.Draw(spriteBatch);
                    break;
                case (int)Menu.CONTROLS:
                    controlsMenu.Draw(spriteBatch, MiddleScreenWidth);
                    backButton.Draw(spriteBatch);
                    break;
                case (int)Menu.CREDITS:
                    backButton.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
