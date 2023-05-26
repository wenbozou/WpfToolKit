using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WpfToolKit.StringRCConvert
{
    public class StringRC
    {
        #region 字段
        /// <summary>
        /// 文件路径
        /// </summary>
        private string _filePath = string.Empty;
        /// <summary>
        /// 文件数据内容,以行的形式保存
        /// </summary>
        private List<string> _lstLineData = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, string> _dicLanguageRC = new Dictionary<string, string>();
        #endregion

        #region 属性
        #endregion


        public StringRC(string filePath)
        {
        }

        public void Start(string filePath)
        {
            ParseRCFile(filePath);
        }


        protected bool ParseRCFile(string filePath)
        {
            bool bResult = false;

            if (string.IsNullOrEmpty(filePath)
                || !File.Exists(filePath))
                return bResult;

            _filePath = filePath;

            try
            {
                using (StreamReader sr = new StreamReader(_filePath, Encoding.UTF8))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                        _lstLineData.Add(line);
                }

            }
            catch (Exception e) { }


            return bResult;
        }
    }
}
