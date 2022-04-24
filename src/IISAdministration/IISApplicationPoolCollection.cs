using Microsoft.Web.Administration;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine.Values;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISApplicationPoolCollection", typeAlias: "КоллекцияПуловПриложенийIIS")]
    public class IISApplicationPoolCollection : AutoContext<IISApplicationPoolCollection>, ICollectionContext, IEnumerable<IISApplicationPool>, IObjectWrapper
    {
        private readonly ApplicationPoolCollection applicationPools;
        private readonly List<IISApplicationPool> collection = new List<IISApplicationPool>();

        public IISApplicationPoolCollection(ApplicationPoolCollection applicationPools)
        {
            this.applicationPools = applicationPools;
            applicationPools.ToList().ForEach(
                x => collection.Add(new IISApplicationPool(x))
            );
        }

        public object UnderlyingObject
            => applicationPools;

        [ContextMethod("Count", "Количество")]
        public int Count()
            => applicationPools.Count;

        [ContextMethod("Get", "Получить")]
        public IISApplicationPool Get(string name)
            => collection.FirstOrDefault(x => x.Name == name);

        [ContextMethod("Add", "Добавить")]
        public IISApplicationPool Add(string name)
        {
            var appPool = applicationPools.Add(name);
            var item = new IISApplicationPool(appPool);
            collection.Add(item);
            return item;
        }

        [ContextMethod("Remove", "Удалить")]
        public void Remove(IISApplicationPool item)
        {
            var appPool = (ApplicationPool)item.UnderlyingObject;
            applicationPools.Remove(appPool);
            collection.Remove(item);
        }

        public override IValue GetIndexedValue(IValue index)
        {
            if (index.DataType != DataType.String)
                throw RuntimeException.InvalidArgumentType();

            var pool = Get(index.AsString());
            if (pool is IISApplicationPool)
                return pool;
            else
                return UndefinedValue.Instance;
        }

        public IEnumerator<IISApplicationPool> GetEnumerator()
            => collection.GetEnumerator();

        public CollectionEnumerator GetManagedIterator()
            => new CollectionEnumerator(GetEnumerator());

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
