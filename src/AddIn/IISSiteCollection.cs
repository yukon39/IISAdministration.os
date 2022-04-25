using Microsoft.Web.Administration;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine.Values;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "IISSiteCollection", typeAlias: "КоллекцияСайтовIIS")]
    public class IISSiteCollection : AutoContext<IISSiteCollection>, ICollectionContext, IEnumerable<IISSite>, IObjectWrapper
    {
        private readonly SiteCollection sites;
        private readonly List<IISSite> collection = new List<IISSite>();

        public IISSiteCollection(SiteCollection sites)
        {
            this.sites = sites;
            sites.ToList().ForEach(
                x => collection.Add(new IISSite(x))
                );
        }

        public object UnderlyingObject 
            => sites;

        [ContextMethod("Count", "Количество")]
        public int Count() 
            => collection.Count;
        
        [ContextMethod("Get", "Получить")]
        public IValue Get(IValue value)
        {
            IISSite site = default;
            if (value.DataType == DataType.Number)
                site = Get(value.AsNumber());
            else if (value.DataType == DataType.String)
                site = Get(value.AsString());

            if (site is IISSite)
                return site;
            else
                return UndefinedValue.Instance;
        }

        public IISSite Get(string name)
            => collection.FirstOrDefault(x => x.Name == name);

        public IISSite Get(decimal Id)
            => collection.FirstOrDefault(x => x.Id == Id);

        [ContextMethod("First", "Первый")]
        public IValue First()
        {
            var site = collection.FirstOrDefault( x => x.Id == 1);
            if (site is IISSite)
                return site;
            else
                return UndefinedValue.Instance;
        }

        public override IValue GetIndexedValue(IValue index)
            => Get(index);

        public IEnumerator<IISSite> GetEnumerator()
            => collection.GetEnumerator();

        public CollectionEnumerator GetManagedIterator()
            => new CollectionEnumerator(GetEnumerator());

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
