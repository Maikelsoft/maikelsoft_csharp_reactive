using System;
using Maikelsoft.Monads.Immutable;

namespace Maikelsoft.Reactive
{
	/// <summary>
	/// 
	/// </summary>
	public static class ExtendIObserver
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="observer"></param>
		/// <param name="errorMessage"></param>
		public static void OnNextError<T>(this IObserver<Try<T>> observer, string errorMessage)
			where T: IEquatable<T>
		{
			observer.OnNext(Try.FromError<T>(errorMessage!));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="observer"></param>
		/// <param name="value"></param>
		public static void OnNextValue<T>(this IObserver<Try<T>> observer, T value)
			where T: IEquatable<T>
		{
			observer.OnNext(Try.FromValue(value));
		}
	}
}