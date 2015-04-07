using UnityEngine;
using System.Collections;
using WarlikeStonesCore.Objects;

public class StoneController : MonoBehaviour {

   Transform myTransform;

   MainController mainController;

   //Камень, за который отвечает контроллер
   public Stone stone;

	// Use this for initialization
	void Start () {
      myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   void OnMouseEnter()
   {
      myTransform.localScale = new Vector3( 1.1f, 1.1f, 1.1f );
   }

   void OnMouseExit()
   {
      myTransform.localScale = new Vector3( 1, 1, 1 );
   }

   void OnMouseDown()
   {
      if (!stone.Selected && mainController.SelectStone(stone))
         stone.Selected = !stone.Selected;
   }

   public void SetMainComntroller( MainController controller )
   {
      mainController = controller;
   }
}
