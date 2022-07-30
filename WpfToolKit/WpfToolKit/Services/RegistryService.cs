using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToolKit.Foundation.Interface;
using WpfToolKit.Foundation.Model;

namespace WpfToolKit.Services
{
    public class RegistryService: IRegistryService
    {

        #region 字段
        private static IRegistryService _registryService = null;
        private static object _syncLock = new object();
        #endregion

        #region 构造函数
        protected RegistryService() { }
        #endregion

        #region 静态方法
        public static IRegistryService GetInstance()
        {
            lock (_syncLock)
            {
                if (_registryService == null)
                {
                    _registryService = new RegistryService();
                }
            }

            return _registryService;
        }
        #endregion


        #region 继承自 IRegistryService
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddRegistryKey(RootKey rootKey, string subKey, string key,  string value)
        {
            try {
                RegistryKey sub = OpenSubKey(rootKey, subKey);
                RegistryKey temp = sub?.CreateSubKey(key);
                temp.SetValue("wb", "123");
                temp?.Flush();
            }
            catch (Exception ex)
            {
            }
            return true;
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <returns></returns>
        public bool DelRegistryKey(RootKey rootKey, string subKey)
        {
            return true;
        }
        /// <summary>
        /// Check
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <returns></returns>
        public bool IsRegistryKeyExist(RootKey rootKey, string subKey)
        {
            return true;
        }
        /// <summary>
        /// Modify
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateRegistryKey(RootKey rootKey, string subKey, string value)
        {
            return true;
        }
        #endregion

        #region 方法
        protected RegistryKey GetRootRegistryKey(RootKey rootKey)
        {
            RegistryKey registryKey = null;
            switch (rootKey)
            {
                case RootKey.CLASSES_ROOT:
                    registryKey = Registry.ClassesRoot;
                    break;
                case RootKey.CURRENT_CONFIG:
                    registryKey = Registry.CurrentConfig;
                    break;
                case RootKey.CURRENT_USER:
                    registryKey = Registry.CurrentUser;
                    break;
                case RootKey.LOCAL_MACHINE:
                    registryKey = Registry.LocalMachine;
                    break;
                case RootKey.USERS:
                    registryKey = Registry.Users;
                    break;
            }

            return registryKey;
        }

        protected RegistryKey OpenSubKey(RootKey rootKey, string subKey)
        {
            RegistryKey sub = null;
            RegistryKey root = GetRootRegistryKey(rootKey);
            sub = root?.OpenSubKey(subKey, true);
            return sub;
        }
        #endregion
    }
}
