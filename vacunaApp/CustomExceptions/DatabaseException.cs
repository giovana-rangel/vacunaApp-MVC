using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vacunaApp.CustomExceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
            throw new Exception(message);
        }
    }
}