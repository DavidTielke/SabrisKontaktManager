using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore.Mappings
{
    class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            ToTable("Categories");

            HasKey(c => c.Id);

            Property(c => c.Name)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
