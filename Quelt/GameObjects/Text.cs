using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quelt
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

    public class Text : GameObject
    {
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
            this._textSize = textSize;
            this._textWrapWidth = textWrapWidth ?? uint.MaxValue;

            this.BuildText();
        }

        public Text(GameObject _parent, Vector3 relativeLocation, SpriteFont spriteFont, 
            TextSnap snapping, string text, uint textSize, uint? textWrapWidth)
            : this(_parent, relativeLocation, spriteFont, snapping, new StringBuilder(text), textSize, textWrapWidth) {}

        public void BuildText()
        {
            // Example 1: "This is a <C:#00ff00>green</C> word!\\nHere's a newline, too!"

            List<StringBuilder> strings = SplitText(this._text);

            _displayText = new List<TextBlock>();

            Color currentColor = Color.Black;

            int currentLine = 0;
            float currentLineLength = 0;

            float sectionLength;

            // 60 is the general SpriteFont size number
            float textScale = this._textSize / 60;
            float sectionHeight = this._spriteFont.MeasureString("|").Y * textScale;

            foreach (StringBuilder section in strings)
            {
                sectionLength = this._spriteFont.MeasureString(section).X * textScale;

                if (section[0] == '<' && section[^1] == '>')
                {
                    switch (section[1]) // special code location in string
                    {
                        case ('c'):
                            if (section.Length == 3)
                                currentColor = Color.Black;
                            else
                                currentColor = new Color(Convert.ToUInt32("0x" + section.ToString()[3..6] + "ff", 16));
                            break;
                        default:
                            throw new Exception("String has an invalid code type: " + section[1]);
                    }
                }
                else if (section[0] == '\n')
                {
                    currentLineLength = 0;
                    currentLine = 0;
                }
                else
                {
                    if (currentLineLength + sectionLength > this._textWrapWidth)
                    {
                        currentLine++;
                        currentLineLength = 0;
                    }

                    _displayText.Add(new TextBlock(section, currentColor, new Vector2(currentLineLength, sectionHeight * currentLine)));
                    currentLineLength += sectionLength;
                }
            }
        }

        public static List<StringBuilder> SplitText(StringBuilder text)
        {
            List<StringBuilder> strings = new List<StringBuilder>();
            StringBuilder currentString = new StringBuilder();

            for (var i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (ch == ' ')
                {
                    currentString.Append(ch);
                    strings.Add(currentString);
                    currentString = new StringBuilder();
                }
                else if (ch == '\\')
                {
                    if (currentString.Length > 0)
                    {
                        strings.Add(currentString);
                        currentString = new StringBuilder();
                    }

                    // Will break with \ at end of string
                    i++;
                    ch = text[i];

                    switch (ch)
                    {
                        case ('\\'):
                            currentString.Append('\\');
                            break;
                        case ('n'):
                            currentString.Append('\n');
                            break;
                        case ('t'):
                            currentString.Append('\t');
                            break;
                        case ('<'):
                            currentString.Append('<');
                            break;
                        default:
                            currentString.Append(ch);
                            break;
                    }

                    strings.Add(currentString);
                    currentString = new StringBuilder();
                }
                else if (ch == '<')
                {
                    if (currentString.Length > 0)
                    {
                        strings.Add(currentString);
                        currentString = new StringBuilder();
                    }

                    while (ch != '>')
                    {
                        if (i == text.Length)
                        {
                            strings.Add(currentString);
                            break;
                        }
                        currentString.Append(ch);
                        i++;
                        ch = text[i];
                    }
                    if (i == text.Length)
                        break;

                    currentString.Append('>');

                    strings.Add(currentString);
                    currentString = new StringBuilder();
                }
                else
                {
                    currentString.Append(ch);
                }
            }
            if (currentString.Length > 0)
                strings.Add(currentString);

            return strings;
        }

        public override void Render()
        {
            foreach (TextBlock textBlock in this._displayText)
            {

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