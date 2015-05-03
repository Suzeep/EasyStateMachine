using UnityEngine;
using System.Collections.Generic;

//=====================================================================================
// class Unit00
//=====================================================================================
public class Unit00 : UnitBaseT<Unit00>
{
	//-------------------------------------------------------------------------------------
	// Awake
	//-------------------------------------------------------------------------------------
	void Awake()
	{
		Init();

		Stater.Add( UNIT_STATE.IDLE, typeof(State_Unit00_Idle), this );
		Stater.Add( UNIT_STATE.JUMP, typeof(State_Unit00_Jump), this );
	}
}