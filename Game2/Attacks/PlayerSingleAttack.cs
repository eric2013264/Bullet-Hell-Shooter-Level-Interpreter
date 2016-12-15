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
    public class PlayerSingleAttack : Attacks
    {
        int count = 1;//Bullet class is supposed to have only one bullet in its list

        public PlayerSingleAttack(Texture2D newTexture, Vector2 origin)
        {
            texture = newTexture;
            position = origin;
            isVisible = true;
            attackRing = new List<BaseBullet>();

            for (int i = 0; i < count; i++)
            {
                BaseBullet tempBullet = new BaseBullet(texture);


                double x = origin.X;
                double y = origin.Y;
                tempBullet.position = new Vector2((float)x, (float)y);
                tempBullet.velocity = new Vector2(0, -4);
                attackRing.Add(tempBullet);


            }
        }

        public PlayerSingleAttack(Texture2D newTexture, int count, Vector2 origin)
        {
            texture = newTexture;
            position = origin;
            isVisible = true;
            attackRing = new List<BaseBullet>();

            for (int i = 0; i < count; i++)
            {
                BaseBullet tempBullet = new BaseBullet(texture);


                double x = origin.X;
                double y = origin.Y;
                tempBullet.position = new Vector2((float)x, (float)y);
                tempBullet.velocity = new Vector2(0, -4);
                attackRing.Add(tempBullet);


            }
        }

        public override void Draw(SpriteBatch spriteBatch, player player) //we dont need to pass in List<attacks> enemy_attacks to any of these draw functions, it is never used
        {
            foreach (BaseBullet bullet in attackRing)
            {
                bullet.Draw(spriteBatch, player);
            }

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
