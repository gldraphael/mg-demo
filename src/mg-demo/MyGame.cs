using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace MG.Demo
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class MyGame : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public MyGame()
		{
			graphics = new GraphicsDeviceManager (this);
		}

		protected override void Initialize ()
		{
			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);
		}

		protected override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}
