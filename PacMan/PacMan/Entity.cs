using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    /// <summary>
    /// Entity is the base class for all visible objects
    /// </summary>
    public abstract class Entity
    {
        protected String name;
        protected Vector2 coords;
        private Vector2 speed;
        private Rectangle collisionBox;

        // Getters and setters
        public float X { get { return coords.X; } }
        public float Y { get { return coords.Y; } }
        public float SpeedX { get { return speed.X; } set { speed.X = value; } }
        public float SpeedY { get { return speed.Y; } set { speed.Y = value; } }
        public float Width { get { return MainGame.textures[name].Width; } }
        public float Height { get { return MainGame.textures[name].Height; } }
        public String Name { get { return name; } }
        public Rectangle CollisionBox { get { return collisionBox; } }

        /// <summary>
        /// Create a new entity object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Entity(String name, float x, float y, Vector2 speed, int width, int height)
        {
            this.name = name;
            this.coords = new Vector2(x, y);
            this.speed = speed;
            this.collisionBox = new Rectangle((int)x, (int)y, width, height);

            //MainGame.collision.link(ref this); todo, skicka this som ref
        }

        /// <summary>
        /// Update game logic. Move entity, etc.
        /// </summary>
        /// <param name="window"></param>
        public virtual void update(GameWindow window) {
            this.coords += this.speed;

        
        }

        /// <summary>
        /// Draw entity to screen
        /// </summary>
        /// <param name="spriteBatch"></param>
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
    }
}
