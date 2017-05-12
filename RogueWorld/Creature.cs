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
        public Guid ID = Guid.NewGuid();
        public bool Alive = true;
        public string Name = "creature";
        public Color bgColor = Color.Blue;
        public int height = 1;
        public int width = 1;
        public int xPos = 0;
        public int yPos = 0;

        public float health = 100;
        public float maxHealth = 100;
        public float thirst = 0;
        public float hunger = 0;
        public float thirstMax = 10;
        public float hungerMax = 10;
       
        public int age = 0;
        public int maxAge = 1000;
        public int SpawnAge = GameScreen.globalRandom.Next(200);
        public int SpawnOffspringCount = 2;


        public virtual void SpawnSelf() { }
        public virtual void UpdateAge() { }
        public virtual void ScanDanger() { }
        public virtual void ScanFood() { }
        public virtual void Move() { }
        public virtual void Eat() { }
        public virtual void UpdateHealth() { }       
        public virtual void SpawnOffspring() { }



             

        public virtual void Update() { }

      

        public void CreatureUpdate()
        {
         
        }
        
       
        

    }

}

