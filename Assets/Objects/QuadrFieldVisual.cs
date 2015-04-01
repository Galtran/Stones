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

      public QuadrFieldVisual(int size_x, int size_y) :
         base(size_x, size_y)
      {
         objectStones = new GameObject[size_x, size_y];
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

	}
}
