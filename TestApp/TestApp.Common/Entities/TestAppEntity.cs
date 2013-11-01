using System;
using System.Runtime.Serialization;
using TestApp.Interfaces.Entities;

namespace TestApp.Common.Entities
{
    [DataContract]
    public class TestAppEntity: ITestAppEntity
    {
        [DataMember]
        public Guid UniqueKey { get; private set; }
        [DataMember]
        public string Name { get; private set; }

        public TestAppEntity()
        {
            UniqueKey = Guid.NewGuid();
            Name = "Default Entity";
        }
    }
}
