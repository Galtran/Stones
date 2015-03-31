using UnityEngine;
using System.Collections;

public class StoneController : MonoBehaviour {

   Transform myTransform;

   public int posX;
   public int posY;

	// Use this for initialization
	void Start () {
      myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   void OnMouseEnter()
   {
      myTransform.localScale = new Vector3( 2, 2, 2 );
   }

   void OnMouseExit()
   {
      myTransform.localScale = new Vector3( 1, 1, 1 );
   }

   void OnMouseDown()
   {
      //myTransform.localScale = new Vector3( 2, 2, 2 );
   }
}
