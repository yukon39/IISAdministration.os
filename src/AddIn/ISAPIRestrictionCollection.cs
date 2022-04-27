using Microsoft.Web.Administration;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine.Values;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace com.github.yukon39.IISAdministration
{
    [ContextClass(typeName: "ISAPIRestrictionCollection", typeAlias: "КоллекцияОграниченийISAPI")]
    public class ISAPIRestrictionCollection : AutoContext<ISAPIRestrictionCollection>, ICollectionContext, IEnumerable<ISAPIRestriction>, IObjectWrapper
    {
        private const string SECTION_PATH = "system.webServer/security/isapiCgiRestriction";

        private readonly ConfigurationElementCollection elements;
        private readonly List<ISAPIRestriction> restrictions = new List<ISAPIRestriction>();

        public ISAPIRestrictionCollection(ServerManager serverManager)
        {
            var config = serverManager.GetApplicationHostConfiguration();
            var section = config.GetSection(SECTION_PATH);
            elements = section.GetCollection();
            elements.ToList().ForEach(
                x => restrictions.Add(new ISAPIRestriction(x))
                );
        }

        public object UnderlyingObject
            => elements;

        [ContextMethod("Count", "Количество")]
        public int Count()
            => restrictions.Count;

        [ContextMethod("Get", "Получить")]
        public ISAPIRestriction Get(string path)
            => restrictions.FirstOrDefault(x => x.Path == path);

        [ContextMethod("CreateElement", "СоздатьЭлемент")]
        public ISAPIRestriction CreateElement(string path)
            => new ISAPIRestriction(elements.CreateElement(), path);

        [ContextMethod("Add", "Добавить")]
        public void Add(ISAPIRestriction restriction)
        {
            restrictions.Add(restriction);
            elements.Add((ConfigurationElement)restriction.UnderlyingObject);
        }

        [ContextMethod("Remove", "Удалить")]
        public void Remove(ISAPIRestriction restriction)
        {
            restrictions.Remove(restriction);
            elements.Remove((ConfigurationElement)restriction.UnderlyingObject);
        }

        [ContextMethod("Clear", "Очистить")]
        public void Clear()
        {
            restrictions.Clear();
            elements.Clear();
        }

        public override IValue GetIndexedValue(IValue index)
        {
            if (index.DataType != DataType.String)
                throw RuntimeException.InvalidArgumentType();

            var pool = Get(index.AsString());
            if (pool is ISAPIRestriction)
                return pool;
            else
                return UndefinedValue.Instance;
        }

        public IEnumerator<ISAPIRestriction> GetEnumerator()
           => restrictions.GetEnumerator();

        public CollectionEnumerator GetManagedIterator()
            => new CollectionEnumerator(GetEnumerator());

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
