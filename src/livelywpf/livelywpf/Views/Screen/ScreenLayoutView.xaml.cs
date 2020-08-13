﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace livelywpf.Views
{
    /// <summary>
    /// Interaction logic for ScreenLayoutView.xaml
    /// </summary>
    public partial class ScreenLayoutView : Window
    {
        readonly List<ScreenLabelView> screenLabels = new List<ScreenLabelView>();
        public ScreenLayoutView()
        {
            InitializeComponent();
            this.DataContext = new ScreenLayoutViewModel();

            foreach (var item in ScreenHelper.GetScreen())
            {
                ScreenLabelView lbl = new ScreenLabelView(item.DeviceNumber, item.Bounds.Left + 10, item.Bounds.Top + 10);
                lbl.Show();
                screenLabels.Add(lbl);
            }
        }

        private void ScreenLayoutControl_ChildChanged(object sender, EventArgs e)
        {
            // Hook up x:Bind source.
            global::Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost windowsXamlHost =
                sender as global::Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost;
            var control = windowsXamlHost.GetUwpInternalObject() as global::livelyscreenlayout.ScreenLayoutView;

            if (control != null)
            {
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var item in screenLabels)
            {
                item.Close();
            }
            screenLabels.Clear();
        }
    }
}
