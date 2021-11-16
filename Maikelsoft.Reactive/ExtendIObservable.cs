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
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Try<T>> TrySelect<TSource, T>(
			this IObservable<TSource> source, Func<TSource, T> selector)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T> =>
			source.Select(value => Try.Create(() => selector(value)));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Try<T>> Select<TSource, T>(
			this IObservable<Try<TSource>> source, Func<TSource, T> selector)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T> =>
			source.Select(@try => @try.Select(selector));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Try<T>> Bind<TSource, T>(
			this IObservable<Try<TSource>> source, Func<TSource, Try<T>> selector)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T> =>
			source.Select(@try => @try.Bind(selector));
	}
}