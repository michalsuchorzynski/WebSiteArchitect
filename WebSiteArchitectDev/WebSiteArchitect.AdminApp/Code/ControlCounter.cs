using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteArchitect.AdminApp.Code
{
    public static class ControlCounter
    {
        private static int _inputCount = 0;
        private static int _labelCount = 0;
        private static int _selectCount = 0;
        private static int _buttonCount = 0;

        public static int InputCount
        {
            get
            {
                var count = _inputCount;
                _inputCount++;
                return count;
            }
        }
        public static int LabelCount
        {
            get
            {
                var count = _labelCount;
                _labelCount++;
                return count;
            }
        }
        public static int SelectCount
        {
            get
            {
                var count = _selectCount;
                _selectCount++;
                return count;
            }
        }
        public static int ButtonCount
        {
            get
            {
                var count = _buttonCount;
                _buttonCount++;
                return _buttonCount;
            }
        }
        public static void Clear()
        {
            _inputCount = 0;
            _labelCount = 0;
            _selectCount = 0;
            _buttonCount = 0;

        }
    }
}
