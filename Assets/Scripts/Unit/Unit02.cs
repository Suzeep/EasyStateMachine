using UnityEngine;
using System.Collections.Generic;

//=====================================================================================
// class Unit02
//=====================================================================================
public class Unit02 : UnitBaseT<Unit02>
{
	//-------------------------------------------------------------------------------------
	// Awake
	//-------------------------------------------------------------------------------------
	void Awake()
	{
		Init();

		Stater.Add( UNIT_STATE.IDLE, typeof(State_Unit02_Idle), this );
		Stater.Add( UNIT_STATE.JUMP, typeof(State_Unit02_Jump), this );
	}
}