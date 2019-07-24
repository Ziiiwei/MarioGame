using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class ViewportFactory
    {
        private static readonly ViewportFactory instance = new ViewportFactory();
        private static List<List<Tuple<Point, int, int>>> splitScreenOrigins;

        static ViewportFactory()
        {
            splitScreenOrigins = new List<List<Tuple<Point, int, int>>>()
            {
                new List<Tuple<Point, int, int>>()
                {
                    new Tuple<Point, int, int>(new Point(0, 0), MarioGame.WINDOW_WIDTH, MarioGame.WINDOW_HEIGHT),
                },
                new List<Tuple<Point, int, int>>()
                {
                    new Tuple<Point, int, int>(new Point(0, 0), MarioGame.WINDOW_WIDTH, MarioGame.WINDOW_HEIGHT / 2),
                    new Tuple<Point, int, int>(new Point(0, MarioGame.WINDOW_HEIGHT / 2), MarioGame.WINDOW_WIDTH, MarioGame.WINDOW_HEIGHT / 2)
                },
                new List<Tuple<Point, int, int>>()
                {
                    new Tuple<Point, int, int>(new Point(0, 0), MarioGame.WINDOW_WIDTH / 2, MarioGame.WINDOW_HEIGHT / 2),
                    new Tuple<Point, int, int>(new Point(MarioGame.WINDOW_WIDTH / 2, 0), MarioGame.WINDOW_WIDTH / 2, MarioGame.WINDOW_HEIGHT / 2),
                    new Tuple<Point, int, int>(new Point(0, MarioGame.WINDOW_HEIGHT / 2), MarioGame.WINDOW_WIDTH / 2, MarioGame.WINDOW_HEIGHT / 2),

                },
                new List<Tuple<Point, int, int>>()
                {
                    new Tuple<Point, int, int>(new Point(0, 0), MarioGame.WINDOW_WIDTH / 2, MarioGame.WINDOW_HEIGHT / 2),
                    new Tuple<Point, int, int>(new Point(MarioGame.WINDOW_WIDTH / 2, 0), MarioGame.WINDOW_WIDTH / 2, MarioGame.WINDOW_HEIGHT / 2),
                    new Tuple<Point, int, int>(new Point(0, MarioGame.WINDOW_HEIGHT / 2), MarioGame.WINDOW_WIDTH / 2, MarioGame.WINDOW_HEIGHT / 2),
                    new Tuple<Point, int, int>(new Point(MarioGame.WINDOW_WIDTH / 2, MarioGame.WINDOW_HEIGHT / 2), MarioGame.WINDOW_WIDTH / 2, MarioGame.WINDOW_HEIGHT / 2)

                }
            };
        }

        public static ViewportFactory Instance { get; } = new ViewportFactory();

        private ViewportFactory()
        {

        }

        public Viewport GetViewport(int playerID, int numberOfPlayers)
        {
            var originAndDimensions = splitScreenOrigins[numberOfPlayers-1];

            Point origin = originAndDimensions[playerID].Item1;
            int width = originAndDimensions[playerID].Item2;
            int height = originAndDimensions[playerID].Item3;

            return new Viewport()
            {
                Width = width,
                Height = height,
                X = origin.X,
                Y = origin.Y
            };
        }
    }
}
