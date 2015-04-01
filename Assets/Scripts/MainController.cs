using UnityEngine;
using System.Collections;
using WarlikeStonesCore.Objects.Sequence;
using Assets.Objects;

public class MainController : MonoBehaviour
{

   QuadrFieldVisual field;
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
      field = new QuadrFieldVisual(6, 5);
      field.RandomFillField();

      Camera camera = Camera.main;
      float width = camera.pixelWidth;
      float height = camera.pixelHeight;

      Vector2 bottomLeft = camera.ScreenToWorldPoint( new Vector2( 0, 0 ) );
      Vector2 bottomRight = camera.ScreenToWorldPoint( new Vector2( width, 0 ) );
      Vector2 topLeft = camera.ScreenToWorldPoint( new Vector2( 0, height ) );
      Vector2 topRight = camera.ScreenToWorldPoint( new Vector2( width, height ) );

      /*GameObject new_stone = (GameObject)Instantiate( stoneTemplate, new Vector3( bottomLeft.x, bottomLeft.y, 0), Quaternion.identity );
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
     */

      float start_pos_x = topLeft.x;
      float start_pos_y = topLeft.y + 3;

      for( int i = 0; i < field.sizeX; i++ )
         for( int k = 0; k < field.sizeY; k++ )
      {
         GameObject new_stone = (GameObject)Instantiate(stoneTemplate, new Vector3((float)(i * 1.2) + start_pos_x, (float)(k * 1.2) + start_pos_y, 0), Quaternion.identity);
         new_stone.GetComponent<SpriteRenderer>().sprite = SpriteByType(field.stones[i, k].TypeStone);

         new_stone.GetComponent<StoneController>().stone = field.stones[i, k];
      }

      sequence = new SimpleListSequence();
      sequence.Generate();

      start_pos_x = topLeft.x;

      var seq_stones = sequence.GetSequence( 8 );
      for (int i = 0; i < seq_stones.Count; i++)
      {
         GameObject new_stone = (GameObject)Instantiate(stoneTemplate, new Vector3((float)(i * 1.2) + start_pos_x, 0, 0), Quaternion.identity);
         new_stone.GetComponent<SpriteRenderer>().sprite = SpriteByType(seq_stones[i].TypeStone);
         new_stone.GetComponent<StoneController>().stone = seq_stones[i];
      }
   }

   // Update is called once per frame
   void Update()
   {

   }

   Sprite SpriteByType(WarlikeStonesCore.Objects.Constants.StoneType type)
   {
      switch (type)
      {
         case WarlikeStonesCore.Objects.Constants.StoneType.stRed:
            return redSprite;
         case WarlikeStonesCore.Objects.Constants.StoneType.stBlue:
            return blueSprite;
         case WarlikeStonesCore.Objects.Constants.StoneType.stGreen:
            return greenSprite;
         case WarlikeStonesCore.Objects.Constants.StoneType.stYellow:
            return yellowSprite;
         default:
            return null;
      }
   }
}
