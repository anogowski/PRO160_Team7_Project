using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Sandbox;

namespace SandBox
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {  
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite optionsBackground;
        Texture2D optionsTexture;

        Sprite rectLabel;
        Sprite circLabel;
        Sprite triLabel;
        Texture2D rectTexture;
        Texture2D circTexture;
        Texture2D triTexture;
        Sprite buttonSprite1;
        Sprite buttonSprite2;
        Sprite buttonSprite3;
        Texture2D buttonTexture;
        Texture2D buttonDownTexture;
        Sprite plusButton;
        Sprite minusButton;
        Texture2D plusBtnTexture;
        Texture2D plusBtnDownTexture;
        Texture2D minusBtnTexture;
        Texture2D minusBtnDownTexture;
        
        MouseState mMouseState;
        MouseState oldMouseState;
        Sprite mMouseCursor;
        Texture2D mMouseTexture;

        int selectedShape;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            graphics.PreferredBackBufferWidth = 1700;
            graphics.PreferredBackBufferHeight = 1000;

            graphics.ApplyChanges();

            optionsTexture = Content.Load<Texture2D>("background");
            mMouseTexture = Content.Load<Texture2D>("gamecursor");

            rectTexture = Content.Load<Texture2D>("rectangle");
            circTexture = Content.Load<Texture2D>("circle");
            triTexture = Content.Load<Texture2D>("triangle");
            buttonTexture = Content.Load<Texture2D>("button");
            buttonDownTexture = Content.Load<Texture2D>("buttonDown");
            plusBtnTexture = Content.Load<Texture2D>("plusButton");
            plusBtnDownTexture = Content.Load<Texture2D>("plusButtonDown");
            minusBtnTexture = Content.Load<Texture2D>("minusButton");
            minusBtnDownTexture = Content.Load<Texture2D>("minusButtonDown");

            CreateStartupSprites();

            base.Initialize();
        }

        public void CreateStartupSprites()
        {
            mMouseCursor = new Sprite();
            mMouseCursor.Texture = mMouseTexture;
            mMouseCursor.X = mMouseState.X;
            mMouseCursor.Y = mMouseState.Y;

            optionsBackground = new Sprite();
            optionsBackground.Texture = optionsTexture;
            optionsBackground.X = 0;
            optionsBackground.Y = 700;

            CreateButtonLabels();
            CreateButtons();
        }

        private void CreateButtonLabels()
        {
            rectLabel = new Sprite();
            rectLabel.Texture = rectTexture;
            rectLabel.X = 30;
            rectLabel.Y = 710;

            circLabel = new Sprite();
            circLabel.Texture = circTexture;
            circLabel.X = 30;
            circLabel.Y = 800;

            triLabel = new Sprite();
            triLabel.Texture = triTexture;
            triLabel.X = 30;
            triLabel.Y = 890;
        }

        private void CreateButtons()
        {
            buttonSprite1 = new Sprite();
            buttonSprite1.Texture = buttonTexture;
            buttonSprite1.X = 70;
            buttonSprite1.Y = 745;

            buttonSprite2 = new Sprite();
            buttonSprite2.Texture = buttonTexture;
            buttonSprite2.X = 70;
            buttonSprite2.Y = 835;

            buttonSprite3 = new Sprite();
            buttonSprite3.Texture = buttonTexture;
            buttonSprite3.X = 70;
            buttonSprite3.Y = 925;

            plusButton = new Sprite();
            plusButton.Texture = plusBtnTexture;
            plusButton.X = 220;
            plusButton.Y = 745;

            minusButton = new Sprite();
            minusButton.Texture = minusBtnTexture;
            minusButton.X = 220;
            minusButton.Y = 785;
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
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            mMouseState = Mouse.GetState();
            mMouseCursor.X = mMouseState.X;
            mMouseCursor.Y = mMouseState.Y;

            CheckButtonOnePressed();
            CheckButtonTwoPressed();
            CheckButtonThreePressed();
            CheckPlusBtnPressed();
            CheckMinusBtnPressed();

            oldMouseState = Mouse.GetState();
           
            base.Update(gameTime);
        }

        private void CheckButtonOnePressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > buttonSprite1.X && mMouseCursor.X < buttonSprite1.X + buttonSprite1.Texture.Width
                    && mMouseCursor.Y > buttonSprite1.Y && mMouseCursor.Y < buttonSprite1.Y + buttonSprite1.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        selectedShape = 1;
                        buttonSprite1.Texture = buttonDownTexture;
                        Console.WriteLine("Rectangle Button Pressed");
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    buttonSprite1.Texture = buttonTexture;
                }
            }
        }

        private void CheckButtonTwoPressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > buttonSprite2.X && mMouseCursor.X < buttonSprite2.X + buttonSprite2.Texture.Width
                    && mMouseCursor.Y > buttonSprite2.Y && mMouseCursor.Y < buttonSprite2.Y + buttonSprite2.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        selectedShape = 2;
                        buttonSprite2.Texture = buttonDownTexture;
                        Console.WriteLine("Circle Button Pressed");
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    buttonSprite2.Texture = buttonTexture;
                }
            }
        }

        private void CheckButtonThreePressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > buttonSprite3.X && mMouseCursor.X < buttonSprite3.X + buttonSprite3.Texture.Width
                    && mMouseCursor.Y > buttonSprite3.Y && mMouseCursor.Y < buttonSprite3.Y + buttonSprite3.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        selectedShape = 3;
                        buttonSprite3.Texture = buttonDownTexture;
                        Console.WriteLine("Triangle Button Pressed");
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    buttonSprite3.Texture = buttonTexture;
                }
            }
        }

        private void CheckPlusBtnPressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > plusButton.X && mMouseCursor.X < plusButton.X + plusButton.Texture.Width
                    && mMouseCursor.Y > plusButton.Y && mMouseCursor.Y < plusButton.Y + plusButton.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        plusButton.Texture = plusBtnDownTexture;
                        Console.WriteLine("Plus Button Pressed");
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    plusButton.Texture = plusBtnTexture;
                }
            }
        }

        private void CheckMinusBtnPressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > minusButton.X && mMouseCursor.X < minusButton.X + minusButton.Texture.Width
                    && mMouseCursor.Y > minusButton.Y && mMouseCursor.Y < minusButton.Y + minusButton.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        minusButton.Texture = minusBtnDownTexture;
                        Console.WriteLine("Minus Button Pressed");
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    minusButton.Texture = minusBtnTexture;
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            optionsBackground.Draw(spriteBatch);
            rectLabel.Draw(spriteBatch);
            circLabel.Draw(spriteBatch);
            triLabel.Draw(spriteBatch);
            buttonSprite1.Draw(spriteBatch);
            buttonSprite2.Draw(spriteBatch);
            buttonSprite3.Draw(spriteBatch);
            plusButton.Draw(spriteBatch);
            minusButton.Draw(spriteBatch);
            mMouseCursor.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
