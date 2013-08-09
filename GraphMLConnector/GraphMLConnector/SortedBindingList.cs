using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMLConnector
{
    class SortedBindingList<T> : BindingList<T>
    {
        private ListSortDirection m_sortDirection;
        private PropertyDescriptor m_propertyDescriptor;
		private bool m_isSorted;

    	private const int NO_ITEM_INDEX = -1;

        public SortedBindingList(IEnumerable<T> enumeration)
            : base(new List<T>(enumeration))
        {
        }

        protected override bool IsSortedCore
        {
            get
            {
            	return m_isSorted;
            }
        }

		protected override ListSortDirection SortDirectionCore
		{
			get
			{
				return m_sortDirection;
			}
		}

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
            	return m_propertyDescriptor;
            }
        }

        protected override bool SupportsSearchingCore
        {
            get
            {
            	return true;
            }
        }

		protected override bool SupportsSortingCore
		{
			get
			{
				return true;
			}
		}

        protected override void ApplySortCore(PropertyDescriptor propertyDesciptor, ListSortDirection sortDirection)
        {
			m_isSorted = true;
			m_sortDirection = sortDirection;
			m_propertyDescriptor = propertyDesciptor;

        	var comparer = createComparer(propertyDesciptor, sortDirection);

			sort(comparer);
        }

		protected virtual IComparer<T> createComparer(PropertyDescriptor property, ListSortDirection direction)
		{
			return new PropertyDescriptorComparer<T>(property, direction);
		}

    	private void sort (IComparer <T> comparer)
    	{
    		((List<T>)Items).Sort(comparer);
    		OnListChanged (new ListChangedEventArgs (ListChangedType.Reset, NO_ITEM_INDEX));
    	}

		protected override int FindCore(PropertyDescriptor property, object key)
		{
			int count = Count;

			for (int itemIndex = 0; itemIndex < count; itemIndex++)
			{
				T item = this[itemIndex];
				var itemValue = property.GetValue(item);
				if (itemValue.Equals(key))
				{
					return itemIndex;
				}
			}

			return NO_ITEM_INDEX;
		}

    	protected override void RemoveSortCore()
        {
            m_isSorted = false;
			m_sortDirection = base.SortDirectionCore;
            m_propertyDescriptor = base.SortPropertyCore;

    		OnListChanged (new ListChangedEventArgs (ListChangedType.Reset, NO_ITEM_INDEX));
        }
    }
}

