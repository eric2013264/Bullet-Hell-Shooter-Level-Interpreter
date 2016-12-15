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
    public class BaseBullet
    {
        public Texture2D texture;

        public Vector2 position;
        public Double angleInDegrees;
        public int counter = 0; //for fullCircle

        public float RandomNum; //for CrazyAttack

        public Vector2 velocity;
        public Vector2 origin;

        public bool isVisible;

        public Vector2 whereToGo;
        public bool onCourse;
        public float distance;
        public Vector2 Toward;
        public Vector2 nextPosition;
        

        public BaseBullet(Texture2D newTexture, Vector2 Origin)
        {
            texture = newTexture;
            origin = Origin; 
            position = origin;
            velocity = new Vector2(0, 1); //abstract member variable
            isVisible = true;
        }

        public BaseBullet(Texture2D newTexture)
        {
            texture = newTexture;
            //ERIC Add code here
            velocity = new Vector2(0, 1); //abstract member variable
            isVisible = true;
        }

        public BaseBullet(Texture2D newTexture, float randomNum)
        {
            texture = newTexture;
            RandomNum = randomNum;
            position = origin;
            velocity = new Vector2(0, 1); //abstract member variable
            isVisible = true;
        }

        public void Update(Vector2 spriteLocation)
        {
            position += (3 * velocity); //move bullet further in a straight line
            if (Vector2.Distance(position, spriteLocation) > 700)
            {
                isVisible = false; //deallocate object if it goes off screen
            }
        }

        

        public void Draw(SpriteBatch spriteBatch, player player)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0);
            spriteBatch.End();
        }

        public Rectangle BoundingBox
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
