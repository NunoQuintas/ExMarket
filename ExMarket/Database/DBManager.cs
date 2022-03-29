using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ExMarket.Database
{
    public class DBManager : DbContext
    {
        private string _loggedUser = string.Empty;


        //initializer that sets the username to be recorded in audit fields
        public DBManager(string UserName)
        {
            _loggedUser = UserName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Overrides configuration, this can have specific logic to make the code DB agnostic during runtime by configuration
            //for exercise porpuse, we set it hardcoded to the current config

            optionsBuilder.UseSqlServer("Server=XXXX;Initial Catalog=Exercicio_Marketing;Persist Security Info=False;User ID=sa;Password=XXXXX;Connection Timeout=30;");
        }



        //Overrides SaveChanges to fill audit fields during the commit of changes to the DB
        public override int SaveChanges()
        {
            //Will cycle through all Table Entities tracked in this context, and will fill in auditing values
            foreach (var record in ChangeTracker.Entries<Models._baseTable>())
            {
                switch (record.State)
                {
                    case EntityState.Detached:
                        //detached, do nothing
                        break;
                    case EntityState.Unchanged:
                        //no changes, no audit values changed
                        break;
                    case EntityState.Deleted:
                        //Because we will be flagging deleted records instead of actually deleting them, we override this state
                        record.Entity.Delete(); //our custom flag
                        record.State = EntityState.Modified; //Sets the state to Modified so the EF creates an update statement for this entity
                        record.Entity.ModifiedOn = DateTime.UtcNow;
                        record.Entity.ModifiedBy = _loggedUser;
                        break;
                    case EntityState.Modified:
                        record.Entity.ModifiedOn = DateTime.UtcNow;
                        record.Entity.ModifiedBy = _loggedUser;
                        break;
                    case EntityState.Added:
                        record.Entity.CreatedOn = DateTime.UtcNow;
                        record.Entity.CreatedBy = _loggedUser;
                        record.Entity.ModifiedOn = DateTime.UtcNow;
                        record.Entity.ModifiedBy = _loggedUser;
                        break;
                    default:
                        break;
                }

            }


            return base.SaveChanges();
        }

         
        //Considering the goal for this exercise, uses DBSet directly and not more controlled public functions while the DBSet remain private
        public DbSet<Models.RegistoLeads> RegistoLeads { get; set; }

    }
}
