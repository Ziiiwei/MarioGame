﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Gamespace.Blocks;
using Gamespace.Commands;
using Gamespace.Goombas;
using Gamespace.Koopas;
using Gamespace.States;

namespace Gamespace
{
    public class JsonParser
    {
        private static readonly JsonParser instance = new JsonParser();
        private readonly String collisionActionsPath = "MarioGame/Data/CollisionActions.json";
        private readonly String levelObjectsPath = "MarioGame/Data/Level1.json";

        static JsonParser()
        {
        }

        private JsonParser()
        {
        }

        public static JsonParser Instance
        {
            get
            {
                return instance;
            }
        }

        protected class CollisionDeserializedObject
        {
            public String Mover { get; set; }
            public String Target { get; set; }
            public String Side { get; set; }
            public String Command1 { get; set; }
            public String Command2 { get; set; }
        }

        protected class CollisionDeserializedObjectRoot
        {
            public List<CollisionDeserializedObject> Entries { get; set; }
        }
        internal Dictionary<Tuple<Type, Type, CollisionHandler.Side>, Tuple<Type, Type>> ParseCollisionFile()
        {
            StreamReader reader = File.OpenText(collisionActionsPath);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var magicNumbers = javaScriptSerializer.Deserialize<CollisionDeserializedObjectRoot>(reader.ReadToEnd());
            reader.Close();

            var collisionActions = new Dictionary<Tuple<Type, Type, CollisionHandler.Side>, Tuple<Type, Type>>();

            foreach (var cdo in magicNumbers.Entries)
            {
                Type obj1 = Type.GetType(cdo.Mover);
                Type obj2 = Type.GetType(cdo.Target);
                CollisionHandler.Side Side = (CollisionHandler.Side) Enum.Parse(typeof(CollisionHandler.Side), cdo.Side);
                var key = new Tuple<Type, Type, CollisionHandler.Side>(obj1, obj2, Side);
                var value = new Tuple<Type, Type>(Type.GetType(cdo.Command1), Type.GetType(cdo.Command2));
                collisionActions.Add(key, value);
            }
            return collisionActions;
        }

        protected class LevelDeserializedObject
        {
            public int Uid { get; set; }
            public String T { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public String State { get; set; }
        }

        protected class LevelDeserializedObjectRoot
        {
            public List<LevelDeserializedObject> gameObjects;
        }

        public List<Tuple<int, IGameObject>> ParseLevelFile()
        {
            StreamReader reader = File.OpenText(levelObjectsPath);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var magicNumbers = javaScriptSerializer.Deserialize<LevelDeserializedObjectRoot>(reader.ReadToEnd());
            reader.Close();
            var gameObjects = new List<Tuple<int, IGameObject>>();

            foreach (LevelDeserializedObject ldo in magicNumbers.gameObjects)
            {
                Type t = Type.GetType(ldo.T);
                int x = ldo.X;
                int y = ldo.Y;
                Type state = Type.GetType(ldo.State);

                IGameObject go;

                if (state != null)
                {
                    go = (AbstractGameStatefulObject<Object>)Activator.CreateInstance(t, new Vector2(x, y));
                    AbstractGameStatefulObject<Object> statefulGameObject = (AbstractGameStatefulObject<Object>) go;

                    statefulGameObject.State = state;
                    

                }
                else
                {
                    go = (IGameObject)Activator.CreateInstance(t, new Vector2(x, y));
                }

                gameObjects.Add(new Tuple<int, IGameObject>(go.Uid, go));
            }
            return gameObjects;
        }
    }
}
