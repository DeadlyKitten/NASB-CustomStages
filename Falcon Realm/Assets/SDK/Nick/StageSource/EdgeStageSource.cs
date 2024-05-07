namespace Nick
{
    public class EdgeStageSource : MonoStageSource
	{
		public EdgeColliderStageSource ecss;

		private void OnDrawGizmos()
		{
			ecss.gizmolines();
		}
	}
}
