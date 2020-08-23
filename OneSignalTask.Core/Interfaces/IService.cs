using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OneSignalTask.Core
{
    public interface IAppService
    {
        #region DB Crud Operations
        List<App> GetAll();
        App Get(Expression<Func<App, bool>> expression);
        App Create(AppViewModel input);
        bool Update(AppViewModel app);
        bool Delete(App app);
        bool IsExist(string id);
        #endregion
        #region One Signal APIs
        List<AppViewModel> GetAllApi();
        AppViewModel GetByIdApi(string id);
        AppViewModel UpdateApi(AppInputModel input);
        AppViewModel CreateApi(AppInputModel input);
        #endregion
    }
}
