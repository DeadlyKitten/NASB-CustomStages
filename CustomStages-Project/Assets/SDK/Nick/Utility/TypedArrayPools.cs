using System.Collections.Generic;

namespace Nick
{
	public class TypedArrayPools<T>
	{
		public class ArrayPool<TT>
		{
			public class TTMaker : Pool.ObjectGenerator<TT[]>
			{
				public int arraySize;

				public TTMaker(int size)
				{
					arraySize = size;
				}

				public override TT[] MakeObject()
				{
					return new TT[arraySize];
				}
			}

			public int arraySize;

			private Pool.ObjectPool<TT[]> pool;

			public ArrayPool(int size)
			{
				arraySize = size;
				pool = new Pool.ObjectPool<TT[]>(new TTMaker(size), 2);
			}

			public TT[] GetArray()
			{
				return pool.GetObject();
			}

			public void PutArray(TT[] array)
			{
				if (array != null)
				{
					pool.PutObject(array);
				}
			}

			public void PutArrayClear(TT[] array)
			{
				if (array != null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = default(TT);
					}
					pool.PutObject(array);
				}
			}
		}

		private Dictionary<int, ArrayPool<T>> pools;

		private T[] zeroArray;

		public TypedArrayPools()
		{
			pools = new Dictionary<int, ArrayPool<T>>();
			zeroArray = new T[0];
		}

		public T[] GetArray(int size)
		{
			if (size == 0)
			{
				return zeroArray;
			}
			if (!pools.ContainsKey(size))
			{
				pools.Add(size, new ArrayPool<T>(size));
			}
			return pools[size].GetArray();
		}

		public void PutArray(T[] arr)
		{
			if (arr.Length != 0)
			{
				if (!pools.ContainsKey(arr.Length))
				{
					pools.Add(arr.Length, new ArrayPool<T>(arr.Length));
				}
				pools[arr.Length].PutArray(arr);
			}
		}

		public void PutArrayClear(T[] arr)
		{
			if (arr.Length != 0)
			{
				if (!pools.ContainsKey(arr.Length))
				{
					pools.Add(arr.Length, new ArrayPool<T>(arr.Length));
				}
				pools[arr.Length].PutArrayClear(arr);
			}
		}
	}
}
