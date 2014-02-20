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
        
        #region(Variable Declarations)
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

        Sprite gravLabel;
        Sprite gravUpBtn;
        Sprite gravDownBtn;
        Texture2D gravTexture;
        Sprite displayGravity;

        Sprite weightUpBtn;
        Sprite weightDownBtn;
        Sprite displayWeight;

        Sprite weightLabel;
        Texture2D weightTexture;
        
        Texture2D plusBtnTexture;
        Texture2D plusBtnDownTexture;
        Texture2D minusBtnTexture;
        Texture2D minusBtnDownTexture;

        MouseState mMouseState;
        MouseState oldMouseState;
        Sprite mMouseCursor;
        Texture2D mMouseTexture;

        int selectedShape;
        int initialGravity;
        int initialWeight;
        #endregion

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

            initialGravity = 2;
            initialWeight = 0;

            optionsTexture = Content.Load<Texture2D>("background");
            mMouseTexture = Content.Load<Texture2D>("gamecursor");

            rectTexture = Content.Load<Texture2D>("rectangle");
            circTexture = Content.Load<Texture2D>("circle");
            triTexture = Content.Load<Texture2D>("triangle");
            buttonTexture = Content.Load<Texture2D>("button");
            buttonDownTexture = Content.Load<Texture2D>("buttonDown");
            gravTexture = Content.Load<Texture2D>("gravLabel");
            plusBtnTexture = Content.Load<Texture2D>("plusButton");
            plusBtnDownTexture = Content.Load<Texture2D>("plusButtonDown");
            minusBtnTexture = Content.Load<Texture2D>("minusButton");
            minusBtnDownTexture = Content.Load<Texture2D>("minusButtonDown");
            weightTexture = Content.Load<Texture2D>("weightLabel");

            CreateStartupSprites();

            base.Initialize();
        }
        
        // Sets up the options menu at the bottom of the screen
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

        // Read the method name
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

            gravLabel = new Sprite();
            gravLabel.Texture = gravTexture;
            gravLabel.X = 200;
            gravLabel.Y = 711;

            weightLabel = new Sprite();
            weightLabel.Texture = weightTexture;
            weightLabel.X = 310;
            weightLabel.Y = 711;

            displayGravity = new Sprite();
            displayGravity.X = 235;
            displayGravity.Y = 745;

            displayWeight = new Sprite();
            displayWeight.X = 345;
            displayWeight.Y = 745;
        }

        // Read the method name
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

            gravUpBtn = new Sprite();
            gravUpBtn.Texture = plusBtnTexture;
            gravUpBtn.X = 200;
            gravUpBtn.Y = 745;

            gravDownBtn = new Sprite();
            gravDownBtn.Texture = minusBtnTexture;
            gravDownBtn.X = 200;
            gravDownBtn.Y = 785;

            weightUpBtn = new Sprite();
            weightUpBtn.Texture = plusBtnTexture;
            weightUpBtn.X = 310;
            weightUpBtn.Y = 745;

            weightDownBtn = new Sprite();
            weightDownBtn.Texture = minusBtnTexture;
            weightDownBtn.X = 310;
            weightDownBtn.Y = 785;

        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

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
            CheckGravUpBtnPressed();
            CheckGravDownBtnPressed();
            CheckWeightUpBtnPressed();
            CheckWeightDownBtnPressed();
            CheckGravity();
            CheckWeight();

            oldMouseState = Mouse.GetState();
           
            base.Update(gameTime);
        }

        // Checks what the amount of gravity is and displays it accordingly
        private void CheckGravity()
        {
            switch (initialGravity)
            {
                case 0:
                    displayGravity.Texture = Content.Load<Texture2D>("num0");
                    break;
                case 1:
                    displayGravity.Texture = Content.Load<Texture2D>("num1");
                    break;
                case 2:
                    displayGravity.Texture = Content.Load<Texture2D>("num2");
                    break;
                case 3:
                    displayGravity.Texture = Content.Load<Texture2D>("num3");
                    break;
                case 4:
                    displayGravity.Texture = Content.Load<Texture2D>("num4");
                    break;
                case 5:
                    displayGravity.Texture = Content.Load<Texture2D>("num5");
                    break;
                case 6:
                    displayGravity.Texture = Content.Load<Texture2D>("num6");
                    break;
                case 7:
                    displayGravity.Texture = Content.Load<Texture2D>("num7");
                    break;
                case 8:
                    displayGravity.Texture = Content.Load<Texture2D>("num8");
                    break;
                case 9:
                    displayGravity.Texture = Content.Load<Texture2D>("num9");
                    break;
                case 10:
                    displayGravity.Texture = Content.Load<Texture2D>("num10");
                    break;
            }

            if (initialGravity < 0)
            {
                initialGravity = 0;
            }
            else if (initialGravity > 10)
            {
                initialGravity = 10;
            }
        }

        private void CheckWeight()
        {
            switch (initialWeight)
            {
                case 0:
                    displayWeight.Texture = Content.Load<Texture2D>("num0");
                    break;
                case 1:
                    displayWeight.Texture = Content.Load<Texture2D>("num1");
                    break;
                case 2:
                    displayWeight.Texture = Content.Load<Texture2D>("num2");
                    break;
                case 3:
                    displayWeight.Texture = Content.Load<Texture2D>("num3");
                    break;
                case 4:
                    displayWeight.Texture = Content.Load<Texture2D>("num4");
                    break;
                case 5:
                    displayWeight.Texture = Content.Load<Texture2D>("num5");
                    break;
                case 6:
                    displayWeight.Texture = Content.Load<Texture2D>("num6");
                    break;
                case 7:
                    displayWeight.Texture = Content.Load<Texture2D>("num7");
                    break;
                case 8:
                    displayWeight.Texture = Content.Load<Texture2D>("num8");
                    break;
                case 9:
                    displayWeight.Texture = Content.Load<Texture2D>("num9");
                    break;
                case 10:
                    displayWeight.Texture = Content.Load<Texture2D>("num10");
                    break;
            }

            if (initialWeight < 0)
            {
                initialWeight = 0;
            }
            else if (initialWeight > 10)
            {
                initialWeight = 10;
            }
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

        private void CheckGravUpBtnPressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > gravUpBtn.X && mMouseCursor.X < gravUpBtn.X + gravUpBtn.Texture.Width
                    && mMouseCursor.Y > gravUpBtn.Y && mMouseCursor.Y < gravUpBtn.Y + gravUpBtn.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        gravUpBtn.Texture = plusBtnDownTexture;
                        initialGravity++;
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    gravUpBtn.Texture = plusBtnTexture;
                }
            }
        }

        private void CheckGravDownBtnPressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > gravDownBtn.X && mMouseCursor.X < gravDownBtn.X + gravDownBtn.Texture.Width
                    && mMouseCursor.Y > gravDownBtn.Y && mMouseCursor.Y < gravDownBtn.Y + gravDownBtn.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        gravDownBtn.Texture = minusBtnDownTexture;
                        initialGravity--;
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    gravDownBtn.Texture = minusBtnTexture;
                }
            }
        }

        private void CheckWeightUpBtnPressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > weightUpBtn.X && mMouseCursor.X < weightUpBtn.X + weightUpBtn.Texture.Width
                    && mMouseCursor.Y > weightUpBtn.Y && mMouseCursor.Y < weightUpBtn.Y + weightUpBtn.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        weightUpBtn.Texture = plusBtnDownTexture;
                        initialWeight++;
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    weightUpBtn.Texture = plusBtnTexture;
                }
            }
        }

        private void CheckWeightDownBtnPressed()
        {
            if (mMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                if (mMouseCursor.X > weightDownBtn.X && mMouseCursor.X < weightDownBtn.X + weightDownBtn.Texture.Width
                    && mMouseCursor.Y > weightDownBtn.Y && mMouseCursor.Y < weightDownBtn.Y + weightDownBtn.Texture.Height)
                {
                    if (mMouseState.LeftButton == ButtonState.Pressed)
                    {
                        weightDownBtn.Texture = minusBtnDownTexture;
                        initialWeight--;
                    }
                }
            }
            if (mMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (mMouseState.LeftButton == ButtonState.Released)
                {
                    weightDownBtn.Texture = minusBtnTexture;
                }
            }
        }

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
            gravLabel.Draw(spriteBatch);
            gravUpBtn.Draw(spriteBatch);
            gravDownBtn.Draw(spriteBatch);
            displayGravity.Draw(spriteBatch);
            displayWeight.Draw(spriteBatch);
            weightLabel.Draw(spriteBatch);
            weightUpBtn.Draw(spriteBatch);
            weightDownBtn.Draw(spriteBatch);
            mMouseCursor.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
