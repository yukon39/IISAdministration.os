using Microsoft.Web.Administration;
using ScriptEngine.Machine.Contexts;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISServerManager", typeAlias: "МенеджерСервераIIS")]
    public class IISServerManager : AutoContext<IISServerManager>, IObjectWrapper
    {
        private readonly ServerManager serverManager;

        [ScriptConstructor]
        public static IISServerManager ScriptConstructor()
            => new IISServerManager();

        private IISServerManager()
            => serverManager = new ServerManager();

        [ContextMethod("CommitChanges", "ЗаписатьИзменения")]
        public void CommitChanges()
            => serverManager.CommitChanges();

        public object UnderlyingObject 
            => serverManager;
    }
}
