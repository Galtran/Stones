using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlikeStonesCore.Objects.Fileds;

namespace WarlikeStones
{
   class Program
   {
      static void Main(string[] args)
      {
         QuadrField field = new QuadrField(4, 3);
         field.RandomFillField();
         ConsolePrinter printer = new ConsolePrinter(field);
         printer.Print();

         System.Console.ReadLine();

         int i = 0;
         do
         {
            int x = Int32.Parse(System.Console.ReadLine());
            int y = Int32.Parse(System.Console.ReadLine());

            field.SafeSelectStone(field.stones[x, y]);
            printer.Print();
            i++;
         }
         while (i < 3);
      }
   }
}
