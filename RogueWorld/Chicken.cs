using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueWorld
{
    class Chicken : Creature
    {

        public override void Update()
        {
           
            //eat grass at current square
            GameScreen.terrainMap[xPos, yPos].foodPotential =0;
            
            if (age > SpawnAge)
            {
                Alive = false;
                for (int i = 0; i < GameScreen.globalRandom.Next(1, 3); i++)
                {
                    int x = GameScreen.globalRandom.Next(GameScreen.mapWidth);
                    int y = GameScreen.globalRandom.Next(GameScreen.mapHeight);

                    Chicken creature = new Chicken();
                    creature.Name = "Chicken";
                    creature.bgColor = Color.Gold;
                    creature.height = GameScreen.tileHeight;
                    creature.width = GameScreen.tileWidth;
                    creature.maxAge = 1000;
                    creature.xPos = x;
                    creature.yPos = y;
                    GameScreen.spawnList.Add(creature);
                }
            }     
        }



        public override void ScanDanger()
        {
            List<Creature> scanList = new List<Creature>();

            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if (xPos + i > 0 && xPos + i < GameScreen.mapWidth - 1 && yPos + j > 0 && yPos + j < GameScreen.mapHeight - 1)
                    {
                        foreach (var item in GameScreen.terrainMap[xPos + i, yPos + j].stuffList )
                        {
                            Type type = item.GetType();

                            if (type == typeof(Wolf))
                            {
                              //hide from wolf
                            }
                        }                        
                    }
                }
            }           
        }

        public override void Move()
        {
            base.Move();
            GameScreen.terrainMap[xPos, yPos].stuffList.RemoveAll(x => x.ID == this.ID);

            GameScreen.terrainMap[xPos, yPos].stuffList.Add(this);

        }

        public override void ScanFood()
        {

            float highestFoodValue = 0;
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

            GameScreen.terrainMap[xPos, yPos].stuffList.Add(this);

           
            health += highestFoodValue;
            if (health > maxHealth) health = maxHealth;

        }
    }
}
