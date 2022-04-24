using Microsoft.Web.Administration;
using ScriptEngine.Machine.Contexts;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISApplicationPool", typeAlias: "ПулПриложенийIIS")]
    public class IISApplicationPool : AutoContext<IISApplicationPool>, IObjectWrapper
    {
        private readonly ApplicationPool applicationPool;

        public IISApplicationPool(ApplicationPool applicationPool)
            => this.applicationPool = applicationPool;

        public object UnderlyingObject
            => applicationPool;

        public override string AsString()
            => applicationPool.Name;

        [ContextProperty("Name", "Имя")]
        public string Name
            => applicationPool.Name;

        [ContextMethod("Rename", "Переименовать")]
        public string Rename(string newName)
            => applicationPool.Name = newName;

        [ContextProperty("Enable32BitAppOnWin64", "Разрешить32БитныеПриложения")]
        public bool Enable32BitAppOnWin64
        {
            get => applicationPool.Enable32BitAppOnWin64;
            set => applicationPool.Enable32BitAppOnWin64 = value;
        }

        [ContextProperty("ManagedPipelineMode", "РежимУправляемогоКонтейнера")]
        public string ManagedPipelineMode
            => applicationPool.ManagedPipelineMode.ToString();

        [ContextProperty("ManagedRuntimeVersion", "ВерсияУправляемойСреды")]
        public string ManagedRuntimeVersion
            => applicationPool.ManagedRuntimeVersion;

        [ContextProperty("AutoStart", "Автозапуск")]
        public bool AutoStart
            => applicationPool.AutoStart;

        [ContextProperty("State", "Состояние")]
        public string State
            => applicationPool.State.ToString();

        [ContextMethod("Start", "Запустить")]
        public void Start()
            => applicationPool.Start();

        [ContextMethod("Stop", "Остановить")]
        public void Stop()
            => applicationPool.Stop();

        [ContextMethod("Recycle", "Перезапустить")]
        public void Recycle()
            => applicationPool.Recycle();
    }
}
