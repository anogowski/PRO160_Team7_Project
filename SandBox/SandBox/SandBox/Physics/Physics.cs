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

		/// <summary>
		/// Air resistance is a value between 0 and 1 that slows down the velocity of an object.
		/// </summary>
		public float AirResistance {
			get;
			set;
		}

        public Physics(float gravity = 9.8f)
        {
 
        }

        public void addGeneralForces<T>(ref T shape) where T : Shape
        {
            addFreeFall(ref shape);
        }

        private void addFreeFall<T>(ref T shape) where T : Shape
        {
            shape.Velocity = new Vector3(shape.Velocity.X, (Gravity * shape.MoveTime * shape.MoveTime) / 2, 0);            
        }

		public void addAirResistance<T>(ref T shape) where T : Shape {
			shape.Velocity *= AirResistance;
		}
    }
}
