using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppTest.Commons
{
    public static class GlobalExceptionHandling
    {
        public static void WriteTraceLogs(string _traceMsg)
        {
            System.Diagnostics.Debug.WriteLine("[" + DateTime.Now + "] " + _traceMsg);
        }

        public static void WriteExceptionLog(Exception _ex)
        {

        }


    }
}
