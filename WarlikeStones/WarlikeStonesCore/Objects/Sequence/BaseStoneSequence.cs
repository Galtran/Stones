using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarlikeStonesCore.Objects.Sequence
{
   public abstract class BaseStoneSequence
   {
      //Сгенерировать последовательность камней
      abstract public bool Generate();

      //Получить последовательность камней количества count
      abstract public List<Stone> GetSequence(int count);

      //Получить минимальную комбинацию камней, которую надо собрать
      abstract public List<Stone> GetMinCombination(int count);

      //Удалить камни в начале последовательности, последовательность дополняется в конце на удаленное количество
      abstract public bool DeleteStones(int count);
      abstract public bool DeleteStones(List<Stone> del_stones);

      //получить очередной камень последовательности
      abstract public Stone GetNextStone();

      //скинуть текущий камень последовательности в нулевой
      virtual public void ResetNextStone()
      {
         curStoneCount = 0;
      }

      //Убавить на 1 текущий камень последовательности
      virtual public void ReduceByOneNextStone()
      {
         curStoneCount = (curStoneCount > 0 ? curStoneCount - 1 : 0);
      }

      protected int curStoneCount;
   }
}
