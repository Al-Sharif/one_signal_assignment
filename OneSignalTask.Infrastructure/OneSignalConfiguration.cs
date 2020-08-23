using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSignalTask.Infrastructure
{
    public class OneSignalConfiguration
    {
        public string AppId { get; set; }
        public string UserAuthKey { get; set; }
        public string BaseUrl { get; set; }
        public OneSignalRoutes AppRoutes { get; set; }
    }

    public class OneSignalRoutes
    {
        public string GetAll { get; set; }
        public string GetById { get; set; }
        public string Create { get; set; }
        public string Update { get; set; }
    }
}
