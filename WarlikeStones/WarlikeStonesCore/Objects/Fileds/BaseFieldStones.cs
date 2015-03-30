using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarlikeStonesCore.Objects.Fileds
{
   //Базовый класс поля
   abstract public class BaseFieldStones
   {
      //Выделенные камни
      protected List<Stone> selectStones;

      public BaseFieldStones()
      {
         selectStones = new List<Stone>();
      }
      //Может ли быть выбран данный камень
      abstract public bool CanSelectStone(Stone stone);

      //Заполнить поле случайными камнями
      abstract public bool RandomFillField();

      //Можно ли удалить выбранные камни
      abstract public bool CanDeleteSelectedStones();

      //Удалить выбранные камни, заполнить пустоты новыми
      //Вернуть количество очков
      abstract public int DeleteSelectStones();

      //Получить все выделенные камни
      virtual public List<Stone> GetSelectedStones()
      {
         return selectStones;
      }

      //выделить камень
      virtual public void SelectStone(Stone stone)
      {
         stone.Selected = true;
         selectStones.Add(stone);
      }

      //Выделить камень, только если это возможно
      virtual public bool SafeSelectStone(Stone stone)
      {
         if (CanSelectStone(stone))
            SelectStone(stone);
         else 
            return false;

         return true;
      }

      //Снять выделение
      virtual public void DeselectStone(Stone stone)
      {
         stone.Selected = false;
         selectStones.Remove(stone);
      }

      //Снять выделение со всех камней
      virtual public void DeselectAllStone()
      {
         foreach (var stone in GetSelectedStones())
            stone.Selected = false;
      }
   }
}
