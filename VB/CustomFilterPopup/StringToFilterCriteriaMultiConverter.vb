Imports DevExpress.Data.Filtering
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Windows.Data
Imports System.Windows.Markup

Namespace HowToBindToMDB
    Public Class ToFilterCriteriaMultiConverter
        Inherits MarkupExtension
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
            Return Nothing
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Dim searchString = DirectCast(value, String)
            If String.IsNullOrEmpty(searchString) Then
                Return Nothing
            End If
            Dim resultCriteria = CriteriaOperator.Parse(String.Format("Contains([DisplayText],'{0}')", searchString))
            Console.WriteLine(resultCriteria)
            Return resultCriteria
        End Function

        Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function
    End Class
End Namespace
