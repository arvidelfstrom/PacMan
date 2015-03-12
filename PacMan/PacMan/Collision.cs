using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacMan
{
    public class Collision
    {
        private ArrayList entities;

        /// <summary>
        /// Initialize the collision class
        /// </summary>
        public Collision()
        {
            this.entities = new ArrayList();
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
        /// Check collisions and notify the entities where collisions occured
        /// </summary>
        public void checkCollisions()
        {
            foreach (Entity entity in entities)
            {
                Console.WriteLine(entity.CollisionBox.ToString());
            }
        }
    }
}
