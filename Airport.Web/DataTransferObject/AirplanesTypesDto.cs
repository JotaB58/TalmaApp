using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airport.Web.DataTransferObject
{
    public class AirplanesTypesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AirplanesTypesDto()
        {
            Id = 0;
            Name = string.Empty;
        }
    }
}