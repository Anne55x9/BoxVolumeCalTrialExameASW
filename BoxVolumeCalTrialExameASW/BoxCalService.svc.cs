using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BoxVolumeCalTrialExameASW
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BoxCalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BoxCalService.svc or BoxCalService.svc.cs at the Solution Explorer and start debugging.
    public class BoxCalService : IBoxCalService
    {
      
        /// <summary>
        /// Metode GetVolume og GetSide som henholdvis retunere et volumen af en boks. 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public double GetVolume(double length, double width, double height)
        {
            return length * width * height;
        }

        /// <summary>
        /// Metode GetSide som retunere værdien af en manglende side af en boks ud fra 3 kendte parametre volume, side1 og side2. 
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="side1"></param>
        /// <param name="side2"></param>
        /// <returns></returns>

        public double GetSide(double volume, double side1, double side2)
        {
            return volume / (side1 * side2);
        }
        
    }
}
