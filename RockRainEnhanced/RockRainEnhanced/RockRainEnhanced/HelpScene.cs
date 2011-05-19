using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RockRainEnhanced.Core;

namespace RockRainEnhanced
{
    /// <summary>
    /// This is a game component that represents the hlp scene.
    /// </summary>
    public class HelpScene : GameScene
    {
        public HelpScene(Game game, Texture2D textureBack, Texture2D textureFront)
            : base(game)
        {
            Components.Add(new ImageComponent(game, textureBack, ImageComponent.DrawMode.Stretch));
            Components.Add(new ImageComponent(game, textureFront, ImageComponent.DrawMode.Center));
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
