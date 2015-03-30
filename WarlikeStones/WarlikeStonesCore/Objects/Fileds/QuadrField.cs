using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlikeStonesCore.Utils;
using WarlikeStonesCore.Objects.Stones;

namespace WarlikeStonesCore.Objects.Fileds
{
   //Обычное квадратное поле, связи в 4 стороны
   public class QuadrField : BaseFieldStones
   {
      //Размеры поля
      public int sizeX;
      public int sizeY;
      public Stone[,] stones;

      public QuadrField(int size_x, int size_y)
      {
         sizeX = size_x;
         sizeY = size_y;

         stones = new Stone[sizeX, sizeY];
      }

      //Является ли переданный камень невыделенным соседом последнего выделенного
      public override bool CanSelectStone(Stone stone)
      {
         if (!(stone is QuadrStone))
            return false;

         if( stone.Selected )
            return false;

         if (selectStones.Count == 0)
            return true;

         QuadrStone q_stone = (QuadrStone)stone;
         QuadrStone last_select_stone = (QuadrStone)selectStones[selectStones.Count - 1];
         if (Math.Abs(q_stone.X - last_select_stone.X) == 1 && Math.Abs(q_stone.Y - last_select_stone.Y) == 1)
            return true;

         return false;

      }

      public override bool RandomFillField()
      {
         Random rnd = new Random();
         for (int i = 0; i < sizeX; i++)
            for (int k = 0; k < sizeY; k++)
            {
               Stone new_stone = ObjectUtils.GenerateRandomStone(rnd);
               stones[i, k] = new QuadrStone(new_stone.TypeStone, i, k);
               //Console.Write(new_stone.TypeStone.ToString());
            }

         return true;
      }

      public override bool CanDeleteSelectedStones()
      {
         return selectStones.Count >= Constants.SimpleListSequenceMinCountCombination;
      }

      public override int DeleteSelectStones()
      {
         int count = selectStones.Count;
         Random rnd = new Random();
         foreach (var item in selectStones)
         {
            QuadrStone tmp_stone = (QuadrStone)item;

            Stone new_stone = ObjectUtils.GenerateRandomStone(rnd);
            stones[tmp_stone.X, tmp_stone.Y] = new QuadrStone(new_stone.TypeStone, tmp_stone.X, tmp_stone.Y);
         }
         selectStones.Clear();

         return count;
      }
   }
}
