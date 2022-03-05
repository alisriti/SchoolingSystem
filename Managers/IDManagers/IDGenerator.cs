using System;

namespace SchoolingSystem.Managers.IDManagers
{
    public class IDGenerator : IIDGenerator
    {
        public string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}