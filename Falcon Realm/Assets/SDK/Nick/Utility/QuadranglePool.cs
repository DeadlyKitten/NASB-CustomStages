namespace Nick
{
	public class QuadranglePool
	{
		public class QuadrangleMaker : Pool.ObjectGenerator<Quadrangle>
		{
			public override Quadrangle MakeObject()
			{
				return new Quadrangle();
			}
		}

		private static Pool.ObjectPool<Quadrangle> _pool;

		static QuadranglePool()
		{
			_pool = new Pool.ObjectPool<Quadrangle>(new QuadrangleMaker(), 128);
		}

		public static Quadrangle GetObject()
		{
			return _pool.GetObject();
		}

		public static void PutObject(Quadrangle o)
		{
			_pool.PutObject(o);
		}
	}
}
