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
        private const int NO_REPEAT_CHECK = -1;
        private const int REPEAT_UPER_LIMIT = 600; 


        
        static AnimationFactory() { }
        private AnimationFactory()
        {
            GoalCheckFun locationCheck = (p, c, goal_p, goal_c) =>
           {              
               return (Vector2.Distance(p,goal_p)<= DISTANCE_PRECISION);
           };

            GoalCheckFun verticalCheck = (p, c, goal_p, goal_c) =>
            {
                return (Math.Abs(p.Y-goal_p.Y) <= DISTANCE_PRECISION);
            };

            GoalCheckFun horizontalCheck = (p, c, goal_p, goal_c) =>
            {
                return (Math.Abs(p.X - goal_p.X) <= DISTANCE_PRECISION);
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
                        (typeof(MarioMoveLeftCommand),50,NO_REPEAT_CHECK),
                        (typeof(MarioMoveRightCommand),100,NO_REPEAT_CHECK),
                        (typeof(MarioCrouchCommand),0,60),
                        (typeof(MarioJumpCommand),0,60)
                    }
                },

                {
                    typeof(PlayMarioTouchFlag),
                    new List<(Type, int, int)>
                    {
                        (typeof(MarioClimbingDownCommand),150,NO_REPEAT_CHECK),
                        (typeof(MarioMoveRightCommand),200,NO_REPEAT_CHECK)
                    }
                }

            };

            newFrameCaculation = new Dictionary<Type, Func<Vector2,int,Vector2>>()
            {
                {typeof(MarioClimbingUpCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X,p.Y-d))},
                {typeof(MarioClimbingDownCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X,p.Y+d))},
                {typeof(MarioMoveLeftCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X-d,p.Y))},
                {typeof(MarioMoveRightCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X+d,p.Y))},
                {typeof(MarioCrouchCommand), new Func<Vector2, int, Vector2>((p,d) => new Vector2(p.X,p.Y))},
                {typeof(MarioJumpCommand), new Func<Vector2, int, Vector2>((p,d)=>new Vector2(p.X,p.Y))}
            };

            goalCheckFuncLog = new Dictionary<Type, GoalCheckFun>()
            {
                {typeof(MarioClimbingUpCommand),verticalCheck},
                {typeof(MarioClimbingDownCommand),verticalCheck},
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
