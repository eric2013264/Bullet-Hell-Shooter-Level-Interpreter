using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;

namespace Robot_House_Touhou_Game
{
    //creation of enemy builder (not implemented yet)
    class enemy_builder
    {
        private abstract_path path = null;
        private enemy new_enemy = null;

        public void attach_path1(Vector2 origin)
        {
            path = new path1(origin);
        }

        public void attach_path2(Vector2 origin)
        {
            path = new path2(origin);
        }

        public void attach_path3(Vector2 origin)
        {
            path = new path3(origin);
        }

        public void attach_path4(Vector2 origin)
        {
            path = new path4(origin);
        }

        public void attach_path5(Vector2 origin)
        {
            path = new path5(origin);
        }

        public void attach_path6(Vector2 origin)
        {
            path = new path6(origin);
        }

        public void attach_path7(Vector2 origin)
        {
            path = new path7(origin);
        }

        public void attach_path8(Vector2 origin)
        {
            path = new path7(origin);
        }

        public void attach_midboss(Vector2 origin)
        {
            path = new midboss(origin);
        }
        public void attach_stage1(Vector2 origin)
        {
            path = new stage1(origin);
        }
        public void attach_stage2(Vector2 origin)
        {
            path = new stage2(origin);
        }
        public void attach_stage3(Vector2 origin)
        {
            path = new stage3(origin);
        }


        public enemy_with_movement Build(string new_ID, int new_health, bool fire_state, Vector2 new_origin, string bullet_path, string bullet_attack)
        {
            enemy_with_movement new_enemy = new enemy_with_movement(new_ID, new_health, fire_state, new_origin, bullet_path, bullet_attack);

            if (path != null)
            {
                new_enemy.path_map = path.path_map;
                new_enemy.path = new_enemy.path_map[0];
            }

            else
            {
                return null;
            }

            return new_enemy;
        }
    }
}
