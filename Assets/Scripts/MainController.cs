using UnityEngine;
using System.Collections;
using WarlikeStonesCore.Objects.Fileds;
using WarlikeStonesCore.Objects.Sequence;

public class MainController : MonoBehaviour
{

   QuadrField field;
   BaseStoneSequence sequence;

   public int tmp;
   public GameObject stoneTemplate;
   public Sprite redSprite;
   public Sprite greenSprite;
   public Sprite blueSprite;
   public Sprite yellowSprite;

   // Use this for initialization
   void Awake()
   {
      field = new QuadrField( 6, 5 );
      field.RandomFillField();

      Camera camera = Camera.main;
      float width = camera.pixelWidth;
      float height = camera.pixelHeight;

      Vector2 bottomLeft = camera.ScreenToWorldPoint( new Vector2( 0, 0 ) );
      Vector2 bottomRight = camera.ScreenToWorldPoint( new Vector2( width, 0 ) );
      Vector2 topLeft = camera.ScreenToWorldPoint( new Vector2( 0, height ) );
      Vector2 topRight = camera.ScreenToWorldPoint( new Vector2( width, height ) );

      GameObject new_stone = (GameObject)Instantiate( stoneTemplate, new Vector3( bottomLeft.x, bottomLeft.y, 0), Quaternion.identity );
      new_stone.GetComponent<SpriteRenderer>().sprite = redSprite;

      new_stone = (GameObject)Instantiate( stoneTemplate, new Vector3( bottomRight.x, bottomRight.y, 0 ), Quaternion.identity );
      new_stone.GetComponent<SpriteRenderer>().sprite = yellowSprite;

      new_stone = (GameObject)Instantiate( stoneTemplate, new Vector3( topLeft.x, topLeft.y, 0 ), Quaternion.identity );
      new_stone.GetComponent<SpriteRenderer>().sprite = blueSprite;

      new_stone = (GameObject)Instantiate( stoneTemplate, new Vector3( topRight.x, topRight.y, 0 ), Quaternion.identity );
      new_stone.GetComponent<SpriteRenderer>().sprite = greenSprite;

      Vector2 center = camera.ScreenToWorldPoint( new Vector2( width / 2, height / 2 ) );
      new_stone = (GameObject)Instantiate( stoneTemplate, new Vector3( center.x, center.y, 0 ), Quaternion.identity );
      new_stone.GetComponent<SpriteRenderer>().sprite = greenSprite;
     

      /*for( int i = 0; i < field.sizeX; i++ )
         for( int k = 0; k < field.sizeY; k++ )
      {
         GameObject new_stone = (GameObject)Instantiate( stoneTemplate, new Vector3( (float)( i * 1.2 ), (float)( k * 1.2 ), 0 ), Quaternion.identity );
         if( field.stones[i,k].TypeStone == WarlikeStonesCore.Objects.Constants.StoneType.stRed )
            new_stone.GetComponent<SpriteRenderer>().sprite = redSprite;
         else if( field.stones[i, k].TypeStone == WarlikeStonesCore.Objects.Constants.StoneType.stBlue )
            new_stone.GetComponent<SpriteRenderer>().sprite = blueSprite;
         else if( field.stones[i, k].TypeStone == WarlikeStonesCore.Objects.Constants.StoneType.stGreen )
            new_stone.GetComponent<SpriteRenderer>().sprite = greenSprite;
         else if( field.stones[i, k].TypeStone == WarlikeStonesCore.Objects.Constants.StoneType.stYellow )
            new_stone.GetComponent<SpriteRenderer>().sprite = yellowSprite;

         new_stone.GetComponent<StoneController>().posX = i;
         new_stone.GetComponent<StoneController>().posY = k;
      }*/

      sequence = new SimpleListSequence();
      sequence.Generate();

      

   }

   // Update is called once per frame
   void Update()
   {

   }
}
