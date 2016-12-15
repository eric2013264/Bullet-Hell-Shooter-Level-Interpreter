using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;

namespace Robot_House_Touhou_Game
{
    //player class
    public class player
    {
        Vector2 origin;
        public bool respawn = false;
        public bool invincibility = false;
        public int ticker = 0;
        Vector2 respawn_path = new Vector2(250, 400);
        public int life = 3;///3 health initially 
        public bool isVisible;
        public player(Vector2 new_origin)
        {
            origin = new_origin;
        }

        //returns health
        public int getlife()
        {
            return life;

        }
        //sets health
        public void setlife(int newlife)
        {
            life = newlife;
        }

        //sets origin
        public void set_origin(Vector2 new_origin)
        {
            origin = new_origin;
        }

        //returns origin
        public Vector2 get_origin()
        {
            return origin;
        }

        //updates the player's location on screen
        public void update_path()
        {

            if (get_origin().X < respawn_path.X)
            {
                Vector2 temp = new Vector2(get_origin().X + 5, get_origin().Y);
                set_origin(temp);
            }

            if (get_origin().X > respawn_path.X)
            {
                Vector2 temp = new Vector2(get_origin().X - 5, get_origin().Y);
                set_origin(temp);

            }

            if (get_origin().Y < respawn_path.Y)
            {
                Vector2 temp = new Vector2(get_origin().X, get_origin().Y + 5);
                set_origin(temp);

            }

            if (get_origin().Y > respawn_path.Y)
            {
                Vector2 temp = new Vector2(get_origin().X, get_origin().Y - 5);
                set_origin(temp);

            }

            if (get_origin().X == respawn_path.X && get_origin().Y == respawn_path.Y)
            {
                respawn = false;
            }


        }

        //creation of the hitbox
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)origin.X + 18,
                    (int)origin.Y + 18,
                    2,
                    2);
            }
        }

        //collision detection functions
        public void Collide(enemy1 enemy, player player)
        {
            if (respawn == false && invincibility == false)
            {
                if (enemy.BoundingBox.Intersects(player.BoundingBox) && enemy.isVisible == true)
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

        //public void Collide(AttackDecorator attack, player player)
        //{
        //    if (respawn == false && invincibility == false)
        //    {
        //        if (attack.collision(player.BoundingBox) BoundingBox.Intersects(player.BoundingBox) && attack.isVisible == true)
        //        {
        //            Vector2 temp = new Vector2(250, 500);
        //            player.set_origin(temp);
        //            player.respawn = true;
        //            player.invincibility = true;
        //            player.update_path();
        //            player.life--;
        //            attack.isVisible = false;
        //        }
        //    }

        //}

        

    }
}
