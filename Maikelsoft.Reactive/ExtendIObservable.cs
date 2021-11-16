using System;
using System.Diagnostics.Contracts;
using System.Reactive.Linq;
using Maikelsoft.Monads.Immutable;

namespace Maikelsoft.Reactive
{
	/// <summary>
	/// Extends the <see cref="IObservable{T}"/> interface.
	/// </summary>
	public static class ExtendIObservable
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="predicate"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<ITry<T>> Where<T>(this IObservable<ITry<T>> source,
			Func<T, bool> predicate)
			where T : IEquatable<T>
		{
			return source.Where(@try => @try.HasError || predicate(@try.Value));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<ITry<T>> Select<TSource, T>(
			this IObservable<ITry<TSource>> source, Func<TSource, T> selector)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T>
		{
			return source.Select(@try => @try.Select(selector));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<ITry<T>> Select<TSource, T>(
			this IObservable<ITry<TSource>> source, Func<TSource, ITry<T>> selector)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T>
		{
			return source.Select(@try => @try.Bind(selector));
		}

		///// <summary>
		///// 
		///// </summary>
		///// <typeparam name="T"></typeparam>
		///// <param name="source"></param>
		///// <param name="onNextValue"></param>
		///// <param name="onNextError"></param>
		///// <param name="cancellationToken"></param>
		//public static void Subscribe<T>(this IObservable<ITry<T>> source, Action<T> onNextValue,
		//	Action<string> onNextError, CancellationToken cancellationToken)
		//	where T : IEquatable<T>
		//{
		//	source.Subscribe(@try =>
		//	{
		//		@try.Match(onNextError, onNextValue);
		//	}, cancellationToken);
		//}

		///// <summary>
		///// 
		///// </summary>
		///// <typeparam name="T"></typeparam>
		///// <param name="source"></param>
		///// <param name="onNextValue"></param>
		///// <param name="onNextError"></param>
		///// <param name="onCompleted"></param>
		///// <param name="cancellationToken"></param>
		//public static void Subscribe<T>(this IObservable<ITry<T>> source, Action<T> onNextValue,
		//	Action<string> onNextError, Action onCompleted, CancellationToken cancellationToken)
		//	where T : IEquatable<T>
		//{
		//	source.Subscribe(@try =>
		//	{
		//		@try.Match(onNextError, onNextValue);
		//	}, onCompleted, cancellationToken);
		//}

		///// <summary>
		///// 
		///// </summary>
		///// <typeparam name="T"></typeparam>
		///// <param name="source"></param>
		///// <param name="onNextValue"></param>
		///// <param name="onNextError"></param>
		///// <returns></returns>
		//public static IDisposable Subscribe<T>(this IObservable<ITry<T>> source,
		//	Action<T> onNextValue, Action<string> onNextError)
		//	where T : IEquatable<T>
		//{
		//	return source.Subscribe(@try =>
		//	{
		//		@try.Match(onNextError, onNextValue);
		//	});
		//}

		///// <summary>
		///// 
		///// </summary>
		///// <typeparam name="T"></typeparam>
		///// <param name="source"></param>
		///// <param name="onNextValue"></param>
		///// <param name="onNextError"></param>
		///// <param name="onCompleted"></param>
		///// <returns></returns>
		//public static IDisposable Subscribe<T>(this IObservable<ITry<T>> source,
		//	Action<T> onNextValue, Action<string> onNextError, Action onCompleted)
		//	where T : IEquatable<T>
		//{
		//	return source.Subscribe(@try =>
		//	{
		//		@try.Match(onNextError, onNextValue);
		//	}, onCompleted);
		//}
	}
}