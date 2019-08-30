using DevExpress.Xpf.PivotGrid.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DXPivotGrid_CustomFilterPopup {
    class CustomFilterPopupTemplateSelector : FilterPopupTemplateSelector {
        public DataTemplate CustomTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
        var field = FieldHeader.GetHeader(container)?.Field;
            if(field != null && field.Group == null)
                return CustomTemplate;
            return LegacyTemplate;
        }
    }
}
