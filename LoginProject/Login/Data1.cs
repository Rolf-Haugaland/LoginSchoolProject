using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Login
{
    class Data1
    {
        public string[] CurrentUserSignedIn;
        public string StringwholeFile = "";
        public string[] UserFileStringArray = { };
        public int UserLine = 0;
        public static int AlreadyBeenRun = 0;
        public void readFile()
        {
            FileStream fs = new FileStream("AllUsersAndPasswords.txt", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            StringwholeFile = Encoding.ASCII.GetString(buffer);
            UserFileStringArray = StringwholeFile.Split(',');
            fs.Flush();
            fs.Close();
        }
    }
}
