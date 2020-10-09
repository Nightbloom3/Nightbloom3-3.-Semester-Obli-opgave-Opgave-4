using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using FanLibrary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opgave_4_Simple_REST_Service.Controllers
{
    [Route("api/FanOutPut")]
    [ApiController]
    public class FanOutPutController : ControllerBase
    {
        // GET: api/<FanOutPutController>
        [HttpGet]
        public IEnumerable<FanOutPut> Get()
        {
            return FanoutputdataList;
        }

        // GET api/<FanOutPutController>/5
        [HttpGet("{id}")]
        public FanOutPut Get(int id)
        {
            return FanoutputdataList.Find(i => i.id == id);

            // Her skal den gennemløbe listen, og "find" det første match, der passe med det objekt vi har oprette "i"
            // Når den finder et match mellem i.id og objektet fra listen "id" - bliver det returneret.
        }

        // POST api/<FanOutPutController>
        [HttpPost]
        public void Post([FromBody] FanOutPut value)
        {
            FanoutputdataList.Add(value);

            // frombody laver en query i json format som converters til FanOutPut format.
        }

        // PUT api/<FanOutPutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutPut value)
        {
            FanOutPut fan = Get(id);
            if (fan != null)
            {
                fan.Navn = value.Navn;
                fan.Temp = value.Temp;
                fan.Fugt = value.Fugt;
            }

            // Hvis det lokalt oprettede objekt ikke er null = at der allerede findes et objekt med samme id.
            // skal den sætte det "nye" navn = navn.
        }

        // DELETE api/<FanOutPutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutPut fanput = Get(id);
            FanoutputdataList.Remove(fanput);
        }

        private static readonly List<FanOutPut> FanoutputdataList = new List<FanOutPut>()
        {
            new FanOutPut("lokale", 25, 50),
            new FanOutPut("dds", 25, 32)
        };


        // for kunne få adgang til din klasse, skal du under dependices henter reff

    }
}