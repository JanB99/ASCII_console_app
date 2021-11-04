using System;
using System.Collections.Generic;
using System.Text;

namespace ASCII_console_app
{
    class Vec2
    {

        public float x, y;

        public Vec2(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public float MagSq() {
            return x * x + y * y;
        }

        public static Vec2 Limit(Vec2 a, float n)
        {
            if (a.MagSq() > n * n)
            {
                return Mult(
                    Div(a, Identity((int)Math.Sqrt(a.MagSq()))),
                    Identity((int)n));
            }
            return null;
        }

        public static Vec2 Add(Vec2 a, Vec2 b) {
            return new Vec2(a.x + b.x, a.y + b.y);
        }

        public static Vec2 Sub(Vec2 a, Vec2 b) {
            return new Vec2(a.x - b.x, a.y - b.y);
        }

        public static Vec2 Mult(Vec2 a, Vec2 b)
        {
            return new Vec2(a.x * b.x, a.y * b.y);
        }
        public static Vec2 Div(Vec2 a, Vec2 b)
        {
            if (b.x == 0 || b.y == 0) throw new ArithmeticException();
            return new Vec2(a.x / b.x, a.y / b.y);
        }

        public static Vec2 Identity(float val) {
            return new Vec2(val, val);
        }
    }
}
