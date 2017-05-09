using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueWorld
{
    public partial class GameScreen : Form
    {
        Bitmap Backbuffer;

        public static Random globalRandom = new Random();
        public static int tileWidth = 4;
        public static int tileHeight = 4;
        public static int mapWidth = 160;
        public static int mapHeight = 120;
        public static Terrain[,] terrainMap = new Terrain[mapWidth, mapHeight];
        public int GrassGrowSpeed = 1;
        public static int NumberChickens = 5;

        public static List<Creature> creatureList = new List<Creature>();

        public GameScreen()
        {
            InitializeComponent();
            this.Height = 519;
            this.Width = 657;

            ResetGame();

            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer, true);

            Timer GameTimer = new Timer();
            GameTimer.Interval = 10;
            GameTimer.Tick += new EventHandler(GameTimer_Tick);
            GameTimer.Start();

            this.ResizeEnd += new EventHandler(GameScreen_CreateBackBuffer);
            this.Load += new EventHandler(GameScreen_CreateBackBuffer);
            this.Paint += new PaintEventHandler(GameScreen_Paint);

            this.KeyDown += new KeyEventHandler(GameScreen_KeyDown);


        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.A) { }
            //               
            else if (e.KeyCode == Keys.D) { }
            //
            else if (e.KeyCode == Keys.W) { }
            //
            else if (e.KeyCode == Keys.S) { }
            //
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            if (Backbuffer != null)
            {
                e.Graphics.DrawImageUnscaled(Backbuffer, Point.Empty);
            }
        }

        void GameScreen_CreateBackBuffer(object sender, EventArgs e)
        {
            if (Backbuffer != null)
                Backbuffer.Dispose();

            Backbuffer = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        void Draw()
        {
            if (Backbuffer != null)
            {
                using (var g = Graphics.FromImage(Backbuffer))
                {
                    g.Clear(Color.Black);

                    DrawMap(g);
                    DrawCreature(g);
                }

                Invalidate();
            }
            this.Text = creatureList.Count().ToString();
        }

        void GameTimer_Tick(object sender, EventArgs e)
        {
            GameUpdate();
            Draw();

            // TODO: Add the notion of dying (disable the timer and show a message box or something)
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



        private void GameUpdate()
        {
            foreach (var creature in creatureList)
            {
                creature.Update();
            }

            int numberToSpawn = 0;

            foreach (var creature in creatureList)
            {
                numberToSpawn += creature.SpawnOffspring;
            }

            for (int i = 0; i < numberToSpawn; i++)
            {
                AddCreature();
            }
            creatureList.RemoveAll(x => x.Alive == false);

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    terrainMap[x, y].foodPotential += GrassGrowSpeed;

                    if (terrainMap[x, y].foodPotential > 255)
                    {
                        terrainMap[x, y].foodPotential = 255;
                    }
                    terrainMap[x, y].bgColor = Color.FromArgb(255, 0, terrainMap[x, y].foodPotential, 0);
                }
            }
        }


        private Terrain RandomTerrain()
        {
            int foodPotential = globalRandom.Next(255);
            Terrain terrain = new Terrain();
            terrain.Name = "Grass";
            terrain.foodPotential = foodPotential;
            terrain.bgColor = Color.FromArgb(255, 0, foodPotential, 0);

            return terrain;
        }


        public static void AddCreature()
        {
            Creature creature;
            for (int i = 0; i < NumberChickens; i++)
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



        public void DrawFog(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
            g.FillRectangle(brush, new Rectangle(0, 0, 640, 480));
            brush.Dispose();
        }


        public void DrawMap(Graphics g)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    DrawSquare(g, x, y, terrainMap[x, y].bgColor);
                }
            }
        }

        public void DrawCreature(Graphics g)
        {
            foreach (var creature in creatureList)
            {
                FillCircle(g, creature.xPos, creature.yPos, creature.height, creature.bgColor);
            }
        }

        public void DrawSquare(Graphics g, int x, int y, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            //Pen pen = new Pen(Color.Black);
            g.FillRectangle(brush, new Rectangle(x * tileWidth, y * tileWidth, tileWidth, tileWidth));
            //g.DrawRectangle(pen, new Rectangle(x * tileHeight, y * tileHeight, tileHeight, tileHeight));
            brush.Dispose();
            //pen.Dispose();
        }

        public void DrawCircle(Graphics g, float x, float y, float radius, Color color)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawEllipse(pen, x, y, radius, radius);
            pen.Dispose();
        }

        public void FillCircle(Graphics g, float x, float y, float radius, Color color)
        {
            SolidBrush brush = new SolidBrush(color);
            g.FillEllipse(brush, x * tileWidth, y * tileHeight, radius, radius);
            brush.Dispose();
        }

        private void GameScreen_Resize(object sender, EventArgs e)
        {
            this.Text = "H: " + this.Height + "  W: " + this.Width;
        }
    }
}
