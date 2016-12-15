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
    public class StraightUpPath : AttackDecorator
    {
        public StraightUpPath(Attacks attack)
        {
            this.Attack = attack;
            this.isVisible = true;
        }

        public override void Update()
        {
            foreach (BaseBullet bullet in Attack.attackRing)
            {
                bullet.position += (3 * bullet.velocity); //move bullet further in a straight line
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