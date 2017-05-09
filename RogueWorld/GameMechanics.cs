using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueWorld
{
    public enum Direction { UP = 0, RIGHT = 1, DOWN = 2, LEFT = 3 }

    class GameMechanics
    {
        public Point MoveRandom(int x, int y)
        {
            Point currentPosition = new Point(x, y);
            int moveDirection = GameScreen.globalRandom.Next(4);
            Point newPosition = new Point();
            newPosition = currentPosition;

            switch (moveDirection)
            {
                case 0: //UP
                    if ((newPosition.Y -= 1) < 1)
                    {
                        MoveRandom(x,y);
                    }
                    else
                    {
                        newPosition.Y -= 1;
                    }
                    break;
                case 1: //RIGHT
                    if ((newPosition.X += 1) > GameScreen.mapWidth-1)
                    {
                        MoveRandom(x,y);
                    }
                    else
                    {
                        newPosition.X += 1;
                    }
                    break;
                case 2: //DOWN
                    if ((newPosition.Y += 1) > GameScreen.mapHeight-1)
                    {
                        MoveRandom(x,y);
                    }
                    else
                    {
                        newPosition.Y += 1;
                    }
                    break;
                case 3: //LEFT
                    if ((newPosition.X -= 1) < 1)
                    {
                        MoveRandom(x,y);
                    }
                    else
                    {
                        newPosition.X -= 1;
                    }
                    break;
                default:
                    break;
            }
            return newPosition;
        }


    }
}
