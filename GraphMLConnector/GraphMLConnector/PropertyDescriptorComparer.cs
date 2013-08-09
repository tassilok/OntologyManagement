using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphMLConnector
{
    class PropertyDescriptorComparer<T> : IComparer<T>
    {
        private const int ASCENDING = 1;
        private const int DESCENDING = -1;

        private readonly int m_sortDirection;
        private readonly PropertyDescriptor m_propertyDescriptor;
        private readonly IComparer m_comparer;

        public PropertyDescriptorComparer(PropertyDescriptor propertyDescriptor, ListSortDirection sortDirection)
        {
            m_propertyDescriptor = propertyDescriptor;
            m_comparer = getComparerFromDescriptor();

            m_sortDirection = sortDirection == ListSortDirection.Ascending ? ASCENDING : DESCENDING;
        }

        private IComparer getComparerFromDescriptor()
        {
            Type comparerType = typeof(Comparer<>);
            Type comparerForPropertyType = comparerType.MakeGenericType(m_propertyDescriptor.PropertyType);

            return (IComparer)comparerForPropertyType.InvokeMember("Default",
                                                                     BindingFlags.GetProperty |
                                                                     BindingFlags.Public |
                                                                     BindingFlags.Static,
                                                                     null, null, null);
        }

        public int Compare(T x, T y)
        {
            object xValue = m_propertyDescriptor.GetValue(x);
            object yValue = m_propertyDescriptor.GetValue(y);

            return m_sortDirection * m_comparer.Compare(xValue, yValue);
        }
    }
}
