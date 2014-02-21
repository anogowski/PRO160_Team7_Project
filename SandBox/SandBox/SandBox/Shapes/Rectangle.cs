﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace PhysicsSandbox.Shapes
{
    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Vector3 LeftTop { get { return Vector3.Add(vecs[0], Position); } }
        public Vector3 RightTop { get { return Vector3.Add(vecs[1], Position); } }
        public Vector3 RightBottom { get { return Vector3.Add(vecs[2], Position); } }
        public Vector3 LeftBottom { get { return Vector3.Add(vecs[3], Position); } }

        public Rectangle(Vector3 position, Vector3 velocity, float mass = 1.0f, float momentum = 0.0f, int width = 10, int height = 10)
        {
            this.Position = position;
            this.Mass = mass;
            this.Momentum = momentum;
            Width = width;
            Height = height;
            Velocity = velocity;
            MoveTime = 0;
            NumOfPoints = 4;
            GenVectorsForRectangle();
        }

        private void GenVectorsForRectangle()
        {
            Vector3 leftTop = new Vector3(-Width / 2, -Height / 2 , 0);
            Vector3 rightTop = new Vector3(Width / 2, -Height / 2, 0);
            Vector3 rightBottom = new Vector3( Width / 2, Height / 2, 0);
            Vector3 leftBottom= new Vector3(-Width / 2, Height / 2, 0);

            vecs[0] = leftTop;
            vecs[1] = rightTop;
            vecs[2] = rightBottom;
            vecs[3] = leftBottom;
        }


    }
}
