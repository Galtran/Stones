using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarlikeStonesCore.Objects
{
   //Класс с константами
   public class Constants
   {
      public enum StoneType
      {
         stEmpty,
         stRed,
         stGreen,
         stYellow,
         stBlue,

         stMaxType
      }

      //Длина последовательности, которая создана в каждый момент времени
      public static int SimpleListSequenceCount = 20;
      //Минимальное число камней, которые можно удалить в данной последовательности
      public static int SimpleListSequenceMinCountCombination = 3;

      public static Random rnd = new Random();
   }
}
