using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfToolKit.Foundation.Model;

namespace WpfToolKit.Foundation.Interface
{
    public interface IRegistryService
    {
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool AddRegistryKey(RootKey rootKey, string subKey, string key,  string value);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <returns></returns>
        bool DelRegistryKey(RootKey rootKey, string subKey);
        /// <summary>
        /// Check
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <returns></returns>
        bool IsRegistryKeyExist(RootKey rootKey, string subKey);
        /// <summary>
        /// Modify
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subKey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool UpdateRegistryKey(RootKey rootKey, string subKey, string value);
    }
}
