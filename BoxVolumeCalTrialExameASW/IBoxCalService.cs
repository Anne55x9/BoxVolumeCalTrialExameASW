using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BoxVolumeCalTrialExameASW
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBoxCalService" in both code and config file together.
    [ServiceContract]
    public interface IBoxCalService
    {
        /// <summary>
        /// To metoder i Service klassen som indeholder 3 lokale parametre og retunere enten en boks volume
        /// eller en manglende side af boksen hvis 2 sider kendes. 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [OperationContract]
        double GetVolume(double length,double width,double height);

        [OperationContract]
        double GetSide(double volume, double side1, double side2);

        /// <summary>
        /// Metode til at indsætte udregninger i azur tabel.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="volume"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        [OperationContract]
        void InsertBoxCalRequest(String request, double volume, double length, double width, double height);

        /// <summary>
        /// Metode til at se alle udregninger fra azure tabel.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<BoxCalRequest> GetAllRequest();
    }


    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
