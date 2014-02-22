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
        //a container of all rectangles
        List<PhysicsSandbox.Shapes.Rectangle> rectangleList = new List<PhysicsSandbox.Shapes.Rectangle>();

        //a container of all triangles
        List<Triangle> triangleList = new List<Triangle>();

        //a container of all circles
        List<Circle> circleList = new List<Circle>();

        //a method: addShapes(shape object, shape type);

        private PhysicsSandbox.Shapes.Rectangle DrawRectangle(PhysicsSandbox.Shapes.Rectangle rect, int width, int height, Vector3 pos, float mass, float momentum)
        {
            rect.Width = width;
            rect.Height = height;
            rect.Position = pos;
            rect.Mass = mass;
            rect.Momentum = momentum;
            rectangleList.Add(rect);
            return rect;
        }
        private PhysicsSandbox.Shapes.Rectangle DrawRectangle(PhysicsSandbox.Shapes.Rectangle rect, int width, int height, Vector3 pos)
        {
            rect.Width = width;
            rect.Height = height;
            rect.Position = pos;
            rectangleList.Add(rect);
            return rect;
        }

        private Circle DrawCircle(Circle circ, float mass, float momentum, int radius, Vector3 pos)
        {
            circ.Radius = radius;
            circ.Mass = mass;
            circ.Momentum = momentum;
            circ.Position = pos;
            circleList.Add(circ);
            return circ;
        }
        private Circle DrawCircle(Circle circ, int radius, Vector3 pos)
        {
            circ.Radius = radius;
            circ.Position = pos;
            circleList.Add(circ);
            return circ;
        }
        
        private Triangle DrawTriangle(Triangle tri, int width, int height, Vector3 pos, float mass, float momentum)
        {
            tri.Width = width;
            tri.Height = height;
            tri.Position = pos;
            tri.Mass = mass;
            tri.Momentum = momentum;
            triangleList.Add(tri);
            return tri;
        }
        private Triangle DrawTriangle(Triangle tri, int width, int height, Vector3 pos)
        {
            tri.Width = width;
            tri.Height = height;
            tri.Position = pos;
            triangleList.Add(tri);
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
            foreach (var rect in rectangleList)
            {
                //rect.Draw somehow
            }

             foreach (var circ in circleList)
            {
                //circ.draw
            }

            foreach (var tri in triangleList)
            {
                //tri
            }
        }
    }
}
