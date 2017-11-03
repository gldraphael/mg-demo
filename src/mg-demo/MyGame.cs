using System;
using MG.Demo.Managers;
using MG.Demo.Screens;
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
		ScreenManager screenManager;

		public MyGame()
		{
			graphics = new GraphicsDeviceManager (this);
			screenManager = new ScreenManager(this);
		}

		protected override void Initialize ()
		{
			Content.RootDirectory = "Content";
			Components.Add(screenManager);
			screenManager.AddScreen(new BackgroundScreen());

			base.Initialize();
		}

		protected override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
		}
	}
}
