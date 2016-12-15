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
    public class CrazyAttack : Attacks //USING THIS FOR THE QURIKY LOOPS crazyAttack ----- TRY taking absolute value in update. this hits it kinda close to the games look
    {
        private Vector2 Origin;
        private Double distanceFromCenter = 14; ///How Wide Circle is

        Double x;
        Double y;

        public CrazyAttack(Texture2D newTexture, int count, Vector2 origin)//higher count the better here
        {
            velocity = new Vector2(0, 1); //abstract variable velocity
            texture = newTexture;
            Origin = origin;


            attackRing = new List<BaseBullet>(count);



            Double angleInDegrees = 0, change = 1080 / count; //1 time around per 360

            Double deviation = 1;

            Random rnd = new Random();
            for (int i = 0; i < count / 2; i++)
            {
                float randomNum = rnd.Next(-10, 10) / 5; // difference of 0 + or - up to 2, pass this into each circBullet

                BaseBullet tempBullet = new BaseBullet(texture, randomNum);
                angleInDegrees += change;
                tempBullet.angleInDegrees = angleInDegrees;

                Double angleAsRadians = (tempBullet.angleInDegrees * Math.PI) / 180.0; //credit: http://www.softwareandfinance.com/CSharp/Draw_Circle_Pixel.html

                x = origin.X + (Math.Cos(angleAsRadians) * distanceFromCenter * deviation / 2) + randomNum; //dividing by 2 makes it skinnier vertically
                y = origin.Y + (distanceFromCenter * deviation);
                tempBullet.position = new Vector2((float)x, (float)y);
                tempBullet.velocity = new Vector2(0, 1);
                attackRing.Add(tempBullet);

                if (deviation < 10)
                {
                    deviation *= 1.05;
                }
                else
                {
                    deviation += 0.05;
                }

            }
            angleInDegrees = 0;
            deviation = 1;
            for (int i = 0; i < count; i++)//changed this part
            {
                float randomNum = rnd.Next(-10, 10) / 5; // difference of 0 + or - up to 2, pass this into each circBullet

                BaseBullet tempBullet = new BaseBullet(texture, randomNum);
                angleInDegrees -= change;
                tempBullet.angleInDegrees = angleInDegrees;

                Double angleAsRadians = (tempBullet.angleInDegrees * Math.PI) / 180.0; //credit: http://www.softwareandfinance.com/CSharp/Draw_Circle_Pixel.html

                x = origin.X + -((Math.Cos(angleAsRadians) * distanceFromCenter * deviation / 2)) + randomNum; //dividing by 2 makes it skinnier vertically
                y = origin.Y + distanceFromCenter * deviation;
                tempBullet.position = new Vector2((float)x, (float)y);
                tempBullet.velocity = new Vector2(0, 1);
                attackRing.Add(tempBullet);

                if (deviation < 10)
                {
                    deviation *= 1.05;
                }
                else
                {
                    deviation += 0.05;
                }

            }



            isVisible = true;
        }

        public override void Draw(SpriteBatch spriteBatch, player player)
        {
            foreach (BaseBullet bullet in attackRing)
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
    }
}
