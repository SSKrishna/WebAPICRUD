using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPICRUD.Models;

namespace WebAPICRUD.Controllers
{
    public class PersonsController : ApiController
    {
        List<Person> lstPersons = new List<Person>() {

        new Person() { id = 10, Name = "abc", Address = "usa" },
        new Person() { id = 20, Name = "test", Address = "usa" },
        new Person () { id = 30, Name = "user1",Address = "ind"}
        };
        public IHttpActionResult GetAllpersons()
        {
            List<Person> PerObj = lstPersons;
            return Ok(lstPersons);
        }

        public IHttpActionResult GetPerson(int ID)
        {
            Person Obj = (from per in lstPersons where per.id == ID select per).SingleOrDefault();
            return Ok(Obj);
        }

        public IHttpActionResult PostPerson(Person PerObj)
        {
            try
            {
                lstPersons.Add(PerObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(lstPersons);

        }

    
        public IHttpActionResult GetCounties()
        {
        List<string> lstCountry = new List<string>()
            {
                "USA","IND","AUS","UK"
            };
        return Ok(lstCountry);
        }

        public IHttpActionResult GetStates(string cname)
        {
        List<string> lstStates = new List<string>();
        lstStates.Add("Select");
        switch (cname)
        {
            case "USA":
                {
                    lstStates.Add("NY");
                    lstStates.Add("CA");
                    lstStates.Add("NJ");
                    break;
                }
            case "IND":
                {
                    lstStates.Add("TS");
                    lstStates.Add("AP");
                    lstStates.Add("TN");
                    break;
                }

            default:
                {
                    break;
                }
        }

        return Ok(lstStates);
        }

    }


}
