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
            bool b = false;
            if (!((rec1.LeftTop.X > rec2.LeftTop.X + rec2.Width - 1) ||
               (rec1.LeftTop.Y > rec2.LeftTop.Y + rec2.Height - 1) ||
               (rec2.LeftTop.X > rec1.LeftTop.X + rec1.Width - 1) ||
               (rec2.LeftTop.Y > rec1.LeftTop.Y + rec1.Height - 1)))
            {
                b = true;
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
            return b;
           
        }

    }
}
