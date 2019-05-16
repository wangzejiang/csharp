using System;
using System.Collections.Generic;
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
    }
}
