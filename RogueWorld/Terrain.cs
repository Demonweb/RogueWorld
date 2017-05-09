using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RogueWorld
{
    public class Terrain
    {
        public string Name = "Grass";
        public Color bgColor = Color.Green;
        public List<Object> stuffList = new List<Object>();

        public int foodPotential = 0;
    }
}
