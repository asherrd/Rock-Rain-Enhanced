using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RockRainEnhanced.Core
{
    /// <summary>
    /// This is a base class for all game scenes
    /// </summary>
    public abstract class GameScene : Microsoft.Xna.Framework.DrawableGameComponent
    {
        /// <summary>
        /// List of child GameComponents
        /// </summary>
        private readonly List<GameComponent> components;

        public GameScene(Game game)
            : base(game)
        {
            components = new List<GameComponent>();
            Visible = false;
            Enabled = false;
        }

        /// <summary>
        /// Show the scene
        /// </summary>
        public virtual void Show()
        {
            Visible = true;
            Enabled = true;
        }

        /// <summary>
        /// Hide the scene
        /// </summary>
        public virtual void Hide()
        {
            Visible = false;
            Enabled = false;
        }

        /// <summary>
        /// Components of Game Scene
        /// </summary>
        public List<GameComponent> Components {get { return components; }}

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
            //update child GameComponents (if Enabled)
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].Enabled)
                    components[i].Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Allows the game component draw your content in game screen
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // Draw the child GameComponents (if drawable)
            for (int i = 0; i < components.Count; i++)
            {
                GameComponent gc = components[i];
                if ((gc is DrawableGameComponent) &&
                    ((DrawableGameComponent)gc).Visible)
                {
                    ((DrawableGameComponent)gc).Draw(gameTime);
                }
            }
            base.Draw(gameTime);
        }
    }
}
