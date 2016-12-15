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
    public abstract class Attacks //base class that all other attacks inherit from
    {
        public List<BaseBullet> attackRing;

        public Texture2D texture;

        public Vector2 position;

        public Vector2 velocity;
        public Vector2 origin;

        public bool isVisible;

        
        public Vector2 playerLocation;

        public Vector2 spriteLocation = new Vector2(0, 0);

        public void setOrigin(Vector2 Origin)
        {
            origin = Origin;
        }

        public void setVelocity(Vector2 Velocity)
        {
            velocity = Velocity;
        }

        public virtual void Draw(SpriteBatch spritebatch, player player)
        {
            //Defined by you
        }

        public virtual void Draw(SpriteBatch spritebatch, List<AttackDecorator> player_attacks, List<enemy1> enemies)
        {
            //Defined by you
        }

        public virtual void Draw(SpriteBatch spritebatch, List<AttackDecorator> player_attacks, List<enemy> enemies)
        {
            //Defined by you
        }

        public virtual void Update() //IMPORTANT!!! NEED TO PHASE THIS OUT ---B
        {
            //you choose if we need this or not
        }

        public virtual int collision(Rectangle BoundingBox)
        {
            return 0; 
        }

        public virtual Rectangle BoundingBox
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
    }
}