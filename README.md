# StateMachine

## Example Usage

```
using SimpleStateMachine;

enum State
{
	Init,
	Running
}

public class InitState : IState
{
	StateMachine m_stateMachine; 
	public void OnStart( StateMachine sm )
	{
		m_stateMachine = sm;
	}
	
	public void Update()
	{
		//Update once, then transition to the running state
		stateMachine.SetState( (int)State.Running );
	}
	
	public void OnFinish(){}
}

public class RunningState : IState
{
	StateMachine m_stateMachine; 
	public void OnStart( StateMachine sm )
	{
		m_stateMachine = sm;
	}
	
	public void Update(){}
	public void OnFinish(){}
}


// ------------------------------------------------
StateMachine stateMachine = new StateMachine();
stateMachine.AddState( (int)State.Init, new InitState() ); 
stateMachine.AddState( (int)State.Running, new RunningState() ); 
stateMachine.SetState( (int)State.Init );

while( true )
{
	stateMachine.Update();
}
```

