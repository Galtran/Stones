using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlikeStonesCore.Objects.Fileds;
using UnityEngine;
using WarlikeStonesCore.Objects;
using WarlikeStonesCore.Objects.Stones;

namespace Assets.Objects
{
	public class QuadrFieldVisual : QuadrField
	{

      GameObject[,] objectStones;

      private bool needRecalcSprite;
      public bool NeedRecalcSprite
      {
         get { return needRecalcSprite; }
         set { needRecalcSprite = value; }
      }

      public QuadrFieldVisual(int size_x, int size_y) :
         base(size_x, size_y)
      {
         objectStones = new GameObject[size_x, size_y];
      }

      public GameObject GetObjectStone(int x, int y)
      {
         return objectStones[x, y];
      }

      public void SetObjectStone(int x, int y, GameObject obj)
      {
         objectStones[x, y] = obj;
      }

      public GameObject FindObjecByStone( Stone stone )
      {
         QuadrStone q_stone = (QuadrStone)stone;
         return objectStones[q_stone.X, q_stone.Y];
      }

      public override int DeleteSelectStones()
      {
         var selected = GetSelectedStones();
         int res = base.DeleteSelectStones();

         foreach (QuadrStone item in GetSelectedStones())
         {
            GameObject stone_object = objectStones[item.X, item.Y];
            stone_object.GetComponent<SpriteRenderer>().sprite = null;
            stone_object.GetComponent<StoneController>().stone = GetStone(item.X, item.Y);
         }

         needRecalcSprite = true;

         return res;
      }

	}
}
