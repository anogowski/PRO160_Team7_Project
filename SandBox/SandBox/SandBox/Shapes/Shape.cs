using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsSandbox.Shapes
{
    public class Shape
    {
        protected Vector3[] vecs = new Vector3[4];

        public Texture2D img { get; set; }

        public int Size { get { return vecs.Length; } }

        public Vector3 GetVec(int index)
        {
            return vecs[index];        
        }

        public float MoveTime { get; set; }        

        public Vector2 Position { get; set; }

        public Vector2 Origin { get; set; }

        public Vector2 Velocity { get; set; }

        public float Momentum { get; set; }

        public float Mass { get; set; }

        public int NumOfPoints { get; set; }
    }
}
