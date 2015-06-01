using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Fx.Util
{
    public static class RegExp
    {
        public const string Numeric2Decimal = @"^\d*[\.,]?\d{1,2}$";
        public const string Numeric2Decimal2 = @"^(\$|)([0-9]\d{0,2}(\,\d{3})*|([1-9]\d*))(\.\d{1,2})?$";
        public const string Numeric3Decimal = @"^(\$|)([0-9]\d{0,3}(\,\d{3})*|([1-9]\d*))(\.\d{1,3})?$";
        public const string Numeric4Decimal = @"^(\$|)([0-9]\d{0,2}(\,\d{3})*|([1-9]\d*))(\.\d{1,4})?$";
        public const string Alphanumerics = @"^[\w ñÑáéíóúÁÉÍÓÚ]*$";
        public const string OnlyNumbers = @"[0-9]+";
        public const string OnlyLetter = @"^[a-zA-Z_áéíóúñ\s]*$";
        public const string DateFormat = @"^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$";
        public const string ValidExtensionPdf = @"^.*\.(pdf)$";
        public const string ValidExtensionImage = @"^.*\.(bmp|jpg|jpeg|tif|png)$";
        public const string ValidEmail = @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$";
        public const string ValidExtensionDocx = @"^.*\.(docx)$";
        public const string Mayora0 = "^([0-9].[1-9][1-9])$";
        public const string LoginName = "^[a-z0-9_-]{3,25}$";
        public const string AlphanumericsZeroSpecial = @"^[ A-Za-z0-9_.,\/#&+-]*$";
    }
}
