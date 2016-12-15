using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;

namespace Robot_House_Touhou_Game
{
    public class CircBulletAttack : Attacks
    {
        int Count;
        public Double distanceFromCenter = 60;//was 135
        Double x;
        Double y;

        public CircBulletAttack(Texture2D newTexture, int count, Vector2 Origin)
        {
            velocity = new Vector2(0, 1); //abstract variable velocity
            texture = newTexture;
            origin = Origin;
            Count = count;


            attackRing = new List<BaseBullet>(Count);


            Double angleInDegrees = 0, change = 360 / Count;
            Double deviation = 1;
            for (int i = 0; i < count + 2; i++)
            {
                BaseBullet tempBullet = new BaseBullet(texture);
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

        public override void Draw(SpriteBatch spriteBatch, player player) //we dont need to pass in List<attacks> enemy_attacks to any of these draw functions, it is never used
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
