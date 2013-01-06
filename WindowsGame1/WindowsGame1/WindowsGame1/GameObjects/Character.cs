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


namespace WindowsGame1.GameObjects
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Character : Microsoft.Xna.Framework.DrawableGameComponent
    {

        #region Properties
        SpriteBatch spriteBatch;
        public int hp;
        public int damage;
        public Vector2 location;
        public Vector2 moveDirection;
        public Vector2 shootDirection;
        public Vector2 lookDirection;
        protected Texture2D body;
        protected Texture2D head;
        public Boolean isMe;
        #endregion

        #region Contructors
        public Character(Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here
        }

        public Character(Game game, SpriteBatch spriteBatch, Vector2 Location,int HP, int Damage)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.location = Location;
            this.hp = HP;
            this.damage = Damage;
            // TODO: Construct any child components here
        }
        #endregion
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
            base.Draw(gameTime);
        }
    }
}