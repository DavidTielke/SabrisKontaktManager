using System;
using System.Runtime.Serialization;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract.DataClasses
{
    [Serializable]
    public class IdNotFoundException : DataStoringException
    {
        public IdNotFoundException()
        {
        }

        public IdNotFoundException(string message) : base(message)
        {
        }

        public IdNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected IdNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}