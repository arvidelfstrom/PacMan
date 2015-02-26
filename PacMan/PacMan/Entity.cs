using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    public abstract class Entity
    {
        protected String name;
        protected Vector2 coords;
        private Vector2 speed;

        public Entity(String name, Vector2 coords, Vector2 speed)
        {
            this.name = name;
            this.coords = coords;
            this.speed = speed;
        }

        public Entity(String name, float y, float x, Vector2 speed): this(name, new Vector2(x, y), speed) {}

        public Entity(String name, float y, float x): this(name, new Vector2(x, y), new Vector2(2F, 0)) {}

        public Entity(String name, Vector2 coords): this(name, coords, new Vector2(2F, 0)) {}

        public virtual void update(GameWindow window) {
            this.coords += this.speed;
        }

        public virtual void drawEntity(SpriteBatch spriteBatch) {
            Texture2D texture = MainGame.textures[name];
            spriteBatch.Draw(texture, coords, Color.White);
        }
        
        public float X { get { return coords.X; } }
        public float Y { get { return coords.Y; } }
        public float SpeedX { get { return speed.X; } set { speed.X = value; } }
        public float SpeedY { get { return speed.Y; } set { speed.Y = value; } }
        public float Width { get { return MainGame.textures[name].Width; } }
        public float Height { get { return MainGame.textures[name].Height; } }
        public String Name { get { return name; } }
        

    }
}
