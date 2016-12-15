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
    class TrackerPath : AttackDecorator //Eric's converted tracker bullet
    {

        public TrackerPath(Attacks attack)
        {
            this.Attack = attack;
            this.isVisible = true;
        }

        public override void Update()// float distance, float XDist)
        {
            foreach (BaseBullet trackerBullet in Attack.attackRing)
            {
                float XDist = Math.Abs(trackerBullet.position.X - Attack.playerLocation.X);
                if (trackerBullet.nextPosition.Y >= 0)
                {
                    trackerBullet.position.Y += trackerBullet.nextPosition.Y;
                }
                else
                {
                    trackerBullet.position.Y -= trackerBullet.nextPosition.Y;
                }
                trackerBullet.position.X += trackerBullet.nextPosition.X;

                if (Vector2.Distance(trackerBullet.position, playerLocation) > 700)
                {
                    isVisible = false;
                }

                if (Vector2.Distance(trackerBullet.position, spriteLocation) > 700)
                {
                    isVisible = false;
                }
            }


            foreach (BaseBullet bullet in Attack.attackRing)
            {
                if (Vector2.Distance(bullet.position, spriteLocation) > 700)
                {
                    bullet.isVisible = false; //deallocate object if it goes off screen
                }
            }

        }

        public override void Draw(SpriteBatch spriteBatch, player player) //we dont need to pass in List<attacks> enemy_attacks to any of these draw functions, it is never used
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
