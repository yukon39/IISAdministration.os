using Microsoft.Web.Administration;
using ScriptEngine.Machine.Contexts;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISApplication", typeAlias: "ПриложениеIIS")]
    public class IISApplication : AutoContext<IISApplication>, IObjectWrapper
    {
        private readonly Application application;

        public IISApplication(Application application)
            => this.application = application;

        public object UnderlyingObject
            => application;

        public override string ToString()
            => application.ToString();

        public override string AsString()
            => application.ToString();

        [ContextProperty("Path", "Путь")]
        public string Path
            => application.Path;

        [ContextProperty("PhysicalPath", "ФизическийПуть")]
        public string PhysicalPath
            => application.VirtualDirectories["/"].PhysicalPath;


        [ContextProperty("ApplicationPoolName", "ИмяПулаПриложений")]
        public string ApplicationPoolName
        {
            get => application.ApplicationPoolName;
            set => application.ApplicationPoolName = value;
        }

    }
}
