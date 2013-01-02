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
using WindowsGame1.Managers;


namespace WindowsGame1.Screens
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Screen : Microsoft.Xna.Framework.DrawableGameComponent
    {

        public Global.ScreenState state;
        public int index;
        public SpriteBatch spriteBatch;
        public ScreenManager scrManager;
        protected Texture2D backGround;
        public Boolean isDraw = false;
        public Screen(ScreenManager scrManager, Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.scrManager = scrManager;
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
