using MidiToKeyBoard.Core.Constant;
using MidiToKeyboard.Keyborad.PressKey;
using Vanara.PInvoke;

namespace MidiToKeyboard.Keyborad.HotkeyCapture;

public sealed class Hotkey
{
    public bool Alt { get; set; }
    public bool Control { get; set; }
    public bool Shift { get; set; }
    public bool Windows { get; set; }

    private EnumKey key;

    public EnumKey Key
    {
        get => key;
        set
        {
            if (value != EnumKey.CONTROL && value != EnumKey.MENU && value != EnumKey.SHIFT)
            {
                key = value;
            }
            else
            {
                key = EnumKey.None;
            }
        }
    }

    public User32.HotKeyModifiers ModifierKey =>
        (Windows ? User32.HotKeyModifiers.MOD_WIN : User32.HotKeyModifiers.MOD_NONE) |
        (Control ? User32.HotKeyModifiers.MOD_CONTROL : User32.HotKeyModifiers.MOD_NONE) |
        (Shift ? User32.HotKeyModifiers.MOD_SHIFT : User32.HotKeyModifiers.MOD_NONE) |
        (Alt ? User32.HotKeyModifiers.MOD_ALT : User32.HotKeyModifiers.MOD_NONE);

    public Hotkey()
    {
        Reset();
    }

    public Hotkey(string hotEnumKeytr)
    {
        try
        {
            string[] EnumKeytrs = hotEnumKeytr.Replace(" ", string.Empty).Split('+');

            foreach (string EnumKeytr in EnumKeytrs)
            {
                if (EnumKeytr.Equals("Win", StringComparison.OrdinalIgnoreCase))
                {
                    Windows = true;
                }
                else if (EnumKeytr.Equals("Ctrl", StringComparison.OrdinalIgnoreCase))
                {
                    Control = true;
                }
                else if (EnumKeytr.Equals("Shift", StringComparison.OrdinalIgnoreCase))
                {
                    Shift = true;
                }
                else if (EnumKeytr.Equals("Alt", StringComparison.OrdinalIgnoreCase))
                {
                    Alt = true;
                }
                else
                {
                    Key = (EnumKey)Enum.Parse(typeof(EnumKey), EnumKeytr);
                }
            }
        }
        catch
        {
            throw new ArgumentException("Invalid Hotkey");
        }
    }

    public override string ToString()
    {
        string str = string.Empty;
        if (Key != EnumKey.None)
        {
            str = string.Format("{0}{1}{2}{3}{4}",
                Windows ? "Win + " : string.Empty,
                Control ? "Ctrl + " : string.Empty,
                Shift ? "Shift + " : string.Empty,
                Alt ? "Alt + " : string.Empty,
                Key);
        }
        return str;
    }

    public void Reset()
    {
        Alt = false;
        Control = false;
        Shift = false;
        Windows = false;
        Key = EnumKey.None;
    }
}
