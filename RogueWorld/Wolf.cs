using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueWorld
{
    class Wolf : Creature
    {
        GameMechanics gm = new GameMechanics();

        public override void Update()
        {
          
            age += 1;
            health -= 1;

            Hunt();

            
            if (health < 1)
            {
                Alive = false;
            }

            if (age > SpawnAge)
            {
                Alive = false;
                GameScreen.terrainMap[xPos, yPos].stuffList.RemoveAll(x => x.ID == this.ID);

                for (int i = 0; i < GameScreen.globalRandom.Next(0, 8); i++)
                {
                    Wolf creature;
                    creature = new Wolf();
                    creature.Name = "Wolf";
                    creature.health = 200;
                    creature.maxHealth = 200;
                    creature.maxAge = 1000;
                    creature.SpawnAge = GameScreen.globalRandom.Next(1000);
                    creature.bgColor = Color.Red;
                    creature.height = GameScreen.tileHeight;
                    creature.width = GameScreen.tileWidth;
                    creature.xPos =xPos+ GameScreen.globalRandom.Next(7)-3;
                    creature.yPos =yPos+ GameScreen.globalRandom.Next(7)-3;

                    if (creature.xPos < 0) creature.xPos = 0;
                    if (creature.xPos > GameScreen.mapWidth - 1) creature.xPos = GameScreen.mapWidth - 1;
                    if (creature.yPos < 0) creature.yPos = 0;
                    if (creature.yPos > GameScreen.mapHeight - 1) creature.yPos = GameScreen.mapHeight - 1;

                    GameScreen.spawnList.Add(creature);                    
                }

            }
        }

        private void Hunt()
        {
            GameScreen.terrainMap[xPos, yPos].stuffList.RemoveAll(x => x.ID == this.ID);

            for (int i = 0; i < GameScreen.terrainMap[xPos, yPos].stuffList.Count; i++)
            {
              
                    GameScreen.terrainMap[xPos, yPos].stuffList[i].Alive = false;
                    health = 200;
                             
            }          
            GameScreen.terrainMap[xPos, yPos].stuffList.Add(this);

        }




    }
}
