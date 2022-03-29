using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExMarket.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MarketingController : ControllerBase
    {
        //default logger

        private readonly ILogger<MarketingController> _logger;

        public MarketingController(ILogger<MarketingController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public string Status()
        {
            return "Active";
        }


        [HttpPut]
        public ActionResult<Database.Models.RegistoLeads> Put(Database.Models.RegistoLeads registo) //Ideally it should have a data transfer model and not be using the direct DB model
        {

            try
            {

                _logger.LogDebug("Entered MarketingController.PUT");


                _logger.LogDebug("Begin data validation");
                //Validates fields
                //Optimally this should consider a more robust validation
                if (
                    string.IsNullOrEmpty(registo.Nome) 
                    ||
                    registo.Nome.Length > 200
                    )
                {
                    //Something wrong, return error message
                    _logger.LogDebug("Name Failed Validation. Value: " + registo.Nome);

                }



                if (
                    string.IsNullOrEmpty(registo.Email)
                    ||
                    registo.Email.Length > 150
                    ||
                    false //Could have additional validation, forbidden domains, blacklists, etc 
                    )
                {
                    //Something wrong, return error message
                    _logger.LogDebug("Email Failed Validation. Value: " + registo.Nome);

                }

                _logger.LogDebug("Finished data validation");



                _logger.LogDebug("Initializing Database Connection and adding record");
                Database.DBManager _db = new Database.DBManager(registo.Nome); //since we don't have an auth model to indentify the user making changes, we shall use the Name provided

                _db.RegistoLeads.Add(registo);


                _logger.LogDebug("Saving Changes");
                _db.SaveChanges();

                _logger.LogInformation("Registo Leads Record added");

                return registo;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException, null);
                return StatusCode(500); //basic default internal server error
            }
        }
    }
}
