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
        private Boolean didCollide;
        private Boolean isAlive;

        // Getters and setters
        public float X { get { return coords.X; } }
        public float Y { get { return coords.Y; } }
        public float SpeedX { get { return speed.X; } set { speed.X = value; } }
        public float SpeedY { get { return speed.Y; } set { speed.Y = value; } }
        public float Width { get { return MainGame.textures[name].Width; } }
        public float Height { get { return MainGame.textures[name].Height; } }
        public String Name { get { return name; } }
        public Rectangle CollisionBox { get { return collisionBox; } }
        public Boolean DidCollide { get { return didCollide; } set { didCollide = value;  } }
        public Boolean IsAlive { get { return isAlive; } set { isAlive = value;  } }

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
            this.didCollide = false;
            this.collisionBox = new Rectangle((int)x, (int)y, width, height);
            this.isAlive = true;
        }

        /// <summary>
        /// Update game logic. Move entity, etc.
        /// </summary>
        /// <param name="window"></param>
        public virtual void update(GameWindow window) {
            // Don't update if the entity is dead
            if (!isAlive) return;

            this.coords += this.speed;
            this.collisionBox.X = (int)this.coords.X;
            this.collisionBox.Y = (int)this.coords.Y;
            
        }

        /// <summary>
        /// Draw entity to screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void drawEntity(SpriteBatch spriteBatch) {
            // Don't draw if the entity is dead
            if (!isAlive) return;

            Texture2D texture = MainGame.textures[name];
            spriteBatch.Draw(texture, coords, Color.White);

            // todo: draw hitbox rectangle
        }

        /// <summary>
        /// Triggered when this entity collides with another entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void onCollision(Entity entity)
        {
            // Collided with an entity!
        }

        /// <summary>
        /// Triggered when this entity collides with a wall
        /// </summary>
        /// <param name="wall"></param>
        public virtual void onCollision(Rectangle wall)
        {
            // Collided with a wall!
        }
    }
}
