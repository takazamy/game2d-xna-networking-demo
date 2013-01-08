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


namespace WindowsGame1.Core
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Button : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D buttonImage;
        String name;
        public Global.ButtonState state;
        Vector2 location = Vector2.Zero;
        public Button(Game game, SpriteBatch spriteBatch, String name, Vector2 location)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.name = name;
            this.location = location;
            // TODO: Construct any child components here
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
            buttonImage = this.Game.Content.Load<Texture2D>(name);
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
            spriteBatch.Draw(this.buttonImage, location, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
