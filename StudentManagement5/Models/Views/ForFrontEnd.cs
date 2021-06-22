using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement5.Models.Views
{
    public class ForFrontEnd<T>
    {
        public T data { get; set; }
        public bool state { get; set; }
        public string message { get; set; }
        public Exception exception { get; set; }

        public ForFrontEnd() { }
        public ForFrontEnd(T data, bool state, string message, Exception exception)
        {
            this.data = data;
            this.state = state;
            this.message = message;
            this.exception = exception;
        }
        public static ForFrontEnd<T> True(T data)
        {
            return new ForFrontEnd<T>(data, true, "", null);
        }
        public static ForFrontEnd<T> False(T data, string message, Exception exception)
        {
            return new ForFrontEnd<T>(data, false, message, exception);
        }
    }
}
