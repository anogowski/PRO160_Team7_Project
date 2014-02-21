using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhysicsSandbox.Shapes;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Sandbox
{
    public class Collision
    {
        public static bool RectangleRectangleCollision( Rectangle rec1,  Rectangle rec2)
        {
            bool b = true;
            if ((rec1.Position.X > rec2.Position.X + rec2.Width - 1) &&
               (rec1.Position.Y > rec2.Position.Y + rec2.Height - 1) &&
               (rec2.Position.X > rec1.Position.X + rec1.Width - 1) &&
               (rec2.Position.Y > rec1.Position.Y + rec1.Height - 1))
            {
                b = false;
            }
            return b;
        }

        public static bool RectangleCircleCollision( Rectangle rec,  Circle cir)
        {
            bool b = false;
            return b;

        }

        public static bool RectangleTriangleCollision( Rectangle rec,  Triangle tri)
        {
            bool b = false;
            return b;

        }

        public static bool TriangleTriangleCollision( Triangle tri1,  Triangle tri2)
        {
            bool b = false;
            return b;

        }

        public static bool TriangleCircleCollision( Triangle tri,  Circle cir)
        {
            bool b = false;
            return b;
            
        }

        public static bool CircleCircleCollision( Circle cir1,  Circle cir2)
        {

            bool b = false;
            float radius1 = cir1.Radius;
            float readius2 = cir2.Radius;

            return b;
        }

        public static double findShapeDistance<T>(T shapeA, T shapeB) where T: Shape
        {
            Microsoft.Xna.Framework.Vector3 pointA = shapeA.Position;
            Microsoft.Xna.Framework.Vector3  pointB = shapeB.Position;

            return Math.Sqrt((int)(pointB.X - pointA.X) ^ 2 + (int)(pointB.Y - pointA.Y) ^ 2);
        }
    }
}
