using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class FireMario : IMarioState
    {
        private Texture2D Texture { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Vector2 location;
        private IMario mario;

        public FireMario(int rows, int columns, Texture2D texture, Vector2 Location)
        {
            Rows = Rows;
            Columns = Columns;
            Texture = texture;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            location = Location;
        }
        public void Draw()
        {

        }
        public void Update()
        {
            
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
            mario.marioState = new SuperMario(mario, Rows, Columns, Texture, location);
        }
        public void Upgrade()
        {
            // cannot upgrade further
        }
    }
}
