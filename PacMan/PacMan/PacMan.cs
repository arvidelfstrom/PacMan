﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    class PacMan : Entity
    {

        public PacMan(String name, float x, float y): base(name, x, y, new Vector2(0, 0))
        {

        }

        public override void update(GameWindow window) {
            handleKeyboard();

            //TODO handle collision

            base.update(window);
        }

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
