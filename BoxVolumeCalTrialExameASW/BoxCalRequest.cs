using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoxVolumeCalTrialExameASW
{
    public class BoxCalRequest
    {
        /// <summary>
        /// Properties som matcher attributter i tabellen på azure.
        /// </summary>
        public String Request { get; set; }

        public double Volume { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

    }
}