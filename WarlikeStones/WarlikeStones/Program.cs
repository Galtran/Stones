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
      }
   }
}
