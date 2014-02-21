using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PhysicsSandbox.Shapes;
using PhysicsSandbox.Physics;

namespace SandBox
{
    class DrawShapesManager
    {
        //make a container of all rectangles
        //make a container of all triangles
        //make a container of all circles

        //a method: addShapes(shape object, shape type);

        private PhysicsSandbox.Shapes.Rectangle DrawRectangle(PhysicsSandbox.Shapes.Rectangle rect, int width, int height, Vector3 pos, float mass, float momentum)
        {
            rect.Width = width;
            rect.Height = height;
            rect.Position = pos;
            rect.Mass = mass;
            rect.Momentum = momentum;
            return rect;
        }
        private PhysicsSandbox.Shapes.Rectangle DrawRectangle(PhysicsSandbox.Shapes.Rectangle rect, int width, int height, Vector3 pos)
        {
            rect.Width = width;
            rect.Height = height;
            rect.Position = pos;
            return rect;
        }

        private Circle DrawCircle(Circle circ, float mass, float momentum, int radius, Vector3 pos)
        {
            circ.Radius = radius;
            circ.Mass = mass;
            circ.Momentum = momentum;
            circ.Position = pos;
            return circ;
        }
        private Circle DrawCircle(Circle circ, int radius, Vector3 pos)
        {
            circ.Radius = radius;
            circ.Position = pos;
            return circ;
        }
        
        private Triangle DrawTriangle(Triangle tri, int width, int height, Vector3 pos, float mass, float momentum)
        {
            tri.Width = width;
            tri.Height = height;
            tri.Position = pos;
            tri.Mass = mass;
            tri.Momentum = momentum;
            return tri;
        }
        private Triangle DrawTriangle(Triangle tri, int width, int height, Vector3 pos)
        {
            tri.Width = width;
            tri.Height = height;
            tri.Position = pos;
            return tri;
        }

        public void UpdatePhysics(Physics p)
        {
            //iterate all list elemtns
            //foreach (var item in rectangles)
            //{
            //    DrawRectangle(....);
            //}

            // foreach (var item in rectangles)
            //{
            //    DrawRectangle(....);
            //}
            //}

            // foreach (var item in rectangles)
            //    {
            //        DrawRectangle(....);
            //    }
            //}
        }

        public void Draw()
        {
            //iterate all list elemtns
            //foreach (var item in rectangles)
            //{
            //    DrawRectangle(....);
            //}

            // foreach (var item in rectangles)
            //{
            //    DrawRectangle(....);
            //}
            //}

            // foreach (var item in rectangles)
            //    {
            //        DrawRectangle(....);
            //    }
            //}
        }
    }
}
