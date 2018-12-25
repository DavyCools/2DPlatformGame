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
        enum Menu { MENU, PLAY, INFO, CONTROLS, CREDITS, EXIT, PAUSE, NEXTLEVEL };
        int currentMenu = (int)Menu.MENU;
        Button playButton, infoButton,controlsButton, creditsButton, exitButton, resumeButton, restartButton, quitButton, backButton, continueButton, checkboxCheatsButton, checkboxFullscreenButton;

        IMenu mainMenuBackground,controlsMenu,infoMenu;
        GamePlayMenu fullGame;
        Texture2D titelTexture;
        Texture2D checkboxOffTexture, checkboxOnTexture;
        SpriteFont scoreFont;
        bool checkboxCheats = false;
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
            quitButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            backButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 200)) { Scale = 0.4f };
            continueButton = new Button(new Vector2(MiddleScreenWidth - 400, MiddleScreenHeight - 178 + 100)) { Scale = 0.4f };
            checkboxCheatsButton = new Button(new Vector2(MiddleScreenWidth - 15 , MiddleScreenHeight + 95)) { Scale = 0.1f};
            checkboxFullscreenButton = new Button(new Vector2(MiddleScreenWidth + 220, MiddleScreenHeight + 95)) { Scale = 0.1f };

            mainMenuBackground = new MainMenu(Content);
            controlsMenu = new ControlsMenu(Content);
            infoMenu = new InfoMenu(Content);
            fullGame = new GamePlayMenu();
            fullGame.Initialize(Content,ScreenHeight,ScreenWidth);
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
            titelTexture = Content.Load<Texture2D>("2DGameName");
            playButton.ButtonTexture = Content.Load<Texture2D>("PlayButton");
            infoButton.ButtonTexture = Content.Load<Texture2D>("InfoButton");
            controlsButton.ButtonTexture = Content.Load<Texture2D>("controlsButton");
            creditsButton.ButtonTexture = Content.Load<Texture2D>("CreditsButton");
            exitButton.ButtonTexture = Content.Load<Texture2D>("ExitButton");
            restartButton.ButtonTexture = Content.Load<Texture2D>("RestartButton");
            quitButton.ButtonTexture = Content.Load<Texture2D>("QuitButton");
            backButton.ButtonTexture = Content.Load<Texture2D>("BackButton");
            resumeButton.ButtonTexture = Content.Load<Texture2D>("ResumeButton");
            continueButton.ButtonTexture = Content.Load<Texture2D>("ContinueButton");
            checkboxOffTexture = Content.Load<Texture2D>("CheckboxOff");
            checkboxOnTexture = Content.Load<Texture2D>("CheckboxOn");
            checkboxCheatsButton.ButtonTexture = checkboxOffTexture;
            checkboxFullscreenButton.ButtonTexture = checkboxOffTexture;
            scoreFont = Content.Load<SpriteFont>("ScoreFont");
            fullGame.LoadContent(Content);
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
            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (currentMenu != (int)Menu.PLAY)
            {
                mainMenuBackground.Update(gameTime);
                IsMouseVisible = true;
            }
            switch (currentMenu)
            {
                case (int)Menu.MENU:
                    if (playButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.PLAY;
                        fullGame.SetCheats(checkboxCheats);
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
                    if (checkboxCheatsButton.CheckClicked(mouseState))
                    {
                        if (!checkboxCheats)
                            checkboxCheatsButton.ButtonTexture = checkboxOnTexture;
                        else
                            checkboxCheatsButton.ButtonTexture = checkboxOffTexture;
                        checkboxCheats = !checkboxCheats;
                        Thread.Sleep(100);
                    }
                    if (checkboxFullscreenButton.CheckClicked(mouseState))
                    {
                        if (checkboxFullscreenButton.ButtonTexture == checkboxOffTexture)
                            checkboxFullscreenButton.ButtonTexture = checkboxOnTexture;
                        else
                            checkboxFullscreenButton.ButtonTexture = checkboxOffTexture;
                        graphics.ToggleFullScreen();
                        Thread.Sleep(100);
                    }
                    break;
                case (int)Menu.PLAY:
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        currentMenu = (int)Menu.PAUSE;
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.E))
                        if (fullGame.CheckEndOfLevel())
                            currentMenu = (int)Menu.NEXTLEVEL;
                    fullGame.Update(gameTime);
                    IsMouseVisible = false;
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
                case (int)Menu.PAUSE:
                    if (resumeButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.PLAY;
                    }
                    if (quitButton.CheckClicked(mouseState))
                    {
                        //fullGame.ResetCurrentLevel();
                        fullGame.Initialize(Content, ScreenHeight, ScreenWidth);
                        fullGame.LoadContent(Content);
                        currentMenu = (int)Menu.MENU;
                        Thread.Sleep(100);
                    }
                    if (restartButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.PLAY;
                        fullGame.ResetCurrentLevel();
                    }
                    break;
                case (int)Menu.NEXTLEVEL:
                    if (quitButton.CheckClicked(mouseState))
                    {
                        //fullGame.ResetCurrentLevel();
                        fullGame.Initialize(Content, ScreenHeight, ScreenWidth);
                        fullGame.LoadContent(Content);
                        currentMenu = (int)Menu.MENU;
                        Thread.Sleep(100);
                    }
                    if (continueButton.CheckClicked(mouseState))
                    {
                        currentMenu = (int)Menu.PLAY;
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
            if(currentMenu != (int)Menu.PLAY)
            {
                spriteBatch.Begin();
                mainMenuBackground.Draw(spriteBatch, MiddleScreenWidth);
                if (currentMenu != (int)Menu.NEXTLEVEL)
                    spriteBatch.Draw(titelTexture, new Vector2(MiddleScreenWidth - 500, 25), null, Color.AliceBlue, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
            switch (currentMenu)
            {
                case (int)Menu.MENU:
                    playButton.Draw(spriteBatch);
                    infoButton.Draw(spriteBatch);
                    controlsButton.Draw(spriteBatch);
                    creditsButton.Draw(spriteBatch);
                    exitButton.Draw(spriteBatch);
                    checkboxCheatsButton.Draw(spriteBatch);
                    checkboxFullscreenButton.Draw(spriteBatch);
                    if(checkboxCheats)
                        spriteBatch.DrawString(scoreFont, "Cheats on ", (new Vector2(MiddleScreenWidth - 35, MiddleScreenHeight + 145)), Color.Black);
                    else
                        spriteBatch.DrawString(scoreFont, "Cheats off", (new Vector2(MiddleScreenWidth - 35, MiddleScreenHeight + 145)), Color.Black);
                    spriteBatch.DrawString(scoreFont, "Fullscreen", (new Vector2(MiddleScreenWidth + 190, MiddleScreenHeight + 145)), Color.Black);
                    break;
                case (int)Menu.PLAY:
                    fullGame.Draw(gameTime, spriteBatch);
                    break;
                case (int)Menu.INFO:
                    infoMenu.Draw(spriteBatch, MiddleScreenWidth);
                    backButton.Draw(spriteBatch);
                    break;
                case (int)Menu.CONTROLS:
                    controlsMenu.Draw(spriteBatch, MiddleScreenWidth);
                    backButton.Draw(spriteBatch);
                    break;
                case (int)Menu.CREDITS:
                    backButton.Draw(spriteBatch);
                    break;
                case (int)Menu.PAUSE:
                    resumeButton.Draw(spriteBatch);
                    restartButton.Draw(spriteBatch);
                    quitButton.Draw(spriteBatch);
                    break;
                case (int)Menu.NEXTLEVEL:
                    fullGame.DrawEndLevelStars(spriteBatch);
                    continueButton.Draw(spriteBatch);
                    quitButton.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
