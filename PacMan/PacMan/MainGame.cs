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

namespace PacMan
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Entity pacMan;
        Entity coin;
        Entity cherry;
        Entity enemy;
        public static Dictionary<String, Texture2D> textures;
        public Collision collision;
        public static Score score;
        bool lost;
        static MainGame instance;
        public static MainGame Instance {
            get { return instance; }
        }
        public Entity PacMan {
            get { return pacMan; }
        }

        public MainGame()
        {
            instance = this;
            lost = false;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            textures = new Dictionary<string,Texture2D>();
            collision = new Collision();
        }

        public void Lost()
        {
            this.lost = true;
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
            
            // Load all images
            textures.Add("pacman", this.Content.Load<Texture2D>("pacman"));
            textures.Add("coin", this.Content.Load<Texture2D>("coin"));
            textures.Add("cherry", this.Content.Load<Texture2D>("cherry"));
            textures.Add("enemy", this.Content.Load<Texture2D>("enemy"));
            
            // Create all objects
            pacMan = new PacMan("pacman", 200, 200);

            // Example content
            cherry = new Cherry("cherry", 400, 300);
            coin = new Coin("coin", 300, 400);

            enemy = new Enemy("enemy", 200, 400);
            
            // Add entities to collision detection
            this.collision.link(ref pacMan);
            this.collision.link(ref cherry);
            this.collision.link(ref coin);
            this.collision.link(ref enemy);

            // Example wall collision box
            this.collision.addWall(new Rectangle(0, 0, 800, 50));

            score = new Score(Content.Load<SpriteFont>("Score"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            pacMan.update(Window);
            cherry.update(Window);
            coin.update(Window);
            enemy.update(Window);
            
            collision.checkCollisions();

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

            if (lost)
            {
                //Skriv Lost Text här!
            }
            else
            {

                pacMan.drawEntity(spriteBatch);
                // TODO: Add your drawing code here

                cherry.drawEntity(spriteBatch);
                // TODO: Add your drawing code here

                coin.drawEntity(spriteBatch);

                enemy.drawEntity(spriteBatch);

                // TODO: Add your drawing code here
                score.drawEntity(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
