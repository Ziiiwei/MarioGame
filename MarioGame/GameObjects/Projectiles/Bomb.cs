using Gamespace.Data;
using Gamespace.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class Bomb : AbstractGameStatefulObject<IProjectileState>, IProjectile
    {
        protected static Dictionary<ShootAngle, Type> initialOrientation;
        protected Dictionary<ShootAngle, Func<Vector2, Func<Vector2, int, Vector2>>> trajectoryLog;
        protected static readonly Dictionary<ShootAngle, Func<Vector2, int, Vector2>> spriteOffset;
        protected int bounceCounter = 0;
        protected int bounceBound;
        protected IMario owner;

        public ShootAngle Angle { get; set; }


        static Bomb()
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

        public Bomb(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen)
        {
            bounceBound = 4;
            State = (IProjectileState)Activator.CreateInstance(initialOrientation[angle], this);
            SetSprite();
        }

        public Bomb() : this(new Vector2(0), ShootAngle.Right)
        {

            trajectoryLog = new Dictionary<ShootAngle, Func<Vector2, Func<Vector2, int, Vector2>>>
            {
                 {ShootAngle.Left, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X - GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y - GameObjectPhysics.PhysicsConstants.Y_V;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) },

                 {ShootAngle.Right, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X + GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y - GameObjectPhysics.PhysicsConstants.Y_V;
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

        public virtual void ChangeDirection(ShootAngle angle)
        {
            State.ChangeDirection(angle);
            SetSprite();
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(this.GetType().Name, "", "");
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

        public virtual void Remove()
        {
            Sprite = SpriteFactory.Instance.GetSprite("Fireball_out", "", "");
            World.Instance.RemoveFromWorld(this);
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            base.CollideLeft(collisionArea);
            Vector2 ini_v = new Vector2(-GameObjectPhysics.Velocity.X/1.4f, GameObjectPhysics.Velocity.Y / 1.4f);
            GameObjectPhysics.TrajectMove(trajectoryLog[ShootAngle.Right].Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            base.CollideRight(collisionArea);
            Vector2 ini_v = new Vector2(-GameObjectPhysics.Velocity.X/1.4f, GameObjectPhysics.Velocity.Y / 1.4f);
            GameObjectPhysics.TrajectMove(trajectoryLog[ShootAngle.Left].Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideDown(Rectangle collisionArea)
        {
            base.CollideDown(collisionArea);
            Vector2 ini_v = new Vector2(GameObjectPhysics.Velocity.X/1.4f, -GameObjectPhysics.Velocity.Y / 1.4f);
            GameObjectPhysics.TrajectMove(trajectoryLog[ShootAngle.Up].Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideUp(Rectangle collisionArea)
        {
            base.CollideUp(collisionArea);
            Vector2 ini_v = new Vector2(GameObjectPhysics.Velocity.X/1.4f, -GameObjectPhysics.Velocity.Y / 1.4f);
            GameObjectPhysics.TrajectMove(trajectoryLog[ShootAngle.Down].Invoke(ini_v));
            bounceCounter++;
        }

        public virtual void Shoot(ShootAngle angle, Vector2 initialV, Vector2 initialP)
        {
            State.ChangeDirection(angle);
            int offset = angle == ShootAngle.Up ? Sprite.Height : Sprite.Width;
            GameObjectPhysics.Position = spriteOffset[angle].Invoke(initialP, offset);
            GameObjectPhysics.TrajectMove(trajectoryLog[angle].Invoke(initialV));
        }

        public virtual void OwnerScores()
        {
            owner.ScoreKill();
        }

        public virtual void SetOwner(IGameObject owner)
        {
            this.owner = (IMario)owner;
        }
    }
}
