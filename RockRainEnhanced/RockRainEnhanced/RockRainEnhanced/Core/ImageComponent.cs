using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace RockRainEnhanced.Core
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ImageComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public enum DrawMode
        {
            Center = 1,
            Stretch,
        };

        protected readonly Texture2D texture;
        protected readonly DrawMode drawMode;
        protected SpriteBatch spriteBatch = null;
        protected Rectangle imageRect;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="game">The game object</param>
        /// <param name="texture">Texture to draw</param>
        /// <param name="drawMode">Draw mode</param>
        public ImageComponent(Game game, Texture2D texture, DrawMode drawMode)
            : base(game)
        {
            this.texture = texture;
            this.drawMode = drawMode;
            // get the current sprite batch
            spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));

            // create a rectangle with the size and position of the image
            switch (drawMode)
            {
                case DrawMode.Center:
                    imageRect = new Rectangle((Game.Window.ClientBounds.Width -
                                texture.Width) / 2, (Game.Window.ClientBounds.Height -
                                texture.Height) / 2, texture.Width, texture.Height);
                    break;
                case DrawMode.Stretch:
                    imageRect = new Rectangle(0, 0, Game.Window.ClientBounds.Width,
                                Game.Window.ClientBounds.Height);
                    break;
            }
        }

        /// <summary>
        /// Allows the game component to draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, imageRect, Color.White);
            base.Draw(gameTime);
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
