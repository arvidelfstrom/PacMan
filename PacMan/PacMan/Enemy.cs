using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace PacMan
{
    class Enemy : Entity
    {
        public Enemy(String name, float x, float y): base (name, x, y, new Vector2(0, 0), 27, 37)
        {

        }

        public override void update(GameWindow window)
        {

            //TODO handle collision

            base.update(window);
        }

        public override void drawEntity(SpriteBatch spriteBatch) 
        {
            if (!IsAlive) return;


            Texture2D texture = MainGame.textures[name];
            spriteBatch.Draw(texture, coords, Color.White);
        }
    }
}
