using System.Collections.Generic;

namespace DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}