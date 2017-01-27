using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBagBench
{
    public class User
    {
        private const string Salt = "AutoBagAdmin";
        public bool LoggedIn { get; protected set; }
        public bool Login(string password)
        {
            try
            {
                string Chipher = SettingHelper.GetPassword();
                string Password = StringCipher.Decrypt(Chipher, password);

                if (Password == Salt)
                {
                    LoggedIn = true;
                    return true;
                }
            }
            catch (Exception exception)
            {
                
            }
            return false;
        }

        public bool LogOff()
        {
            LoggedIn = false;
            return true;
        }

        public bool ChangePassword(string newpassword)
        {
            if (LoggedIn == true)
            {
                string Cipher = StringCipher.Encrypt(Salt, newpassword);
                SettingHelper.SetPassword(Cipher);
                return true;
            }
            return false;
        }
    }
}
