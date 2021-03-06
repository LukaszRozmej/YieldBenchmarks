using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;

namespace YieldBenchmark
{
    [SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net60)]
    [MemoryDiagnoser]
    public class YieldBenchmark
    {
        [Params(100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000)]
        public int Count { get; set; }

        [Benchmark]
        public int Yield()        
        {
            int sum = 0;
            IEnumerable<int> enumerable = Gen(Count);
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }

        private IEnumerable<int> Gen(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return i;
            }
        }

        [Benchmark]
        public int Array()
        {
            int sum = 0;
            int[] enumerable = GenArr(Count);
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }
        
        [Benchmark]
        public int SpanArray()
        {
            int sum = 0;
            Span<int> enumerable = GenArr(Count).AsSpan();
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }

        [Benchmark]
        public int ArrayAsEnumerable()         
        {
            int sum = 0;
            IEnumerable<int> enumerable = GenArr(Count);
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }
        
        [Benchmark]
        public int ArrayFor()
        {
            int sum = 0;
            int[] enumerable = GenArr(Count);
            for (var index = 0; index < enumerable.Length; index++)
            {
                sum += enumerable[index];
            }

            return sum;
        }
        
        [Benchmark]
        public int SpanArrayFor()
        {
            int sum = 0;
            Span<int> enumerable = GenArr(Count).AsSpan();
            for (var index = 0; index < enumerable.Length; index++)
            {
                sum += enumerable[index];
            }

            return sum;
        }

        private int[] GenArr(int count)
        {
            int[] arr = new int[count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            return arr;
        }
        
        [Benchmark]
        public int ListPreAllocated()
        {
            int sum = 0;
            List<int> genArr = GenList(Count, true);
            foreach (int item in genArr)
            {
                sum += item;
            }

            return sum;
        }
        
        [Benchmark]
        public int ListPreAllocatedFor()
        {
            int sum = 0;
            List<int> genArr = GenList(Count, true);
            for (var index = 0; index < genArr.Count; index++)
            {
                sum += genArr[index];
            }

            return sum;
        }
        
        [Benchmark]
        public int ListAsEnumerablePreAllocated()
        {
            int sum = 0;
            IEnumerable<int> enumerable = GenList(Count, true);
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }
        
        [Benchmark]
        public int List()
        {
            int sum = 0;
            List<int> enumerable = GenList(Count, false);
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }
        
        [Benchmark]
        public int ListFor()
        {
            int sum = 0;
            List<int> enumerable = GenList(Count, false);
            for (var index = 0; index < enumerable.Count; index++)
            {
                sum += enumerable[index];
            }

            return sum;
        }

        [Benchmark]
        public int ListAsEnumerable()
        {
            int sum = 0;
            IEnumerable<int> enumerable = GenList(Count, false);
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }

        private List<int> GenList(int count, bool preAllocate)
        {
            List<int> list = preAllocate ? new(count) : new();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            return list;
        }

        [Benchmark]
        public int EnumerableWithStructEnumerator()
        {
            int sum = 0;
            IEnumerable<int> enumerable = GenEnumerableWithStructEnumerator(Count);
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }

        [Benchmark]
        public int EnumerableWithClassEnumerator()
        {
            int sum = 0;
            IEnumerable<int> enumerable = GenEnumerableWithClassEnumerator(Count);
            foreach (int item in enumerable)
            {
                sum += item;
            }

            return sum;
        }
        private IEnumerable<int> GenEnumerableWithStructEnumerator(int count) => new Enumerable(count, CreateStructEnumerator);
        private IEnumerable<int> GenEnumerableWithClassEnumerator(int count) => new Enumerable(count, CreateClassEnumerator);
        private IEnumerator<int> CreateStructEnumerator(int count) => new StructEnumeratorImpl(count);
        private IEnumerator<int> CreateClassEnumerator(int count) => new ClassEnumeratorImpl(count);

        [Benchmark]
        public int StructEnumerator()
        {
            int sum = 0;
            StructEnumeratorImpl enumerator = new StructEnumeratorImpl(Count);
            foreach (int item in enumerator)
            {
                sum += item;
            }

            return sum;
        }
        
        [Benchmark]
        public int ClassEnumerator()
        {
            int sum = 0;
            ClassEnumeratorImpl enumerator = new(Count);
            foreach (int item in enumerator)
            {
                sum += item;
            }

            return sum;
        }

        private struct StructEnumeratorImpl : IEnumerator<int>
        {
            private readonly int _count;
            private int _index;

            public StructEnumeratorImpl(int count)
            {
                _count = count;
                _index = -1;
            }

            public StructEnumeratorImpl GetEnumerator() => this;

            public bool MoveNext()
            {
                return _index++ < _count;
            }

            public void Reset()
            {
                _index = -1;
            }

            public int Current => _index;

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
        
        private class ClassEnumeratorImpl : IEnumerator<int>
        {
            private readonly int _count;
            private int _index;

            public ClassEnumeratorImpl(int count)
            {
                _count = count;
                _index = -1;
            }

            public ClassEnumeratorImpl GetEnumerator() => this;

            public bool MoveNext()
            {
                return _index++ < _count;
            }

            public void Reset()
            {
                _index = -1;
            }

            public int Current => _index;

            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
        
        private class Enumerable : IEnumerable<int>
        {
            private readonly int _count;
            private readonly Func<int, IEnumerator<int>> _enumeratorFactory;

            public Enumerable(int count, Func<int, IEnumerator<int>> enumeratorFactory)
            {
                _count = count;
                _enumeratorFactory = enumeratorFactory;
            }

            public IEnumerator<int> GetEnumerator() => _enumeratorFactory(_count);
            
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}