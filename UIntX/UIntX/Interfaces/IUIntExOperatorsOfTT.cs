
namespace michele.natale.Numbers;


/// <summary>Defines a mechanism for Operations.</summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TResult">The type that contains the product of 
/// <typeparamref name="TSelf" /> and <typeparamref name="TOther" />.</typeparam>
/// <remarks>
/// <see href="https://github.com/dotnet/designs/tree/main/accepted/2021/statics-in-interfaces"></see>
/// </remarks>
internal interface IUIntExOperators<TSelf, TResult> where TSelf : IUIntExOperators<TSelf, TResult>?
{

  /// <summary>
  /// Computes the unary plus of a value.
  /// </summary>
  /// <param name="value">The value for which to compute the unary plus.</param>
  /// <returns>The unary plus of value.</returns>
  static abstract TResult operator +(TSelf value);


  /// <summary>Computes the unary negation of a value.</summary>
  /// <param name="value">The value for which to compute its unary negation.</param>
  /// <returns>The unary negation of <paramref name="value" />.</returns>
  static abstract TResult operator -(TSelf value);


  /// <summary>Computes the unary negation of a value.</summary>
  /// <param name="value">The value for which to compute its unary negation.</param>
  /// <returns>The unary negation of <paramref name="value" />.</returns>
  /// <exception cref="OverflowException">The unary negation of 
  /// <paramref name="value" /> is not representable by <typeparamref name="TResult" />.</exception>
  static virtual TResult operator checked -(TSelf value) => -value;


  /// <summary>
  /// Shifts a value left by a given amount.
  /// </summary>
  /// <param name="value">The value that is shifted left by shiftamount.</param>
  /// <param name="shiftamount">The amount by which value is shifted left.</param>
  /// <returns>The result of shifting value left by shiftamount.</returns>
  static abstract TResult operator <<(TSelf value, int shiftamount);


  /// <summary>
  /// Shifts a value right by a given amount.
  /// </summary>
  /// <param name="value">The value that is shifted right by shiftamount.</param>
  /// <param name="shiftamount">The amount by which value is shifted right.</param>
  /// <returns>The result of shifting value right by shiftamount.</returns>
  static abstract TResult operator >>(TSelf value, int shiftamount);


  /// <summary>
  /// Shifts a value right by a given amount.
  /// </summary>
  /// <param name="value">The value that is shifted right by shiftamount.</param>
  /// <param name="shiftamount">The amount by which value is shifted right.</param>
  /// <returns>The result of shifting value right by shiftamount.</returns>
  static abstract TResult operator >>>(TSelf value, int shift);

}
