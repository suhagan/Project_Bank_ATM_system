using System;

namespace Project___The_Bank
{
    public class Clients
    {
        public string ClientsName { get; set; }
        public int ClientsID { get; set; }
        public string ClientsPassword { get; set; }
        public List<AccountsInfo> AccountHolders = new List<AccountsInfo>();
        private static int id = 1;

        public Clients(string clientname, string password)
        {
            this.ClientsID = id;
            this.ClientsName = clientname;
            this.ClientsPassword = password;
            id++;
        }
    }
}