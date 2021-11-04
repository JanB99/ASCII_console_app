using System;
using System.Collections.Generic;
using System.Text;

namespace ASCII_console_app
{
    class Ball
    {
        public Vec2 loc, vel, acc;
        public int r;

        public Ball(int x, int y, int r) {
            loc = new Vec2(x, y);
            vel = Vec2.Identity(0);
            acc = Vec2.Identity(0);
            this.r = r;
        }

        public void Update() {
            vel = Vec2.Add(vel, acc);
            loc = Vec2.Add(loc, vel);
            acc = Vec2.Identity(0);

            if (loc.y + r >= Program.HEIGHT - 1 || loc.y - r < 0) {
                loc.y = Program.HEIGHT - r;
                vel.y *= -1;
            }
            if (loc.x + r >= Program.WIDTH - 1 || loc.x - r < 0)
            {
                loc.x = Program.WIDTH - r;
                vel.x *= -1;
            }

           

        }

        public void ApplyForce(Vec2 f) {
            acc = Vec2.Add(acc, f);
        }
    }
}
