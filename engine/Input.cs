using Microsoft.Xna.Framework.Input;

namespace Engine;

public class Input {
    private static KeyboardState prevKeyboardState;
    private static KeyboardState keyboardState;

    public static void Update() {
        prevKeyboardState = keyboardState;
        keyboardState = Keyboard.GetState();
    }

    public static bool IsPressed(Keys key) {
        return keyboardState.IsKeyDown(key);
    }

    public static bool IsJustPressed(Keys key) {
        return IsPressed(key) && !prevKeyboardState.IsKeyDown(key);
    }

    public static bool IsReleased(Keys key) {
        return !IsPressed(key);
    }

    public static bool IsJustReleased(Keys key) {
        return !IsJustPressed(key);
    }
}