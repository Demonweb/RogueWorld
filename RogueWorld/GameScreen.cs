using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueWorld
{
    public partial class GameScreen : Form
    {
        Graphics formGraphics;

        public static Random globalRandom = new Random();
        public int tileWidth = 16;
        public int tileHeight = 16;
        public static int mapWidth = 40;
        public static int mapHeight = 30;
        public static Terrain[,] terrainMap = new Terrain[mapWidth, mapHeight];


        List<Creature> creatureList = new List<Creature>();

        public GameScreen()
        {
            InitializeComponent();
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
            GameDraw();
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            GameCycle();
        }

        private void ResetGame()
        {
            ResetMap();
            creatureList.Clear();
            AddCreature();
        }

        private void ResetMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    terrainMap[x, y] = RandomTerrain();
                }
            }
        }


        private void GameCycle()
        {
            GameUpdate();
            GameDraw();
        }


        private void GameUpdate()
        {
            foreach (var creature in creatureList)
            {
                creature.Update();
            }
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    terrainMap[x, y].foodPotential += 1;
                    if (terrainMap[x, y].foodPotential > 25)
                    {
                        terrainMap[x, y].foodPotential = 25;
                    }
                    terrainMap[x, y].bgColor = Color.FromArgb(255, 0, terrainMap[x, y].foodPotential*10, 0);
                }
            }
        }


        private void GameDraw()
        {
            formGraphics = pictureBox1.CreateGraphics();
            ClearPanel();
            DrawMap();
            DrawCreature();
            formGraphics.Dispose();
        }

        private Terrain RandomTerrain()
        {
            int g = globalRandom.Next(25);
            Terrain terrain = new Terrain();
            terrain.Name = "Grass";
            terrain.foodPotential = g;
            terrain.bgColor = Color.FromArgb(255, 0, g * 10, 0);

            return terrain;
        }


        public void AddCreature()
        {
            Creature creature;
            for (int i = 0; i < 5; i++)
            {
                creature = new Creature();
                creature.height = tileHeight;
                creature.width = tileWidth;
                int xpos = globalRandom.Next(mapWidth);
                int ypos = globalRandom.Next(mapHeight);
                creature.xPos = xpos;
                creature.yPos = ypos;

                creatureList.Add(creature);
                terrainMap[xpos, ypos].stuffList.Add(creature);
            }
        }

        public void ClearPanel()
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            formGraphics.FillRectangle(brush, new Rectangle(0, 0, 640, 480));
            brush.Dispose();
        }

        public void DrawFog()
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
            formGraphics.FillRectangle(brush, new Rectangle(0, 0, 640, 480));
            brush.Dispose();
        }


        public void DrawMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    DrawSquare(x, y, terrainMap[x, y].bgColor);
                }
            }
        }

        public void DrawCreature()
        {
            foreach (var creature in creatureList)
            {
                FillCircle(creature.xPos, creature.yPos, creature.height, creature.bgColor);
            }
        }

        public void DrawSquare(int x, int y, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            Pen pen = new Pen(Color.Black);

            formGraphics.FillRectangle(brush, new Rectangle(x * tileWidth, y * tileWidth, tileWidth, tileWidth));
            formGraphics.DrawRectangle(pen, new Rectangle(x * tileHeight, y * tileHeight, tileHeight, tileHeight));
            brush.Dispose();
            pen.Dispose();
        }

        public void DrawCircle(float x, float y, float radius, Color color)
        {
            Pen pen = new Pen(Color.Black);
            formGraphics.DrawEllipse(pen, x, y, radius, radius);
            pen.Dispose();
        }

        public void FillCircle(float x, float y, float radius, Color color)
        {
            SolidBrush brush = new SolidBrush(color);

            formGraphics.FillEllipse(brush, x * tileWidth, y * tileHeight, radius, radius);
            brush.Dispose();
        }




    }
}
