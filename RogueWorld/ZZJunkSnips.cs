using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueWorld
{
    class ZZJunkSnips
    {

        //GameScreen.terrainMap[xPos, yPos].stuffList.RemoveAll(x => x.ID == this.ID);



        //foreach (var creature in creatureList)
        //           {
        //               System.Type type = creature.GetType();

        //               if (type==typeof(Chicken))
        //               {
        //                  //dosomething
        //               }

        //           }


        //private void Hunt()
        //{
        //    GameScreen.terrainMap[xPos, yPos].stuffList.RemoveAll(x => x.ID == this.ID);

        //    float highestFoodValue = 0;
        //    List<Point> moveDirectionList = new List<Point>();

        //    //up
        //    int tryX = xPos - 1;
        //    if (tryX >= 0)
        //    {
        //        if (highestFoodValue == GameScreen.terrainMap[xPos - 1, yPos].foodPotential)
        //        {
        //            moveDirectionList.Add(new Point(-1, 0));
        //        }
        //        else if (highestFoodValue < GameScreen.terrainMap[xPos - 1, yPos].foodPotential)
        //        {
        //            moveDirectionList.Clear();
        //            highestFoodValue = GameScreen.terrainMap[xPos - 1, yPos].foodPotential;
        //            moveDirectionList.Add(new Point(-1, 0));
        //        }
        //    }
        //    //down
        //    tryX = xPos + 1;
        //    if (tryX < GameScreen.mapWidth)
        //    {
        //        if (highestFoodValue == GameScreen.terrainMap[xPos + 1, yPos].foodPotential)
        //        {
        //            moveDirectionList.Add(new Point(1, 0));
        //        }
        //        else if (highestFoodValue < GameScreen.terrainMap[xPos + 1, yPos].foodPotential)
        //        {
        //            moveDirectionList.Clear();
        //            highestFoodValue = GameScreen.terrainMap[xPos + 1, yPos].foodPotential;
        //            moveDirectionList.Add(new Point(1, 0));
        //        }
        //    }
        //    //right
        //    int tryY = yPos + 1;
        //    if (tryY < GameScreen.mapHeight)
        //    {
        //        if (highestFoodValue == GameScreen.terrainMap[xPos, yPos + 1].foodPotential)
        //        {
        //            moveDirectionList.Add(new Point(0, 1));
        //        }
        //        else if (highestFoodValue < GameScreen.terrainMap[xPos, yPos + 1].foodPotential)
        //        {
        //            moveDirectionList.Clear();
        //            highestFoodValue = GameScreen.terrainMap[xPos, yPos + 1].foodPotential;
        //            moveDirectionList.Add(new Point(0, 1));
        //        }
        //    }
        //    //left
        //    tryY = yPos - 1;
        //    if (tryY >= 0)
        //    {
        //        if (highestFoodValue == GameScreen.terrainMap[xPos, yPos - 1].foodPotential)
        //        {
        //            moveDirectionList.Add(new Point(0, -1));
        //        }
        //        else if (highestFoodValue < GameScreen.terrainMap[xPos, yPos - 1].foodPotential)
        //        {
        //            moveDirectionList.Clear();
        //            highestFoodValue = GameScreen.terrainMap[xPos, yPos - 1].foodPotential;
        //            moveDirectionList.Add(new Point(0, -1));
        //        }
        //    }

        //    int dir = GameScreen.globalRandom.Next(moveDirectionList.Count);

        //    xPos += moveDirectionList[dir].X;
        //    yPos += moveDirectionList[dir].Y;

        //    GameScreen.terrainMap[xPos, yPos].stuffList.Add(this);

        //    health += highestFoodValue;
        //    if (health > maxHealth) health = maxHealth;

        //}



    }
}
