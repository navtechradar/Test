using System;
using System.ServiceModel;
using TestApp.Common.Entities;
using TestApp.Interfaces.Entities;

namespace TestApp.Entity.Service.Interfaces
{
    [ServiceContract]
    [ServiceKnownType(typeof(TestAppEntity))]
    public interface IEntityService
    {
        [OperationContract]
        ITestAppEntity GetEntity(Guid uniqueKey);

        [OperationContract]
        int GetId();
    }
}
