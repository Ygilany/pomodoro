using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Pomodoro.ViewModels;

namespace Pomodoro
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
