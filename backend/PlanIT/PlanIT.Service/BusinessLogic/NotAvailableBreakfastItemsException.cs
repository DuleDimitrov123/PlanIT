using System;
using System.Collections.Generic;
using System.Text;

namespace PlanIT.Service.BusinessLogic
{
    public class NotAvailableBreakfastItemsException : Exception
    {
        private IList<string> _notAvailableBreakfastItems;

        public NotAvailableBreakfastItemsException()
        {
            _notAvailableBreakfastItems = new List<string>();
        }

        public NotAvailableBreakfastItemsException(IList<string> notAvailableBreakfastItems)
        {
            _notAvailableBreakfastItems = notAvailableBreakfastItems;
        }

        public override string Message
        {
            get
            {
                var message = "These breakfasts are not available for you company:\n";

                foreach (var item in _notAvailableBreakfastItems)
                {
                    message += $"-{item}\n";
                }

                return message;
            }
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
