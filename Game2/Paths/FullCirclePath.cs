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
    public class FullCirclePath : AttackDecorator //UPDATED CIRC ATTACK
    {                                     //THE FULL SHABANG, USED FOR COMPLETE CIRCLE ATTACKS THAT GROW LARGER AND SPIN  
        public Vector2 Origin;
        public Double distanceFromCenter = 75;//was 135

        public FullCirclePath (Attacks attack)
        {
            this.Attack = attack;
            this.isVisible = true;
        }

        public override void Update()
        {


            foreach (BaseBullet bullet in Attack.attackRing)
            {
                //start here
                bullet.counter++;
                bullet.angleInDegrees += 0.5;//was 0.05 //slowly expands and rotates

                Double angleAsRadians = (bullet.angleInDegrees * Math.PI) / 180.0;

                if (bullet.counter < 600)//was 550
                {
                    bullet.position.X += (float)(Math.Cos(angleAsRadians) * 1.0); //higher the number we * by, the wider the 
                    bullet.position.Y += (float)1.5 + (float)(Math.Sin(angleAsRadians) * 1.0);
                }


                if (Vector2.Distance(bullet.position, spriteLocation) > 700)
                {
                    bullet.isVisible = false; //deallocate object if it goes off screen

                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch,  player player) //we dont need to pass in List<attacks> enemy_attacks to any of these draw functions, it is never used
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
