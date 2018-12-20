using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KvitkouNet.Web.Models.UserManagement
{
    public class UserGroupModel
    {
        /// <summary>
        /// ���������� ����� ������
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// ��� ������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �������� ���������� ������
        /// </summary>
        public string Description { get; set; }
    }
}