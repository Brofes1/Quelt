using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Quelt
{
    public struct JsonStruct
    {
        enum ConstructorState
        {
            ReadingName,
            ReadingContent,
            ReadingStruct
        };

        private Dictionary<string, object> _components;

        public JsonStruct()
        {
            this._components = new Dictionary<string, object>();
        }

        public JsonStruct(string contents) : this(new StringBuilder(contents)) { }

        public JsonStruct(StringBuilder contents)
        {
            this._components = new Dictionary<string, object>();

            contents.Replace("\r\n", "");

            int depth = 0;

            bool inQuotations = false;
            ConstructorState state = ConstructorState.ReadingName;

            StringBuilder name = new StringBuilder();
            StringBuilder content = new StringBuilder();
            char currentChar = ' ';
            char previousChar;

            // i = 1 to ignore beginning {, length-1 to ignore ending }
            for (var i = 1; i < contents.Length - 1; i++)
            {
                previousChar = currentChar;
                currentChar = contents[i];

                while (currentChar == ' ' && !inQuotations)
                {
                    contents.Remove(i, 1);
                    currentChar = contents[i];
                }

                if (currentChar == '"' && previousChar != '\\')
                {
                    inQuotations = !inQuotations;
                }

                if (state == ConstructorState.ReadingName)
                {
                    if (currentChar == '"') { }
                    else if (!inQuotations && currentChar == ':')
                    {
                        state = ConstructorState.ReadingContent;
                    }
                    else if (inQuotations)
                    {
                        name.Append(currentChar);
                    }
                }
                else if (state == ConstructorState.ReadingContent)
                {
                    if (!inQuotations && currentChar == '{')
                    {
                        content.Append(currentChar);
                        depth = 1;
                        state = ConstructorState.ReadingStruct;
                    }
                    else if (!inQuotations && (currentChar == ',' || i == contents.Length - 2))
                    {
                        if (i == contents.Length - 2)
                        {
                            content.Append(currentChar);
                        }

                        bool boolContents;
                        double doubleContents;
                        int intContents;

                        string contentsString = content.ToString();

                        if (contentsString == "True")
                        {
                            this._components[name.ToString()] = true;
                        }
                        else if ( contentsString == "False")
                        {
                            this._components[name.ToString()] = false;
                        }
                        else if (int.TryParse(contentsString, out intContents))
                        {
                            this._components[name.ToString()] = intContents;
                        }
                        else if (double.TryParse(contentsString, out doubleContents))
                        {
                            this._components[name.ToString()] = doubleContents;
                        }
                        else if (string.IsNullOrEmpty(contentsString))
                        {
                            throw new System.Exception("JSON values cannot be null!");
                        }
                        else
                        {
                            this._components[name.ToString()] = contentsString;
                        }

                        name.Clear();
                        content.Clear();
                        state = ConstructorState.ReadingName;
                    }
                    else
                    {
                        content.Append(currentChar);
                    }
                }
                else if (state == ConstructorState.ReadingStruct)
                {
                    if ((!inQuotations && currentChar == ',' && depth == 0) || (depth == 1 && i == contents.Length - 2 && currentChar == '}'))
                    {
                        if (depth == 1 && i == contents.Length - 2 && currentChar == '}')
                        {
                            content.Append('}');
                        }

                        this._components[name.ToString()] = new JsonStruct(content);

                        name.Clear();
                        content.Clear();
                        state = ConstructorState.ReadingName;
                    }
                    else
                    {
                        content.Append(currentChar);

                        if (currentChar == '{') depth++;
                        if (currentChar == '}') depth--;
                    }
                }
            }
        }

        public void SetComponent(string name, object o)
        {
            this._components.Add(name, o);
        }

        public T GetComponent<T>(string name)
        {
            return (T)this._components[name];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<string, object>.KeyCollection keys = this._components.Keys;
            string[] names = keys.ToArray();

            sb.Append("{");
            for (int i = 0; i < names.Length; i++)
            {
                sb.Append('"');
                sb.Append(names[i]);
                sb.Append('"');
                sb.Append(':');

                if (this._components[names[i]].GetType() == typeof(string))
                    sb.Append("\"" + this._components[names[i]] + "\"");
                else if (this._components[names[i]].GetType() == typeof(bool) && (bool)this._components[names[i]] == true)
                    sb.Append("true");
                else if (this._components[names[i]].GetType() == typeof(bool) && (bool)this._components[names[i]] == false)
                    sb.Append("false");
                else
                    sb.Append(this._components[names[i]]);

                if (i < names.Length - 1)
                    sb.Append(",");
            }
            sb.Append("}");

            return sb.ToString();
        }

        public static JsonStruct ToJsonStruct<T>(T o) where T : JsonStructConvertable
        {
            JsonStruct jsonStruct = new JsonStruct();

            string[] names;
            object[] objects;

            (names, objects) = o.GetObjectsAndNames();

            if (names.Length != objects.Length) throw new Exception("List of names and objects are not the same length!");

            for (int i = 0; i < names.Length; i++)
            {
                jsonStruct.SetComponent(names[i], objects[i]);
            }

            return jsonStruct;
        }
    }

    public interface JsonStructConvertable
    {
        /// <summary>
        /// Should return a list of strings and a list of objects. The strings represent the names to be saved in the file.
        /// </summary>
        /// <returns></returns>
        public abstract (string[], object[]) GetObjectsAndNames();
    }
}
