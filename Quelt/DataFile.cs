using Microsoft.Xna.Framework;
using System.IO;
using System.Text;

namespace Quelt
{
    public class DataFile
    {
        public JsonStruct json;
        public bool isLoaded = false;

        string _path;

        bool fileExists
        {
            get
            {
                return File.Exists(_path);
            }
        }

        public DataFile(string path)
        {
            this._path = path;
            this.json = new JsonStruct();
        }

        public void Load()
        {
            if (this.fileExists)
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(_path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        sb.Append(s);
                    }   
                }
                this.json = new JsonStruct(sb);
            }
            this.isLoaded = true;
        }

        public void Save()
        {
            if (!this.fileExists)
            {
                Directory.CreateDirectory(Directory.GetParent(this._path).FullName);
            }

            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.Write(this.json.ToString());
            }
        }
    }
}
