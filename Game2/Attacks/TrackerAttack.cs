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
    class TrackerAttack : Attacks
    {

        private int Count = 1;


        public TrackerAttack(Texture2D newTexture, Vector2 origin, Vector2 player_origin)
        {
            texture = newTexture;
            position = origin;
            //ERIC Add code here
            velocity = new Vector2(0, 1); //abstract member variable
            attackRing = new List<BaseBullet>(Count);
            playerLocation = player_origin;

            for (int i = 0; i < Count; i++)
            {
                BaseBullet tempBullet = new BaseBullet(texture);
                tempBullet.isVisible = true;
                double x = origin.X;
                double y = origin.Y;
                tempBullet.position = new Vector2((float)x, (float)y);
                Vector2 currentPosition = position;
                Vector2 destinationPosition = playerLocation;
                tempBullet.nextPosition = getVelocity(currentPosition, destinationPosition);//next position is what path is updtated 

                attackRing.Add(tempBullet);
            }




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

        public Vector2 getVelocity(Vector2 currentPosition, Vector2 destinationPosition)
        {
            double angle = calcAngleBetweenPoints(currentPosition, destinationPosition);//cmopute angle between two locations
            float x = (float)Math.Cos(angle);
            float y = (float)Math.Sin(angle);
            return new Vector2(x, y);
        }

        public double calcAngleBetweenPoints(Vector2 p1, Vector2 p2)
        {
            return ((Math.Atan2(p2.Y - p1.Y, p2.X - p1.X))); //return degrees
        }
    }
}
