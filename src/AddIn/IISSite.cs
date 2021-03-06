using Microsoft.Web.Administration;
using ScriptEngine.Machine.Contexts;
using System;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISSite", typeAlias: "СайтIIS")]
    public class IISSite : AutoContext<IISSite>, IObjectWrapper
    {
        private readonly Site site;
        private readonly Lazy<IISApplicationCollection> applications;

        public IISSite(Site site)
        {
            this.site = site;
            applications = new Lazy<IISApplicationCollection>(
                () => new IISApplicationCollection(site.Applications)
                );
        }

        public object UnderlyingObject 
            => site;

        public override string ToString()
            => site.ToString();

        public override string AsString()
            => site.ToString();

        [ContextProperty("Name", "Имя")]
        public string Name
            => site.Name;

        [ContextProperty("ID", "Идентификатор")]
        public decimal Id
            => site.Id;

        [ContextProperty("Applications", "Приложения")]
        public IISApplicationCollection Applications
            => applications.Value;

        [ContextProperty("State", "Состояние")]
        public string State
            => site.State.ToString();

        [ContextMethod("Start", "Запустить")]
        public void Start()
            => site.Start();

        [ContextMethod("Stop", "Остановить")]
        public void Stop()
            => site.Stop();
    }
}
