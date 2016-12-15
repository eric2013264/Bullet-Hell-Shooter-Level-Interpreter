using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robot_House_Touhou_Game
{
    class Collisions
    {
        int playerDamage = 1000;
        bool god_mode = true;
        public string godModeEnabled; 
        public void Collide(AttackDecorator attackDecorator, player player)
        {
            if (player.respawn == false && player.invincibility == false)
            {
                int returnvalue = 0;
                returnvalue = attackDecorator.collision(player.BoundingBox);
                if (returnvalue != -1 && god_mode == false)
                {
                    Vector2 temp = new Vector2(250, 500);
                    player.set_origin(temp);
                    player.respawn = true;
                    player.invincibility = true;
                    player.update_path();
                    player.life--;
                }
            }

        }

        public bool Collide(List<enemy1> enemies, enemy1 enemy, AttackDecorator bullet)
        {
            // Merge eventually once we figure out dynamics behind killing them 

            if (enemy.BoundingBox.Intersects(bullet.BoundingBox) && bullet.isVisible == true && enemy.isVisible == true)
            {
                enemy.health -= playerDamage;
                bullet.isVisible = false;
                if (enemy.health <= 0)
                {
                    enemy.isVisible = false;
                    enemy.firing = false;
                    return true; 
                }
                

            }
            return false;
        }

        //This is for power ups collide -by John
        public bool Collide(Vector2 powerups_coordinate, player player)
        {
            //TODO: create bouding box for the coordinate
            Rectangle power_ups_bounding_box = new Rectangle(
                   (int)powerups_coordinate.X,
                   (int)powerups_coordinate.Y,
                   25,
                   25);



            if (power_ups_bounding_box.Intersects(player.BoundingBox))
            {
                if (player.respawn == false)
                {
                    return true;
                }

            }
            return false;
        }
        public void Collide(enemy enemy, player player)
        {
            if (player.respawn == false && player.invincibility == false)
            {
                if (enemy.BoundingBox.Intersects(player.BoundingBox) && enemy.isVisible == true && god_mode == false)
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

        public void Collide(enemy1 enemy, player player)
        {
            if (player.respawn == false && player.invincibility == false)
            {
                if (enemy.BoundingBox.Intersects(player.BoundingBox) && enemy.isVisible == true)
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
        public bool Collide(List<enemy> enemies, enemy enemy, AttackDecorator bullet)
        {
            // Merge eventually once we figure out dynamics behind killing them 
            foreach (BaseBullet shot in bullet.Attack.attackRing)
            {
                if (enemy.BoundingBox.Intersects(shot.BoundingBox) && shot.isVisible == true && enemy.isVisible == true)
                {
                    enemy.health--;
                    bullet.isVisible = false;
                    if (enemy.health == 0)
                    {
                        enemy.isVisible = false;
                        enemy.firing = false;
                        return true; 
                    }

                }

            }
            return false; 
            

        }

        public void setGodMode()
        {
            god_mode = true;
            playerDamage = 1000;
            godModeEnabled = "GOD MODE ENABLED";
        }
        public void revertGodMode()
        {
            god_mode = false;
            playerDamage = 1;
            godModeEnabled = "";
        }
    }
}