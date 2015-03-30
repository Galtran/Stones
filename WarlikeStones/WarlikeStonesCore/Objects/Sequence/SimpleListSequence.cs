using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlikeStonesCore.Utils;

namespace WarlikeStonesCore.Objects.Sequence
{
   class SimpleListSequence : BaseStoneSequence
   {
      List<Stone> stones;

      public SimpleListSequence()
      {
         stones = new List<Stone>();
      }

      public override bool Generate()
      {
         Random rnd = new Random();
         for (int i = 0; i < Constants.SimpleListSequenceCount; i++)
            stones.Add(ObjectUtils.GenerateRandomStone(rnd));

         return true;
      }

      public override List<Stone> GetSequence(int count)
      {
         int sub_list_size = Math.Min( count, stones.Count );
         List<Stone> sub_list = new List<Stone>(sub_list_size);
         for (int i = 0; i < sub_list_size; i++)
            sub_list.Add(stones[i]);

         return sub_list;
      }

      public override List<Stone> GetMinCombination(int count)
      {
         if (stones.Count < Constants.SimpleListSequenceMinCountCombination)
            throw new Exception("В последовательности сгенерировано менее 3 камней!");

         List<Stone> sub_list = new List<Stone>(Constants.SimpleListSequenceMinCountCombination);
         for (int i = 0; i < Constants.SimpleListSequenceMinCountCombination; i++)
            sub_list.Add(stones[i]);

         return sub_list;
      }

      public override bool DeleteStones(int count)
      {
         if (stones.Count < count)
            throw new Exception("В последовательности нет столько камней, сколько просят удалить!");

         stones.RemoveRange(0, count);
         return true;
      }

      public override bool DeleteStones(List<Stone> del_stones)
      {
         foreach (var item in del_stones)
            stones.Remove(item);

         return true;
      }
   }
}
