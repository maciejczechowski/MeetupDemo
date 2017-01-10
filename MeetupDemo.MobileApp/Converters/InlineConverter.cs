﻿using System;
using MvvmCross.Platform.Converters;

namespace MeetupDemo.MobileApp
{
	public class InlineConverter<TIn, TOut> : MvxValueConverter<TIn, TOut>
	{
		public Func<TIn, TOut> ConversionFunction { get; set; }
		public Func<TOut, TIn> BackConversionFunction { get; set; }


		public InlineConverter(Func<TIn, TOut> conversionFunction)
		{
			this.ConversionFunction = conversionFunction;
		}


		public InlineConverter(Func<TIn, TOut> conversionFunction, Func<TOut, TIn> BackConversionFunction)
		{
			this.ConversionFunction = conversionFunction;
		}

		protected override TOut Convert(TIn value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var result = this.ConversionFunction(value);

			return result;
		}

		protected override TIn ConvertBack(TOut value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (this.BackConversionFunction != null)
			{
				var result = this.BackConversionFunction(value);

				return result;
			}
			else
			{
				throw new NotImplementedException("Reverse conversion not implemented");
			}
		}
	}
}
