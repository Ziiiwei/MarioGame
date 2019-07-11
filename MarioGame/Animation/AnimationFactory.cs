using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Commands;
using Microsoft.Xna.Framework;


namespace Gamespace.Animation
{
  
    public class AnimationFactory
    {
        private Dictionary<Type,List<(Type, int, int)>> animationLog;
        private Dictionary<Type, Func<Vector2, int, Vector2>> newFrameCaculation;
        private Dictionary<Type, GoalCheckFun> goalCheckFuncLog;


        private delegate bool GoalCheckFun(Vector2 location, int repeat,Vector2 goallocation,int goalrepeat);
        private delegate Vector2 GoalPointCal(Vector2 location, int distance);
        private const int DISTANCE_PRECISION = 4;


        
        static AnimationFactory() { }
        private AnimationFactory()
        {
            GoalCheckFun locationCheck = (p, c, goal_p, goal_c) =>
           {              
               return (Vector2.Distance(p,goal_p)<= DISTANCE_PRECISION || c>=goal_c);
           };

            GoalCheckFun verticalCheck = (p, c, goal_p, goal_c) =>
            {
                return (Math.Abs(p.Y-goal_p.Y) <= DISTANCE_PRECISION||c>=goal_c);
            };

            GoalCheckFun horizontalCheck = (p, c, goal_p, goal_c) =>
            {
                return (Math.Abs(p.X - goal_p.X) <= DISTANCE_PRECISION||c>=goal_c);
            };

            GoalCheckFun repeatCheck = (p, c, goal_p, goal_c) =>
            {
                return c>=goal_c;
            };




            animationLog = new Dictionary<Type, List<(Type, int, int)>>()
            {
                {
                    typeof(PlayTestAnimation),
                    new List<(Type, int,int)>
                    {
                        (typeof(MarioMoveLeftCommand),50,1000),
                        (typeof(MarioMoveRightCommand),100,1000),
                        (typeof(MarioCrouchCommand),0,100),
                        (typeof(MarioJumpCommand),0,100)
                    }
                }
            };

            newFrameCaculation = new Dictionary<Type, Func<Vector2,int,Vector2>>()
            {
                {typeof(MarioClimbingUpCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X,p.Y-d))},
                {typeof(MarioClimingDownCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X,p.Y+d))},
                {typeof(MarioMoveLeftCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X-d,p.Y))},
                {typeof(MarioMoveRightCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X+d,p.Y))},
                {typeof(MarioCrouchCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X,p.Y))},
                {typeof(MarioJumpCommand), new Func<Vector2, int, Vector2>((p,d)=>new Vector2(p.X,p.Y))}
            };

            goalCheckFuncLog = new Dictionary<Type, GoalCheckFun>()
            {
                {typeof(MarioClimbingUpCommand),verticalCheck},
                {typeof(MarioClimingDownCommand),verticalCheck},
                {typeof(MarioMoveLeftCommand), horizontalCheck},
                {typeof(MarioMoveRightCommand), horizontalCheck},
                {typeof(MarioCrouchCommand), repeatCheck},
                {typeof(MarioJumpCommand), repeatCheck}
            };

        }

        private static readonly AnimationFactory instance = new AnimationFactory();
        public static AnimationFactory Instance { get; } = new AnimationFactory();

        public IAnimation<IGameObject> GetAnimation(IGameObject obj, Action afterCommand, Type type)
        {
            Animation animation = new Animation(obj, afterCommand);
            Vector2 pointToBegin = new Vector2(obj.PositionOnScreen.X, obj.PositionOnScreen.Y);

            foreach ((Type command,int distance,int repeat) in animationLog[type])
            {
                animation.AddFrame(new KeyFrame(obj, command, animation,
                    new Func<Vector2, int, Vector2, int, bool>(goalCheckFuncLog[command]),
                    newFrameCaculation[command].Invoke(pointToBegin, distance),
                    repeat
                    ));
                pointToBegin = newFrameCaculation[command].Invoke(pointToBegin, distance);
            }

            return animation;
        }


    }
}
