using MagicMirror.Abstractions;

namespace MagicMirror.Tests.Abstractions
{
    public class ObjectWrapper_Tests
    {
        internal class DummyClass
        {
            public DummyClass()
            {
                SomeList = new();
            }

            public List<int> SomeList { get; }

            public string SomeString { get; set; }
        }

        [Fact]
        public void Example()
        {
            var obj = new DummyClass();
            var wrapper = new ObjectWrapper(obj);

            var str = "Exemple";
            var prop = wrapper.Properties[nameof(DummyClass.SomeString)];
            Assert.Null(prop.Get());
            prop.Set(str);
            Assert.Equal(obj.SomeString, str);
            Assert.Equal(obj.SomeString, prop.Get());
            Assert.Equal(obj.SomeString, prop.GetAndCast<string>());

            var listWrapper = wrapper.Properties[nameof(DummyClass.SomeList)].GetAndWrap();
            obj.SomeList.AddRange([1, 2, 3, 4]);
            Assert.NotNull(listWrapper);
            Assert.Equal(obj.SomeList.Count, listWrapper.Properties[nameof(List<int>.Count)].GetAndCast<int>());
        }
    }
}
