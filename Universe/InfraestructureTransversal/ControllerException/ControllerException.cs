using System;

namespace Universe.InfraestructureTransversal.ControllerException
{
    public class ControllerException:Exception
    {

        public ControllerException(String message) : base(message) { }
        public ControllerException(String message, Exception inner) : base(message, inner) { }
    }
}
