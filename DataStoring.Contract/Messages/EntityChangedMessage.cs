using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract.DataClasses;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.Contract.Messages
{
    public class EntityChangedMessage
    {
        public object Entity { get; set; }
        public DateTime ChangedDate { get; set; }
        public ChangedReason Reason { get; set; }
    }
}
