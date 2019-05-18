using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anylsycm
{
    public static class Utils
    {
        public static string getConfig(string path)
        {
            return string.Format("{0}{1}", "D:/cc/", path);
        }

        public static string readTopWords()
        {
            return File.ReadAllText(getConfig("topwords.txt"));
        }
        public static string writeTopWords(string words)
        {
            File.WriteAllText(getConfig("topwords.txt"), words);
            return words;
        }
    }
}
