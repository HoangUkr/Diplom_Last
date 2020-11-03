using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Temporary_Server
{
    [Serializable]
    class AccountField
    {
        internal string status;
        internal string password;
        internal string fullName;
        internal string IP;
        internal bool isLoggedIn;
        internal bool visible;
        internal ArrayList contacts;

        public AccountField(string password, bool isLoggedIn, string fullName, string IP)
        {
            this.fullName = fullName;
            this.password = password;
            this.isLoggedIn = isLoggedIn;
            this.IP = IP;
            contacts = new ArrayList();
        }
    }
    [Serializable]
    class Database
    {
        private Hashtable database;
        internal ArrayList offlineMessages;
        public Database()
        {
            database = new Hashtable();
            offlineMessages = new ArrayList();
            Load();
        }
        internal bool Add(string username, string password, string fullName, string IP)
        {
            if (database.Contains(username))
                return false;
            database.Add(username, new AccountField(password, false, fullName, IP));
            return Save();
        }
        internal bool ChangePassword(string username, string curPassword, string newPassword)
        {
            if (database.Contains(username))
            {
                if (((AccountField)database[username]).password == curPassword)
                {
                    ((AccountField)database[username]).password = newPassword;
                    Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        internal bool ChangeDisplayName(string username, string displayName)
        {
            if (database.Contains(username))
            {
                ((AccountField)database[username]).fullName = displayName;
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool SetIP(string username, string IP)
        {
            if (database.Contains(username))
            {
                ((AccountField)database[username]).IP = IP;
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool SignIn(string username, string password, bool visible)
        {
            if (database.Contains(username))
            {
                if (((AccountField)database[username]).password == password)
                {
                    ((AccountField)database[username]).isLoggedIn = true;
                    ((AccountField)database[username]).visible = visible;
                    Console.WriteLine(DateTime.Now.ToString() + ": " + username + " da dang nhap thanh cong!");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        internal bool SignOut(string username)
        {
            if (database.Contains(username))
            {
                ((AccountField)database[username]).isLoggedIn = false;
                ((AccountField)database[username]).visible = false;
                Console.WriteLine(DateTime.Now.ToString() + ": " + username + " da thoat!");
                return true;
            }
            return false;
        }
        internal bool ContactExists(string username)
        {
            return (database.Contains(username));
        }
        internal bool IsLoggedIn(string username)
        {
            if (database.Contains(username))
            {
                return ((AccountField)database[username]).isLoggedIn;
            }
            else
            {
                return false;
            }
        }
        internal bool IsVisible(string username)
        {
            if (database.Contains(username))
            {
                return ((AccountField)database[username]).visible;
            }
            else
            {
                return false;
            }
        }
        internal void ChangeStatus(string username)
        {
            ((AccountField)database[username]).visible = !((AccountField)database[username]).visible;
        }
        internal string GetfullName(string username)
        {
            return ((AccountField)database[username]).fullName;
        }
        internal string GetIP(string username)
        {
            return ((AccountField)database[username]).IP;
        }
        internal bool AddContact(string username, string contact)
        {
            if (database.Contains(username))
            {
                if (((AccountField)database[username]).contacts.Contains(contact))
                    return false;
                if (database.Contains(contact))
                {
                    ((AccountField)database[username]).contacts.Add(contact);
                    return Save();
                }
            }
            return false;
        }
        internal bool RemoveContact(string username, string contact)
        {
            if (database.Contains(username))
            {
                if (((AccountField)database[username]).contacts.Contains(contact))
                {
                    ((AccountField)database[username]).contacts.Remove(contact);
                    return Save();
                }
            }
            return false;
        }
        internal ArrayList GetContacts(string username)
        {
            if (database.Contains(username))
            {
                return ((AccountField)database[username]).contacts;
            }
            return null;
        }
        internal bool Load()
        {
            try
            {
                FileStream fileStream = new FileStream("UserInfo.dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Database temp = (Database)binaryFormatter.Deserialize(fileStream);
                this.database = temp.database;
                this.offlineMessages = temp.offlineMessages;
                fileStream.Close();
                return true;
            }
            catch
            {
                database = new Hashtable();
                offlineMessages = new ArrayList();
                return false;
            }
        }
        internal bool Save()
        {
            try
            {
                FileStream fileStream =
                    new FileStream("UserInfo.dat", FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, this);
                fileStream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
