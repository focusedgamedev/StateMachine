namespace SimpleStateMachine
{
	public interface IState
	{
		void OnStart( StateMachine sm );
		void Update();
		void OnFinish();
	}
}