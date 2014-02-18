using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PhysicsSandbox.Shapes;

namespace PhysicsSandbox.Physics
{
    public class Physics
    {
        //general forces
        public float Gravity { get; set; }

        public Physics(float gravity = 9.8f)
        {
 
        }

        public void addGeneralForces(ref Shape shape)
        {
            addFreeFall(ref shape);
        }

        private void addFreeFall(ref Shape shape)
        {
            shape.Velocity = new Vector2(shape.Velocity.X, (Gravity * shape.MoveTime * shape.MoveTime) / 2);            
        }
    }
}
