using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;
using Microsoft.Xna.Framework.Input;
using System.Xml.Linq;

namespace Monkey_Banana_Gamas
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
        private Vector2 _scorePos;
        private int score = -1;
        private Rectangle _monkeyRectangle, _bananRectangle;
        private double _elapsed;
        Random _random = new Random();
        Stopwatch stopwatch = new();
        private SpriteFont _score;

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
            _score = Content.Load<SpriteFont>("myScore");

            _monkeyRectangle = new Rectangle(_monkeyXPos, _monkeyYPos, _monkeyWidth, _monkeyHeight);
            _bananRectangle = new Rectangle(_bananXPos, _bananYPos, _bananWidth, _bananHeight);
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

            if(_monkeyRectangle.Intersects(_bananRectangle))
            {
                _bananYPos = _randomY;
                _bananXPos = _randomX;
                _elapsed = 0;
                score += 1;
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

            _monkeyRectangle.X = _monkeyXPos;
            _monkeyRectangle.Y = _monkeyYPos;
            _bananRectangle.X = _bananXPos;
            _bananRectangle.Y = _bananYPos;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_monkey, _monkeyRectangle, Color.White);
            _spriteBatch.Draw(_banan, _bananRectangle, Color.White);
            _spriteBatch.DrawString(_score, $"Score: {score}", _scorePos, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
