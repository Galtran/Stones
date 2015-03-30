using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlikeStonesCore.Objects.Fileds;
using WarlikeStonesCore.Objects.Sequence;
using WarlikeStonesCore.Objects;

namespace WarlikeStones
{
   class Program
   {
      static void Main(string[] args)
      {
         QuadrField field = new QuadrField(4, 3);
         field.RandomFillField();
         BaseStoneSequence seq = new SimpleListSequence();
         seq.Generate();

         ConsolePrinter printer = new ConsolePrinter(field, seq);
         printer.PrintField();
         System.Console.WriteLine();
         printer.PrintSeq();

         int i = 0;
         do
         {
            int x = Int32.Parse(System.Console.ReadLine());
            if (x == 100)
               break;
            int y = Int32.Parse(System.Console.ReadLine());

            Stone next_stone = seq.GetNextStone();
            if (!(next_stone.TypeStone == field.stones[x, y].TypeStone && field.SafeSelectStone(field.stones[x, y])))
               seq.ReduceByOneNextStone();
            
            printer.PrintField();

            if (field.GetSelectedStones().Count > 1)
            {
               System.Console.WriteLine("Clear:");
               seq.DeleteStones(field.GetSelectedStones().Count);
               field.DeleteSelectStones();

               printer.PrintField();
               printer.PrintSeq();
            }
            i++;
         }
         while (true);
      }
   }
}
