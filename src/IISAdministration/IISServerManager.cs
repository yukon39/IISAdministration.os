using Microsoft.Web.Administration;
using ScriptEngine.Machine.Contexts;
using System;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISServerManager", typeAlias: "МенеджерСервераIIS")]
    public class IISServerManager : AutoContext<IISServerManager>, IObjectWrapper
    {
        private readonly ServerManager serverManager;
        private readonly Lazy<IISApplicationPoolCollection> applicationPools;

        [ScriptConstructor]
        public static IISServerManager ScriptConstructor()
            => new IISServerManager();

        [ScriptConstructor]
        public static IISServerManager ScriptConstructor(string applicationHostConfigurationPath)
            => new IISServerManager(applicationHostConfigurationPath);

        private IISServerManager(string applicationHostConfigurationPath)
            : this(new ServerManager(applicationHostConfigurationPath)) { }

        private IISServerManager()
            : this(new ServerManager()) { }

        private IISServerManager(ServerManager serverManager)
        {
            this.serverManager = new ServerManager();
            applicationPools = new Lazy<IISApplicationPoolCollection>(
                () => new IISApplicationPoolCollection(serverManager.ApplicationPools)
            );
        }

        [ContextMethod("CommitChanges", "ЗаписатьИзменения")]
        public void CommitChanges()
            => serverManager.CommitChanges();

        [ContextProperty("ApplicationPools", "ПулыПриложений")]
        public IISApplicationPoolCollection ApplicationPools
            => applicationPools.Value;

        public object UnderlyingObject
            => serverManager;
    }
}
