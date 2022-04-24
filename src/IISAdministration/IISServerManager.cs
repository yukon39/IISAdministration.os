using Microsoft.Web.Administration;
using ScriptEngine.Machine.Contexts;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISServerManager", typeAlias: "МенеджерСервераIIS")]
    public class IISServerManager : AutoContext<IISServerManager>, IObjectWrapper
    {
        private readonly ServerManager serverManager;
        private readonly IISApplicationPoolCollection applicationPools;

        [ScriptConstructor]
        public static IISServerManager ScriptConstructor()
            => new IISServerManager();

        private IISServerManager()
        {
            serverManager = new ServerManager();
            applicationPools = new IISApplicationPoolCollection(serverManager.ApplicationPools);
        }

        [ContextMethod("CommitChanges", "ЗаписатьИзменения")]
        public void CommitChanges()
            => serverManager.CommitChanges();

        [ContextProperty("ApplicationPools", "ПулыПриложений")]
        public IISApplicationPoolCollection ApplicationPools
            => applicationPools;

        public object UnderlyingObject
            => serverManager;
    }
}
