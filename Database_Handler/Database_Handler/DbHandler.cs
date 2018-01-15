/*
* NAME          :   DbHandler   
* 
* FIRST VERSION :   January 14, 2018
*  
* PURPOSE       :   The purpose of this class is to connect to a MySQL database and be able to 
*                   perform SQL commands.
*               
*                   This uses MySql.Data reference which was aqcuired at https://dev.mysql.com/downloads/mysql/
*/

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Handler
{
    public class DbHandler
    {
        private MySqlConnection Connect { set; get; }
        private string ConnectionString { set; get; }



        // Constructor with no IpAddress or port selected, will default to localhost:3306
        public DbHandler(string user, string password, string database)
            : this("127.0.0.1", "3306", database, user, password) { }

        // Constructor with no selected database
        public DbHandler(string IpAddress, string user, string port, string password)        
            : this(IpAddress, port, "", user, password) { }

        // Default Constructor
        public DbHandler(string IpAddress, string port, string database, string user,  string password)
        {
            ConnectionString = $"Server={IpAddress};Port={port};Database={database};Uid={user};Pwd={password};";
        }




        /*
        * Function		:	ConnectToDb
        *
        * Description	:   This function will take the ConnectionString and attempt to connect to the 
        *                   database
        *	
        * Parameters	:   none
        *	
        * Return Value	:	void	
        */
        public void ConnectToDb()
        {
            string logStart = Logger.LogMessageStart("DbHandler", "ConnectToDb");

            try
            {
                Connect = new MySqlConnection(ConnectionString);
                Logger.WriteLog(logStart + "Connection Successful");
                Connect.Open();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(logStart + "Connection ERROR: " + ex.Message);
            }
        }
    }
}
