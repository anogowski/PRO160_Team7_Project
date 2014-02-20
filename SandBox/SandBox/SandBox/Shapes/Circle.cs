using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PhysicsSandbox.Shapes
{
    public class Circle : Shape
    {
        public float Radius { get; set; }

        public Circle(Vector3 position, float mass = 1.0f, float momentum = 0.0f, float radius = 1.0f)
        {
            this.Position = position;
            this.Mass = mass;
            this.Momentum = momentum;
        }
        
    }
}
