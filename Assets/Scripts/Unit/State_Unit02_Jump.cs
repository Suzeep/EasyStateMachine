using UnityEngine;
using System.Collections;
using Holoville.HOTween;

//=====================================================================================
// class State_Unit02_Jump
//=====================================================================================
public class State_Unit02_Jump : State<Unit02, UNIT_STATE>
{
	//-------------------------------------------------------------------------------------
	// Enter
	//-------------------------------------------------------------------------------------
	public override void Enter()
	{
		m_Rno	= 0;
		m_PosY	= this.transform.position.y;
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
			parms.Prop( "position", new Vector3(0,2,0), true );
			parms.Ease( EaseType.EaseOutExpo );
			parms.Loops( 2, LoopType.Yoyo );

			m_Tweener = HOTween.To( this.transform, 0.6f, parms );
		}
			break;

		case 1:
		{
			if( m_Tweener.isComplete )
			{
				m_Rno	= 2;
				m_Timer	= 0.10f;
			}
		}
			break;

		case 2:
		{
			m_Timer -= Time.deltaTime;
			if( m_Timer < 0.0f )
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

		if( m_Tweener != null ){
			m_Tweener.Kill();
			m_Tweener = null;
		}

		var pos = this.transform.position;
		pos.y = m_PosY;
		this.transform.position = pos;
	}

	//=====================================================================================
	// member
	//=====================================================================================
	public int			m_Rno;
	public float		m_Timer;
	public float		m_PosY;
	private Tweener		m_Tweener;
}