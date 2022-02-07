using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public class User
    {
        private int _age;

        public User(int v)
        {
            this._age = v;
        }

        public int Age
        {

            get { return _age; }


            set
            {
                _age = value;
            }

        }


    }

}
