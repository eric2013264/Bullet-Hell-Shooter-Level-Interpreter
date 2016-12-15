using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;

namespace Robot_House_Touhou_Game
{
    //enemy movement class (not implemented yet)
    public class path1 : abstract_path
    {
        public path1(Vector2 new_origin)
        {
            path_map = new Vector2[]
               {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X + 700, new_origin.Y + 210),
               };
        }

    }
    public class path2 : abstract_path
    {
        public path2(Vector2 new_origin)
        {
            path_map = new Vector2[]
                {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X -700, new_origin.Y + 210),
                };
        }
    }
    public class path3 : abstract_path
    {
        public path3(Vector2 new_origin)
        {
            path_map = new Vector2[]
                {
                        new Vector2(new_origin.X, 160),
                        new Vector2(new_origin.X, new_origin.Y- 500),
                };
        }
    }
    public class path4 : abstract_path
    {
        public path4(Vector2 new_origin)
        {
            path_map = new Vector2[]
               {
                   new Vector2(new_origin.X, new_origin.Y + 100),
                   new Vector2(new_origin.X - 700, new_origin.Y + 170),
                   // new Vector2(50, 0), 
                   //new Vector2(50, 0)
               };
        }
    }
    public class path5 : abstract_path
    {
        public path5(Vector2 new_origin)
        {
            path_map = new Vector2[]
            {

                new Vector2(new_origin.X, new_origin.Y + 100),
                new Vector2(new_origin.X + 700, new_origin.Y + 170),
                // new Vector2(50, 0),                    
                //new Vector2(50, 0)    
            };
        }
    }
    public class path6 : abstract_path
    {
        public path6(Vector2 new_origin)
        {
            path_map = new Vector2[]
               {
                        new Vector2(new_origin.X, new_origin.Y + 600),
               };
        }
    }
    public class path7 : abstract_path
    {
        public path7(Vector2 new_origin)
        {
            path_map = new Vector2[]
               {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X + 700, new_origin.Y + 210),
               };
        }
    }
    public class path8 : abstract_path
    {
        public path8(Vector2 new_origin)
        {
            path_map = new Vector2[]
               {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X + 700, new_origin.Y + 210),
               };
        }
    }

    public class midboss : abstract_path
    {
        public midboss(Vector2 new_origin)
        {
            path_map = new Vector2[]            
            {
                new Vector2(new_origin.X, new_origin.Y + 100),
                new Vector2(new_origin.X - 150, new_origin.Y + 140),
                new Vector2(new_origin.X + 250, new_origin.Y + 170),
                new Vector2(50, 0),
                new Vector2(new_origin.X, new_origin.Y + 100),
                new Vector2(new_origin.X, new_origin.Y)         
            };
        }
    }
    public class stage1 : abstract_path
    {
        public stage1(Vector2 new_origin)
        {
            path_map = new Vector2[]
               {
                       new Vector2(new_origin.X, new_origin.Y + 150),
                        new Vector2(new_origin.X + 100, new_origin.Y + 130),
                        new Vector2(new_origin.X + 70, new_origin.Y + 100),
               };
        }
    }

    public class stage2 : abstract_path
    {
        public stage2(Vector2 new_origin)
        {
            path_map = new Vector2[]
               {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X + 700, new_origin.Y + 210),
               };
        }
    }

    public class stage3 : abstract_path
    {
        public stage3(Vector2 new_origin)
        {
            path_map = new Vector2[]
               {
                        new Vector2(new_origin.X, new_origin.Y + 180),
                        new Vector2(new_origin.X + 700, new_origin.Y + 210),
               };
        }
    }
}
