using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PacMan
{
    public class Collision
    {
        private List<Entity> entities;
        private List<Rectangle> walls;

        /// <summary>
        /// Initialize the collision class
        /// </summary>
        public Collision()
        {
            this.entities = new List<Entity>();
            this.walls = new List<Rectangle>();
        }
        
        /// <summary>
        /// Link the entity to the collision library
        /// </summary>
        /// <param name="entity"></param>
        public void link(ref Entity entity)
        {
            this.entities.Add(entity);
        }

        /// <summary>
        /// Add a collision wall
        /// </summary>
        /// <param name="wall"></param>
        public void addWall(Rectangle wall)
        {
            this.walls.Add(wall);
        }

        /// <summary>
        /// Check collisions and notify the entities where collisions occured
        /// </summary>
        public void checkCollisions()
        {
            foreach (Entity entity in entities)
            {
                // Reset entity collision
                entity.DidCollide = false;

                // Detect wall collision
                foreach (Rectangle wall in walls)
                {
                    if (entity.CollisionBox.Intersects(wall))
                    {
                        entity.onCollision(wall);
                    }
                }
            }

            // Loop all objects
            foreach (Entity entity1 in entities)
            {
                // Loop all objects again
                foreach (Entity entity2 in entities)
                {
                    // Check if each object collides with the other and they haven't already collided
                    if (entity1 != entity2
                        && entity1.CollisionBox.Intersects(entity2.CollisionBox)
                        && !entity1.DidCollide
                        && !entity2.DidCollide
                        && entity1.IsAlive
                        && entity2.IsAlive)
                    {
                        entity1.DidCollide = true;
                        entity2.DidCollide = true;

                        entity1.onCollision(entity2);
                        entity2.onCollision(entity1);
                    }
                }
   
            }
        }
    }
}
