using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGLogicBase
{
    public abstract  class Singleton<T> where T:class, new()
    {
        static T inst = null;

        public T GetInst() {
            if (inst == null) {
                inst = new T();
            }

            return inst;
        }
    }
}
