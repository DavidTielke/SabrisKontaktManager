using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCo.Core.Configuration.ConfigObjects;

namespace DavidTielke.PersonManagerCoCo.Logic.PersonManagement
{
    public class PersonManagementConfiguration
    {
        [ConfigMap("Persons","AgeThreshold")]
        public virtual int AgeThreshold { get; set; }
    }
}
