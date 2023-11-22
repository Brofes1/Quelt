using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Quelt
{
    public static class InputHandler
    {
        public static Dictionary<string, Button> keys = new Dictionary<string, Button>();

        static KeyboardState _currentKeyboardState = Keyboard.GetState();
        static KeyboardState _previousKeyboardState = Keyboard.GetState();

        static MouseState _currentMouseState = Mouse.GetState();
        static MouseState _previousMouseState = Mouse.GetState();

        #region letters
        public static readonly Button A = new Button();
        public static readonly Button B = new Button();
        public static readonly Button C = new Button();
        public static readonly Button D = new Button();
        public static readonly Button E = new Button();
        public static readonly Button F = new Button();
        public static readonly Button G = new Button();
        public static readonly Button H = new Button();
        public static readonly Button I = new Button();
        public static readonly Button J = new Button();
        public static readonly Button K = new Button();
        public static readonly Button L = new Button();
        public static readonly Button M = new Button();
        public static readonly Button N = new Button();
        public static readonly Button O = new Button();
        public static readonly Button P = new Button();
        public static readonly Button Q = new Button();
        public static readonly Button R = new Button();
        public static readonly Button S = new Button();
        public static readonly Button T = new Button();
        public static readonly Button U = new Button();
        public static readonly Button V = new Button();
        public static readonly Button W = new Button();
        public static readonly Button X = new Button();
        public static readonly Button Y = new Button();
        public static readonly Button Z = new Button();
        #endregion

        #region numbers
        public static Button Zero = new Button();
        public static Button One = new Button();
        public static Button Two = new Button();
        public static Button Three = new Button();
        public static Button Four = new Button();
        public static Button Five = new Button();
        public static Button Six = new Button();
        public static Button Seven = new Button();
        public static Button Eight = new Button();
        public static Button Nine = new Button();
        #endregion

        #region special
        public static Button Tab = new Button();
        public static Button Caps = new Button();
        public static Button LShift = new Button();
        public static Button LControl = new Button();
        public static Button LAlt = new Button();
        public static Button RAlt = new Button();
        public static Button RCtrl = new Button();
        public static Button RShift = new Button();
        public static Button Enter = new Button();
        public static Button Backspace = new Button();
        public static Button Esc = new Button();
        #endregion

        #region other
        public static Button Backquote = new Button();
        public static Button Comma = new Button();
        public static Button Period = new Button();
        public static Button Slash = new Button();
        public static Button Semicolon = new Button();
        public static Button Quote = new Button();
        public static Button OpenBracket = new Button();
        public static Button CloseBracket = new Button();
        public static Button Backslash = new Button();
        public static Button Minus = new Button();
        public static new Button Equals = new Button();
        #endregion

        #region function
        public static Button FunctionOne = new Button();
        public static Button FunctionTwo = new Button();
        public static Button FunctionThree = new Button();
        public static Button FunctionFour = new Button();
        public static Button FunctionFive = new Button();
        public static Button FunctionSix = new Button();
        public static Button FunctionSeven = new Button();
        public static Button FunctionEight = new Button();
        public static Button FunctionNine = new Button();
        public static Button FunctionTen = new Button();
        public static Button FunctionEleven = new Button();
        public static Button FunctionTwelve = new Button();
        #endregion

        #region arrows
        public static Button UpArrow = new Button();
        public static Button LeftArrow = new Button();
        public static Button DownArrow = new Button();
        public static Button RightArrow = new Button();
        #endregion

        #region movement
        public static Button Insert = new Button();
        public static Button Delete = new Button();
        public static Button Home = new Button();
        public static Button End = new Button();
        public static Button PageUp = new Button();
        public static Button PageDown = new Button();
        #endregion

        #region numpad
        public static Button NumpadZero = new Button();
        public static Button NumpadOne = new Button();
        public static Button NumpadTwo = new Button();
        public static Button NumpadThree = new Button();
        public static Button NumpadFour = new Button();
        public static Button NumpadFive = new Button();
        public static Button NumpadSix = new Button();
        public static Button NumpadSeven = new Button();
        public static Button NumpadEight = new Button();
        public static Button NumpadNine = new Button();
        #endregion

        #region mouse
        public static Vector2 mousePosition = new Vector2(0, 0);
        public static Vector2 previousMousePosition = new Vector2(0, 0);
        
        public static Vector2 mousePositionChange { get { return mousePosition - previousMousePosition; } }
        
        public static Button LeftMouse = new Button();
        public static Button RightMouse = new Button();
        public static Button MiddleMouse = new Button();
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
            #endregion
        }
    }

    public class Button
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
