using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlockUser
{
    class AllowUser
    {
        // 使用人員名單
        string[] UserList = new string[]
        {
            "user1",
            "user2"
        };

        // 檢查執行人員帳號
        public bool CheckUser(string target)
        {
            foreach (String user in UserList)
            {
                if (target == user)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
