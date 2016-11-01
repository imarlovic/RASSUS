using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        [OperationContract]
        void sensorOffline(string IPaddress, int port);

    }

    [DataContract]
    public partial class UserAddress:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        bool userExists = false;
        string name = string.Empty;
        string ipaddress = string.Empty;
        int port;

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
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {   if(value != name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
                
            }
        }
    }

    public class Measurement
    {
        private string username;
        private string parameter;
        private float averageValue;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Parameter
        {
            get
            {
                return parameter;
            }

            set
            {
                parameter = value;
            }
        }

        public float AverageValue
        {
            get
            {
                return averageValue;
            }

            set
            {
                averageValue = value;
            }
        }

        public Measurement(string username, string parameter, float averageValue)
        {
            Username = username;
            Parameter = parameter;
            AverageValue = averageValue;
        }
    }

}
