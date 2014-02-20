using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PhysicsSandbox.Shapes
{
    public class Triangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Vector3 Top { get { return Vector3.Add(Top, Position); } set; }
        public Vector3 LeftBottom { get { return Vector3.Add(LeftBottom, Position); } set; }
        public Vector3 RightBottom { get {return  Vector3.Add(RightBottom, Position); } set; }

        public Triangle(Vector3 position, float mass = 1.0f, float momentum = 0.0f, int width = 10, int height = 10)
        {
            this.Position = position;
            this.Mass = mass;
            this.Width = width;
            this.Height = height;
            this.Momentum = momentum;
            NumOfPoints = 3;
            GenTrianglePoints();
        }

        private void GenTrianglePoints()
        {
            Top = new Vector3(0, -Height / 2, 0);
            LeftBottom = new Vector3( -Width / 2, Height / 2, 0);
            RightBottom = new Vector3(Width / 2, Height / 2, 0);
        }
    }
}
