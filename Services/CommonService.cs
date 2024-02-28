using System;
using System.Reflection;

namespace EasyXNoteDataAccessAPI.Services
{
    public class CommonService
    {
        public bool GetSuccessValue(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo successProperty = objectType.GetProperty("success");

            if (successProperty != null && successProperty.PropertyType == typeof(bool))
            {
                bool successValue = (bool)successProperty.GetValue(obj);
                return successValue;
            }
            else
            {
                return false;
            }
        }

        public string GetMessageValue(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo messageProperty = objectType.GetProperty("message");

            if (messageProperty != null && messageProperty.PropertyType == typeof(string))
            {
                string messageValue = (string)messageProperty.GetValue(obj);
                return messageValue;
            }
            else
            {
                return "Unknown message";
            }
        }
        public string GetErrorMessage(object obj)
        {
            object errorObj = obj.GetType().GetProperty("error")?.GetValue(obj);

            if (errorObj != null)
            {
                PropertyInfo messageProperty = errorObj.GetType().GetProperty("message");
                if (messageProperty != null && messageProperty.PropertyType == typeof(string))
                {
                    string errorMessage = (string)messageProperty.GetValue(errorObj);
                    return errorMessage;
                }
            }

            return "Unknown error occurred";
        }
    }
}