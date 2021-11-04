using System;

namespace ASCII_console_app
{
    class Program
    {
        public static int HEIGHT = 50, WIDTH = 50, FPS = 20;

        static void Main(string[] args)
        {
            char[] grid = Clear();
            bool running = true;

            Ball ball = new Ball(WIDTH / 2, HEIGHT / 2, 10);

            ball.ApplyForce(new Vec2(0, 0));
            while (running)
            {
                Fill(grid);

                //update
                ball.ApplyForce(new Vec2(0, 1));
                ball.Update();

                //draw
                Circle(ball.loc, ball.r, grid);
                Draw(grid);
                System.Threading.Thread.Sleep(1000 / FPS);
                grid = Clear();
            }
        }

        public static char[] Clear() {
            return new char[HEIGHT * WIDTH];
        } 

        public static void Fill(char[] grid) {
            for (int i = 0; i < HEIGHT * WIDTH; i++)
            {
                grid[i] = '0';
            }
        }

        public static void Draw(char[] grid) {
            
            char[][] charset = new char[][] {
                new char[] { ' ', '_' }, 
                new char[] { '^', 'C' }, 
            };

            // 0 0 = *
            // 0 1 = _
            // 1 0 = ^
            // 1 1 = C

            int line = 0;
            for (int y = 0; y < HEIGHT; y += 2)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    if (y + 1 >= HEIGHT) continue;
                    char c = charset[grid[y + x * WIDTH] - '0'][grid[(y + 1) + x * WIDTH] - '0'];
                    Console.SetCursorPosition(x, line);
                    Console.Write(c);
                }
                line++;
            }

        }

        public static void Circle(Vec2 pos, int r, char[] grid) {
            Vec2 lt = new Vec2(pos.x - r, pos.y - r);
            Vec2 rb = new Vec2(pos.x + r, pos.y + r);

            for (int x = (int)lt.x; x < rb.x; x++) {
                for (int y = (int)lt.y; y < rb.y; y++)
                {
                    if (y < 0 || y >= HEIGHT || x < 0 || x >= WIDTH) continue;
                    if (Math.Sqrt(Vec2.Sub(pos, new Vec2(x, y)).MagSq()) <= r) grid[y + x * WIDTH] = '1';
                }
            }
        }
    }
}
