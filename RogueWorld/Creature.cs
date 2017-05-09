using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RogueWorld
{
    public class Creature
    {
        public readonly Guid ID = new Guid();
        public string Name = "Chicken";
        public Color bgColor = Color.Yellow;
        public float height = 1;
        public float width = 1;
        public int xPos = 0;
        public int yPos = 0;

        public int health = 100;
        public int thirst = 0;
        public int hunger = 0;
        public int thirstMax = 10;
        public int hungerMax = 10;
        public bool Alive = true;
        public int age = 0;
        public int SpawnClock = GameScreen.globalRandom.Next(1000);
        public int SpawnOffspring = 0;

        public void Update()
        {
            age += 1;

            Hunt();
            //MoveRandom();
            GameScreen.terrainMap[xPos, yPos].foodPotential = 0;
            health -= 20;

            if (health <= 0)
            {
                Alive = false;
            }

            if (age > SpawnClock)
            {
                Alive = false;
                SpawnOffspring = GameScreen.globalRandom.Next(2);
            }


        }

        private void Hunt()
        {
            int highestFoodValue = 0;
            List<Point> moveDirectionList = new List<Point>();

            //up
            int tryX = xPos - 1;
            if (tryX >= 0)
            {
                if (highestFoodValue == GameScreen.terrainMap[xPos - 1, yPos].foodPotential)
                {
                    moveDirectionList.Add(new Point(-1, 0));
                }
                else if (highestFoodValue < GameScreen.terrainMap[xPos - 1, yPos].foodPotential)
                {
                    moveDirectionList.Clear();
                    highestFoodValue = GameScreen.terrainMap[xPos - 1, yPos].foodPotential;
                    moveDirectionList.Add(new Point(-1, 0));
                }
            }
            //down
            tryX = xPos + 1;
            if (tryX < GameScreen.mapWidth)
            {
                if (highestFoodValue == GameScreen.terrainMap[xPos + 1, yPos].foodPotential)
                {
                    moveDirectionList.Add(new Point(1, 0));
                }
                else if (highestFoodValue < GameScreen.terrainMap[xPos + 1, yPos].foodPotential)
                {
                    moveDirectionList.Clear();
                    highestFoodValue = GameScreen.terrainMap[xPos + 1, yPos].foodPotential;
                    moveDirectionList.Add(new Point(1, 0));
                }
            }
            //right
            int tryY = yPos + 1;
            if (tryY < GameScreen.mapHeight)
            {
                if (highestFoodValue == GameScreen.terrainMap[xPos, yPos + 1].foodPotential)
                {
                    moveDirectionList.Add(new Point(0, 1));
                }
                else if (highestFoodValue < GameScreen.terrainMap[xPos, yPos + 1].foodPotential)
                {
                    moveDirectionList.Clear();
                    highestFoodValue = GameScreen.terrainMap[xPos, yPos + 1].foodPotential;
                    moveDirectionList.Add(new Point(0, 1));
                }
            }
            //left
            tryY = yPos - 1;
            if (tryY >= 0)
            {
                if (highestFoodValue == GameScreen.terrainMap[xPos, yPos - 1].foodPotential)
                {
                    moveDirectionList.Add(new Point(0, -1));
                }
                else if (highestFoodValue < GameScreen.terrainMap[xPos, yPos - 1].foodPotential)
                {
                    moveDirectionList.Clear();
                    highestFoodValue = GameScreen.terrainMap[xPos, yPos - 1].foodPotential;
                    moveDirectionList.Add(new Point(0, -1));
                }
            }

            int dir = GameScreen.globalRandom.Next(moveDirectionList.Count);

            xPos += moveDirectionList[dir].X;
            yPos += moveDirectionList[dir].Y;

            health += highestFoodValue;
            if (health > 100) health = 100;

        }


        private void MoveRandom()
        {
            int moveDirection = GameScreen.globalRandom.Next(4);
            if (moveDirection == 0)//up
            {
                yPos -= 1;
                if (yPos <= 0)
                {
                    yPos = 0;
                    MoveRandom();
                }

            }
            if (moveDirection == 2)//down
            {
                yPos += 1;
                if (yPos >= GameScreen.mapHeight - 1)
                {
                    yPos = GameScreen.mapHeight - 1;
                    MoveRandom();
                }
            }
            if (moveDirection == 1)//right
            {
                xPos += 1;
                if (xPos >= GameScreen.mapWidth - 1)
                {
                    xPos = GameScreen.mapWidth - 1;
                    MoveRandom();
                }
            }
            if (moveDirection == 3)//left
            {
                xPos -= 1;
                if (xPos <= 0)
                {
                    xPos = 0;
                    MoveRandom();
                }
            }
        }




    }

}

