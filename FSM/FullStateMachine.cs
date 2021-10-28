using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class FullStateMachine
    {
        public Status currentStatus { get; set; }

        public FullStateMachine(Status status)
        {
            this.currentStatus = status;
        }
    }
}
