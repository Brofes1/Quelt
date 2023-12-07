namespace Quelt
{
    public class Text : GameObject
    {
        public enum TextSnap
        {
            topLeft,
            topRight,
            bottomLeft,
            bottomRight
        }

        public enum TextBuildingMode
        {
            readingString,
            escapeActive,
            readingParameter
        }

        private StringBuilder _text;
        private List<TextBlock> _displayText;
        private SpriteFont _spriteFont;
        private uint _textSize;
        private uint _textWrapWidth;

        public uint TextSize
        {
            get
            {
                return this._textSize;
            }
            set
            {
                this._textSize = value;
                this.BuildText();
            }
        }

        public uint TextWrapWidth
        {
            get
            {
                return this._textWrapWidth;
            }
            set
            {
                this._textWrapWidth = value;
                this.BuildText();
            }
        }

        public Text(GameObject _parent, Vector3 relativeLocation, SpriteFont spriteFont, 
            TextSnap snapping, StringBuilder text, uint textSize, uint? textWrapWidth)
            : base(_parent, relativeLocation)
        {
            this._spriteFont = spriteFont;
            this._text = text;
            this._textSize;
            this._textWrapWidth = textWrapWidth ?? uint.maxValue;
        }

        public Text(GameObject _parent, Vector3 relativeLocation, SpriteFont spriteFont, 
            TextSnap snapping, string text, uint textSize, uint? textWrapWidth)
            : this(_parent, relativeLocation, spriteFont, snapping, new StringBuilder(text), textSize, textWrapWidth) {}

        public List<TextBlock> BuildText()
        {
            // Example 1: This is a <C:#00ff00>green</C> word!\nHere's a newline, too!

            _displayText = new List<TextBlock>();
        }

        public static List<StringBuilder> SplitText(StringBuilder text, uint textWrapWidth)
        {
            List<StringBuilder> strings = new List<StringBuilder>();

            StringBuilder currentString = new StringBuilder();
            for (var i = 0; i < text.Length, i++)
            {
                char ch = text[i];

                if (ch == ' ')
                {
                    currentString.Append(ch);
                    strings.Add(currentString);
                    currentString = new StringBuilder();
                }
                if (ch == '\\')
                {
                    if (currentString.Length > 0)
                    {
                        strings.Add(currentString);
                        currentString = new StringBuilder();
                    }

                    i++;
                    char ch = text[i];

                    switch (ch)
                    {
                        case ('\\'):
                            currentString.Append('\\');
                    }
                    if (ch == '\\')
                    {
                        currentString.Append('\\');
                    }
                    else if (ch ==)
                }
            }
        }
    }

    public class TextBlock
    {
        public StringBuilder text;
        public Color color;
        public Vector2 location;
        public float scale;
        
        public TextBlock(StringBuilder text, Color color, Vector2 location)
        {
            this.text = text;
            this.color = color;
            this.location = location;
        }
    }
}