using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;


namespace Gamespace
{
    public class JsonParser
    {
        private static readonly JsonParser instance = new JsonParser();
        private readonly string collisionActionsPath = "MarioGame/Data/DataFiles/OtherCollisionActions.json";
        private readonly string statefulCollisionActionsPath = "MarioGame/Data/DataFiles/OtherStatefulCollisionActions.json";

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
            public string Mover { get; set; }
            public string Target { get; set; }
            public string Side { get; set; }
            public string Command1 { get; set; }
            public string Command2 { get; set; }
        }

        protected class CollisionDeserializedObjectRoot
        {
            public List<CollisionDeserializedObject> Entries { get; set; }
        }
        private Dictionary<Tuple<Type, Type, CollisionHandler.Side>, Tuple<Type, Type>> ParseCollisionFile(string path)
        {
            StreamReader reader = File.OpenText(path);
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

        internal Dictionary<Tuple<Type, Type, CollisionHandler.Side>, Tuple<Type, Type>> ParseCollisionFile()
        {
            return ParseCollisionFile(collisionActionsPath);
        }

        internal Dictionary<Tuple<Type, Type, CollisionHandler.Side>, Tuple<Type, Type>> ParseCollisionStatefulFile()
        {
            return ParseCollisionFile(statefulCollisionActionsPath);
        }

        protected class LevelDeserializedObject
        {
            public int Uid { get; set; }
            public string T { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public string State { get; set; }
        }

        protected class LevelDeserializedObjectRoot
        {
            public List<LevelDeserializedObject> gameObjects;
        }

        public List<Tuple<int, IGameObject>> ParseLevelFile(string levelObjectsPath)
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
                    go = (IGameObject)Activator.CreateInstance(t, new Vector2(x, y), state);
                }
                else
                {
                    go = (IGameObject)Activator.CreateInstance(t, new Vector2(x, y));
                }

                World.Instance.AddGameObject(go);
            }
            return gameObjects;
        }
    }
}
