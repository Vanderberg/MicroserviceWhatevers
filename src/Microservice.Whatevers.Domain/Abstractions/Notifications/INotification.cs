using System.Collections;
using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public interface INotification
    {
        void AddError(string error);
        void AddError(INotification notification);
        void AddError(string error, INotification externalNofification);
        void AddErrors(IEnumerable<INotification> notifications);
        void AddErrors(IEnumerable<string> errors);
        void GetError();
        IEnumerable<string> GetErrors();
    }
}