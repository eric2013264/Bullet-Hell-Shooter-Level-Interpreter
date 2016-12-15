using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;

namespace Robot_House_Touhou_Game
{
    class enemy_with_movement : enemy
    {
        public List<Vector2[]> paths = new List<Vector2[]>();
        public enemy_with_movement(string new_ID, int new_health, bool fire_state, Vector2 new_origin, string new_bullet_path, string new_bullet_attack)
        {
            ID = new_ID;
            health = new_health;
            firing = fire_state;
            set_origin(new_origin);
            index = 0;
            isVisible = true;
            speedX = 4;
            speedY = 4;
            bullet_path = new_bullet_path;
            bullet_attack = new_bullet_attack;
        }
        public virtual void set_path(enemy enemy, GameTime gameTime, float timecounter)
        {
            if (index + 1 < path_map.Length)
            {
                if ((ID == "midboss" || ID == "boss"))
                {
                    pause_time++;
                    if (pause_time == 100)
                    {
                        index++;
                        path = path_map[index];
                        pause_time = 0;
                    }

                }
                else
                {
                    index++;
                    path = path_map[index];
                }

            }
            if (out_of_bounds(this) == true)
            {
                finished = true;
            }
        }

        public bool out_of_bounds(enemy enemy)
        {
            if (enemy.get_origin().X < 0 || enemy.get_origin().X > 650)
            {
                return true;
            }

            if (enemy.get_origin().Y < -100 || enemy.get_origin().Y > 600)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public void update_path(GameTime gameTime, float timecounter)
        {

            if (get_origin().X < get_path().X)
            {
                Vector2 temp = new Vector2(get_origin().X + speedX, get_origin().Y);
                this.set_origin(temp);
            }

            if (get_origin().X > get_path().X)
            {
                Vector2 temp = new Vector2(get_origin().X - speedX, get_origin().Y);
                this.set_origin(temp);

            }

            if (get_origin().Y < get_path().Y)
            {
                Vector2 temp = new Vector2(get_origin().X, get_origin().Y + speedY);
                this.set_origin(temp);

            }

            if (get_origin().Y > get_path().Y)
            {
                Vector2 temp = new Vector2(get_origin().X, get_origin().Y - speedY);
                this.set_origin(temp);

            }

            if ((index == path_map.Length - 1) && (ID == "midboss" || ID == "boss"))
            {
                repeat_bool = true;
            }

            if (Vector2.Distance(this.get_origin(), this.get_path()) < 3)
            {
                if ((ID == "midboss" || ID == "boss") && repeat_bool)
                {
                    index = -1;
                    repeat_bool = false;
                }

                this.set_path(this, gameTime, timecounter);
            }
        }
    }
}

