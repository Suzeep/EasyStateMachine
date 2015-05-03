using UnityEngine;
using System.Collections.Generic;

//=====================================================================================
// class UnitBaseT
//=====================================================================================
public class UnitBaseT<T> : UnitBase where T : MonoBehaviour
{
	//-------------------------------------------------------------------------------------
	// set action
	//-------------------------------------------------------------------------------------
	public override void		SetAction( UNIT_STATE state )
	{
		m_State		= state;
		m_IsAction	= true;

		m_Stater.Change( state );
	}
	
	//=====================================================================================
	// property
	//=====================================================================================
	public StateMachine<UNIT_STATE, T>	Stater {
		get { return m_Stater; }
	}

	//=====================================================================================
	// member
	//=====================================================================================
	public UNIT_STATE					m_State;
	private StateMachine<UNIT_STATE, T>	m_Stater = new StateMachine<UNIT_STATE, T>();
}