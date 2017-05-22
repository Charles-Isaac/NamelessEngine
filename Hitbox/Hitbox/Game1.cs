using System;
using Hitbox.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hitbox
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D[] m_GenericTextures;
        private Texture2D[] m_ExplosionTextures;
        GenericEntityWithHitbox EntityA;
        GenericEntityWithHitbox EntityB;
        private Engine.Hitbox m_GenericHitbox;

        private LineSegment m_DemonstrationLineHitbox;
        private Texture2D LineTexture;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            m_GenericTextures = new Texture2D[8];

            m_ExplosionTextures = new Texture2D[81];




            m_DemonstrationLineHitbox = new LineSegment(new Vector2(), new Vector2());
            


            m_GenericHitbox =
                new Engine.Hitbox(new LineSegment[]
                {
                    new LineSegment(new Vector2(32, -3), new Vector2(32, 64)),
                    new LineSegment(new Vector2(10, 32), new Vector2(54, 32)),
                    new LineSegment(new Vector2(8, 0), new Vector2(56, 0))
                });
            
            EntityA = new GenericEntityWithHitbox(m_GenericTextures,new Vector2(300, 200), new Vector2(100,100), new Vector2(1000, 0), m_GenericHitbox,0,2000,false);
            EntityB = new GenericEntityWithHitbox(m_GenericTextures, new Vector2(100, 300), new Vector2(32,32), new Vector2(0, 0), m_GenericHitbox,0,3000,true);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LineTexture = new Texture2D(GraphicsDevice, 1, 1, false,
    SurfaceFormat.Color);

            Int32[] pixel = { 0xFFFFFF }; // White. 0xFF is Red, 0xFF0000 is Blue
            LineTexture.SetData<Int32>(pixel, 0, LineTexture.Width * LineTexture.Height);



            m_GenericTextures[0] = Content.Load<Texture2D>("Texture/Soldier0");
            m_GenericTextures[1] = Content.Load<Texture2D>("Texture/Soldier1");
            m_GenericTextures[2] = Content.Load<Texture2D>("Texture/Soldier2");
            m_GenericTextures[3] = Content.Load<Texture2D>("Texture/Soldier3");
            m_GenericTextures[4] = Content.Load<Texture2D>("Texture/Soldier4");
            m_GenericTextures[5] = Content.Load<Texture2D>("Texture/Soldier5");
            m_GenericTextures[6] = Content.Load<Texture2D>("Texture/Soldier6");
            m_GenericTextures[7] = Content.Load<Texture2D>("Texture/Soldier7");
            

            Texture2D expl = Content.Load<Texture2D>("Texture/Explosion");


            
            for (int i = 0; i < 81; i++)
            {
                Texture2D originalTexture = Content.Load<Texture2D>("Texture/Explosion");
                Rectangle sourceRectangle = new Rectangle(i%9*100, i/9*100, 100, 100);
                
                m_ExplosionTextures[i] = new Texture2D(GraphicsDevice, sourceRectangle.Width, sourceRectangle.Height);
                Color[] data = new Color[sourceRectangle.Width * sourceRectangle.Height];
                originalTexture.GetData(0, sourceRectangle, data, 0, data.Length);
                m_ExplosionTextures[i].SetData(data);
            }
            


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                m_DemonstrationLineHitbox.Start += new Vector2(0, -0.3f * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                m_DemonstrationLineHitbox.Start += new Vector2(-0.2f * gameTime.ElapsedGameTime.Milliseconds, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                m_DemonstrationLineHitbox.Start += new Vector2(0, 0.3f * gameTime.ElapsedGameTime.Milliseconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                m_DemonstrationLineHitbox.Start += new Vector2(0.2f * gameTime.ElapsedGameTime.Milliseconds, 0);
            }


            //EntityA.Velocity = new Vector2((float)Math.Cos(gameTime.TotalGameTime.TotalMilliseconds / 400.0) * 481, (float)Math.Sin(gameTime.TotalGameTime.TotalMilliseconds / 500.0) * 200);
            EntityB.Velocity = new Vector2((float)Math.Cos(gameTime.TotalGameTime.TotalMilliseconds / 500.0) * 100, (float)Math.Sin(gameTime.TotalGameTime.TotalMilliseconds / 500.0) * 100);
            EntityA.Velocity = new Vector2(0,0);
            EntityA.Position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            m_DemonstrationLineHitbox = new LineSegment(m_DemonstrationLineHitbox.Start,
                new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y));
            // TODO: Add your update logic here
            EntityA.Update(gameTime);
            EntityB.Update(gameTime);
            if (gameTime.TotalGameTime.TotalMilliseconds > 2000 && gameTime.TotalGameTime.TotalMilliseconds < 2100)
            {
                EntityA.EntityTextures = m_ExplosionTextures;
                EntityA.AnimationLoop = false;
                EntityA.AnimationTimerStart = gameTime.TotalGameTime.TotalMilliseconds;
                EntityA.AnimationTimerDuration = 500;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here

            spriteBatch.Draw(EntityA.CurrentTexture(), EntityA.Position,
                new Rectangle(0, 0, (int) EntityA.Size.X, (int) EntityA.Size.Y),
                EntityA.CheckIfHit(m_DemonstrationLineHitbox) ? Color.Red : Color.White, 0, new Vector2(), 2,
                SpriteEffects.None, 0f);
            spriteBatch.Draw(EntityB.CurrentTexture(), EntityB.Position,
                new Rectangle(0, 0, (int) EntityB.Size.X, (int) EntityB.Size.Y),
                EntityB.CheckIfHit(m_DemonstrationLineHitbox) ? Color.Red : (EntityB.CheckIfHit(EntityA) ? Color.Blue : Color.White), 0, new Vector2(), 2,
                SpriteEffects.None, 0f);

            DrawLine(spriteBatch,m_DemonstrationLineHitbox,Color.Green,3);
            base.Draw(gameTime);
            spriteBatch.End();
        }
        public void DrawLine( SpriteBatch spriteBatch, LineSegment line, Color color, int width = 1)
        {
            Rectangle r = new Rectangle((int)line.Start.X, (int)line.Start.Y, (int)(line.End - line.Start).Length() + width, width);
            Vector2 v = Vector2.Normalize(line.Start - line.End);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (line.Start.Y > line.End.Y) angle = MathHelper.TwoPi - angle;
            
            spriteBatch.Draw(LineTexture, r, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
