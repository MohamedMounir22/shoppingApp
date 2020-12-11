﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Syncfusion.ListView.XForms.UWP;
using Syncfusion.SfBusyIndicator.XForms.UWP;
using Syncfusion.SfMaps.XForms.UWP;
using Syncfusion.SfRating.XForms.UWP;
using Syncfusion.SfRotator.XForms.UWP;
using Syncfusion.XForms.UWP.BadgeView;
using Syncfusion.XForms.UWP.Border;
using Syncfusion.XForms.UWP.Buttons;
using Syncfusion.XForms.UWP.Cards;
using Syncfusion.XForms.UWP.ComboBox;
using Syncfusion.XForms.UWP.Expander;
using Syncfusion.XForms.UWP.Graphics;
using Xamarin.Forms;
using Application = Windows.UI.Xaml.Application;
using Frame = Windows.UI.Xaml.Controls.Frame;

namespace ShoppingCart.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                // you'll need to add `using System.Reflection;`
                var assembliesToInclude = new List<Assembly>
                {
                    //Now, add all the assemblies your app uses
                    typeof(SfMapsRenderer).GetTypeInfo().Assembly,
                    typeof(SfCardViewRenderer).GetTypeInfo().Assembly,
                    typeof(SfSegmentedControlRenderer).GetTypeInfo().Assembly,
                    typeof(SfRotatorRenderer).GetTypeInfo().Assembly,
                    typeof(SfExpanderRenderer).GetTypeInfo().Assembly,
                    typeof(SfCheckBoxRenderer).GetTypeInfo().Assembly,
                    typeof(SfBadgeViewRenderer).GetTypeInfo().Assembly,
                    typeof(SfGradientViewRenderer).GetTypeInfo().Assembly,
                    typeof(SfRatingRenderer).GetTypeInfo().Assembly,
                    typeof(SfComboBoxRenderer).GetTypeInfo().Assembly,
                    typeof(SfListViewRenderer).GetTypeInfo().Assembly,
                    typeof(SfBorderRenderer).GetTypeInfo().Assembly,
                    typeof(SfButtonRenderer).GetTypeInfo().Assembly,
                    typeof(SfBusyIndicatorRenderer).GetTypeInfo().Assembly
                };

                Forms.Init(e, assembliesToInclude);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}