// By Juan Mendoza 30/08/2015

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("Sends an Event when a serie of buttons and axis are pressed")]
	public class ComboEvent : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The name of the button. Set in the Unity Input Manager.")]
		public FsmString buttonName1;
		
		[RequiredField]
        [Tooltip("The name of the button. Set in the Unity Input Manager.")]
		public FsmString buttonName2;
		
        [Tooltip("The name of the button. Set in the Unity Input Manager.")]
		public FsmString buttonName3;
		
		[Tooltip("Horizontal axis as defined in the Input Manager")]
		public FsmString horizontalAxis;
		
		[Tooltip("Vertical axis as defined in the Input Manager")]
		public FsmString verticalAxis;
		
		[Tooltip("Up axis too?")]
		public FsmBool up;
		
		[Tooltip("Down axis too?")]
		public FsmBool down;
		
		[Tooltip("Left axis too?")]
		public FsmBool left;
		
		[Tooltip("Right axis too?")]
		public FsmBool right;
		
		[Tooltip("Event to send if the button is pressed.")]
		public FsmEvent sendEvent;
		
		public override void Reset()
		{
			buttonName1 = "Fire1";
			buttonName2= "Fire2";
			buttonName3="Fire3";
			horizontalAxis = "Horizontal";
			verticalAxis = "Vertical";
			sendEvent = null;
		}

		public override void OnUpdate()
		{
			var button1 = Input.GetButton(buttonName1.Value);
			var button2= Input.GetButton(buttonName2.Value);
			var button3= false;
			var up_value=false;
			var down_value=false;
			var left_value=false;
			var right_value=false;
			
			if (buttonName3.IsNone)
			{
				button3= true;
			}
			else
			{
				button3=Input.GetButton(buttonName3.Value);
			}
			//AXIS
			var vertical = Input.GetAxis(verticalAxis.Value);
			var horizontal= Input.GetAxis(horizontalAxis.Value);
			if (up.Value==false)
			{
				up_value=true;
			}
			else
			{
				if (vertical>0)
				{
					up_value=true;
				}
				
			}
			///////////
			if (down.Value==false)
			{
				down_value=true;
			}
			else
			{
				if (vertical<0)
				{
					down_value=true;
				}
			}
			/////
			if (left.Value==false)
			{
				left_value=true;
			}
			else
			{
				if (horizontal<0)
				{
					left_value=true;
				}
			}
			/////////
			if (right.Value==false)
			{
				right_value=true;
			}
			else
			{
				if (horizontal>0)
				{
					right_value=true;
				}
			}
			//MAIN
			if (button1 & button2 & button3 & up_value & down_value & left_value & right_value)
			{
			    Fsm.Event(sendEvent);
			}
			
		}
	}
}