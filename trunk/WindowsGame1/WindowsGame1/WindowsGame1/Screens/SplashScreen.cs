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
    public class SplashScreen : Screen
    {

       
        public SplashScreen(ScreenManager scrManager, Game game, SpriteBatch spriteBatch)
            : base(scrManager, game, spriteBatch)
        {
            this.state = Global.ScreenState.GS_SPLASH_SCREEN;
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
            backGround = this.Game.Content.Load<Texture2D>("SplashScreen");
            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            MouseState mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed)   
            {
                scrManager.state = Global.ScreenState.GS_MENU;
                Boolean flag = false;
                foreach (Screen scr in scrManager.ScreenList)
                {
                    if (scr.state == Global.ScreenState.GS_MENU)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    MenuScreen menu = new MenuScreen(scrManager, this.Game, this.spriteBatch);
                    scrManager.Append(menu);
                    scrManager.PlayScreen(Global.ScreenState.GS_MENU);
                    //_scrManager.UpdateIndex();
                }

            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.isDraw)
            {
                this.spriteBatch.Begin();
                this.spriteBatch.Draw(backGround, Vector2.Zero, Color.White);
                this.spriteBatch.End(); 
            }
            
            base.Draw(gameTime);
        }

    }
}
