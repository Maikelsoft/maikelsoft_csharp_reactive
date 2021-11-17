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
		#region Try Monad

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
			this IObservable<Try<TSource>> source, Func<TSource, T> selector)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T> =>
			source.Select(@try => @try.Select(selector));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="source"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Try<TResult>> TrySelect<TSource, TResult>(
			this IObservable<Try<TSource>> source, Func<TSource, int, TResult> selector)
			where TSource : IEquatable<TSource>
			where TResult : IEquatable<TResult> =>
			source.Select((@try, i) => @try.Select(value => selector(value, i)));


		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource1"></typeparam>
		/// <typeparam name="TSource2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="source1"></param>
		/// <param name="source2"></param>
		/// <param name="resultSelector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Try<TResult>> TryCombineLatest<TSource1, TSource2, TResult>(
			this IObservable<Try<TSource1>> source1,
			IObservable<Try<TSource2>> source2, Func<TSource1, TSource2, TResult> resultSelector)
			where TSource1 : IEquatable<TSource1>
			where TSource2 : IEquatable<TSource2>
			where TResult : IEquatable<TResult> =>
			source1.CombineLatest(source2, (try1, try2) => try1.CombineWith(try2, resultSelector));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource1"></typeparam>
		/// <typeparam name="TSource2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="source1"></param>
		/// <param name="source2"></param>
		/// <param name="resultSelector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Try<TResult>> TryWithLatestFrom<TSource1, TSource2, TResult>(
			this IObservable<Try<TSource1>> source1,
			IObservable<Try<TSource2>> source2, Func<TSource1, TSource2, TResult> resultSelector)
			where TSource1 : IEquatable<TSource1>
			where TSource2 : IEquatable<TSource2>
			where TResult : IEquatable<TResult> =>
			source1.WithLatestFrom(source2, (try1, try2) => try1.CombineWith(try2, resultSelector));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource1"></typeparam>
		/// <typeparam name="TSource2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="source1"></param>
		/// <param name="source2"></param>
		/// <param name="resultSelector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Try<TResult>> TryZip<TSource1, TSource2, TResult>(
			this IObservable<Try<TSource1>> source1,
			IObservable<Try<TSource2>> source2, Func<TSource1, TSource2, TResult> resultSelector)
			where TSource1 : IEquatable<TSource1>
			where TSource2 : IEquatable<TSource2>
			where TResult : IEquatable<TResult> =>
			source1.Zip(source2, (try1, try2) => try1.CombineWith(try2, resultSelector));

		#endregion

		#region Optional Monad

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Optional<T>> OptionalSelect<TSource, T>(
			this IObservable<Optional<TSource>> source, Func<TSource, T> selector)
			where TSource : IEquatable<TSource>
			where T : IEquatable<T> =>
			source.Select(optional => optional.Select(selector));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="source"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Optional<TResult>> OptionalSelect<TSource, TResult>(
			this IObservable<Optional<TSource>> source, Func<TSource, int, TResult> selector)
			where TSource : IEquatable<TSource>
			where TResult : IEquatable<TResult> =>
			source.Select((optional, i) => optional.Select(value => selector(value, i)));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource1"></typeparam>
		/// <typeparam name="TSource2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="source1"></param>
		/// <param name="source2"></param>
		/// <param name="resultSelector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Optional<TResult>> OptionalCombineLatest<TSource1, TSource2, TResult>(
			this IObservable<Optional<TSource1>> source1,
			IObservable<Optional<TSource2>> source2, Func<TSource1, TSource2, TResult> resultSelector)
			where TSource1 : IEquatable<TSource1>
			where TSource2 : IEquatable<TSource2>
			where TResult : IEquatable<TResult> =>
			source1.CombineLatest(source2, (optional1, optional2) => optional1.CombineWith(optional2, resultSelector));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource1"></typeparam>
		/// <typeparam name="TSource2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="source1"></param>
		/// <param name="source2"></param>
		/// <param name="resultSelector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Optional<TResult>> OptionalWithLatestFrom<TSource1, TSource2, TResult>(
			this IObservable<Optional<TSource1>> source1,
			IObservable<Optional<TSource2>> source2, Func<TSource1, TSource2, TResult> resultSelector)
			where TSource1 : IEquatable<TSource1>
			where TSource2 : IEquatable<TSource2>
			where TResult : IEquatable<TResult> =>
			source1.WithLatestFrom(source2, (optional1, optional2) => optional1.CombineWith(optional2, resultSelector));

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TSource1"></typeparam>
		/// <typeparam name="TSource2"></typeparam>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="source1"></param>
		/// <param name="source2"></param>
		/// <param name="resultSelector"></param>
		/// <returns></returns>
		[Pure]
		public static IObservable<Optional<TResult>> OptionalZip<TSource1, TSource2, TResult>(
			this IObservable<Optional<TSource1>> source1,
			IObservable<Optional<TSource2>> source2, Func<TSource1, TSource2, TResult> resultSelector)
			where TSource1 : IEquatable<TSource1>
			where TSource2 : IEquatable<TSource2>
			where TResult : IEquatable<TResult> =>
			source1.Zip(source2, (optional1, optional2) => optional1.CombineWith(optional2, resultSelector));

		#endregion
	}
}