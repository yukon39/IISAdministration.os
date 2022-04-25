using Microsoft.Web.Administration;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine.Values;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISApplicationCollection", typeAlias: "КоллекцияПриложенийIIS")]
    public class IISApplicationCollection : AutoContext<IISApplicationCollection>, ICollectionContext, IEnumerable<IISApplication>, IObjectWrapper
    {
        private readonly ApplicationCollection applications;
        private readonly List<IISApplication> collection = new List<IISApplication>();

        public IISApplicationCollection(ApplicationCollection applications)
        {
            this.applications = applications;
            applications.ToList().ForEach(
                x => collection.Add(new IISApplication(x))
            );
        }

        public object UnderlyingObject 
            => applications;

        [ContextMethod("Count", "Количество")]
        public int Count() 
            => applications.Count;

        [ContextMethod("Add", "Добавить")]
        public IISApplication Add(string path, string physicalPath)
        {
            var application = applications.Add(path, physicalPath);
            var item = new IISApplication(application);
            collection.Add(item);
            return item;
        }

        [ContextMethod("Get", "Получить")]
        public IISApplication Get(string path)
            => collection.FirstOrDefault(x => x.Path == path);

        public override IValue GetIndexedValue(IValue index)
        {
            if (index.DataType != DataType.String)
                throw RuntimeException.InvalidArgumentType();

            var item = Get(index.AsString());
            if (item is IISApplication)
                return item;
            else
                return UndefinedValue.Instance;
        }

        public IEnumerator<IISApplication> GetEnumerator()
            => collection.GetEnumerator();

        public CollectionEnumerator GetManagedIterator()
            => new CollectionEnumerator(GetEnumerator());

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
