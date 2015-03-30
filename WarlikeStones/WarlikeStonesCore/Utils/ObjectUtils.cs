using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlikeStonesCore.Objects;

namespace WarlikeStonesCore.Utils
{
   public class ObjectUtils
   {
      public static Stone GenerateRandomStone(Random rnd)
      {
         return new Stone((Constants.StoneType)(rnd.Next((int)Constants.StoneType.stMaxType - 1) + 1));
      }
   }
}
