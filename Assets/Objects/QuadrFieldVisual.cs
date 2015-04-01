using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlikeStonesCore.Objects.Fileds;
using UnityEngine;

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

	}
}
