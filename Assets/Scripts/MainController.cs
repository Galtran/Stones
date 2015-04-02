using UnityEngine;
using System.Collections;
using WarlikeStonesCore.Objects.Sequence;
using Assets.Objects;
using WarlikeStonesCore.Objects;

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
      float start_pos_y = topLeft.y;

      for( int i = 0; i < field.sizeX; i++ )
         for( int k = 0; k < field.sizeY; k++ )
      {
         GameObject new_stone = (GameObject)Instantiate(stoneTemplate, new Vector3((float)(i * 1.2) + start_pos_x + 0.5f, (float)(k * 1.2) - start_pos_y, 0), Quaternion.identity);
         new_stone.GetComponent<SpriteRenderer>().sprite = SpriteByType(field.GetStone(i, k).TypeStone);

         new_stone.GetComponent<StoneController>().stone = field.GetStone(i, k);
         new_stone.GetComponent<StoneController>().SetMainComntroller( this );

         field.SetObjectStone( i, k, new_stone );
      }

      sequence = new SimpleListSequence();
      sequence.Generate();

      start_pos_x = topLeft.x + 0.5f;

      var seq_stones = sequence.GetSequence( 8 );
      for (int i = 0; i < seq_stones.Count; i++)
      {
         GameObject new_stone = (GameObject)Instantiate( stoneTemplate, new Vector3( (float)( i * 1.2 ) + start_pos_x, topLeft.y - 0.5f, 0 ), Quaternion.identity );
         new_stone.GetComponent<SpriteRenderer>().sprite = SpriteByType(seq_stones[i].TypeStone);
         new_stone.GetComponent<StoneController>().stone = seq_stones[i];
      }
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void SelectStone( Stone selected_stone )
   {
      GameObject selected_obj = field.FindObjecByStone( selected_stone );
      selected_obj.GetComponent<SpriteRenderer>().color = selected_stone.Selected ? Color.grey : Color.white;

      Stone next_stone = sequence.GetNextStone();
      if (!(next_stone.TypeStone == selected_stone.TypeStone && field.SafeSelectStone(selected_stone)))
         sequence.ReduceByOneNextStone();


      if (field.GetSelectedStones().Count > 2)
      {
         System.Console.WriteLine("Clear:");
         sequence.DeleteStones(field.GetSelectedStones().Count);
         field.DeleteSelectStones();

         if (field.NeedRecalcSprite)
            RecalcSprite();
      }
   }

   private void RecalcSprite()
   {
      for (int i = 0; i < field.sizeX; i++)
         for (int k = 0; k < field.sizeY; k++)
         {
            SpriteRenderer tmp_obj_sprite_renderer = field.GetObjectStone(i, k).GetComponent<SpriteRenderer>();
            if (tmp_obj_sprite_renderer.sprite == null)
               tmp_obj_sprite_renderer.sprite = SpriteByType(field.GetStone(i, k).TypeStone);

         }

      field.NeedRecalcSprite = false;
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
