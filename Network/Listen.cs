using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using TLog.Users;
using System.ServiceModel.Description;

namespace TLog.Network
{
    class WCFService
    {
        [ServiceContract]
        public interface ISync
        {
            [OperationContract]
            bool Upload(byte[] userList);

            [OperationContract]
            byte[] Download();
        }

        [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue, IncludeExceptionDetailInFaults = true)]
        public class Sync : ISync
        {
            public byte[] Download()
            {
                Debug.Log("Client requested download, now uploading active users...");
                var users = Manager.Serialization.ObjectAsBytes(Manager.Main.Instance.activeUsers);
                // for deletion syncing
                Manager.Main.Instance.activeUsers.RemoveAll(x => x.markedForDeletion);
                return users;
            }

            public bool Upload(byte[] newUser)
            {
                Debug.Log("Client requested upload, accepting client upload...");

                var userObj = Manager.Serialization.BytesAsObject<User>(newUser);
                Debug.Log("Received {0} users from client", Manager.Main.Instance.activeUsers.Count);

                return Manager.Main.Instance.mergeUser(userObj);
            }
        }

        public static EndpointAddress findServer()
        {
            Debug.Log("Looking for sync servers...");

            var discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            var criteria = new FindCriteria(typeof(ISync));
            criteria.Duration = new TimeSpan(0, 0, 5);
            var syncServices = discoveryClient.Find(criteria);
            discoveryClient.Close();

            if (syncServices.Endpoints.Count == 0)
            {
                Debug.Log("Could not find any sync servers. Attempting to use fallback");

                // non-portable
                if (Environment.MachineName.ToLower() != "ruc328-d01")
                    return new EndpointAddress("http://ruc328-d01:8080/tLog");
                return null;
            }

            else
                return syncServices.Endpoints[0].Address;
        }

        public static ServiceHost Start()
        {
            Debug.Log("Starting WFC service...");
            try
            {
                var service = new ServiceHost(typeof(Sync), new Uri("http://localhost:8080/tLog"));
                service.AddServiceEndpoint(typeof(ISync), new BasicHttpBinding(), new Uri("http://localhost:8080/tLog"));

                ServiceDiscoveryBehavior discoveryBehavior = new ServiceDiscoveryBehavior();
                service.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

                // send announcements on UDP multicast transport
                discoveryBehavior.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());
                service.Description.Endpoints.Add(new UdpDiscoveryEndpoint());

                service.Open();
                return service;
            }

            catch (Exception)
            {
                //fixme
                var service = new ServiceHost(typeof(Sync), new Uri("http://localhost:80/Temporary_Listen_Addresses/TLog"));
                service.AddServiceEndpoint(typeof(ISync), new BasicHttpBinding(), new Uri("http://localhost:80/Temporary_Listen_Addresses/TLog"));

                ServiceDiscoveryBehavior discoveryBehavior = new ServiceDiscoveryBehavior();
                service.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

                // send announcements on UDP multicast transport
                discoveryBehavior.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());
                service.Description.Endpoints.Add(new UdpDiscoveryEndpoint());

                service.Open();
                return service;
            }
        }
        public static ISync Connect(EndpointAddress server)
        {        
            if (server != null)
            {
                Debug.Log("Connecting to WFC server...");

                var myBinding = new BasicHttpBinding();
                myBinding.SendTimeout = new TimeSpan(0, 0, 5);
                var myEndpoint = server;
                var myChannelFactory = new ChannelFactory<ISync>(myBinding, myEndpoint);

                ISync client = null;

                try
                {
                    foreach (OperationDescription op in myChannelFactory.Endpoint.Contract.Operations)
                    {
                        var dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>();
                        if (dataContractBehavior != null)
                        {
                            dataContractBehavior.MaxItemsInObjectGraph = int.MaxValue;
                        }
                    }
                    return myChannelFactory.CreateChannel();
                }

                catch (Exception E)
                {
                    if (client != null)
                    {
                        ((ICommunicationObject)client).Abort();
                        throw new NetException("Could not connect to WFC server - " + E.Message);
                    }
                }
            }

            throw new NetException("Server endpoint is null!");
        }
    }
}
