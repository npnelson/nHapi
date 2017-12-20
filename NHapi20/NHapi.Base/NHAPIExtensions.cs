using NHapi.Base.Model.Primitive;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHapi.Base.NetStandard
{
   public static class NHAPIExtensions
   {
	  public static DateTime? GetAsNullableDate(this TSComponentOne obj)
	  {
		 try
		 {
			string[] dateFormats = new string[] { "yyyyMMddHHmm", "yyyyMMdd", "yyyyMMddHHmmss", "yyyyMMddHHmmss.fff" };
			DateTime? val = null;
			System.Globalization.CultureInfo culture = System.Threading.Thread.CurrentThread.CurrentCulture;
			if (!string.IsNullOrEmpty(obj.Value))
			   val = DateTime.ParseExact(obj.Value, dateFormats, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
			return val;
		 }
		 catch (Exception ex)
		 {
			throw new InvalidOperationException("Could not get field as dateTime", ex);
		 }
	  }

   }
}
