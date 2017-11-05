using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MG.Demo
{
	/// <summary>
	/// Helper for reading input from keyboard and gamepad. This public class tracks
	/// the current and previous state of both input devices, and implements query
	/// properties for high level input actions such as "move up through the menu"
	/// or "pause the game".
	/// </summary>
	public class InputState
	{
		public InputStateProperties Current { get; set; } = new InputStateProperties();
		public InputStateProperties Previous { get; set; } = new InputStateProperties();

		/// <summary>
		/// Update the input state
		/// </summary>
		public void Update()
		{
			var newState = new InputStateProperties
			{
				MouseState = Mouse.GetState(),
				KeyboardState = Keyboard.GetState(),
				GamePadState = GamePad.GetState(PlayerIndex.One)
			};
			Previous = Current;
			Current = newState;
		}


		/// <summary>
		/// Helper for checking if a key was newly pressed during this update.
		/// </summary>
		public bool IsNewKeyPress(Keys key)
		{
			return (Current.KeyboardState.IsKeyDown(key) &&
					Previous.KeyboardState.IsKeyUp(key));
		}


		public class InputStateProperties
		{
			public KeyboardState KeyboardState { get; set; }
			public GamePadState GamePadState { get; set; }
			public MouseState MouseState { get; set; }
		}
	}
}
