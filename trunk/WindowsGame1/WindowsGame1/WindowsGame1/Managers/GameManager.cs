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
using WindowsGame1.Screens;


namespace WindowsGame1.Managers
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameManager : Microsoft.Xna.Framework.GameComponent
    {

        ScreenManager scrManager;
        SpriteBatch spriteBatch;
        public GameManager(Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        /// 
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            scrManager = new ScreenManager(this.Game, spriteBatch);
            this.Game.Components.Add(this.scrManager);
            scrManager.Append(new SplashScreen(scrManager, this.Game, this.spriteBatch));
            scrManager.CurScreen = scrManager.ScreenList[0];
            scrManager.PlayScreen(0);
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            scrManager.Update(gameTime);
            base.Update(gameTime);
        }

    }
}
