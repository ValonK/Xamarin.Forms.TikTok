using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Xamarin.Forms.TikTok.Core.ViewModels._Base
{
	public abstract class BaseViewModel : MvxViewModel
	{
		private bool _isBusy;
		private bool _isRefreshing;
		private string _title;
		
		public bool IsBusy
		{
			get => _isBusy;
			set
			{
				_isBusy = value;
				SetProperty(ref _isRefreshing, value);
			}
		}

		public bool IsRefreshing
		{
			get => _isRefreshing;
			set
			{
				_isRefreshing = value;
				SetProperty(ref _isRefreshing, value);
			}
		}

		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				SetProperty(ref _title, value);
			}
		}
	}
}
