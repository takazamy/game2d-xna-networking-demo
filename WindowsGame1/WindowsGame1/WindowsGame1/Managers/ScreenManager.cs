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
    public class ScreenManager : Microsoft.Xna.Framework.GameComponent
    {

        #region Properties

        public List<Screen> ScreenList;
        public Screen this[int index]
        {
            get
            {
                return ScreenList[index];
            }
            set
            {
                ScreenList[index] = value;
            }
        }
        public Screen CurScreen;

        public Global.ScreenState state = Global.ScreenState.GS_SPLASH_SCREEN;

        private int curIndex = -1;
        #endregion

        public ScreenManager(Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            ScreenList = new List<Screen>();
           
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
            CurScreen.Update(gameTime);
            base.Update(gameTime);
        }

        public void Append(Screen screen)
        {
            screen.index = this.ScreenList.Count - 1;
            ScreenList.Add(screen);
            this.Game.Components.Add(screen);
        }

        public void PlayScreen(int index)
        {
            this.CurScreen.isDraw = false;
            this.CurScreen = ScreenList[index];
            this.curIndex = index;
            this.CurScreen.isDraw = true;
        }
        public void PlayScreen(Global.ScreenState state)
        {
            try
            {
                foreach (Screen scr in this.ScreenList)
                {
                    if (scr.state == state)
                    {
                        CurScreen.isDraw = false;
                        CurScreen = scr;
                        curIndex = scr.index;
                        this.CurScreen.isDraw = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void NextScreen()
        {
            CurScreen.isDraw = false;
            this.CurScreen = ScreenList[++curIndex];
            CurScreen.isDraw = true;
        }

        public void PrevScreen()
        {
            CurScreen.isDraw = false;
            CurScreen = ScreenList[--curIndex];
            CurScreen.isDraw = true; ;
        }

        public void UpdateIndex()
        {
            for (int i = 0; i < this.ScreenList.Count; i++)
            {
                ScreenList[i].index = i;
            }
        }

    }
}
