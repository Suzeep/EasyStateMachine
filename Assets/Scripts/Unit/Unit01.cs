using UnityEngine;
using System.Collections.Generic;

//=====================================================================================
// class Unit01
//=====================================================================================
public class Unit01 : UnitBaseT<Unit01>
{
	//-------------------------------------------------------------------------------------
	// Awake
	//-------------------------------------------------------------------------------------
	void Awake()
	{
		Init();

		Stater.Add( UNIT_STATE.IDLE, typeof(State_Unit01_Idle), this );
		Stater.Add( UNIT_STATE.JUMP, typeof(State_Unit01_Jump), this );
	}
}