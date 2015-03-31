using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   void OnMouseEnter()
   {
      Debug.Log( "enter" );
   }

   void OnMouseExit()
   {
      Debug.Log( "exit" );
   }

   void OnMouseDown()
   {
      Debug.Log( "clicked" );
   }
}
