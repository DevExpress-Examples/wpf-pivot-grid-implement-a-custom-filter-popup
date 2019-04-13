using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace CustomFilterPopup {
    public class ToFilterCriteriaMultiConverter : MarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            var searchString = (string)value;
            if (string.IsNullOrEmpty(searchString)) return null;
            var resultCriteria = CriteriaOperator.Parse(string.Format("Contains([DisplayText],'{0}')", searchString));
            Console.WriteLine(resultCriteria);
            return resultCriteria;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
