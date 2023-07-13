using System;
using System.Collections.Generic;
using System.Text;


namespace RegisterApp.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();

        T GetEndpoint(int serialNumber);
        void Insert(T entity);
        void Exclude(int serialNumber);
        void Update(int serialNumber, SwitchState switchState);
    }
}
