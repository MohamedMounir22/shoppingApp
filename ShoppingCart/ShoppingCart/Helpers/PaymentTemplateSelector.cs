﻿using ShoppingCart.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ShoppingCart.Helpers
{
    /// <summary>
    /// This is used to set different templates in payment view.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class PaymentTemplateSelector : DataTemplateSelector
    {
        #region Methods

        /// <summary>
        /// Returns Xamarin.Forms.DataTemplate.
        /// </summary>
        /// <param name="item">The Model</param>
        /// <param name="container">The bindable object</param>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var payment = item as Payment;

            if (payment.CardNumber != null)
                return CardTemplate;
            return CommonTemplate;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the property that has been bound with ItemTemplate.
        /// </summary>
        public DataTemplate CardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with ItemTemplate.
        /// </summary>
        public DataTemplate CommonTemplate { get; set; }

        #endregion
    }
}