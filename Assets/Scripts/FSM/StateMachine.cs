using UnityEngine;
using System.Collections.Generic;

//=====================================================================================
// class StateMachine<T_STATE, T_OWNER>
//=====================================================================================
public class StateMachine<T_STATE, T_OWNER> where T_OWNER : MonoBehaviour
{
	//-------------------------------------------------------------------------------------
	// add state
	//-------------------------------------------------------------------------------------
	public void		Add( T_STATE no, System.Type type, T_OWNER owner )
	{
		var state = owner.gameObject.AddComponent(type) as State<T_OWNER, T_STATE>;

		state.Owner		= owner;
		state.No		= no;
		state.enabled	= false;

		m_StateList.Add( no, state );
	}
	
	//-------------------------------------------------------------------------------------
	// change state
	//-------------------------------------------------------------------------------------
	public void		Change( T_STATE no )
	{
		// call finalyze on current state
		if( m_StateList.ContainsKey(m_CurrentNo) )
		{
			State<T_OWNER, T_STATE> current_state = m_StateList[ m_CurrentNo ];
			current_state.Exit();
			current_state.enabled = false;
		}
		
		// call initialize on next state
		if( m_StateList.ContainsKey(no) )
		{
			State<T_OWNER, T_STATE> next_state = m_StateList[ no ];
			next_state.Enter();
			next_state.enabled = true;
			
			m_CurrentNo = no;	// change current no
		}
	}
	
	//=====================================================================================
	// property
	//=====================================================================================
	public T_STATE		CurrentNo { get { return m_CurrentNo; } }
	public Dictionary<T_STATE, State<T_OWNER, T_STATE>>		StateList { get { return m_StateList; } }
	
	//=====================================================================================
	// member
	//=====================================================================================
	private T_STATE		m_CurrentNo;
	private Dictionary<T_STATE, State<T_OWNER, T_STATE>>	m_StateList = new Dictionary<T_STATE, State<T_OWNER, T_STATE>>();
}