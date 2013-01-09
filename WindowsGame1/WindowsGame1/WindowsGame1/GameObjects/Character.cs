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
        public Vector2 shootDirection ;
        double headRotation = 0;
        public Vector2 Center;
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

            this.shootDirection = new Vector2(0, -1);
            
           // this.CalcDegreeRotation();
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
            moveDirection = new Vector2(0, 0);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            body = this.Game.Content.Load<Texture2D>("body");
            head = this.Game.Content.Load<Texture2D>("head");
            Center = new Vector2(this.body.Width / 2, this.body.Height / 2);
            //Vector2 Dest = new Vector2(Mouse.GetState().X - this.location.X, Mouse.GetState().Y - this.location.Y);
            //headRotation = Global.GetSignedAngleBetween2DVectors(shootDirection, Dest, new Vector2(Dest.Y, -Dest.X));
            //spriteBatch.Begin();
            //this.spriteBatch.Draw(this.head, location, null, Color.White, (float)headRotation,
            //    new Vector2(this.head.Bounds.Center.X, this.head.Bounds.Center.Y), 1, SpriteEffects.None, 1);

            //spriteBatch.End();

            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            MouseState state = Mouse.GetState();

            CalcDegreeRotation();
            
            
            KeyboardState keystate = Keyboard.GetState();
           
            moveDirection = shootDirection;
            moveDirection.Normalize();
            if (keystate.IsKeyDown(Keys.S))
            {
                location-= moveDirection;
            }
            if (keystate.IsKeyDown(Keys.W))
            {
                location += moveDirection; 
            }
            if (keystate.IsKeyDown(Keys.A))
            {
                
            }
            if (keystate.IsKeyDown(Keys.D))
            {

            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.body, new Rectangle((int)location.X,(int)location.Y,50,50),null ,Color.White,(float)headRotation,  new Vector2(this.Center.X, this.Center.Y),SpriteEffects.None,1);
            //this.spriteBatch.Draw(this.head, new Vector2(location.X - this.head.Bounds.Center.X, location.Y - this.head.Bounds.Center.Y), Color.White);
            this.spriteBatch.Draw(this.head,new Rectangle((int)location.X,(int)location.Y,25,25), null, Color.White, (float)headRotation,
                new Vector2( this.head.Bounds.Center.X, this.head.Bounds.Center.Y), SpriteEffects.None, 1);

            this.spriteBatch.End();
            base.Draw(gameTime);
        }

        protected void CalcDegreeRotation()
        {
            MouseState state = Mouse.GetState();
            Vector2 lastShootDirection = this.shootDirection;
            this.shootDirection = new Vector2(state.X - this.location.X, state.Y - this.location.Y);

            if (lastShootDirection != shootDirection)
            {

                this.headRotation += Global.GetSignedAngleBetween2DVectors(lastShootDirection, shootDirection, new Vector2(shootDirection.Y, -shootDirection.X));
            }
            
        }
    }
}
