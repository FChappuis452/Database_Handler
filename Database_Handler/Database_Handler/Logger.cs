/*
* NAME          :   Logger   
*                   
* FIRST VERSION :   January 14, 2018
* 
* PURPOSE       :   The purpose of the logger class will be to log the events in the DB class. 
*                   It will create a log file in the root folder where the application is running.
*                   
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Handler
{
    public static class Logger
    {
        
        public static string Filename { set; get; } 

        /*
        * Function		:	WriteLog
        *
        * Description	:   This will write the log to a file.  The file will be name
        *                   according to date
        *	
        * Parameters	:   string message: the message being written to file
        *	
        * Return Value	:	datatype	
        */
        public static void WriteLog(string message)
        {
            DateTime date = DateTime.Today;   
            Filename = date.ToString("MMM-dd-yyyy") + ".log";

            try
            {
                lock (Filename)
                {
                    using (StreamWriter writer = new StreamWriter(Filename, true))
                    {
                        writer.WriteLine(message);
                        Console.WriteLine("");
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(Filename, true))
                {
                    writer.WriteLine("(Logging ERROR: " + ex.Message);
                }
            }
        }




        /*
        * Function		:   LogMessageStart
        *
        * Description	:   This will create the header for the log file message
        *                   The header will be current time (24hr HH:mm:ss) the className.method
        *                   ex. 20:30:45 [classname.method] 
        *	
        * Parameters	:   string className    :   The originating class where the logging event happens
        *                   string method       :   The originating method where the logging event happens
        *	
        * Return Value	:	string  : Will return the formatted string
        */
        public static string LogMessageStart(string className, string method)
        {
            DateTime date = DateTime.Now;
            string message = date.ToString("HH:mm:ss") + " [" + className + "." + method + "] ";
            return message;
        }
    }
}