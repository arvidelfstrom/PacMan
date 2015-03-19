using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    public class Score
    {
        private SpriteFont font;
        private int count;

        public Score(SpriteFont loadedFont)
        {
            font = loadedFont;
            count = 0;
        }

        public void addScore(int addCount)
        {
            count += addCount;
        }
        
        public void drawEntity(SpriteBatch spriteBatch) 
        {
            spriteBatch.DrawString(font, "Score: " + count, new Vector2(10, 10), Color.Black);
        }
    }
}
