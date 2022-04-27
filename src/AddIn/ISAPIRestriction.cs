using Microsoft.Web.Administration;
using ScriptEngine.Machine.Contexts;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "ISAPIRestriction", typeAlias: "ОграничениеISAPI")]
    public class ISAPIRestriction : AutoContext<ISAPIRestriction>, IObjectWrapper
    {
        private readonly ConfigurationElement element;

        internal ISAPIRestriction(ConfigurationElement element)
            => this.element = element;

        internal ISAPIRestriction(ConfigurationElement element, string path) 
            : this(element)
            => element["path"] = path;

        public object UnderlyingObject
            => element;

        [ContextProperty("Path", "Путь")]
        public string Path
            => (string)element["path"];

        [ContextProperty("Allowed", "Разрешено")]
        public bool Allowed
        {
            get => (bool)element["allowed"];
            set => element["allowed"] = value;
        }

        [ContextProperty("Description", "Описание")]
        public string Description
        {
            get => (string)element["description"];
            set => element["description"] = value;
        }
    }
}
