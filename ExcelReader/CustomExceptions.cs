using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader
{
    class NotAllColumnsException : Exception
    {
        public NotAllColumnsException(string message) : base(message)
        {
        }
    }

    class DateGoodFormatButNotValidException : Exception
    {
        public DateGoodFormatButNotValidException(string message) : base(message)
        {
        }
    }

    class LongSearchException : Exception
    {
        public LongSearchException(string message) : base(message)
        {
        }
    }
}
