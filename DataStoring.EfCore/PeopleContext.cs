using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore.Mappings;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore
{
    public class PeopleContext : DbContext
    {
        public PeopleContext()
        {
            Database.Log += m => Console.WriteLine(m);
            Database.Connection.ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SabrisKontaktManager;Integrated Security=True";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
        }
    }
}
