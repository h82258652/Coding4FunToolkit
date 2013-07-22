﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Coding4Fun.Toolkit.Controls.Common;
using Microsoft.Phone.Controls;

namespace Coding4Fun.Toolkit.Test.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = this;

			// WP 7 check
	        LockScreenTile.Visibility = (Environment.OSVersion.Platform != PlatformID.WinCE) ? Visibility.Visible :  Visibility.Collapsed;

			Loaded += MainPage_Loaded;
        }

		void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			ThreadPool.QueueUserWorkItem(state =>
				{
					try
					{
						LayoutRoot.Background = new SolidColorBrush(Colors.Red);

					}
					catch (UnauthorizedAccessException ex0)
					{
						Debug.WriteLine("caught: "  + ex0);
					}

					SafeDispatcher.Run(() =>
						{
							LayoutRoot.Background = new SolidColorBrush(Colors.Transparent);
						});
				});
		}

		private void LockScreen_Click(object sender, RoutedEventArgs e)
		{
			NavigateTo("/Samples/LockScreenPreview.xaml");
		}

		private void Chat_Click(object sender, RoutedEventArgs e)
		{
			NavigateTo("/Samples/ChatBubbleControls.xaml");
		}

        private void Slider_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/Slider.xaml");
        }
        
        private void TimeSpan_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/Timespan.xaml");
        }

        private void Overlays_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/Overlays.xaml");
        }

        private void Prompts_Click(object sender, RoutedEventArgs e)
        {
			NavigateTo("/Samples/PromptControls.xaml");
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/AboutItems.xaml");
        }

        private void Memory_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/Memory.xaml");
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/ButtonControls.xaml");
        }

        private void Colors_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/ColorControls.xaml");
        }

		private void MetroFlow_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/MetroFlow.xaml");
        }

		private void Binding_Click(object sender, RoutedEventArgs e)
		{
			NavigateTo("/Samples/Binding.xaml");
		}

		private void Audio_Click(object sender, RoutedEventArgs e)
		{
			NavigateTo("/Samples/Audio.xaml");
		}

        private void Storage_Click(object sender, RoutedEventArgs e)
		{
			NavigateTo("/Samples/Storage.xaml");
		}

		private void GzipWebClient_Click(object sender, RoutedEventArgs e)
		{
			NavigateTo("/Samples/Gzip.xaml");
		}
		
    	private void NavigateTo(string page)
        {
            NavigationService.Navigate(new Uri(page, UriKind.Relative));
        }

        private void SuperImage_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo("/Samples/SuperImage.xaml");
        }
    }
}