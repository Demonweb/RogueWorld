using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace RogueWorld
{
    public class Terrain
    {
        public string Name = "Grass";
        public Color bgColor = Color.Green;
        public bool blocked = false;

        //public Image image = Image.FromFile(Application.StartupPath + "\\TerrainSprites\\0.png");


        public List<Creature> stuffList = new List<Creature>();

        public float foodPotential = 0;

        //public void SetImage(string fileName)
        //{ 
        //    image= Image.FromFile(Application.StartupPath + "\\TerrainSprites\\" + fileName);       
        //}

    }
}
