using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlikeStonesCore.Objects.Sequence;

namespace WarlikeStonesCore.Objects.Fileds
{
   public class ConsolePrinter
   {
      QuadrField gameField;
      BaseStoneSequence seq;
      public ConsolePrinter(QuadrField field, BaseStoneSequence _seq)
      {
         gameField = field;
         seq = _seq;
      }

      public void PrintField()
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

      public void PrintSeq()
      {
         for (int i = 0; i < seq.GetSequence(5).Count; i++)
         {
            System.Console.Write(seq.GetSequence(5)[i].TypeStone.ToString() + " ");
            //System.Console.WriteLine();
         }

         System.Console.WriteLine();
      }
   }
}
