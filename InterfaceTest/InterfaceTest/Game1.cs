using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MB_GameTemplate
{
    public class Game1 : Game
    {
        private float time;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<GameObject> Objects;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            TargetElapsedTime = TimeSpan.FromTicks(333333);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Objects = new List<GameObject>();

            //Testing GameObject classes:
            Random rand = new Random();

            Objects.Add(new Player(0f, 400f, 0f, 40f, 80f, 0.25f, Content.Load<Texture2D>("ring"), Color.White, new Vector2(GraphicsDevice.Viewport.Width * 0.5f, GraphicsDevice.Viewport.Height * 0.5f),
                new Vector2(1, 0), 40, 40, CollisionState.COLLISION_ALL));

            Random randomizer = new Random();

            for (int i = 1; i <= 200; i++)
            {
                Objects.Add(new Bouncer(1.02f, randomizer.Next(20, 50), 999f, 0f, 0f, 0f, 0f, Content.Load<Texture2D>("ring"), Color.Blue, new Vector2(randomizer.Next(0, GraphicsDevice.Viewport.Width), randomizer.Next(0, GraphicsDevice.Viewport.Height)),
                new Vector2(randomizer.Next(-1, 1), randomizer.Next(-1, 1)), 20, 20, CollisionState.COLLISION_ALL));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            KeyboardHandler.UpdateKeyboard();

            foreach (MovingObject mover in Objects)
            {
                mover.Move(time / 1000, GraphicsDevice);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            foreach (GameObject entity in Objects)
            {
                entity.UpdateRectangle();
                _spriteBatch.Draw(entity.Sprite, entity.Rect, entity.RenderColor);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}