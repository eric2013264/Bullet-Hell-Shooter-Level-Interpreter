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
    public class CollapsingCirclePath : AttackDecorator ///Collapsing Circle Attack
    {
        public Vector2 Origin;
        public Double distanceFromCenter = 100;

        public CollapsingCirclePath(Attacks attack)
        {
            this.Attack = attack;
            this.isVisible = true;
        }

        public override void Update()
        {
            foreach (BaseBullet bullet in Attack.attackRing)
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
            foreach (BaseBullet bullet in Attack.attackRing)
            {
                bullet.position += (1 * bullet.velocity); //higher the number we * by the faster the circle moves downwards
            }
        }

        public override void Draw(SpriteBatch spriteBatch, player player)
        {
            foreach (BaseBullet bullet in Attack.attackRing)
            {
                bullet.Draw(spriteBatch, player);
            }

        }

        public override int collision(Rectangle BoundingBox)
        {
            return (this.Attack.collision(BoundingBox));
        }
    }
}
