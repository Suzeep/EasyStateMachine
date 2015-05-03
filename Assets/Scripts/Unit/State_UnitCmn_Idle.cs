using UnityEngine;
using System.Collections;
using Holoville.HOTween;

//=====================================================================================
// class State_UnitCmn_Idle
//=====================================================================================
public class State_UnitCmn_Idle<T> : State<T, UNIT_STATE> where T : UnitBaseT<T>
{
	//-------------------------------------------------------------------------------------
	// Enter
	//-------------------------------------------------------------------------------------
	public override void Enter()
	{
		m_Rno = 0;
	}
	//-------------------------------------------------------------------------------------
	// Update
	//-------------------------------------------------------------------------------------
	void Update()
	{
		switch( m_Rno )
		{
		case 0:
		{
			m_Rno = 1;

			var parms = new TweenParms();

			parms.Prop( "localScale", new Vector3(1.3f,1.3f,1.3f) );
			parms.Ease( EaseType.EaseOutBounce );

			m_Tweener = HOTween.To( this.transform, 0.80f, parms );
		}
			break;

		case 1:
		{
			if( m_Tweener.isComplete )
			{
				m_Rno = 2;

				var parms = new TweenParms();
				
				parms.Prop( "localScale", new Vector3(1,1,1) );
				parms.Ease( EaseType.Linear );
				
				m_Tweener = HOTween.To( this.transform, 0.30f, parms );
			}
		}
			break;

		case 2:
		{
			if( m_Tweener.isComplete )
			{
				m_Rno = 0;
			}
		}
			break;
		}
	}
	//-------------------------------------------------------------------------------------
	// Exit
	//-------------------------------------------------------------------------------------
	public override void Exit()
	{
		Owner.m_IsAction = false;

		this.transform.localScale = Vector3.one;

		if( m_Tweener != null ){
			m_Tweener.Kill();
			m_Tweener = null;
		}
	}

	//=====================================================================================
	// member
	//=====================================================================================
	public int			m_Rno;
	private Tweener		m_Tweener;
}