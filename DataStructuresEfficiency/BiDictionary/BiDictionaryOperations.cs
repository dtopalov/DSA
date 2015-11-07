namespace BiDictionary
{
    using System;

    using Wintellect.PowerCollections;

    class BiDictionaryOperations
    {
        static void Main()
        {
            var biDictionary =
                new BiDictionary<int, string, DateTime>(
                    new MultiDictionary<int, Triple<int, string, DateTime>>(true),
                    new MultiDictionary<string, Triple<int, string, DateTime>>(true),
                    new MultiDictionary<CompositeKey<int, string>, Triple<int, string, DateTime>>(true));

            biDictionary.AddByFirstKey(1, new Triple<int, string, DateTime>(1, "one", DateTime.Today));
            biDictionary.AddBySecondKey("two", new Triple<int, string, DateTime>(2, "two", DateTime.Today));
            biDictionary.AddByCompositeKey(new CompositeKey<int, string>(3, "three"), new Triple<int, string, DateTime>(3, "three", DateTime.Today));

            Console.WriteLine("Elements: " + biDictionary.Count);
            Console.WriteLine("T1 keys: " + string.Join(", ", biDictionary.KeysT1));
            Console.WriteLine("T2 keys: " + string.Join(", ", biDictionary.KeysT2));
            Console.WriteLine("Composite keys: " + string.Join(", ", biDictionary.KeysComposite));

            foreach (var key in biDictionary)
            {
                foreach (var triple in key.Value)
                {
                    Console.WriteLine($"Triple: K1: {triple.FirstKey}; K2: {triple.SecondKey}; V: {triple.Value}");
                }
            }
        }
    }
}
