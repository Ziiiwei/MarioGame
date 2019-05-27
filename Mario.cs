using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Interfaces
{
    public class Mario : IMario
    {
        private Texture2D Texture { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Vector2 location;
        private IMarioState marioState;
        
        public Mario(rows, columns, Texture2D texture, Vector2 Location)
        {
            Rows = Rows;
            Columns = Columns;
            Texture = texture;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            location = Location;
            marioState = new SmallMario();
        }
        public void Draw()
        {

        }
        public void Update()
        {
            
        }
        public void Jump()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
        public void MovingRight()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
        public void MovingLeft()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }
        public void FacingLeft()
        {

        }
        public void FacingRight()
        {

        }

        public void Crouch()
        {
            
        }
    }
    public class SmallMario : IMarioState
    {
        IMario mario;
        public SmallMario(IMario mario)
    }
    public class SuperMario : IMarioState
    {
        IMario mario;
        public SuperMario(IMario mario)
    }
    public class FireMario : IMarioState
    {
        IMario mario;
        public FireMario(IMario mario)
    }
}
