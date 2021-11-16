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
			where T : IEquatable<T> =>
			source.Where(x => x.HasError || predicate(x.Value));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="selectorThatCanThrowException"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<ITry<T>> TrySelect<TSource, T>(
			this IObservable<TSource> source, Func<TSource, T> selectorThatCanThrowException)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T> =>
			source.Select(x => x.TrySelect(selectorThatCanThrowException));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="selectorThatCanThrowException"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<ITry<T>> TrySelect<TSource, T>(
			this IObservable<ITry<TSource>> source, Func<TSource, T> selectorThatCanThrowException)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T>
		{
			return source.Select(x => x.TrySelect(selectorThatCanThrowException));
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
		public static IObservable<ITry<T>> BindSelect<TSource, T>(
			this IObservable<ITry<TSource>> source, Func<TSource, ITry<T>> selector)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T>
		{
			return source.Select(@try => @try.Bind(selector));
		}
	}
}