using Microsoft.Xna.Framework;
using FarseerGames.FarseerPhysics;

namespace XNAForms
{
    public sealed class Engine
    {
        static readonly PhysicsSimulator physics = new PhysicsSimulator(new Vector2(0, 300));

        static Engine() { }
        Engine() { }

        public static PhysicsSimulator PhysicsSimulator
        {
            get { return physics; }
        }
    }
}
