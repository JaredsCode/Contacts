using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Utils
{
    public class ErrorUtils
    {
        public string FormatErrorMessage(Exception ex)
        {
            string innerException = "";
            if (ex.InnerException != null)
            {
                innerException = GetInnerException(ex);
            }

            return $"Message: {ex.Message}{Environment.NewLine}" +
                $"InnerException: {innerException}{Environment.NewLine}" +
                $"StackTrace: {ex.StackTrace}";
        }
        
        private string GetInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return GetInnerException(ex.InnerException);
            }

            return ex.Message;
        }
    }
}
