﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace SIUC_RSS_Reader
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DetailPage : SIUC_RSS_Reader.Common.LayoutAwarePage
    {
        public DetailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // DONT KNOW IF I LIKE THI OR NOT
            //Run the PopInThemeAnimation 
            Windows.UI.Xaml.Media.Animation.Storyboard sb =
                this.FindName("PopInStoryboard") as Windows.UI.Xaml.Media.Animation.Storyboard;
            if (sb != null) sb.Begin();


            // Add this code to navigate the web view to the selected blog post.
            string itemTitle = (string)navigationParameter;
            FeedItem feedItem = FeedDataSource.GetItem(itemTitle);
            if (feedItem != null)
            {
                this.contentView.Navigate(feedItem.Link);
                this.DataContext = feedItem;
            }
        }

        private void ContentView_NavigationFailed(object sender, WebViewNavigationFailedEventArgs e)
        {
            string errorString = "<p>Page could not be loaded.</p><p>Error is: " + e.WebErrorStatus.ToString() + "</p>";
            this.contentView.NavigateToString(errorString);
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}
