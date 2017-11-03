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
		/// Checks for a "menu up" input action (on either keyboard or gamepad).
		/// </summary>
		public bool MenuUp
		{
			get
			{
				return IsNewKeyPress(Keys.Up) ||
					   (Current.GamePadState.DPad.Up == ButtonState.Pressed &&
						Previous.GamePadState.DPad.Up == ButtonState.Released) ||
					   (Current.GamePadState.ThumbSticks.Left.Y > 0 &&
						Previous.GamePadState.ThumbSticks.Left.Y <= 0);
			}
		}


		/// <summary>
		/// Checks for a "menu down" input action (on either keyboard or gamepad).
		/// </summary>
		public bool MenuDown
		{
			get
			{
				return IsNewKeyPress(Keys.Down) ||
					   (Current.GamePadState.DPad.Down == ButtonState.Pressed &&
						Previous.GamePadState.DPad.Down == ButtonState.Released) ||
					   (Current.GamePadState.ThumbSticks.Left.Y < 0 &&
						Previous.GamePadState.ThumbSticks.Left.Y >= 0);
			}
		}


		/// <summary>
		/// Checks for a "menu select" input action (on either keyboard or gamepad).
		/// </summary>
		public bool MenuSelect
		{
			get
			{
				return IsNewKeyPress(Keys.Space) ||
					   IsNewKeyPress(Keys.Enter) ||
					   (Current.GamePadState.Buttons.A == ButtonState.Pressed &&
						Previous.GamePadState.Buttons.A == ButtonState.Released) ||
					   (Current.GamePadState.Buttons.Start == ButtonState.Pressed &&
						Previous.GamePadState.Buttons.Start == ButtonState.Released);
			}
		}


		/// <summary>
		/// Checks for a "menu cancel" input action (on either keyboard or gamepad).
		/// </summary>
		public bool MenuCancel
		{
			get
			{
				return IsNewKeyPress(Keys.Escape) ||
					   (Current.GamePadState.Buttons.B == ButtonState.Pressed &&
						Previous.GamePadState.Buttons.B == ButtonState.Released) ||
					   (Current.GamePadState.Buttons.Back == ButtonState.Pressed &&
						Previous.GamePadState.Buttons.Back == ButtonState.Released);
			}
		}


		/// <summary>
		/// Checks for a "pause the game" input action (on either keyboard or gamepad).
		/// </summary>
		public bool PauseGame
		{
			get
			{
				return IsNewKeyPress(Keys.Escape) ||
					   (Current.GamePadState.Buttons.Back == ButtonState.Pressed &&
						Previous.GamePadState.Buttons.Back == ButtonState.Released) ||
					   (Current.GamePadState.Buttons.Start == ButtonState.Pressed &&
						Previous.GamePadState.Buttons.Start == ButtonState.Released);
			}
		}


		/// <summary>
		/// Checks for a positive "ship color change" input action
		/// </summary>
		public bool ShipColorChangeUp
		{
			get
			{
				return IsNewKeyPress(Keys.Up) ||
				   (Current.GamePadState.Buttons.RightShoulder == ButtonState.Pressed &&
					Previous.GamePadState.Buttons.RightShoulder == ButtonState.Released);
			}
		}


		/// <summary>
		/// Checks for a negative "ship color change" input action.
		/// </summary>
		public bool ShipColorChangeDown
		{
			get
			{
				return IsNewKeyPress(Keys.Down) ||
					(Current.GamePadState.Buttons.LeftShoulder == ButtonState.Pressed &&
					 Previous.GamePadState.Buttons.LeftShoulder == ButtonState.Released);
			}
		}



		/// <summary>
		/// Checks for a positive "ship model change" input action.
		/// </summary>
		public bool ShipModelChangeUp
		{
			get
			{
				return IsNewKeyPress(Keys.Right) ||
					(Current.GamePadState.Triggers.Right >= 1f &&
					 Previous.GamePadState.Triggers.Right < 1f);
			}
		}


		/// <summary>
		/// Checks for a negative "ship model change" input action.
		/// </summary>
		public bool ShipModelChangeDown
		{
			get
			{
				return IsNewKeyPress(Keys.Left) ||
					(Current.GamePadState.Triggers.Left >= 1f &&
					 Previous.GamePadState.Triggers.Left < 1f);
			}
		}


		/// <summary>
		/// Checks for a "mark ready" input action (on either keyboard or gamepad).
		/// </summary>
		public bool MarkReady
		{
			get
			{
				return IsNewKeyPress(Keys.X) ||
					   (Current.GamePadState.Buttons.X == ButtonState.Pressed &&
						Previous.GamePadState.Buttons.X == ButtonState.Released);
			}
		}

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
