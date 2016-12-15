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
    public class OLDcircAttackCollapse : Attacks ///Collapsing Circle Attack
    {
        public Vector2 Origin;

        public List<circBullet> attackRing;


        public Double distanceFromCenter = 100;

        Double x;
        Double y;

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)x,
                    (int)y,
                    10,
                    10);
            }

        }
        public OLDcircAttackCollapse(Texture2D newTexture, int count, Vector2 origin)
        {
            velocity = new Vector2(0, 1); //abstract variable velocity
            texture = newTexture;
            Origin = origin;


            attackRing = new List<circBullet>(count);


            Double angleInDegrees = 0, change = 360 / count;
            Double deviation = 1;
            for (int i = 0; i < count + 2; i++)
            {
                circBullet tempBullet = new circBullet(texture);
                angleInDegrees += change;
                tempBullet.angleInDegrees = angleInDegrees;

                Double angleAsRadians = (tempBullet.angleInDegrees * Math.PI) / 180.0;

                x = origin.X + Math.Cos(angleAsRadians) * distanceFromCenter;
                y = origin.Y + Math.Sin(angleAsRadians) * distanceFromCenter;
                tempBullet.position = new Vector2((float)x, (float)y);
                tempBullet.velocity = new Vector2(0, 1);
                attackRing.Add(tempBullet);
                deviation += 5;
            }



            isVisible = true;
        }



        public override void Update()
        {
            foreach (circBullet bullet in attackRing)
            {
                bullet.angleInDegrees += 1;

                Double angleAsRadians = (bullet.angleInDegrees * Math.PI) / 180.0;

                Double x = bullet.position.X + Math.Cos(angleAsRadians) * 0.5; //higher the number we * by, the wider the 
                Double y = bullet.position.Y + Math.Sin(angleAsRadians) * 0.5; //circle will be 

                bullet.position = new Vector2((float)(x), (float)(y));

                if (Vector2.Distance(bullet.position, spriteLocation) > 700)
                {
                    bullet.isVisible = false; //deallocate object if it goes off screen

                }
            }
            foreach (circBullet bullet in attackRing)
            {
                bullet.position += (1 * bullet.velocity); //higher the number we * by the faster the circle moves downwards
            }
        }

        public override void Draw(SpriteBatch spriteBatch, player player)
        {
            foreach (circBullet bullet in attackRing)
            {
                bullet.Draw(spriteBatch, player);
            }

        }

        public override int collision(Rectangle BoundingBox)
        {
            for (int i = 0; i < attackRing.Count; i++)// Attacks bullet in attackRing)
            {
                if (attackRing[i].BoundingBox.Intersects(BoundingBox) && attackRing[i].isVisible == true)
                {
                    attackRing[i].isVisible = false;
                    attackRing.RemoveAt(i);

                    return i;
                }
            }
            return -1;
        }


        public class circBullet : Attacks
        {
            public Double angleInDegrees;
            public circBullet(Texture2D newTexture)
            {
                texture = newTexture;
                isVisible = true;
            }

            public override void Draw(SpriteBatch spriteBatch, player player)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0);

                spriteBatch.End();
            }

            public override Rectangle BoundingBox
            {
                get
                {
                    return new Rectangle(
                        (int)position.X,
                        (int)position.Y,
                        10,
                        10);
                }
            }
            public override int collision(Rectangle BoundingBox)
            {
                return 0;
            }


        }

    }
}
