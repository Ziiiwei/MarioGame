using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Interfaces
{
    public class SuperMario : IMarioState
    {
        private Texture2D Texture { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Vector2 location;
        private IMario mario;
        
        public SuperMario(Mario, int rows, int columns, Texture2D texture, Vector2 Location)
        {
            mario = Mario;
            Rows = Rows;
            Columns = Columns;
            Texture = texture;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            location = Location;
        }
        public void Draw()
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
        public void Jump()
        {
            
        }
        public void MovingRight()
        {
            
        }
        public void MovingLeft()
        {
            
        }
        public void FacingLeft()
        {

        }
        public void FacingRight()
        {

        }

        public void CrouchRight()
        {

        }
        public void CrouchLeft()
        {

        }
        public void TakeDamage()
        {
            mario.marioState = new SmallMario(mario ,int rows, int columns, Texture2D texture, Vector2 Location);
        }
        public void Upgrade()
        {
            mario.marioState = new FireMario(mario, int rows, int columns, Texture2D texture, Vector2 Location);
        }
    }
}
