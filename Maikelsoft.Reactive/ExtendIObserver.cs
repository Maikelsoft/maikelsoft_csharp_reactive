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
		/// <param name="details"></param>
		public static void OnNextError<T>(this IObserver<Try<T>> observer, string errorMessage, string? details = null)
			where T: IEquatable<T>
		{
			observer.OnNext(Try.FromError<T>(errorMessage, details));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="observer"></param>
		/// <param name="error"></param>
		public static void OnNextError<T>(this IObserver<Try<T>> observer, Error error)
			where T: IEquatable<T>
		{
			observer.OnNext(Try.FromError<T>(error));
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