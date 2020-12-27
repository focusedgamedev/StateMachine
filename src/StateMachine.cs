using System;
using System.Collections.Generic;

namespace SimpleStateMachine
{
	public class StateMachine
	{
		Dictionary<int, IState> m_states = new Dictionary<int, IState>();

		IState m_currentState = null;
		IState m_nextState = null;

		public void AddState( int key, IState state )
		{
			try
			{
				m_states.Add( key, state );
			}
			catch( Exception e )
			{
				throw e;
			}
		}

		public void SetState( int key )
		{
			IState state;
			if ( m_states.TryGetValue( key, out state ) )
			{
				if ( m_currentState != null )
				{
					m_currentState.OnFinish();
				}

				m_nextState = state;
			}
		}

		public void Update()
		{
			if ( m_nextState != null )
			{
				m_nextState.OnStart( this );
				m_currentState = m_nextState;
				m_nextState = null;
			}

			if ( m_currentState != null )
			{
				m_currentState.Update();
			}
		}

		public void Shutdown()
		{
			if (m_currentState != null)
			{
				m_currentState.OnFinish();
				m_currentState = null;
			}

			m_states.Clear();
		}
	}
}