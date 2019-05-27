using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint2.Interfaces;
namespace Sprint2
{
    public class Mario : IMario
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int currentFrame;
        public int totalFrames;
        public Vector2 location;
        public IMarioState marioState;
        
        public Mario(int rows, int columns, Texture2D texture, Vector2 Location)
        {
            Rows = Rows;
            Columns = Columns;
            Texture = texture;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            location = Location;
            marioState = new SmallMario(this, rows, columns, texture, Location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            marioState.Draw();
        }
        public void Update()
        {
            marioState.Update();
        }
        public void Jump()
        {
            marioState.Jump();
        }
        public void MovingRight()
        {
            marioState.MovingRight();
        }
        public void MovingLeft()
        {
            marioState.MovingLeft();
        }
        public void FacingLeft()
        {
            marioState.FacingLeft();
        }
        public void FacingRight()
        {
            marioState.FacingRight();
        }

        public void CrouchRight()
        {
            marioState.CrouchRight();
        }
        public void CrouchLeft()
        {
            marioState.CrouchLeft();
        }
        public void TakeDamage()
        {
            marioState.TakeDamage();
        }
        public void Upgrade()
        {
            marioState.Upgrade();
        }
    }
}
