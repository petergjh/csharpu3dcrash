using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    /// <summary>
    /// 索引器
    /// </summary>
    class Person3
    {
        private string name;
        private string sex;
        private string tel;
        public string this[int index] // 定义索引器
        {
            get
            { switch (index)
                {
                    case 1:
                        return name;
                    case 2:
                        return sex;
                    case 3:
                        return tel;
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 1:
                        name = value;
                        break;
                    case 2:
                        sex = value;
                        break;
                    case 3:
                        tel = value;
                        break;
                    default:
                        throw new
                            ArgumentOutOfRangeException("index");

                }
            }

        }

        public void Say()
        {
            // 通过this[1]、this[2]、this[3]获取相应字段值
            Console.WriteLine("我叫" + this[1] + ",我是" + this[2] + "生，我电话是：" + this[3]);
        }


    }
}
