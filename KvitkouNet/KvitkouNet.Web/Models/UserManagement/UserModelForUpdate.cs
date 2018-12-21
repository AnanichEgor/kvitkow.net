using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Models.UserManagement
{
    public class UserModelForUpdate
    {
        /// <summary>
        /// ��� ������������
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// �������� ������������
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// ������� ������������
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// ������ ������� ������������ 
        /// </summary>
        public IList<string> Adress { get; set; }

        /// <summary>
        /// ������ ��������� ������������
        /// </summary>
        public IList<string> PhoneNumbers { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// ���� ��������
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
