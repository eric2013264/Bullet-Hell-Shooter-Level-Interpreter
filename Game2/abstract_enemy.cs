using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;

namespace Robot_House_Touhou_Game
{
    //abstract enemy. The base for all enemies
    public abstract class enemy
    {
        public List<Attacks> attacks;
        public float speedX;
        public float speedY;
        public string ID;
        public int health;
        private Vector2 origin;
        public Vector2 path;
        public Color[] colorData = new Color[100 * 100];
        public int index;
        public bool isVisible;
        public bool firing;
        public bool finished = false;
        public int path_number = 1;
        public Vector2[] path_map;
        public bool repeat_bool = false;
        public int pause_time = 0;
        public string bullet_path;
        public string bullet_attack;

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)origin.X,
                    (int)origin.Y,
                    30,
                    30);
            }
        }

        //public void Collide(List<enemy> enemies, enemy enemy, PlayerAttacks bullet)
        //{
        //    if ((enemy.BoundingBox.Intersects(bullet.BoundingBox) && enemy.ID == "enemy6") || (enemy.BoundingBox.Intersects(bullet.BoundingBox) && enemy.ID == "boss"))
        //    {
        //        bullet.isVisible = false;
        //    }

        //    else if (enemy.BoundingBox.Intersects(bullet.BoundingBox))
        //    {
        //        enemy.isVisible = false;
        //        enemy.firing = false;
        //    }
        //}

        public Vector2 get_origin()
        {
            return origin;
        }

        public void set_origin(Vector2 new_origin)
        {
            origin = new_origin;
        }

        public Vector2 get_path()
        {
            return path;
        }

        public void Collide(enemy enemy, player player)
        {
            if (enemy.BoundingBox.Intersects(player.BoundingBox) && enemy.isVisible == true)
            {
                if (player.respawn == false && player.invincibility == false)
                {
                    Vector2 temp = new Vector2(250, 500);
                    player.set_origin(temp);
                    player.respawn = true;
                    player.invincibility = true;
                    player.update_path();
                    player.setlife(player.getlife() - 1);
                }

            }
        }

        // Most Recent Update: Bullet now doesn't pass through the enemy! No through and throughs -Eric
        public void Collide(List<enemy> enemies, enemy enemy, AttackDecorator bullet)
        {
            // Merge eventually once we figure out dynamics behind killing them 

            if (enemy.BoundingBox.Intersects(bullet.BoundingBox) && bullet.isVisible == true && enemy.isVisible == true)
            {
                enemy.health--;
                bullet.isVisible = false;
                if (enemy.health == 0)
                {
                    enemy.isVisible = false;
                    enemy.firing = false;
                }

            }

        }



    }

}
