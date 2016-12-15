using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;

namespace Robot_House_Touhou_Game
{
    //all different types of enemies
    public class non_shooting_enemy1 : enemy
    {
        public non_shooting_enemy1(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;

            path_map = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X + 650, new_origin.Y + 210),
                };

            path = path_map[index];
        }
    }

    public class non_shooting_enemy2 : enemy
    {
        public non_shooting_enemy2(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;

            path_map = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X -650, new_origin.Y + 210),
                };
            path = path_map[index];
        }
    }

    public class non_shooting_enemy3 : enemy
    {
        public non_shooting_enemy3(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;

            path_map = new Vector2[]
                {
                        new Vector2(new_origin.X, 160),
                        new Vector2(new_origin.X, new_origin.Y),
                };
            path = path_map[index];
        }


    }

    public class non_shooting_enemy4 : enemy
    {
        public non_shooting_enemy4(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;

            path_map = new Vector2[]
               {
                        new Vector2(new_origin.X, new_origin.Y + 100),
                        new Vector2(new_origin.X - 650, new_origin.Y + 170),
                   // new Vector2(50, 0), 
                   //new Vector2(50, 0)
               };
            path = path_map[index];
        }
    }

    public class non_shooting_enemy5 : enemy
    {
        public non_shooting_enemy5(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;

            path_map = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 100),
                        new Vector2(new_origin.X + 650, new_origin.Y + 170),
                    // new Vector2(50, 0), 
                    //new Vector2(50, 0)
                };
            path = path_map[index];


        }
    }

    public class non_shooting_enemy6 : enemy
    {
        public non_shooting_enemy6(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;

            path_map = new Vector2[]
               {
                        new Vector2(new_origin.X, new_origin.Y + 600),
               };

            path = path_map[index];


        }
    }

    public class shooting_enemy1 : enemy
    {
        public shooting_enemy1(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;
        }

    }

    public class shooting_enemy2 : enemy
    {
        public shooting_enemy2(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;
        }
    }

    public class mid_boss : enemy
    {
        public mid_boss(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;

            path_map = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 100),
                        new Vector2(new_origin.X - 150, new_origin.Y + 140),
                        new Vector2(new_origin.X - 250, new_origin.Y + 170),
                        new Vector2(50, 0),
                        new Vector2(new_origin.X, new_origin.Y + 100),
                        new Vector2(new_origin.X, new_origin.Y)
                };
            path = path_map[index];
        }
    }
    public class end_boss : enemy
    {
        Vector2[] stage1;
        Vector2[] stage2;
        Vector2[] stage3;
        Vector2[] leave;

        public end_boss(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;


            stage1 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 150),
                        new Vector2(new_origin.X + 100, new_origin.Y + 130),
                        new Vector2(new_origin.X + 70, new_origin.Y + 100),

                };

            stage2 = new Vector2[]
            {
                        new Vector2(new_origin.X, new_origin.Y + 150),
                        new Vector2(new_origin.X + 50, new_origin.Y + 150),
                        new Vector2(new_origin.X - 100, new_origin.Y + 60),

            };

            stage3 = new Vector2[]
            {
                        new Vector2(new_origin.X, new_origin.Y + 150),
                        new Vector2(new_origin.X - 150, new_origin.Y + 150),
                        new Vector2(new_origin.X - 120, new_origin.Y + 160),
                        new Vector2(new_origin.X, new_origin.Y + 70),

            };

            leave = new Vector2[]
            {
                        new Vector2(new_origin.X, -150),

            };




            path = stage1[index];
        }
    }


























    public class enemy1 : enemy
    {
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

        public enemy1(string new_ID, Vector2 new_origin, bool fire)
        {
            attacks = new List<Attacks>(); //initialize new list of attacks 
            isVisible = true;
            ID = new_ID;
            firing = fire;


            //basic enemy will head down and then to the right
            if (ID == "enemy1")
            {
                health = 1;
                origin = new_origin;
                colorData = new Color[100 * 100];
                index = 0;
                speedX = 30;
                speedY = 30;
                path1 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X + 650, new_origin.Y + 210),
                    // new Vector2(50, 0),
                    //new Vector2(50, 0)
                };

                path = path1[index];
            }

            if (ID == "enemy2")
            {
                health = 1;
                origin = new_origin;
                colorData = new Color[100 * 100];
                index = 0;
                speedX = 4;
                speedY = 4;
                path2 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X -650, new_origin.Y + 210),
                    // new Vector2(50, 0), 
                    //new Vector2(50, 0)
                };
                path = path2[index];
            }

            if (ID == "enemy3")
            {
                health = 1;
                origin = new_origin;
                colorData = new Color[100 * 100];
                index = 0;
                speedX = 4;
                speedY = 4;
                path3 = new Vector2[]
                {
                        new Vector2(new_origin.X, 160),
                        new Vector2(new_origin.X, new_origin.Y),
                };
                path = path3[index];
            }

            if (ID == "enemy4")
            {
                health = 100;
                origin = new_origin;
                colorData = new Color[100 * 100];
                index = 0;
                speedX = 2;
                speedY = 2;
                path4 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 100),
                        new Vector2(new_origin.X - 650, new_origin.Y + 170),
                    // new Vector2(50, 0), 
                    //new Vector2(50, 0)
                };
                path = path4[index];
            }

            if (ID == "enemy5")
            {
                health = 100;
                origin = new_origin;
                colorData = new Color[100 * 100];
                index = 0;
                speedX = 2;
                speedY = 2;
                path5 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 100),
                        new Vector2(new_origin.X + 650, new_origin.Y + 170),
                    // new Vector2(50, 0), 
                    //new Vector2(50, 0)
                };
                path = path5[index];
            }

            if (ID == "midboss")
            {
                health = 200;
                origin = new_origin;
                colorData = new Color[100 * 100];
                index = 0;
                speedX = 2;
                speedY = 2;
                repeat = 0;
                path6 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 100),
                        new Vector2(new_origin.X - 150, new_origin.Y + 140),
                        new Vector2(new_origin.X - 250, new_origin.Y + 170),
                        new Vector2(50, 0),
                        new Vector2(new_origin.X, new_origin.Y + 100),
                        new Vector2(new_origin.X, new_origin.Y)
                };
                path = path6[index];
            }

            if (ID == "enemy7")
            {
                health = 1;
                origin = new_origin;
                colorData = new Color[100 * 100];
                index = 0;
                speedX = 2;
                speedY = 2;
                repeat = 0;
                path7 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 600),

                };
                path = path7[index];
            }



            if (ID == "boss")
            {
                origin = new_origin;
                colorData = new Color[100 * 100];
                index = 0;
                health = 500;
                speedX = 2;
                speedY = 2;
                repeat = 0;
                stage1 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 150),
                        new Vector2(new_origin.X + 100, new_origin.Y + 130),
                        new Vector2(new_origin.X + 70, new_origin.Y + 100),

                };

                stage2 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 150),
                        new Vector2(new_origin.X + 50, new_origin.Y + 150),
                        new Vector2(new_origin.X - 100, new_origin.Y + 60),

                };

                stage3 = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 150),
                        new Vector2(new_origin.X - 150, new_origin.Y + 150),
                        new Vector2(new_origin.X - 120, new_origin.Y + 160),
                        new Vector2(new_origin.X, new_origin.Y + 70),

                };

                leave = new Vector2[]
                {
                        new Vector2(new_origin.X, -150),

                };




                path = stage1[index];
            }



        }

        public void Collide(enemy1 enemy, player player)
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
        public void Collide(List<enemy1> enemies, enemy1 enemy, AttackDecorator bullet)
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

        public void update_path(GameTime gameTime, float timecounter)
        {

            if (get_origin().X < get_path().X)
            {
                Vector2 temp = new Vector2(get_origin().X + speedX, get_origin().Y);
                set_origin(temp);
            }

            if (get_origin().X > get_path().X)
            {
                Vector2 temp = new Vector2(get_origin().X - speedX, get_origin().Y);
                set_origin(temp);

            }

            if (get_origin().Y < get_path().Y)
            {
                Vector2 temp = new Vector2(get_origin().X, get_origin().Y + speedY);
                set_origin(temp);

            }

            if (get_origin().Y > get_path().Y)
            {
                Vector2 temp = new Vector2(get_origin().X, get_origin().Y - speedY);
                set_origin(temp);

            }

            if (Vector2.Distance(origin, get_path()) < 3)
            {
                set_path(this, gameTime, timecounter);
            }
        }

        public void set_path(enemy1 enemy, GameTime gameTime, float timecounter)
        {
            if (enemy.ID == "enemy1")
            {
                if (index + 1 < path1.Length)
                {
                    this.index++;
                    path = path1[index];
                }
                if (out_of_bounds(enemy) == true)
                {
                    finished = true;
                }

            }

            if (enemy.ID == "enemy2")
            {
                if (index + 1 < path2.Length)
                {
                    this.index++;
                    path = path2[index];
                }

                if (out_of_bounds(enemy) == true)
                {
                    finished = true;
                }
            }

            if (enemy.ID == "enemy3")
            {
                if (index + 1 < path3.Length && (gameTime.TotalGameTime.Seconds % 2) == 0)
                {
                    firing = false;
                    this.index++;
                    path = path3[index];
                }

                if (out_of_bounds(enemy) == true)
                {
                    finished = true;
                }
            }

            if (enemy.ID == "enemy4")
            {
                if (index + 1 < path4.Length)
                {
                    this.index++;
                    speedY = 1;
                    path = path4[index];
                }

                if (out_of_bounds(enemy) == true)
                {
                    finished = true;
                }
            }

            if (enemy.ID == "enemy5")
            {
                if (index + 1 < path5.Length)
                {
                    this.index++;
                    speedY = 1;
                    path = path5[index];
                }

                if (out_of_bounds(enemy) == true)
                {
                    finished = true;
                }
            }

            if (enemy.ID == "enemy6")
            {
                if (index == 4)
                {
                    index = -1;
                    repeat++;
                    if (timecounter > 80)
                    {
                        firing = false;
                        index = 4;
                    }
                }
                if (index + 1 < path6.Length && (gameTime.TotalGameTime.Seconds % 3) == 0)
                {
                    this.index++;
                    speedY = 2;
                    path = path6[index];
                }

                if (out_of_bounds(enemy) == true)
                {
                    finished = true;
                }
            }

            if (enemy.ID == "enemy7")
            {
                if (index == 4)
                {
                    index = 0;
                    repeat++;
                    if (repeat == 4)
                    {
                        index = 4;
                    }
                }
                if (index + 1 < path7.Length)
                {
                    this.index++;
                    speedY = 2;
                    path = path7[index];
                }

                if (out_of_bounds(enemy) == true)
                {
                    finished = true;
                }
            }

            if (enemy.ID == "boss")
            {
                if (path.Length() == stage1.Length)
                {
                    repeat = 0;
                    if (index + 1 == stage1.Length)
                    {
                        index = -1;
                    }
                    if (index + 1 < stage1.Length && ((timecounter % 2) == 0))
                    {
                        this.index++;
                        path = stage1[index];
                    }
                }
                if (repeat == 3 && path.Length() == stage1.Length)
                {
                    index = 0;
                    path = stage2[index];
                }

                if (path.Length() == stage2.Length)
                {
                    if (index + 1 >= stage2.Length)
                    {
                        index = -1;
                    }

                    if (index + 1 <= stage2.Length && ((timecounter % 2) == 0))
                    {
                        this.index++;
                        path = stage2[index];
                    }
                }

                if (timecounter == 166)
                {
                    index = 0;
                    path = stage3[index];
                }

                if (repeat == 3 && path.Length() == stage1.Length)
                {
                    if (index + 1 == stage3.Length)
                    {
                        index = -1;
                    }

                    if (index + 1 < stage3.Length && ((timecounter % 2) == 0))
                    {
                        this.index++;
                        path = stage3[index];
                    }
                }

                if (timecounter == 30)
                {
                    index = 0;
                    path = leave[index];
                }

                if (out_of_bounds(enemy) == true)
                {
                    finished = true;
                }

            }

        }

        public bool out_of_bounds(enemy1 enemy)
        {
            if (enemy.get_origin().X < 0 || enemy.get_origin().X > 650)
            {
                return true;
            }

            if (enemy.get_origin().Y < -100 || enemy.get_origin().X > 600)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        List<Attacks> attacks; //stores all of the attacks that have been shot by this enemy

        public int repeat;
        public float speedX;
        public float speedY;
        public string ID;
        Vector2 origin;
        Vector2 path;
        Color[] colorData = new Color[100 * 100];
        public int health;
        public int index;
        public bool isVisible;
        public bool firing;
        public bool finished = false;

        Vector2[] path1;
        Vector2[] path2;
        Vector2[] path3;
        Vector2[] path4;
        Vector2[] path5;
        Vector2[] path6;
        Vector2[] path7;
        Vector2[] stage1;
        Vector2[] stage2;
        Vector2[] stage3;
        Vector2[] leave;
    }
}
