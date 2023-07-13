using System.Collections.Generic;
using RegisterApp.Interfaces;

namespace RegisterApp
{
    public class EndpointRepository : IRepository<Endpoint>
    {
        private List<Endpoint> endpointList = new List<Endpoint>();
        public void Update(int serialNumber, SwitchState switchState)
        {
            endpointList[serialNumber].SwitchState = switchState;
        }

        public Endpoint GetEndpoint(int serialNumber)
        {
            return endpointList[serialNumber];
        }

        public void Exclude(int endpointSerialNumber)
        {
            endpointList[endpointSerialNumber].Exclude();
        }

        public void Insert(Endpoint entity)
        {
            endpointList.Add(entity);
        }

        public List<Endpoint> List()
        {
            return endpointList;
        }
    }
}
