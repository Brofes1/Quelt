using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Quelt
{
    public static class InputHandler
    {
        public static Dictionary<string, KeyButton> keys = new Dictionary<string, KeyButton>();

        static KeyboardState _currentKeyboardState = Keyboard.GetState();
        static KeyboardState _previousKeyboardState = Keyboard.GetState();

        static MouseState _currentMouseState = Mouse.GetState();
        static MouseState _previousMouseState = Mouse.GetState();

        #region letters
        public static readonly KeyButton A = new KeyButton();
        public static readonly KeyButton B = new KeyButton();
        public static readonly KeyButton C = new KeyButton();
        public static readonly KeyButton D = new KeyButton();
        public static readonly KeyButton E = new KeyButton();
        public static readonly KeyButton F = new KeyButton();
        public static readonly KeyButton G = new KeyButton();
        public static readonly KeyButton H = new KeyButton();
        public static readonly KeyButton I = new KeyButton();
        public static readonly KeyButton J = new KeyButton();
        public static readonly KeyButton K = new KeyButton();
        public static readonly KeyButton L = new KeyButton();
        public static readonly KeyButton M = new KeyButton();
        public static readonly KeyButton N = new KeyButton();
        public static readonly KeyButton O = new KeyButton();
        public static readonly KeyButton P = new KeyButton();
        public static readonly KeyButton Q = new KeyButton();
        public static readonly KeyButton R = new KeyButton();
        public static readonly KeyButton S = new KeyButton();
        public static readonly KeyButton T = new KeyButton();
        public static readonly KeyButton U = new KeyButton();
        public static readonly KeyButton V = new KeyButton();
        public static readonly KeyButton W = new KeyButton();
        public static readonly KeyButton X = new KeyButton();
        public static readonly KeyButton Y = new KeyButton();
        public static readonly KeyButton Z = new KeyButton();
        #endregion

        #region numbers
        public static KeyButton Zero = new KeyButton();
        public static KeyButton One = new KeyButton();
        public static KeyButton Two = new KeyButton();
        public static KeyButton Three = new KeyButton();
        public static KeyButton Four = new KeyButton();
        public static KeyButton Five = new KeyButton();
        public static KeyButton Six = new KeyButton();
        public static KeyButton Seven = new KeyButton();
        public static KeyButton Eight = new KeyButton();
        public static KeyButton Nine = new KeyButton();
        #endregion

        #region special
        public static KeyButton Tab = new KeyButton();
        public static KeyButton Caps = new KeyButton();
        public static KeyButton LShift = new KeyButton();
        public static KeyButton LControl = new KeyButton();
        public static KeyButton LAlt = new KeyButton();
        public static KeyButton RAlt = new KeyButton();
        public static KeyButton RCtrl = new KeyButton();
        public static KeyButton RShift = new KeyButton();
        public static KeyButton Enter = new KeyButton();
        public static KeyButton Backspace = new KeyButton();
        public static KeyButton Esc = new KeyButton();
        #endregion

        #region other
        public static KeyButton Backquote = new KeyButton();
        public static KeyButton Comma = new KeyButton();
        public static KeyButton Period = new KeyButton();
        public static KeyButton Slash = new KeyButton();
        public static KeyButton Semicolon = new KeyButton();
        public static KeyButton Quote = new KeyButton();
        public static KeyButton OpenBracket = new KeyButton();
        public static KeyButton CloseBracket = new KeyButton();
        public static KeyButton Backslash = new KeyButton();
        public static KeyButton Minus = new KeyButton();
        public static new KeyButton Equals = new KeyButton();
        #endregion

        #region function
        public static KeyButton FunctionOne = new KeyButton();
        public static KeyButton FunctionTwo = new KeyButton();
        public static KeyButton FunctionThree = new KeyButton();
        public static KeyButton FunctionFour = new KeyButton();
        public static KeyButton FunctionFive = new KeyButton();
        public static KeyButton FunctionSix = new KeyButton();
        public static KeyButton FunctionSeven = new KeyButton();
        public static KeyButton FunctionEight = new KeyButton();
        public static KeyButton FunctionNine = new KeyButton();
        public static KeyButton FunctionTen = new KeyButton();
        public static KeyButton FunctionEleven = new KeyButton();
        public static KeyButton FunctionTwelve = new KeyButton();
        #endregion

        #region arrows
        public static KeyButton UpArrow = new KeyButton();
        public static KeyButton LeftArrow = new KeyButton();
        public static KeyButton DownArrow = new KeyButton();
        public static KeyButton RightArrow = new KeyButton();
        #endregion

        #region movement
        public static KeyButton Insert = new KeyButton();
        public static KeyButton Delete = new KeyButton();
        public static KeyButton Home = new KeyButton();
        public static KeyButton End = new KeyButton();
        public static KeyButton PageUp = new KeyButton();
        public static KeyButton PageDown = new KeyButton();
        #endregion

        #region numpad
        public static KeyButton NumpadZero = new KeyButton();
        public static KeyButton NumpadOne = new KeyButton();
        public static KeyButton NumpadTwo = new KeyButton();
        public static KeyButton NumpadThree = new KeyButton();
        public static KeyButton NumpadFour = new KeyButton();
        public static KeyButton NumpadFive = new KeyButton();
        public static KeyButton NumpadSix = new KeyButton();
        public static KeyButton NumpadSeven = new KeyButton();
        public static KeyButton NumpadEight = new KeyButton();
        public static KeyButton NumpadNine = new KeyButton();
        #endregion

        #region mouse
        public static Vector2 mousePosition = new Vector2(0, 0);
        public static Vector2 previousMousePosition = new Vector2(0, 0);
        
        public static Vector2 mousePositionChange { get { return mousePosition - previousMousePosition; } }
        
        public static KeyButton LeftMouse = new KeyButton();
        public static KeyButton RightMouse = new KeyButton();
        public static KeyButton MiddleMouse = new KeyButton();

        static GameObject? _objectMouseOver = null;
        static bool mouseOverGameObject = false;
        public static GameObject objectMouseOver
        {
            get
            {
                return _objectMouseOver ?? Main.rootGameObject;
            }
        }
        #endregion

        public static void UpdateInput()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            #region letters
            A.UpdateState(_currentKeyboardState.IsKeyDown(Keys.A), _previousKeyboardState.IsKeyDown(Keys.A));
            B.UpdateState(_currentKeyboardState.IsKeyDown(Keys.B), _previousKeyboardState.IsKeyDown(Keys.B));
            C.UpdateState(_currentKeyboardState.IsKeyDown(Keys.C), _previousKeyboardState.IsKeyDown(Keys.C));
            D.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D), _previousKeyboardState.IsKeyDown(Keys.D));
            E.UpdateState(_currentKeyboardState.IsKeyDown(Keys.E), _previousKeyboardState.IsKeyDown(Keys.E));
            F.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F), _previousKeyboardState.IsKeyDown(Keys.F));
            G.UpdateState(_currentKeyboardState.IsKeyDown(Keys.G), _previousKeyboardState.IsKeyDown(Keys.G));
            H.UpdateState(_currentKeyboardState.IsKeyDown(Keys.H), _previousKeyboardState.IsKeyDown(Keys.H));
            I.UpdateState(_currentKeyboardState.IsKeyDown(Keys.I), _previousKeyboardState.IsKeyDown(Keys.I));
            J.UpdateState(_currentKeyboardState.IsKeyDown(Keys.J), _previousKeyboardState.IsKeyDown(Keys.J));
            K.UpdateState(_currentKeyboardState.IsKeyDown(Keys.K), _previousKeyboardState.IsKeyDown(Keys.K));
            L.UpdateState(_currentKeyboardState.IsKeyDown(Keys.L), _previousKeyboardState.IsKeyDown(Keys.L));
            M.UpdateState(_currentKeyboardState.IsKeyDown(Keys.M), _previousKeyboardState.IsKeyDown(Keys.M));
            N.UpdateState(_currentKeyboardState.IsKeyDown(Keys.N), _previousKeyboardState.IsKeyDown(Keys.N));
            O.UpdateState(_currentKeyboardState.IsKeyDown(Keys.O), _previousKeyboardState.IsKeyDown(Keys.O));
            P.UpdateState(_currentKeyboardState.IsKeyDown(Keys.P), _previousKeyboardState.IsKeyDown(Keys.P));
            Q.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Q), _previousKeyboardState.IsKeyDown(Keys.Q));
            R.UpdateState(_currentKeyboardState.IsKeyDown(Keys.R), _previousKeyboardState.IsKeyDown(Keys.R));
            S.UpdateState(_currentKeyboardState.IsKeyDown(Keys.S), _previousKeyboardState.IsKeyDown(Keys.S));
            T.UpdateState(_currentKeyboardState.IsKeyDown(Keys.T), _previousKeyboardState.IsKeyDown(Keys.T));
            U.UpdateState(_currentKeyboardState.IsKeyDown(Keys.U), _previousKeyboardState.IsKeyDown(Keys.U));
            V.UpdateState(_currentKeyboardState.IsKeyDown(Keys.V), _previousKeyboardState.IsKeyDown(Keys.V));
            W.UpdateState(_currentKeyboardState.IsKeyDown(Keys.W), _previousKeyboardState.IsKeyDown(Keys.W));
            X.UpdateState(_currentKeyboardState.IsKeyDown(Keys.X), _previousKeyboardState.IsKeyDown(Keys.X));
            Y.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Y), _previousKeyboardState.IsKeyDown(Keys.Y));
            Z.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Z), _previousKeyboardState.IsKeyDown(Keys.Z));
            #endregion

            #region numbers
            Zero.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D0), _previousKeyboardState.IsKeyDown(Keys.D0));
            One.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D1), _previousKeyboardState.IsKeyDown(Keys.D1));
            Two.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D2), _previousKeyboardState.IsKeyDown(Keys.D2));
            Three.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D3), _previousKeyboardState.IsKeyDown(Keys.D3));
            Four.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D4), _previousKeyboardState.IsKeyDown(Keys.D4));
            Five.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D5), _previousKeyboardState.IsKeyDown(Keys.D5));
            Six.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D6), _previousKeyboardState.IsKeyDown(Keys.D6));
            Seven.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D7), _previousKeyboardState.IsKeyDown(Keys.D7));
            Eight.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D8), _previousKeyboardState.IsKeyDown(Keys.D8));
            Nine.UpdateState(_currentKeyboardState.IsKeyDown(Keys.D9), _previousKeyboardState.IsKeyDown(Keys.D9));
            #endregion

            #region special
            Tab.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Tab), _previousKeyboardState.IsKeyDown(Keys.Tab));
            Caps.UpdateState(_currentKeyboardState.IsKeyDown(Keys.CapsLock), _previousKeyboardState.IsKeyDown(Keys.CapsLock));
            LShift.UpdateState(_currentKeyboardState.IsKeyDown(Keys.LeftShift), _previousKeyboardState.IsKeyDown(Keys.LeftShift));
            LControl.UpdateState(_currentKeyboardState.IsKeyDown(Keys.LeftControl), _previousKeyboardState.IsKeyDown(Keys.LeftControl));
            LAlt.UpdateState(_currentKeyboardState.IsKeyDown(Keys.LeftAlt), _previousKeyboardState.IsKeyDown(Keys.LeftAlt));
            RAlt.UpdateState(_currentKeyboardState.IsKeyDown(Keys.RightAlt), _previousKeyboardState.IsKeyDown(Keys.RightAlt));
            RCtrl.UpdateState(_currentKeyboardState.IsKeyDown(Keys.RightControl), _previousKeyboardState.IsKeyDown(Keys.RightControl));
            RShift.UpdateState(_currentKeyboardState.IsKeyDown(Keys.RightShift), _previousKeyboardState.IsKeyDown(Keys.RightShift));
            Enter.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Enter), _previousKeyboardState.IsKeyDown(Keys.Enter));
            Backspace.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Back), _previousKeyboardState.IsKeyDown(Keys.Back));
            Esc.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Escape), _previousKeyboardState.IsKeyDown(Keys.Escape));
            #endregion

            #region other
            Backquote.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemTilde), _previousKeyboardState.IsKeyDown(Keys.OemTilde));
            Comma.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemComma), _previousKeyboardState.IsKeyDown(Keys.OemComma));
            Period.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemPeriod), _previousKeyboardState.IsKeyDown(Keys.OemPeriod));
            Slash.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemQuestion), _previousKeyboardState.IsKeyDown(Keys.OemQuestion));
            Semicolon.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemSemicolon), _previousKeyboardState.IsKeyDown(Keys.OemSemicolon));
            Quote.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemQuotes), _previousKeyboardState.IsKeyDown(Keys.OemQuotes));
            OpenBracket.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemOpenBrackets), _previousKeyboardState.IsKeyDown(Keys.OemOpenBrackets));
            CloseBracket.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemCloseBrackets), _previousKeyboardState.IsKeyDown(Keys.OemCloseBrackets));
            Backslash.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemBackslash), _previousKeyboardState.IsKeyDown(Keys.OemBackslash));
            Minus.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemMinus), _previousKeyboardState.IsKeyDown(Keys.OemMinus));
            Equals.UpdateState(_currentKeyboardState.IsKeyDown(Keys.OemPlus), _previousKeyboardState.IsKeyDown(Keys.OemPlus));
            #endregion

            #region function
            FunctionOne.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F1), _previousKeyboardState.IsKeyDown(Keys.F1));
            FunctionTwo.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F2), _previousKeyboardState.IsKeyDown(Keys.F2));
            FunctionThree.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F3), _previousKeyboardState.IsKeyDown(Keys.F3));
            FunctionFour.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F4), _previousKeyboardState.IsKeyDown(Keys.F4));
            FunctionFive.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F5), _previousKeyboardState.IsKeyDown(Keys.F5));
            FunctionSix.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F6), _previousKeyboardState.IsKeyDown(Keys.F6));
            FunctionSeven.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F7), _previousKeyboardState.IsKeyDown(Keys.F7));
            FunctionEight.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F8), _previousKeyboardState.IsKeyDown(Keys.F8));
            FunctionNine.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F9), _previousKeyboardState.IsKeyDown(Keys.F9));
            FunctionTen.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F10), _previousKeyboardState.IsKeyDown(Keys.F10));
            FunctionEleven.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F11), _previousKeyboardState.IsKeyDown(Keys.F11));
            FunctionTwelve.UpdateState(_currentKeyboardState.IsKeyDown(Keys.F12), _previousKeyboardState.IsKeyDown(Keys.F12));
            #endregion

            #region arrows
            UpArrow.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Up), _previousKeyboardState.IsKeyDown(Keys.Up));
            LeftArrow.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Left), _previousKeyboardState.IsKeyDown(Keys.Left));
            DownArrow.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Down), _previousKeyboardState.IsKeyDown(Keys.Down));
            RightArrow.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Right), _previousKeyboardState.IsKeyDown(Keys.Right));
            #endregion

            #region movement
            Insert.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Insert), _previousKeyboardState.IsKeyDown(Keys.Insert));
            Delete.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Delete), _previousKeyboardState.IsKeyDown(Keys.Delete));
            Home.UpdateState(_currentKeyboardState.IsKeyDown(Keys.Home), _previousKeyboardState.IsKeyDown(Keys.Home));
            End.UpdateState(_currentKeyboardState.IsKeyDown(Keys.End), _previousKeyboardState.IsKeyDown(Keys.End));
            PageUp.UpdateState(_currentKeyboardState.IsKeyDown(Keys.PageUp), _previousKeyboardState.IsKeyDown(Keys.PageUp));
            PageDown.UpdateState(_currentKeyboardState.IsKeyDown(Keys.PageDown), _previousKeyboardState.IsKeyDown(Keys.PageDown));
            #endregion

            #region numpad
            NumpadZero.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad0), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadOne.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad1), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadTwo.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad2), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadThree.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad3), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadFour.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad4), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadFive.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad5), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadSix.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad6), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadSeven.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad7), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadEight.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad8), _previousKeyboardState.IsKeyDown(Keys.A));
            NumpadNine.UpdateState(_currentKeyboardState.IsKeyDown(Keys.NumPad9), _previousKeyboardState.IsKeyDown(Keys.A));
            #endregion

            #region mouse
            mousePosition = _currentMouseState.Position.ToVector2();
            previousMousePosition = _previousMouseState.Position.ToVector2();

            LeftMouse.UpdateState(_currentMouseState.LeftButton == ButtonState.Pressed, _previousMouseState.LeftButton == ButtonState.Pressed);
            RightMouse.UpdateState(_currentMouseState.RightButton == ButtonState.Pressed, _previousMouseState.RightButton == ButtonState.Pressed);
            MiddleMouse.UpdateState(_currentMouseState.MiddleButton == ButtonState.Pressed, _previousMouseState.MiddleButton == ButtonState.Pressed);
            
            Main.gameObjectList = Main.gameObjectList.OrderBy(o => -o.Location.Z).ToList();
            
            foreach (GameObject gameObject in Main.gameObjectList)
            {
                if (gameObject.Hitbox.Contains(mousePosition))
                    objectMouseOver = gameObject;
            }

            #endregion
        }
    }

    public class KeyButton
    {
        public bool pressed = false;
        public bool justPressed = false;
        public bool justReleased = false;

        public void UpdateState(bool currentState, bool previousState)
        {
            this.pressed = currentState;
            this.justPressed = currentState && !previousState;
            this.justReleased = !currentState && previousState;
        }
    }
}
