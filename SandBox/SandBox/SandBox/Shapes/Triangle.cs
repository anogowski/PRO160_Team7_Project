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

        public Triangle(Vector2 position, float mass = 1.0f, float momentum = 0.0f, int width = 10, int height = 10)
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
            Vector3 top = new Vector3(Position.X, Position.Y - Height / 2, 0);
            Vector3 leftBottom = new Vector3(Position.X - Width / 2, Position.Y + Height / 2, 0);
            Vector3 rightButtom = new Vector3(Position.X + Width / 2, Position.Y + Height / 2, 0);
        }
    }
}
