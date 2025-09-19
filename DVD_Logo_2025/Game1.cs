using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;
using Microsoft.Xna.Framework.Input;

namespace DVD_Logo_2025
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _logo;
        private Texture2D _logo2;
        private int _logoWidth = 100;
        private int _logoHeight = 50;
        private int _logoXPos;
        private int _logoYPos;
        private int _logo2XPos;
        private int _logo2YPos;
        private double _elapsed;
        Random _random = new Random();
        Stopwatch stopwatch = new();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

            _logoXPos = (_graphics.PreferredBackBufferWidth / 2) - _logoWidth;
            _logoYPos = (_graphics.PreferredBackBufferHeight / 2) - _logoHeight;
            _logo2XPos = (_graphics.PreferredBackBufferWidth / 2) - _logoWidth;
            _logo2YPos = (_graphics.PreferredBackBufferHeight / 2) - _logoHeight;

            Stopwatch.StartNew();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _logo = Content.Load<Texture2D>("dvd-logo-black-and-white");
            _logo2 = Content.Load<Texture2D>("dvd-logo-black-and-white");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _elapsed += gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Add your update logic here
            
            int _randomY = _random.Next(0, _graphics.PreferredBackBufferHeight - _logoHeight);
            int _randomX = _random.Next(0, _graphics.PreferredBackBufferWidth - _logoWidth);
            
            Debug.WriteLine(_elapsed);
            
            if (_elapsed >= 6)
            {
                _logo2YPos = _randomY;
                _logo2XPos = _randomX;
                _elapsed = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (_logoXPos > 0)
                {
                    _logoXPos -= 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (_logoXPos + _logoWidth <= _graphics.PreferredBackBufferWidth)
                {
                    _logoXPos += 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (_logoYPos > 0)
                {
                    _logoYPos -= 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (_logoYPos + _logoHeight <= _graphics.PreferredBackBufferHeight)
                {
                    _logoYPos += 5;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_logo, new Rectangle(_logoXPos, _logoYPos, _logoWidth, _logoHeight), Color.White);
            _spriteBatch.Draw(_logo2, new Rectangle(_logo2XPos, _logo2YPos, _logoWidth, _logoHeight), Color.Red);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
