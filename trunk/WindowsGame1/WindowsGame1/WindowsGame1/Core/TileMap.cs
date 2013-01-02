using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using System.Drawing;

namespace WindowsGame1.Core
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class TileMap : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Layer
        private class Layer
        {
            public string _name;
            public int _height, _width;
            public bool _isVisible;
            public int[,] _data;
            public Layer(int height, int width, string name, bool isVisible, int[,] data)
            {
                _height = height;
                _width = width;
                _name = name;
                _isVisible = isVisible;
                _data = data;
            }
        }
        #endregion

        #region Properties

        StreamReader _reader;
        JObject _jsonObject = new JObject();
        private int _cellWidth;
        private int _cellHeight;
        private int _rows;
        private int _columns;
        private int[,] _collisionMap;
        public int[,] CollisionMap
        {
            get { return _collisionMap; }
        }

        public int TotalFrame
        {
            get { return (_rows  * _columns); }
        }
        private List<Layer> _layers = new List<Layer>();

        SpriteBatch spriteBatch;
        Texture2D TileSet;
        Rectangle[] recArr;

        #endregion

        public TileMap(Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Constructor to Create a TileMap
        /// </summary>
        /// <param name="game">Game Object</param>
        /// <param name="jsonFilePath">Map JSon File Path</param>
        /// <param name="TileSet">Texture TileSet</param>
        /// <param name="spriteBatch">Graphics of Game</param>
        public TileMap(Game game, string jsonFilePath, Texture2D TileSet, SpriteBatch spriteBatch)
            :base(game)
        {
            #region ReadJsonFile
            _reader = File.OpenText(jsonFilePath);
            _jsonObject = JObject.Parse(_reader.ReadToEnd());
            Layer templayer;
            _rows = (int)_jsonObject["height"];
            _columns = (int)_jsonObject["width"];
            _cellWidth = (int)_jsonObject["tilewidth"];
            _cellHeight = (int)_jsonObject["tileheight"];
            _collisionMap = new int[_rows, _columns];
            foreach (var array in _jsonObject["layers"])
            {
                int height = (int)array["height"];
                int width = (int)array["width"];
                string name = (string)array["name"];
                bool isVisible = (bool)array["visible"];
                int[,]data = new int[height,width];
                int i = 0;
                foreach (var value in array["data"])
                {

                    if (name != "collision")
                    {
                        data[i / width, i % width] = (int)value-1;
                    }
                    else
                    {
                        data[i / width, i % width] = (int)value;
                    }
                    i++;
                }
                if (name == "collision")
                {
                    _collisionMap = data;
                }
                templayer = new Layer(height, width, name, isVisible, data);
                _layers.Add(templayer);
                //Console.WriteLine(array["height"]);
            }
            
            #endregion

            this.spriteBatch = spriteBatch;
            this.TileSet = TileSet;
            int column;
            int row;
            
            recArr = new Rectangle[TileSet.Width/32* TileSet.Height/32];
            for (int i = 0; i < recArr.Length; i++)
            {
                column = i % (TileSet.Width / 32);
                row = i / (TileSet.Width / 32);
                recArr[i] = new Rectangle(column * _cellWidth, row * _cellHeight, _cellWidth, _cellHeight);
            }
            //_graphics = graphics;
            //_textute = new DxImage(TileSet, Global.BitmapType.SOLID, 0, new PointF(0, 0), _cellWidth, _cellHeight, _graphics.DDDevice);
            //CrearTileMapSurface();
           
        }
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (Layer l in _layers)
            {
                if (l._isVisible == true)
                {
                    for(int i = 0; i < l._data.GetLength(0); i++)
                    {
                        for (int j = 0; j < l._data.GetLength(1); j++)
                        {
                            //_textute.DrawImage(j * _cellWidth, i * _cellHeight, l._data[i, j], destSurface);
                            spriteBatch.Draw(this.TileSet, new Vector2(j * _cellWidth, i * _cellHeight), recArr[l._data[i, j]], Color.White);
                        }
                    }
                }
            }
            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
