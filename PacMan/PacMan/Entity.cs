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
        private Rectangle collisionBox;

        public Entity(String name, float x, float y, Vector2 speed, int width, int height)
        {
            this.name = name;
            this.coords = new Vector2(x, y);
            this.speed = speed;
            this.collisionBox = new Rectangle((int)x, (int)y, width, height);
        }

        public virtual void update(GameWindow window) {
            this.coords += this.speed;
        }

        public virtual void drawEntity(SpriteBatch spriteBatch) {
            Texture2D texture = MainGame.textures[name];
            spriteBatch.Draw(texture, coords, Color.White);
        }

        /// <summary>
        /// Triggered when this object collides with another one.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void onCollision(Entity entity)
        {
            // Collided!
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
