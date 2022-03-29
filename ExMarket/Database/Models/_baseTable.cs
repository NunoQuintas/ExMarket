using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExMarket.Database.Models
{
    //Base class for all application tables
    //contains all audit and handles the soft delete mechanism
    public class _baseTable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  //Indicates that the Key will be generated inside the application and not on the DB, so that comparisons between new isntances do not return false positives
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public String CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public String ModifiedBy { get; set; }

        public Boolean Deleted { get; set; }




        #region Helper Functions

            public Boolean Delete()
            {
                this.Deleted = true; //Forces a softdelete with a flag, so no data can be removed

                return true;
            }

        public _baseTable()
        {
            Id = Guid.NewGuid(); //generates GUID for ID, no special logic in this example
        }
        #endregion
    }
}
