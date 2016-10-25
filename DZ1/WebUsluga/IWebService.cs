using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    [ServiceContract]
    public interface IWebService
    {

        [OperationContract]
        bool register(string username, double latitude, double longitude, string IPaddress, int port);

        [OperationContract]
        UserAddress searchNeighbour(string username);

        [OperationContract]
        bool storeMeasurement(string username, string parameter, float averageValue);

    }

    [DataContract]
    public class UserAddress
    {
        bool userExists = false;
        string ipaddress = string.Empty;
        int? port = null;

        [DataMember]
        public bool UserExists
        {
            get { return userExists; }
            set { userExists = value; }
        }

        [DataMember]
        public string IPaddress
        {
            get { return ipaddress; }
            set { ipaddress = value; }
        }

        [DataMember]
        public int? Port
        {
            get { return port; }
            set { port = value; }
        }
    }
}
