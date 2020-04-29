using System.Collections.Generic;
using System.Linq;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public class Notification: INotification
    {
        private readonly List<string> _errrors = new List<string>();
        
        public void AddError(string error) => _errrors.Add(error);

        public void AddError(INotification notification) => AddErrors(notification?.GetErrors());
        
        public void AddError(string error, INotification externalNofification)
        {
            AddError(error);
            AddErrors(externalNofification?.GetErrors());
        }

        public void AddErrors(IEnumerable<INotification> notifications) =>
            AddErrors(notifications?.SelectMany(notification => notification?.GetErrors()));        

        public void AddErrors(IEnumerable<string> errors)
        {
            if (errors is null) return;
            
            _errrors.AddRange(errors);
         }

        public IEnumerable<string> GetErrors() => _errrors;

        public void GetError() => string.Join(", ", _errrors);
    }
}