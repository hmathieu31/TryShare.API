using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Exceptions
{

    [Serializable]
    public class TricycleNotAvailableException : Exception
    {
        public TricycleNotAvailableException() { }
        public TricycleNotAvailableException(string message) : base(message) { }
        public TricycleNotAvailableException(string message, Exception inner) : base(message, inner) { }
        protected TricycleNotAvailableException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
