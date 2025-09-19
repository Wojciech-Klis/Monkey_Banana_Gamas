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
        private Texture2D _monkey;
        private Texture2D _banan;
        private int _monkeyWidth = 200;
        private int _monkeyHeight = 200;
        private int _bananWidth = 120;
        private int _bananHeight = 120;
        private int _monkeyXPos;
        private int _monkeyYPos;
        private int _bananXPos;
        private int _bananYPos;
        private double _elapsed;
        Random _random = new Random();
        Stopwatch stopwatch = new();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;

            _monkeyXPos = (_graphics.PreferredBackBufferWidth / 2) - _monkeyWidth;
            _monkeyYPos = (_graphics.PreferredBackBufferHeight / 2) - _monkeyHeight;
            _bananXPos = (_graphics.PreferredBackBufferWidth / 2) - _monkeyWidth;
            _bananYPos = (_graphics.PreferredBackBufferHeight / 2) - _monkeyHeight;

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
            _monkey = Content.Load<Texture2D>("monkey");
            _banan = Content.Load<Texture2D>("banan");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _elapsed += gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Add your update logic here
            
            int _randomY = _random.Next(0, _graphics.PreferredBackBufferHeight - _monkeyHeight);
            int _randomX = _random.Next(0, _graphics.PreferredBackBufferWidth - _monkeyWidth);
            
            Debug.WriteLine(_elapsed);
            
            if (_elapsed >= 6)
            {
                _bananYPos = _randomY;
                _bananXPos = _randomX;
                _elapsed = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (_monkeyXPos > 0)
                {
                    _monkeyXPos -= 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (_monkeyXPos + _monkeyWidth <= _graphics.PreferredBackBufferWidth)
                {
                    _monkeyXPos += 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (_monkeyYPos > 0)
                {
                    _monkeyYPos -= 5;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (_monkeyYPos + _monkeyHeight <= _graphics.PreferredBackBufferHeight)
                {
                    _monkeyYPos += 5;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_monkey, new Rectangle(_monkeyXPos, _monkeyYPos, _monkeyWidth, _monkeyHeight), Color.White);
            _spriteBatch.Draw(_banan, new Rectangle(_bananXPos, _bananYPos, _bananWidth, _bananHeight), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
