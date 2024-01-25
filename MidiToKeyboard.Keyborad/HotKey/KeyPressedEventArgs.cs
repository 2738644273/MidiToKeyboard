using MidiToKeyBoard.Core.Constant;
using MidiToKeyboard.Keyborad.PressKey;
using Vanara.PInvoke;

namespace MidiToKeyboard.Keyborad.HotkeyCapture;

public class KeyPressedEventArgs : EventArgs
{
    public User32.HotKeyModifiers Modifier { get; }
    public EnumKey Key { get; }

    internal KeyPressedEventArgs(User32.HotKeyModifiers modifier, EnumKey key)
    {
        Modifier = modifier;
        Key = key;
    }
}
