using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DVD_Logo_2025
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _logo;
        private int _logoXPos = 0;
        private int _logoYPos = 0;
        private bool _logoXPosState = true;
        private bool _logoYPosState = true;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (_logoXPos == 0)
            {
                _logoXPosState = true;
            }

            else if (_logoXPos == 1130)
            {
                _logoXPosState = false;
            }

            if (_logoYPos == -40)
            {
                _logoYPosState = true;
            }

            else if (_logoYPos == 610)
            {
                _logoYPosState = false;
            }

            if (_logoXPosState == true)
            {
                _logoXPos += 2;
            }

            else if(_logoXPosState == false)
            {
                _logoXPos -= 2;
            }

            if(_logoYPosState == true)
            {
                _logoYPos += 2;
            }

            else if(_logoYPosState == false)
            {
                _logoYPos -= 2;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            _spriteBatch.Begin();

            _spriteBatch.Draw(_logo, new Rectangle(_logoXPos, _logoYPos, 150, 150), Color.White);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
