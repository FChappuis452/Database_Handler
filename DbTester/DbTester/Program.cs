/*
* Project			:   Db_Testing
*
* File				:   Program.cs
*
* Programmer		: 	Frederic Chappuis
*
* First Version		: 	January 14, 2018
*
* Description		:	This is a sinple console program to test the functions of the Logger and Db class
*/
using Database_Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "lllocalhost";
            string port = "3306";
            string db = "lab4";
            string user = "testAccount";
            string password = "password";

            //Generates a successfull connections
            DbHandler Db = new DbHandler(ip, port, db, user, password);
            Db.ConnectToDb();
           
          
        }
    }
}
