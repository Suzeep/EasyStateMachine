using UnityEngine;
using System.Collections;

public class UnitChecker : MonoBehaviour
{
	// Start
	void Start()
	{
		setAction( UNIT_STATE.IDLE );
	}
	// OnGUI
	void OnGUI()
	{
		float w = Screen.width;
		float h = Screen.height;

		if( GUI.Button(new Rect(w*0.80f,h*0.10f,w*0.10f,h*0.10f),"Idle") ){
			setAction( UNIT_STATE.IDLE );
		}
		if( GUI.Button(new Rect(w*0.80f,h*0.20f,w*0.10f,h*0.10f),"Jump") ){
			setAction( UNIT_STATE.JUMP );
		}
	}

	// set action
	private void	setAction( UNIT_STATE state )
	{
		for( int i=0; i < m_Units.Length; ++i ){
			m_Units[ i ].SetAction( state );
		}
	}

	// member
	public UnitBase[]	m_Units;
}