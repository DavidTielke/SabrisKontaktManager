using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidTielke.PersonManagerCoCo.CrossCutting.DataClasses;

namespace DavidTielke.PersonManagerCoCo.Data.DataStoring.EfCore.Mappings
{
    class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            this.ToTable("People");

            this.HasKey(p => p.Id);

            this.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(255)
                .IsRequired();

            this.Property(p => p.Age)
                .HasColumnName("Age")
                .IsRequired();

            this.Property(p => p.FK_CategoryId)
                .HasColumnName("FK_CategoryId")
                .IsRequired();

            this.HasRequired(p => p.Category)
                .WithMany(c => c.People)
                .HasForeignKey(p => p.FK_CategoryId);
        }
    }
}
