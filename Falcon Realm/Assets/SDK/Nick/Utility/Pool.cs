using System;

namespace Nick
{
	public class Pool
	{
		public class ObjectGenerator<T>
		{
			public virtual T MakeObject()
			{
				return default(T);
			}
		}

		public class ObjectPool<T>
		{
			private T[] _stackArray;

			private int _top;

			private ObjectGenerator<T> _objMaker;

			public int CurrentCount => _top + 1;

			public ObjectPool(ObjectGenerator<T> objectGenerator, int startSize = 16)
			{
				if (objectGenerator == null)
				{
					throw new ArgumentNullException("objectGenerator");
				}
				if (startSize < 1)
				{
					startSize = 1;
				}
				_stackArray = new T[startSize];
				_objMaker = objectGenerator;
				for (int i = 0; i < startSize; i++)
				{
					_stackArray[i] = _objMaker.MakeObject();
				}
				_top = startSize - 1;
			}

			public T GetObject()
			{
				if (_top == -1)
				{
					return _objMaker.MakeObject();
				}
				T result = _stackArray[_top];
				_stackArray[_top--] = default(T);
				return result;
			}

			public void PutObject(T item)
			{
				if (item != null)
				{
					if (_top == _stackArray.Length - 1)
					{
						T[] array = new T[_stackArray.Length * 2];
						Array.Copy(_stackArray, array, _stackArray.Length);
						_stackArray = array;
					}
					_stackArray[++_top] = item;
				}
			}
		}
	}
}
