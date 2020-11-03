using System;
using System.Collections;
namespace LanMessengerLib
{
    [Serializable]
    public class LetterReceive
    {
        string message;
        string from;

        public LetterReceive(string message, string from)
        {
            this.message = message;
            this.from = from;
        }

        public string Message
        {
            get
            {
                return message;
            }
        }

        public string From
        {
            get
            {
                return from;
            }
        }
    }
    public interface IServer
    {   
        bool SignUp(string username, string password, string fullName, string IP);
        bool ChangePassword(string username, string curPassword, string newPassword);
        bool SignIn(string username, string password, bool visible);
        bool SignOut(string username);
        bool IsVisible(string username);
        bool AddContact(string username, string contact);
        bool RemoveContact(string username, string contact);
        void ChangeStatus(string username);
        void ChangeDisplayName(string username, string displayName);
        string GetfullName(string username);
        string GetIP(string username);
        void SetIP(string username, string IP); 
        ArrayList GetContacts(string username);

        bool Send(string from, string to, string message);
        LetterReceive Receive(string to);
        ArrayList ReceiveOffline(string to);
    }
}
