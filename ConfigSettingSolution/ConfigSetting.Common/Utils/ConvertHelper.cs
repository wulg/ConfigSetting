using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.Common
{
    public class ConvertHelper
    {
        public static T ConvertSimpleType<T>(object value)
        {
            Type destinationType = typeof(T);
            if ((value == null) || destinationType.IsInstanceOfType(value))
            {
                return (T)value;
            }
            string str = value as string;
            if ((str != null) && (str.Length == 0))
            {
                return default(T);
            }

            return (T)ConvertSimpleType(value, destinationType);
        }

        public static object ConvertSimpleType(object value, Type destinationType, bool isHideError = true)
        {
            object returnValue;
            if ((value == null || value.ToString() == string.Empty) && destinationType == typeof(Int32))
            {
                return 0;
            }

            if ((value == null) || destinationType.IsInstanceOfType(value))
            {
                return value;
            }

            TypeConverter converter = TypeDescriptor.GetConverter(destinationType);
            bool flag = converter.CanConvertFrom(value.GetType());
            if (!flag)
            {
                converter = TypeDescriptor.GetConverter(value.GetType());
            }

            try
            {
                if (!flag && !converter.CanConvertTo(destinationType))
                {
                    throw new InvalidOperationException("无法转换成类型：" + value.ToString() + "==>" + destinationType);
                }

                try
                {
                    returnValue = (flag ? converter.ConvertFrom(null, null, value) : converter.ConvertTo(null, null, value, destinationType));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("类型转换出错：" + value.ToString() + "==>" + destinationType, e);
                }
            }
            catch (Exception err)
            {
                if (!isHideError) { throw err; }
                return value;
            }

            return returnValue;
        }

    }
}
