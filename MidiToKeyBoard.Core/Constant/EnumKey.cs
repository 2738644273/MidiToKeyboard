using System.ComponentModel;
using System.Drawing.Design;

namespace MidiToKeyBoard.Core.Constant
{

    [Flags]
    public enum EnumKey
    {
        None = 0,
        //
        // 摘要:
        //     Left mouse button
        LBUTTON = 1,
        //
        // 摘要:
        //     Right mouse button
        RBUTTON = 2,
        //
        // 摘要:
        //     Control-break processing
        CANCEL = 3,
        //
        // 摘要:
        //     Middle mouse button (three-button mouse) - NOT contiguous with LBUTTON and RBUTTON
        MBUTTON = 4,
        //
        // 摘要:
        //     Windows 2000/XP: X1 mouse button - NOT contiguous with LBUTTON and RBUTTON
        XBUTTON1 = 5,
        //
        // 摘要:
        //     Windows 2000/XP: X2 mouse button - NOT contiguous with LBUTTON and RBUTTON
        XBUTTON2 = 6,
        //
        // 摘要:
        //     BACKSPACE key
        BACK = 8,
        //
        // 摘要:
        //     TAB key
        TAB = 9,
        //
        // 摘要:
        //     CLEAR key
        CLEAR = 12,
        //
        // 摘要:
        //     ENTER key
        RETURN = 13,
        //
        // 摘要:
        //     SHIFT key
        SHIFT = 16,
        //
        // 摘要:
        //     CTRL key
        CONTROL = 17,
        //
        // 摘要:
        //     ALT key
        MENU = 18,
        //
        // 摘要:
        //     PAUSE key
        PAUSE = 19,
        //
        // 摘要:
        //     CAPS LOCK key
        CAPITAL = 20,
        //
        // 摘要:
        //     Input Method Editor (IME) Kana mode
        KANA = 21,
        //
        // 摘要:
        //     IME Hanguel mode (maintained for compatibility; use HANGUL)
        HANGEUL = 21,
        //
        // 摘要:
        //     IME Hangul mode
        HANGUL = 21,
        //
        // 摘要:
        //     IME Junja mode
        JUNJA = 23,
        //
        // 摘要:
        //     IME final mode
        FINAL = 24,
        //
        // 摘要:
        //     IME Hanja mode
        HANJA = 25,
        //
        // 摘要:
        //     IME Kanji mode
        KANJI = 25,
        //
        // 摘要:
        //     ESC key
        ESCAPE = 27,
        //
        // 摘要:
        //     IME convert
        CONVERT = 28,
        //
        // 摘要:
        //     IME nonconvert
        NONCONVERT = 29,
        //
        // 摘要:
        //     IME accept
        ACCEPT = 30,
        //
        // 摘要:
        //     IME mode change request
        MODECHANGE = 31,
        //
        // 摘要:
        //     SPACEBAR
        SPACE = 32,
        //
        // 摘要:
        //     PAGE UP key
        PRIOR = 33,
        //
        // 摘要:
        //     PAGE DOWN key
        NEXT = 34,
        //
        // 摘要:
        //     END key
        END = 35,
        //
        // 摘要:
        //     HOME key
        HOME = 36,
        //
        // 摘要:
        //     LEFT ARROW key
        LEFT = 37,
        //
        // 摘要:
        //     UP ARROW key
        UP = 38,
        //
        // 摘要:
        //     RIGHT ARROW key
        RIGHT = 39,
        //
        // 摘要:
        //     DOWN ARROW key
        DOWN = 40,
        //
        // 摘要:
        //     SELECT key
        SELECT = 41,
        //
        // 摘要:
        //     PRINT key
        PRINT = 42,
        //
        // 摘要:
        //     EXECUTE key
        EXECUTE = 43,
        //
        // 摘要:
        //     PRINT SCREEN key
        SNAPSHOT = 44,
        //
        // 摘要:
        //     INS key
        INSERT = 45,
        //
        // 摘要:
        //     DEL key
        DELETE = 46,
        //
        // 摘要:
        //     HELP key
        HELP = 47,
        //
        // 摘要:
        //     0 key
        VK_0 = 48,
        //
        // 摘要:
        //     1 key
        VK_1 = 49,
        //
        // 摘要:
        //     2 key
        VK_2 = 50,
        //
        // 摘要:
        //     3 key
        VK_3 = 51,
        //
        // 摘要:
        //     4 key
        VK_4 = 52,
        //
        // 摘要:
        //     5 key
        VK_5 = 53,
        //
        // 摘要:
        //     6 key
        VK_6 = 54,
        //
        // 摘要:
        //     7 key
        VK_7 = 55,
        //
        // 摘要:
        //     8 key
        VK_8 = 56,
        //
        // 摘要:
        //     9 key
        VK_9 = 57,
        //
        // 摘要:
        //     A key
        VK_A = 65,
        //
        // 摘要:
        //     B key
        VK_B = 66,
        //
        // 摘要:
        //     C key
        VK_C = 67,
        //
        // 摘要:
        //     D key
        VK_D = 68,
        //
        // 摘要:
        //     E key
        VK_E = 69,
        //
        // 摘要:
        //     F key
        VK_F = 70,
        //
        // 摘要:
        //     G key
        VK_G = 71,
        //
        // 摘要:
        //     H key
        VK_H = 72,
        //
        // 摘要:
        //     I key
        VK_I = 73,
        //
        // 摘要:
        //     J key
        VK_J = 74,
        //
        // 摘要:
        //     K key
        VK_K = 75,
        //
        // 摘要:
        //     L key
        VK_L = 76,
        //
        // 摘要:
        //     M key
        VK_M = 77,
        //
        // 摘要:
        //     N key
        VK_N = 78,
        //
        // 摘要:
        //     O key
        VK_O = 79,
        //
        // 摘要:
        //     P key
        VK_P = 80,
        //
        // 摘要:
        //     Q key
        VK_Q = 81,
        //
        // 摘要:
        //     R key
        VK_R = 82,
        //
        // 摘要:
        //     S key
        VK_S = 83,
        //
        // 摘要:
        //     T key
        VK_T = 84,
        //
        // 摘要:
        //     U key
        VK_U = 85,
        //
        // 摘要:
        //     V key
        VK_V = 86,
        //
        // 摘要:
        //     W key
        VK_W = 87,
        //
        // 摘要:
        //     X key
        VK_X = 88,
        //
        // 摘要:
        //     Y key
        VK_Y = 89,
        //
        // 摘要:
        //     Z key
        VK_Z = 90,
        //
        // 摘要:
        //     Left Windows key (Microsoft Natural keyboard)
        LWIN = 91,
        //
        // 摘要:
        //     Right Windows key (Natural keyboard)
        RWIN = 92,
        //
        // 摘要:
        //     Applications key (Natural keyboard)
        APPS = 93,
        //
        // 摘要:
        //     Computer Sleep key
        SLEEP = 95,
        //
        // 摘要:
        //     Numeric keypad 0 key
        NUMPAD0 = 96,
        //
        // 摘要:
        //     Numeric keypad 1 key
        NUMPAD1 = 97,
        //
        // 摘要:
        //     Numeric keypad 2 key
        NUMPAD2 = 98,
        //
        // 摘要:
        //     Numeric keypad 3 key
        NUMPAD3 = 99,
        //
        // 摘要:
        //     Numeric keypad 4 key
        NUMPAD4 = 100,
        //
        // 摘要:
        //     Numeric keypad 5 key
        NUMPAD5 = 101,
        //
        // 摘要:
        //     Numeric keypad 6 key
        NUMPAD6 = 102,
        //
        // 摘要:
        //     Numeric keypad 7 key
        NUMPAD7 = 103,
        //
        // 摘要:
        //     Numeric keypad 8 key
        NUMPAD8 = 104,
        //
        // 摘要:
        //     Numeric keypad 9 key
        NUMPAD9 = 105,
        //
        // 摘要:
        //     Multiply key
        MULTIPLY = 106,
        //
        // 摘要:
        //     Add key
        ADD = 107,
        //
        // 摘要:
        //     Separator key
        SEPARATOR = 108,
        //
        // 摘要:
        //     Subtract key
        SUBTRACT = 109,
        //
        // 摘要:
        //     Decimal key
        DECIMAL = 110,
        //
        // 摘要:
        //     Divide key
        DIVIDE = 111,
        //
        // 摘要:
        //     F1 key
        F1 = 112,
        //
        // 摘要:
        //     F2 key
        F2 = 113,
        //
        // 摘要:
        //     F3 key
        F3 = 114,
        //
        // 摘要:
        //     F4 key
        F4 = 115,
        //
        // 摘要:
        //     F5 key
        F5 = 116,
        //
        // 摘要:
        //     F6 key
        F6 = 117,
        //
        // 摘要:
        //     F7 key
        F7 = 118,
        //
        // 摘要:
        //     F8 key
        F8 = 119,
        //
        // 摘要:
        //     F9 key
        F9 = 120,
        //
        // 摘要:
        //     F10 key
        F10 = 121,
        //
        // 摘要:
        //     F11 key
        F11 = 122,
        //
        // 摘要:
        //     F12 key
        F12 = 123,
        //
        // 摘要:
        //     F13 key
        F13 = 124,
        //
        // 摘要:
        //     F14 key
        F14 = 125,
        //
        // 摘要:
        //     F15 key
        F15 = 126,
        //
        // 摘要:
        //     F16 key
        F16 = 127,
        //
        // 摘要:
        //     F17 key
        F17 = 128,
        //
        // 摘要:
        //     F18 key
        F18 = 129,
        //
        // 摘要:
        //     F19 key
        F19 = 130,
        //
        // 摘要:
        //     F20 key
        F20 = 131,
        //
        // 摘要:
        //     F21 key
        F21 = 132,
        //
        // 摘要:
        //     F22 key
        F22 = 133,
        //
        // 摘要:
        //     F23 key
        F23 = 134,
        //
        // 摘要:
        //     F24 key
        F24 = 135,
        //
        // 摘要:
        //     NUM LOCK key
        NUMLOCK = 144,
        //
        // 摘要:
        //     SCROLL LOCK key
        SCROLL = 145,
        //
        // 摘要:
        //     Left SHIFT key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        LSHIFT = 160,
        //
        // 摘要:
        //     Right SHIFT key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        RSHIFT = 161,
        //
        // 摘要:
        //     Left CONTROL key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        LCONTROL = 162,
        //
        // 摘要:
        //     Right CONTROL key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        RCONTROL = 163,
        //
        // 摘要:
        //     Left MENU key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        LMENU = 164,
        //
        // 摘要:
        //     Right MENU key - Used only as parameters to GetAsyncKeyState() and GetKeyState()
        RMENU = 165,
        //
        // 摘要:
        //     Windows 2000/XP: Browser Back key
        BROWSER_BACK = 166,
        //
        // 摘要:
        //     Windows 2000/XP: Browser Forward key
        BROWSER_FORWARD = 167,
        //
        // 摘要:
        //     Windows 2000/XP: Browser Refresh key
        BROWSER_REFRESH = 168,
        //
        // 摘要:
        //     Windows 2000/XP: Browser Stop key
        BROWSER_STOP = 169,
        //
        // 摘要:
        //     Windows 2000/XP: Browser Search key
        BROWSER_SEARCH = 170,
        //
        // 摘要:
        //     Windows 2000/XP: Browser Favorites key
        BROWSER_FAVORITES = 171,
        //
        // 摘要:
        //     Windows 2000/XP: Browser Start and Home key
        BROWSER_HOME = 172,
        //
        // 摘要:
        //     Windows 2000/XP: Volume Mute key
        VOLUME_MUTE = 173,
        //
        // 摘要:
        //     Windows 2000/XP: Volume Down key
        VOLUME_DOWN = 174,
        //
        // 摘要:
        //     Windows 2000/XP: Volume Up key
        VOLUME_UP = 175,
        //
        // 摘要:
        //     Windows 2000/XP: Next Track key
        MEDIA_NEXT_TRACK = 176,
        //
        // 摘要:
        //     Windows 2000/XP: Previous Track key
        MEDIA_PREV_TRACK = 177,
        //
        // 摘要:
        //     Windows 2000/XP: Stop Media key
        MEDIA_STOP = 178,
        //
        // 摘要:
        //     Windows 2000/XP: Play/Pause Media key
        MEDIA_PLAY_PAUSE = 179,
        //
        // 摘要:
        //     Windows 2000/XP: Start Mail key
        LAUNCH_MAIL = 180,
        //
        // 摘要:
        //     Windows 2000/XP: Select Media key
        LAUNCH_MEDIA_SELECT = 181,
        //
        // 摘要:
        //     Windows 2000/XP: Start Application 1 key
        LAUNCH_APP1 = 182,
        //
        // 摘要:
        //     Windows 2000/XP: Start Application 2 key
        LAUNCH_APP2 = 183,
        //
        // 摘要:
        //     Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP:
        //     For the US standard keyboard, the ';:' key
        OEM_1 = 186,
        //
        // 摘要:
        //     Windows 2000/XP: For any country/region, the '+' key
        OEM_PLUS = 187,
        //
        // 摘要:
        //     Windows 2000/XP: For any country/region, the ',' key
        OEM_COMMA = 188,
        //
        // 摘要:
        //     Windows 2000/XP: For any country/region, the '-' key
        OEM_MINUS = 189,
        //
        // 摘要:
        //     Windows 2000/XP: For any country/region, the '.' key
        OEM_PERIOD = 190,
        //
        // 摘要:
        //     Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP:
        //     For the US standard keyboard, the '/?' key
        OEM_2 = 191,
        //
        // 摘要:
        //     Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP:
        //     For the US standard keyboard, the '`~' key
        OEM_3 = 192,
        //
        // 摘要:
        //     Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP:
        //     For the US standard keyboard, the '[{' key
        OEM_4 = 219,
        //
        // 摘要:
        //     Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP:
        //     For the US standard keyboard, the '\|' key
        OEM_5 = 220,
        //
        // 摘要:
        //     Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP:
        //     For the US standard keyboard, the ']}' key
        OEM_6 = 221,
        //
        // 摘要:
        //     Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP:
        //     For the US standard keyboard, the 'single-quote/double-quote' key
        OEM_7 = 222,
        //
        // 摘要:
        //     Used for miscellaneous characters; it can vary by keyboard.
        OEM_8 = 223,
        //
        // 摘要:
        //     Windows 2000/XP: Either the angle bracket key or the backslash key on the RT
        //     102-key keyboard
        OEM_102 = 226,
        //
        // 摘要:
        //     Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        PROCESSKEY = 229,
        //
        // 摘要:
        //     Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
        //     The PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard
        //     input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN,
        //     and WM_KEYUP
        PACKET = 231,
        //
        // 摘要:
        //     Attn key
        ATTN = 246,
        //
        // 摘要:
        //     CrSel key
        CRSEL = 247,
        //
        // 摘要:
        //     ExSel key
        EXSEL = 248,
        //
        // 摘要:
        //     Erase EOF key
        EREOF = 249,
        //
        // 摘要:
        //     Play key
        PLAY = 250,
        //
        // 摘要:
        //     Zoom key
        ZOOM = 251,
        //
        // 摘要:
        //     Reserved
        NONAME = 252,
        //
        // 摘要:
        //     PA1 key
        PA1 = 253,
        //
        // 摘要:
        //     Clear key
        OEM_CLEAR = 254
    }
    //public enum EnumKey
    //{
    //    //
    //    // 摘要:
    //    //     The bitmask to extract modifiers from a key value.
    //    Modifiers = -65536,
    //    //
    //    // 摘要:
    //    //     No key pressed.
    //    None = 0,
    //    //
    //    // 摘要:
    //    //     The left mouse button.
    //    LButton = 1,
    //    //
    //    // 摘要:
    //    //     The right mouse button.
    //    RButton = 2,
    //    //
    //    // 摘要:
    //    //     The CANCEL key.
    //    Cancel = 3,
    //    //
    //    // 摘要:
    //    //     The middle mouse button (three-button mouse).
    //    MButton = 4,
    //    //
    //    // 摘要:
    //    //     The first x mouse button (five-button mouse).
    //    XButton1 = 5,
    //    //
    //    // 摘要:
    //    //     The second x mouse button (five-button mouse).
    //    XButton2 = 6,
    //    //
    //    // 摘要:
    //    //     The BACKSPACE key.
    //    Back = 8,
    //    //
    //    // 摘要:
    //    //     The TAB key.
    //    Tab = 9,
    //    //
    //    // 摘要:
    //    //     The LINEFEED key.
    //    LineFeed = 10,
    //    //
    //    // 摘要:
    //    //     The CLEAR key.
    //    Clear = 12,
    //    //
    //    // 摘要:
    //    //     The RETURN key.
    //    Return = 13,
    //    //
    //    // 摘要:
    //    //     The ENTER key.
    //    Enter = 13,
    //    //
    //    // 摘要:
    //    //     The SHIFT key.
    //    ShiftKey = 16,
    //    //
    //    // 摘要:
    //    //     The CTRL key.
    //    ControlKey = 17,
    //    //
    //    // 摘要:
    //    //     The ALT key.
    //    Menu = 18,
    //    //
    //    // 摘要:
    //    //     The PAUSE key.
    //    Pause = 19,
    //    //
    //    // 摘要:
    //    //     The CAPS LOCK key.
    //    Capital = 20,
    //    //
    //    // 摘要:
    //    //     The CAPS LOCK key.
    //    CapsLock = 20,
    //    //
    //    // 摘要:
    //    //     The IME Kana mode key.
    //    KanaMode = 21,
    //    //
    //    // 摘要:
    //    //     The IME Hanguel mode key. (maintained for compatibility; use HangulMode)
    //    HanguelMode = 21,
    //    //
    //    // 摘要:
    //    //     The IME Hangul mode key.
    //    HangulMode = 21,
    //    //
    //    // 摘要:
    //    //     The IME Junja mode key.
    //    JunjaMode = 23,
    //    //
    //    // 摘要:
    //    //     The IME final mode key.
    //    FinalMode = 24,
    //    //
    //    // 摘要:
    //    //     The IME Hanja mode key.
    //    HanjaMode = 25,
    //    //
    //    // 摘要:
    //    //     The IME Kanji mode key.
    //    KanjiMode = 25,
    //    //
    //    // 摘要:
    //    //     The ESC key.
    //    Escape = 27,
    //    //
    //    // 摘要:
    //    //     The IME convert key.
    //    IMEConvert = 28,
    //    //
    //    // 摘要:
    //    //     The IME nonconvert key.
    //    IMENonconvert = 29,
    //    //
    //    // 摘要:
    //    //     The IME accept key, replaces System.Windows.Forms.Keys.IMEAceept.
    //    IMEAccept = 30,
    //    //
    //    // 摘要:
    //    //     The IME accept key. Obsolete, use System.Windows.Forms.Keys.IMEAccept instead.
    //    IMEAceept = 30,
    //    //
    //    // 摘要:
    //    //     The IME mode change key.
    //    IMEModeChange = 31,
    //    //
    //    // 摘要:
    //    //     The SPACEBAR key.
    //    Space = 32,
    //    //
    //    // 摘要:
    //    //     The PAGE UP key.
    //    Prior = 33,
    //    //
    //    // 摘要:
    //    //     The PAGE UP key.
    //    PageUp = 33,
    //    //
    //    // 摘要:
    //    //     The PAGE DOWN key.
    //    Next = 34,
    //    //
    //    // 摘要:
    //    //     The PAGE DOWN key.
    //    PageDown = 34,
    //    //
    //    // 摘要:
    //    //     The END key.
    //    End = 35,
    //    //
    //    // 摘要:
    //    //     The HOME key.
    //    Home = 36,
    //    //
    //    // 摘要:
    //    //     The LEFT ARROW key.
    //    Left = 37,
    //    //
    //    // 摘要:
    //    //     The UP ARROW key.
    //    Up = 38,
    //    //
    //    // 摘要:
    //    //     The RIGHT ARROW key.
    //    Right = 39,
    //    //
    //    // 摘要:
    //    //     The DOWN ARROW key.
    //    Down = 40,
    //    //
    //    // 摘要:
    //    //     The SELECT key.
    //    Select = 41,
    //    //
    //    // 摘要:
    //    //     The PRINT key.
    //    Print = 42,
    //    //
    //    // 摘要:
    //    //     The EXECUTE key.
    //    Execute = 43,
    //    //
    //    // 摘要:
    //    //     The PRINT SCREEN key.
    //    Snapshot = 44,
    //    //
    //    // 摘要:
    //    //     The PRINT SCREEN key.
    //    PrintScreen = 44,
    //    //
    //    // 摘要:
    //    //     The INS key.
    //    Insert = 45,
    //    //
    //    // 摘要:
    //    //     The DEL key.
    //    Delete = 46,
    //    //
    //    // 摘要:
    //    //     The HELP key.
    //    Help = 47,
    //    //
    //    // 摘要:
    //    //     The 0 key.
    //    D0 = 48,
    //    //
    //    // 摘要:
    //    //     The 1 key.
    //    D1 = 49,
    //    //
    //    // 摘要:
    //    //     The 2 key.
    //    D2 = 50,
    //    //
    //    // 摘要:
    //    //     The 3 key.
    //    D3 = 51,
    //    //
    //    // 摘要:
    //    //     The 4 key.
    //    D4 = 52,
    //    //
    //    // 摘要:
    //    //     The 5 key.
    //    D5 = 53,
    //    //
    //    // 摘要:
    //    //     The 6 key.
    //    D6 = 54,
    //    //
    //    // 摘要:
    //    //     The 7 key.
    //    D7 = 55,
    //    //
    //    // 摘要:
    //    //     The 8 key.
    //    D8 = 56,
    //    //
    //    // 摘要:
    //    //     The 9 key.
    //    D9 = 57,
    //    //
    //    // 摘要:
    //    //     The A key.
    //    A = 65,
    //    //
    //    // 摘要:
    //    //     The B key.
    //    B = 66,
    //    //
    //    // 摘要:
    //    //     The C key.
    //    C = 67,
    //    //
    //    // 摘要:
    //    //     The D key.
    //    D = 68,
    //    //
    //    // 摘要:
    //    //     The E key.
    //    E = 69,
    //    //
    //    // 摘要:
    //    //     The F key.
    //    F = 70,
    //    //
    //    // 摘要:
    //    //     The G key.
    //    G = 71,
    //    //
    //    // 摘要:
    //    //     The H key.
    //    H = 72,
    //    //
    //    // 摘要:
    //    //     The I key.
    //    I = 73,
    //    //
    //    // 摘要:
    //    //     The J key.
    //    J = 74,
    //    //
    //    // 摘要:
    //    //     The K key.
    //    K = 75,
    //    //
    //    // 摘要:
    //    //     The L key.
    //    L = 76,
    //    //
    //    // 摘要:
    //    //     The M key.
    //    M = 77,
    //    //
    //    // 摘要:
    //    //     The N key.
    //    N = 78,
    //    //
    //    // 摘要:
    //    //     The O key.
    //    O = 79,
    //    //
    //    // 摘要:
    //    //     The P key.
    //    P = 80,
    //    //
    //    // 摘要:
    //    //     The Q key.
    //    Q = 81,
    //    //
    //    // 摘要:
    //    //     The R key.
    //    R = 82,
    //    //
    //    // 摘要:
    //    //     The S key.
    //    S = 83,
    //    //
    //    // 摘要:
    //    //     The T key.
    //    T = 84,
    //    //
    //    // 摘要:
    //    //     The U key.
    //    U = 85,
    //    //
    //    // 摘要:
    //    //     The V key.
    //    V = 86,
    //    //
    //    // 摘要:
    //    //     The W key.
    //    W = 87,
    //    //
    //    // 摘要:
    //    //     The X key.
    //    X = 88,
    //    //
    //    // 摘要:
    //    //     The Y key.
    //    Y = 89,
    //    //
    //    // 摘要:
    //    //     The Z key.
    //    Z = 90,
    //    //
    //    // 摘要:
    //    //     The left Windows logo key (Microsoft Natural Keyboard).
    //    LWin = 91,
    //    //
    //    // 摘要:
    //    //     The right Windows logo key (Microsoft Natural Keyboard).
    //    RWin = 92,
    //    //
    //    // 摘要:
    //    //     The application key (Microsoft Natural Keyboard).
    //    Apps = 93,
    //    //
    //    // 摘要:
    //    //     The computer sleep key.
    //    Sleep = 95,
    //    //
    //    // 摘要:
    //    //     The 0 key on the numeric keypad.
    //    NumPad0 = 96,
    //    //
    //    // 摘要:
    //    //     The 1 key on the numeric keypad.
    //    NumPad1 = 97,
    //    //
    //    // 摘要:
    //    //     The 2 key on the numeric keypad.
    //    NumPad2 = 98,
    //    //
    //    // 摘要:
    //    //     The 3 key on the numeric keypad.
    //    NumPad3 = 99,
    //    //
    //    // 摘要:
    //    //     The 4 key on the numeric keypad.
    //    NumPad4 = 100,
    //    //
    //    // 摘要:
    //    //     The 5 key on the numeric keypad.
    //    NumPad5 = 101,
    //    //
    //    // 摘要:
    //    //     The 6 key on the numeric keypad.
    //    NumPad6 = 102,
    //    //
    //    // 摘要:
    //    //     The 7 key on the numeric keypad.
    //    NumPad7 = 103,
    //    //
    //    // 摘要:
    //    //     The 8 key on the numeric keypad.
    //    NumPad8 = 104,
    //    //
    //    // 摘要:
    //    //     The 9 key on the numeric keypad.
    //    NumPad9 = 105,
    //    //
    //    // 摘要:
    //    //     The multiply key.
    //    Multiply = 106,
    //    //
    //    // 摘要:
    //    //     The add key.
    //    Add = 107,
    //    //
    //    // 摘要:
    //    //     The separator key.
    //    Separator = 108,
    //    //
    //    // 摘要:
    //    //     The subtract key.
    //    Subtract = 109,
    //    //
    //    // 摘要:
    //    //     The decimal key.
    //    Decimal = 110,
    //    //
    //    // 摘要:
    //    //     The divide key.
    //    Divide = 111,
    //    //
    //    // 摘要:
    //    //     The F1 key.
    //    F1 = 112,
    //    //
    //    // 摘要:
    //    //     The F2 key.
    //    F2 = 113,
    //    //
    //    // 摘要:
    //    //     The F3 key.
    //    F3 = 114,
    //    //
    //    // 摘要:
    //    //     The F4 key.
    //    F4 = 115,
    //    //
    //    // 摘要:
    //    //     The F5 key.
    //    F5 = 116,
    //    //
    //    // 摘要:
    //    //     The F6 key.
    //    F6 = 117,
    //    //
    //    // 摘要:
    //    //     The F7 key.
    //    F7 = 118,
    //    //
    //    // 摘要:
    //    //     The F8 key.
    //    F8 = 119,
    //    //
    //    // 摘要:
    //    //     The F9 key.
    //    F9 = 120,
    //    //
    //    // 摘要:
    //    //     The F10 key.
    //    F10 = 121,
    //    //
    //    // 摘要:
    //    //     The F11 key.
    //    F11 = 122,
    //    //
    //    // 摘要:
    //    //     The F12 key.
    //    F12 = 123,
    //    //
    //    // 摘要:
    //    //     The F13 key.
    //    F13 = 124,
    //    //
    //    // 摘要:
    //    //     The F14 key.
    //    F14 = 125,
    //    //
    //    // 摘要:
    //    //     The F15 key.
    //    F15 = 126,
    //    //
    //    // 摘要:
    //    //     The F16 key.
    //    F16 = 127,
    //    //
    //    // 摘要:
    //    //     The F17 key.
    //    F17 = 128,
    //    //
    //    // 摘要:
    //    //     The F18 key.
    //    F18 = 129,
    //    //
    //    // 摘要:
    //    //     The F19 key.
    //    F19 = 130,
    //    //
    //    // 摘要:
    //    //     The F20 key.
    //    F20 = 131,
    //    //
    //    // 摘要:
    //    //     The F21 key.
    //    F21 = 132,
    //    //
    //    // 摘要:
    //    //     The F22 key.
    //    F22 = 133,
    //    //
    //    // 摘要:
    //    //     The F23 key.
    //    F23 = 134,
    //    //
    //    // 摘要:
    //    //     The F24 key.
    //    F24 = 135,
    //    //
    //    // 摘要:
    //    //     The NUM LOCK key.
    //    NumLock = 144,
    //    //
    //    // 摘要:
    //    //     The SCROLL LOCK key.
    //    Scroll = 145,
    //    //
    //    // 摘要:
    //    //     The left SHIFT key.
    //    LShiftKey = 160,
    //    //
    //    // 摘要:
    //    //     The right SHIFT key.
    //    RShiftKey = 161,
    //    //
    //    // 摘要:
    //    //     The left CTRL key.
    //    LControlKey = 162,
    //    //
    //    // 摘要:
    //    //     The right CTRL key.
    //    RControlKey = 163,
    //    //
    //    // 摘要:
    //    //     The left ALT key.
    //    LMenu = 164,
    //    //
    //    // 摘要:
    //    //     The right ALT key.
    //    RMenu = 165,
    //    //
    //    // 摘要:
    //    //     The browser back key.
    //    BrowserBack = 166,
    //    //
    //    // 摘要:
    //    //     The browser forward key.
    //    BrowserForward = 167,
    //    //
    //    // 摘要:
    //    //     The browser refresh key.
    //    BrowserRefresh = 168,
    //    //
    //    // 摘要:
    //    //     The browser stop key.
    //    BrowserStop = 169,
    //    //
    //    // 摘要:
    //    //     The browser search key.
    //    BrowserSearch = 170,
    //    //
    //    // 摘要:
    //    //     The browser favorites key.
    //    BrowserFavorites = 171,
    //    //
    //    // 摘要:
    //    //     The browser home key.
    //    BrowserHome = 172,
    //    //
    //    // 摘要:
    //    //     The volume mute key.
    //    VolumeMute = 173,
    //    //
    //    // 摘要:
    //    //     The volume down key.
    //    VolumeDown = 174,
    //    //
    //    // 摘要:
    //    //     The volume up key.
    //    VolumeUp = 175,
    //    //
    //    // 摘要:
    //    //     The media next track key.
    //    MediaNextTrack = 176,
    //    //
    //    // 摘要:
    //    //     The media previous track key.
    //    MediaPreviousTrack = 177,
    //    //
    //    // 摘要:
    //    //     The media Stop key.
    //    MediaStop = 178,
    //    //
    //    // 摘要:
    //    //     The media play pause key.
    //    MediaPlayPause = 179,
    //    //
    //    // 摘要:
    //    //     The launch mail key.
    //    LaunchMail = 180,
    //    //
    //    // 摘要:
    //    //     The select media key.
    //    SelectMedia = 181,
    //    //
    //    // 摘要:
    //    //     The start application one key.
    //    LaunchApplication1 = 182,
    //    //
    //    // 摘要:
    //    //     The start application two key.
    //    LaunchApplication2 = 183,
    //    //
    //    // 摘要:
    //    //     The OEM Semicolon key on a US standard keyboard.
    //    OemSemicolon = 186,
    //    //
    //    // 摘要:
    //    //     The OEM 1 key.
    //    Oem1 = 186,
    //    //
    //    // 摘要:
    //    //     The OEM plus key on any country/region keyboard.
    //    Oemplus = 187,
    //    //
    //    // 摘要:
    //    //     The OEM comma key on any country/region keyboard.
    //    Oemcomma = 188,
    //    //
    //    // 摘要:
    //    //     The OEM minus key on any country/region keyboard.
    //    OemMinus = 189,
    //    //
    //    // 摘要:
    //    //     The OEM period key on any country/region keyboard.
    //    OemPeriod = 190,
    //    //
    //    // 摘要:
    //    //     The OEM question mark key on a US standard keyboard.
    //    OemQuestion = 191,
    //    //
    //    // 摘要:
    //    //     The OEM 2 key.
    //    Oem2 = 191,
    //    //
    //    // 摘要:
    //    //     The OEM tilde key on a US standard keyboard.
    //    Oemtilde = 192,
    //    //
    //    // 摘要:
    //    //     The OEM 3 key.
    //    Oem3 = 192,
    //    //
    //    // 摘要:
    //    //     The OEM open bracket key on a US standard keyboard.
    //    OemOpenBrackets = 219,
    //    //
    //    // 摘要:
    //    //     The OEM 4 key.
    //    Oem4 = 219,
    //    //
    //    // 摘要:
    //    //     The OEM pipe key on a US standard keyboard.
    //    OemPipe = 220,
    //    //
    //    // 摘要:
    //    //     The OEM 5 key.
    //    Oem5 = 220,
    //    //
    //    // 摘要:
    //    //     The OEM close bracket key on a US standard keyboard.
    //    OemCloseBrackets = 221,
    //    //
    //    // 摘要:
    //    //     The OEM 6 key.
    //    Oem6 = 221,
    //    //
    //    // 摘要:
    //    //     The OEM singled/double quote key on a US standard keyboard.
    //    OemQuotes = 222,
    //    //
    //    // 摘要:
    //    //     The OEM 7 key.
    //    Oem7 = 222,
    //    //
    //    // 摘要:
    //    //     The OEM 8 key.
    //    Oem8 = 223,
    //    //
    //    // 摘要:
    //    //     The OEM angle bracket or backslash key on the RT 102 key keyboard.
    //    OemBackslash = 226,
    //    //
    //    // 摘要:
    //    //     The OEM 102 key.
    //    Oem102 = 226,
    //    //
    //    // 摘要:
    //    //     The PROCESS KEY key.
    //    ProcessKey = 229,
    //    //
    //    // 摘要:
    //    //     Used to pass Unicode characters as if they were keystrokes. The Packet key value
    //    //     is the low word of a 32-bit virtual-key value used for non-keyboard input methods.
    //    Packet = 231,
    //    //
    //    // 摘要:
    //    //     The ATTN key.
    //    Attn = 246,
    //    //
    //    // 摘要:
    //    //     The CRSEL key.
    //    Crsel = 247,
    //    //
    //    // 摘要:
    //    //     The EXSEL key.
    //    Exsel = 248,
    //    //
    //    // 摘要:
    //    //     The ERASE EOF key.
    //    EraseEof = 249,
    //    //
    //    // 摘要:
    //    //     The PLAY key.
    //    Play = 250,
    //    //
    //    // 摘要:
    //    //     The ZOOM key.
    //    Zoom = 251,
    //    //
    //    // 摘要:
    //    //     A constant reserved for future use.
    //    NoName = 252,
    //    //
    //    // 摘要:
    //    //     The PA1 key.
    //    Pa1 = 253,
    //    //
    //    // 摘要:
    //    //     The CLEAR key.
    //    OemClear = 254,
    //    //
    //    // 摘要:
    //    //     The bitmask to extract a key code from a key value.
    //    KeyCode = 65535,
    //    //
    //    // 摘要:
    //    //     The SHIFT modifier key.
    //    Shift = 65536,
    //    //
    //    // 摘要:
    //    //     The CTRL modifier key.
    //    Control = 131072,
    //    //
    //    // 摘要:
    //    //     The ALT modifier key.
    //    Alt = 262144
    //}
}
