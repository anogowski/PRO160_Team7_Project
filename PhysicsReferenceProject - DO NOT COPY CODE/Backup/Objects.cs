using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.SimpleSamplesXNA.DrawingSystem;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FarseerGames.FarseerPhysics.Factories;
using FarseerGames.FarseerPhysics.Collisions;

namespace XNAForms.Objects
{
    class PhysicsRectangle
    {
        #region Object Vars
        SpriteBatch spriteBatch;
        RectangleBrush brush;
        Body bodyA;
        Geom geomA; 
        #endregion;

        public PhysicsRectangle(GraphicsDevice graphicsDevice, Color fill, Vector2 location, int width, int height,bool frozen)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
            
            float mass = .5f;

            bodyA = BodyFactory.Instance.CreateRectangleBody(Engine.PhysicsSimulator, width, height, mass);
            bodyA.Position = location;
            bodyA.IsStatic = frozen;

            geomA = GeomFactory.Instance.CreateRectangleGeom(Engine.PhysicsSimulator, bodyA, width, height);
            geomA.FrictionCoefficient = .3f;  
          
            Engine.PhysicsSimulator.Add(bodyA);

            brush = new RectangleBrush(width, height, fill, Color.Black);
            brush.Load(graphicsDevice);

        }

        public void draw()
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            brush.Draw(spriteBatch, bodyA.Position, bodyA.Rotation);
            spriteBatch.End();
        }

        public Geom Geometry
        {
            get { return geomA; }
        }
    }

    class PhysicsPolygon
    {
        #region Object Vars
        PolygonBrush brush;
        Body bodyA;
        Geom geomA;
        #endregion

        public PhysicsPolygon(GraphicsDevice graphicsDevice, Color fill, Vector2 location, Vertices vertices, bool frozen)
        {
            float mass = .5f;

            bodyA = BodyFactory.Instance.CreatePolygonBody(vertices, mass);
            bodyA.Position = location;
            bodyA.IsStatic = frozen;

            geomA = GeomFactory.Instance.CreatePolygonGeom(Engine.PhysicsSimulator, bodyA, vertices, 5);
            geomA.FrictionCoefficient = .3f;

            Engine.PhysicsSimulator.Add(bodyA);

            brush = new PolygonBrush(vertices, fill, Color.Black, 2, 2);
            brush.Load(graphicsDevice);
        }

        public void draw()
        {
            brush.Draw(geomA.Matrix);
        }

        public Geom Geometry
        {
            get { return geomA; }
        }
    }

    class PhysicsCircle
    {
        #region Object Vars
        SpriteBatch spriteBatch;
        CircleBrush brush;
        Body bodyA;
        Geom geomA;
        #endregion

        public PhysicsCircle(GraphicsDevice graphicsDevice, Color fill, Vector2 location, int radius, bool frozen)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);

            float mass = .5f;

            if (radius == 0)
                radius = 1;

            bodyA = BodyFactory.Instance.CreateEllipseBody(Engine.PhysicsSimulator, radius, radius, mass);
            bodyA.Position = location;
            bodyA.IsStatic = frozen;

            geomA = GeomFactory.Instance.CreateEllipseGeom(Engine.PhysicsSimulator, bodyA, radius, radius, 60);
            geomA.FrictionCoefficient = .3f;

            Engine.PhysicsSimulator.Add(bodyA);

            brush = new CircleBrush(radius, fill, Color.Black);
            brush.Load(graphicsDevice);
        }

        public void draw()
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            brush.Draw(spriteBatch, bodyA.Position);
            spriteBatch.End();
        }

        public Geom Geometry
        {
            get { return geomA; }
        }
    }

    class PhysicsPlane
    {
        #region Object Vars
        SpriteBatch spriteBatch;
        RectangleBrush brush;
        Body bodyA;
        Geom geomA;
        #endregion

        public PhysicsPlane(GraphicsDevice graphicsDevice, Color fill, Vector2 location, int width, int height)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);

            float mass = .5f;

            if (width == 0)
                width = 1;

            if (height == 0)
                height = 1;

            bodyA = BodyFactory.Instance.CreateRectangleBody(Engine.PhysicsSimulator, width, height, mass);
            bodyA.Position = location;
            bodyA.IsStatic = true;

            geomA = GeomFactory.Instance.CreateRectangleGeom(Engine.PhysicsSimulator, bodyA, width, height);
            geomA.Body.IsStatic = true;
            geomA.FrictionCoefficient = .3f;

            Engine.PhysicsSimulator.Add(bodyA);

            brush = new RectangleBrush(width, height, fill, Color.Black);
            brush.Load(graphicsDevice);
        }

        public void draw()
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            brush.Draw(spriteBatch, bodyA.Position, bodyA.Rotation);
            spriteBatch.End();
        }

        public Geom Geometry
        {
            get { return geomA; }
        }
    }
}
