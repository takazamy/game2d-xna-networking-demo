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


namespace WindowsGame1
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Global : Microsoft.Xna.Framework.GameComponent
    {
        #region Static Properties

        /// <summary>
        /// Screen State Of Game
        /// </summary>
        public enum ScreenState
        {
            GS_SPLASH_SCREEN = 0,
            GS_MENU = 1,
            GS_LEVEL = 2,
            GS_HELP = 3,
            GS_CREDIT = 4,
            GS_MAIN_GAME = 5,
            GS_ENDGAME = 6,
            GS_EXIT = 7
        }

        public enum ButtonState
        {
            BS_NORMAL = 0,
            BS_HOLD = 1,
        }
        #endregion




        public Global(Game game)
            : base(game)
        {
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

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
