using Gamespace.Projectiles;
using Gamespace.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;

namespace Gamespace.Projectiles
{
    internal class Fireball : AbstractGameStatefulObject<IProjectileState>, IProjectile
    {
        private static readonly Dictionary<ShootAngle, Type> initialOrientation;
        private readonly Dictionary<ShootAngle, Func<Vector2, Func<Vector2, int, Vector2>>> trajectoryLog;
        private static readonly Dictionary<ShootAngle, Func<Vector2, int, Vector2>> spriteOffset;
        private int bounceCounter = 0;
        private readonly int bounceBound = Numbers.BOUNCE_BOUND;
        private IMario owner;

        public ShootAngle Angle { get ; set; }

        
        static Fireball()
        {
            initialOrientation = new Dictionary<ShootAngle, Type>()
            {
                {ShootAngle.Left, typeof(LeftMovingProjectile) },
                {ShootAngle.Right, typeof(RightMovingProjectile) },
                {ShootAngle.Up,typeof(UpMovingProjectile) }

            };

            spriteOffset = new Dictionary<ShootAngle, Func<Vector2, int, Vector2>>()
            {
                {ShootAngle.Left, new Func<Vector2, int, Vector2> ((p,offset)=> new Vector2(p.X - offset,p.Y))},
                {ShootAngle.Right,new Func<Vector2, int, Vector2> ((p,offset)=> new Vector2(p.X,p.Y))},
                {ShootAngle.Up,new Func<Vector2, int, Vector2> ((p,offset)=> new Vector2(p.X,p.Y-offset)) }
            };

            
        }
        
        public Fireball(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen)
        {
            State = (IProjectileState) Activator.CreateInstance(initialOrientation[angle], this);
            SoundManager.Instance.PlaySoundEffect("Fireball");
            SetSprite();
        }

        public Fireball() : this(new Vector2(0), ShootAngle.Right)
        {

            trajectoryLog = new Dictionary<ShootAngle, Func<Vector2, Func<Vector2, int, Vector2>>>
            {
                {ShootAngle.Left, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X - GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) },

                 {ShootAngle.Right, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X + GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) },

                 {ShootAngle.Up, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X;
                    float v_y = ini_v.Y -GameObjectPhysics.PhysicsConstants.Y_V;;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) },
                   {ShootAngle.Down, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X;
                    float v_y = ini_v.Y +GameObjectPhysics.PhysicsConstants.Y_V;;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) }
            };
        }

        public void ChangeDirection(ShootAngle angle)
        {
            State.ChangeDirection(angle);
            SetSprite();
        }

        protected override void SetSprite()
        {
            Sprite =  SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
        }

        protected override void SurrogateUpdate()
        {
            if (bounceCounter < bounceBound)
            {
                base.SurrogateUpdate();
                GameObjectPhysics.Update();
                positionOnScreen = GameObjectPhysics.Position;
            }
            else
            {
                Remove();
            }
        }

        public void Remove()
        {
            Sprite = SpriteFactory.Instance.GetSprite("Fireball_out", "", "");
            World.Instance.RemoveFromWorld(this);
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            base.CollideLeft(collisionArea);
            Vector2 ini_v = new Vector2(-GameObjectPhysics.Velocity.X, GameObjectPhysics.Velocity.Y);
            GameObjectPhysics.TrajectMove(trajectoryLog[ShootAngle.Right].Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            base.CollideRight(collisionArea);
            Vector2 ini_v = new Vector2(-GameObjectPhysics.Velocity.X, GameObjectPhysics.Velocity.Y);
            GameObjectPhysics.TrajectMove(trajectoryLog[ShootAngle.Left].Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideDown(Rectangle collisionArea)
        {
            base.CollideDown(collisionArea);
            Vector2 ini_v = new Vector2(GameObjectPhysics.Velocity.X, -GameObjectPhysics.Velocity.Y);
            GameObjectPhysics.TrajectMove(trajectoryLog[ShootAngle.Up].Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideUp(Rectangle collisionArea)
        {
            base.CollideUp(collisionArea);
            Vector2 ini_v = new Vector2(GameObjectPhysics.Velocity.X, -GameObjectPhysics.Velocity.Y);
            GameObjectPhysics.TrajectMove(trajectoryLog[ShootAngle.Down].Invoke(ini_v));
            bounceCounter++;
        }

        public void Shoot(ShootAngle angle, Vector2 initialV, Vector2 initialP)
        {
            State.ChangeDirection(angle);
            int offset = angle == ShootAngle.Up ? Sprite.Height : Sprite.Width;
            GameObjectPhysics.Position = spriteOffset[angle].Invoke(initialP,offset);
            GameObjectPhysics.TrajectMove(trajectoryLog[angle].Invoke(initialV));
        }

        public void OwnerScores()
        {
            owner.ScoreKill();
        }
        
        public void SetOwner(IMario owner)
        {
            this.owner = owner;
        }
    }
}
