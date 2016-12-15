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
    public class HalfCircleAttack : Attacks
    {
        private Vector2 Origin;

        private Double distanceFromCenter = 80;
        private int Count = 5;

        Double x;
        Double y;

        public HalfCircleAttack(Texture2D newTexture, int count, Vector2 origin)
        {
            velocity = new Vector2(0, 1); //abstract variable velocity
            texture = newTexture;
            Origin = origin;

            Count = 5;
            attackRing = new List<BaseBullet>(count);
            Double angleInDegrees = 200;
            for (int i = 0; i < Count + 2; i++)
            {
                BaseBullet tempBullet = new BaseBullet(texture);
                tempBullet.angleInDegrees = angleInDegrees;

                Double angleAsRadians = (tempBullet.angleInDegrees * Math.PI) / 180.0;

                x = origin.X + Math.Cos(angleAsRadians) * distanceFromCenter;
                y = origin.Y + Math.Sin(angleAsRadians) * distanceFromCenter;
                tempBullet.position = new Vector2((float)x, (float)y);
                tempBullet.velocity = new Vector2(0, 1);
                angleInDegrees += 28;
            }

            for (int i = 0; i < Count; i++)
            {
                BaseBullet tempBullet = new BaseBullet(texture);
                tempBullet.angleInDegrees = angleInDegrees;

                Double angleAsRadians = (tempBullet.angleInDegrees * Math.PI) / 180.0;

                x = origin.X + Math.Cos(angleAsRadians) * distanceFromCenter;
                y = origin.Y + Math.Sin(angleAsRadians) * distanceFromCenter;
                tempBullet.position = new Vector2((float)x, (float)y);
                tempBullet.velocity = new Vector2(0, 1);
                attackRing.Add(tempBullet);
                angleInDegrees += 28;
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
