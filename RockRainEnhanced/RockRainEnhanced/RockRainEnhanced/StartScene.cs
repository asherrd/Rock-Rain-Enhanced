using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using RockRainEnhanced.Core;

namespace RockRainEnhanced
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class StartScene : GameScene
    {
        // Misc
        protected TextMenuComponent menu;
        protected readonly Texture2D elements;
        // Audio stuff
        protected AudioLibrary audio;
        // Spritebatch
        protected SpriteBatch spriteBatch = null;
        // Gui Stuff
        protected Rectangle rockRect = new Rectangle(0, 0, 536, 131);
        protected Vector2 rockPosition;
        protected Rectangle rainRect = new Rectangle(120, 165, 517, 130);
        protected Vector2 rainPosition;
        protected Rectangle enhancedRect = new Rectangle(8, 304, 375, 144);
        protected Vector2 enhancedPosition;
        protected bool showEnhanced;
        protected TimeSpan elapsedTime = TimeSpan.Zero;

        public StartScene(Game game)
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
            if (!menu.Visible)
            {
                if (rainPosition.X >= (Game.Window.ClientBounds.Width - 595) / 2)
                {
                    rainPosition.X -= 15;
                }

                if (rockPosition.X <= (Game.Window.ClientBounds.Width - 715) / 2)
                {
                    rockPosition.X += 15;
                }
                else
                {
                    menu.Visible = true;
                    menu.Enabled = true;

                    MediaPlayer.Play(audio.StartMusic);
#if XBOX360
                    enhancedPosition = new Vector2((rainPosition.X + 
                    rainRect.Width - enhancedRect.Width / 2), rainPosition.Y);
#else
                    enhancedPosition = new Vector2((rainPosition.X +
                        rainRect.Width - enhancedRect.Width / 2) - 80, rainPosition.Y);
#endif
                    showEnhanced = true;
                }
            }
            else
            {
                elapsedTime += gameTime.ElapsedGameTime;

                if (elapsedTime > TimeSpan.FromSeconds(1))
                {
                    elapsedTime -= TimeSpan.FromSeconds(1);
                    showEnhanced = !showEnhanced;
                }
            }
            base.Update(gameTime);
        }
    }
}
