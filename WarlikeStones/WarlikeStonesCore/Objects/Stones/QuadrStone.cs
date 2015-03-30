using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarlikeStonesCore.Objects.Stones
{
   //Камень на квадратном поле
   public class QuadrStone: Stone
   {
      private int coordX;
      public int X
      {
         get { return coordX; }
         set { coordX = value; }
      }
      private int coordY;
      public int Y
      {
         get { return coordY; }
         set { coordY = value; }
      }

      public QuadrStone(Constants.StoneType type, int x, int y) :
         base(type)
      {
         coordX = x;
         coordY = y;
      }
   }
}
