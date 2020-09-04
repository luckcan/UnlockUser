using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;

namespace UnlockUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void unlockBotton_Click(object sender, EventArgs e)
        {
            string DomainName = "DOMAIN";
            string SuperAccount = "Administrator";
            string SuperPassword = "P@ssw0rd";

            AllowUser allowUser = new AllowUser();

            if (allowUser.CheckUser(opBox.Text))
            {
                PrincipalContext context =
                    new PrincipalContext(ContextType.Domain,
                    DomainName,
                    SuperAccount,
                    SuperPassword
                    );

                UserPrincipal user =
                    UserPrincipal.FindByIdentity(context,
                    IdentityType.SamAccountName, accountBox.Text);

                if (user == null)
                {
                    messageLabel.Text = accountBox.Text + " 帳號不存在。";
                }
                else
                {
                    // 停用帳號
                    // user.Enabled = false;

                    // 啟用帳號
                    // user.Enabled = true;

                    // 帳號解鎖
                    user.UnlockAccount();

                    user.Save();
                    messageLabel.Text = accountBox.Text + " 已解除鎖定。";
                }
            }
            else
            {
                messageLabel.Text = opBox.Text + "非授權人員，\n請重新輸入執行人員帳號";
            }
        }
    }
}
