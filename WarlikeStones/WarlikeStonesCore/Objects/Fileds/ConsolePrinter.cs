using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarlikeStonesCore.Objects.Fileds
{
   public class ConsolePrinter
   {
      QuadrField gameField;
      public ConsolePrinter(QuadrField field)
      {
         gameField = field;
      }

      public void Print()
      {
         for( int i = 0; i < gameField.sizeX; i++ )
         {
            for (int k = 0; k < gameField.sizeY; k++)
            {
               System.Console.Write(gameField.stones[i, k].Selected ? gameField.stones[i, k].TypeStone.ToString().ToUpper() : gameField.stones[i, k].TypeStone.ToString() + " ");
            }
            System.Console.WriteLine();
         }

         System.Console.WriteLine();
      }
   }
}
