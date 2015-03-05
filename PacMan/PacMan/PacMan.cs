using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    class PacMan : Entity
    {
        /// <summary>
        /// Initialize the PacMan
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PacMan(String name, float x, float y) : base(name, x, y, new Vector2(0, 0), 48, 48)
        {
            // Do nothing
        }

        /// <summary>
        /// Game logic, handle keyboard presses etc.
        /// </summary>
        /// <param name="window"></param>
        public override void update(GameWindow window) {
            handleKeyboard();

            //TODO handle collision

            base.update(window);
        }

        /// <summary>
        /// Draw PacMan on screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void drawEntity(SpriteBatch spriteBatch)
        {
            Texture2D texture = MainGame.textures[name];
            float rotation = SpeedX > 0 ? 0 : SpeedY > 0 ? (float)(Math.PI / 2) : SpeedY < 0 ? (float)(Math.PI + Math.PI / 2) : (float)(Math.PI);

            spriteBatch.Draw(texture, coords, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Handle keyboard presses
        /// </summary>
        private void handleKeyboard() {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
            {
                SpeedX = -2F;
                SpeedY = 0F;
            }

            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
            {
                SpeedX = 2F;
                SpeedY = 0F;
            }

            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up))
            {
                SpeedX = 0F;
                SpeedY = -2F;
            }

            if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
            {
                SpeedX = 0F;
                SpeedY = 2F;
            }
        }

    }
}
