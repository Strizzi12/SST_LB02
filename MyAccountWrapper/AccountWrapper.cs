﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    public class AccountWrapper
    {
        #region ### WRAPPER ###
        [DllImport("Account.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int createAccount(int typ, double money, IntPtr name);

        //no import of manage/edit account possible because its not implemented in 2nd party dll

        //no import of delete account possible because its not implemented in 2nd party dll

        #endregion

        #region ### INTERFACES ###
        /// <summary>
        /// Interface creates an account with the given parameters
        /// </summary>
        /// <param name="typ"></param>
        /// <param name="money"></param>
        /// <param name="name"></param>
        /// <returns>Returns the ID of the created account or an error code</returns>
        public static int Intf_createAccount(int typ, double money, string name)
        {
            return createAccount(typ, money, Helper.StoIPtr(name));
        }

        /// <summary>
        /// Interface throws NotImplementedException - functionality not included in dll
        /// </summary>
        /// <param name="tmpAccID"></param>
        /// <param name="tmpType"></param>
        /// <returns></returns>
        public static int Intf_editAccount(int tmpAccID, int tmpType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Interface throws NotImplementedException - functionality not included in dll
        /// </summary>
        /// <param name="tmpAccID"></param>
        /// <returns></returns>
        public static int Intf_deleteAccount(int tmpAccID)
        {
            throw new NotImplementedException();
        }

            #endregion
        }
}