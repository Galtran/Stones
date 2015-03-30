using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarlikeStonesCore.Objects
{
   //Базовый класс камня
   public class Stone
   {
      //Тип камня
      private Constants.StoneType typeStone;
      public Constants.StoneType TypeStone
      {
         get { return typeStone; }
         set { typeStone = value; }
      }

      //Выбран ли
      private bool isSelected;
      public bool Selected
      {
         get { return isSelected; }
         set { isSelected = value; }
      }

      public Stone(Constants.StoneType type)
      {
         typeStone = type;
      }
   }
}
