


namespace michele.natale.Numbers;



/// <summary>Defines a mechanism for Operations.</summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <typeparam name="TOther">The type that will multiply <typeparamref name="TSelf" />.</typeparam>
/// <typeparam name="TResult">The type that contains the product of <typeparamref name="TSelf" /> and <typeparamref name="TOther" />.</typeparam>
/// <remarks>
/// <see href="https://github.com/dotnet/designs/tree/main/accepted/2021/statics-in-interfaces"></see>
/// </remarks>
internal interface IUIntExOperators<TSelf, TOther, TResult> where TSelf : IUIntExOperators<TSelf, TOther, TResult>?
{


  /// <summary>Adds two values together to compute their sum.</summary>
  /// <param name="left">The value to which <paramref name="right" /> is added.</param>
  /// <param name="right">The value which is added to <paramref name="left" />.</param>
  /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
  static abstract TResult operator +(TSelf left, TOther right);

  /// <summary>Adds two values together to compute their sum.</summary>
  /// <param name="left">The value to which <paramref name="right" /> is added.</param>
  /// <param name="right">The value which is added to <paramref name="left" />.</param>
  /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
  /// <exception cref="OverflowException">The sum of <paramref name="left" /> and <paramref name="right" /> is not representable by <typeparamref name="TResult" />.</exception>
  static virtual TResult operator checked +(TSelf left, TOther right) => left + right;


  /// <summary>Subtracts two values to compute their difference.</summary>
  /// <param name="left">The value from which <paramref name="right" /> is subtracted.</param>
  /// <param name="right">The value which is subtracted from <paramref name="left" />.</param>
  /// <returns>The difference of <paramref name="right" /> subtracted from <paramref name="left" />.</returns>
  static abstract TResult operator -(TSelf left, TOther right);

  /// <summary>Subtracts two values to compute their difference.</summary>
  /// <param name="left">The value from which <paramref name="right" /> is subtracted.</param>
  /// <param name="right">The value which is subtracted from <paramref name="left" />.</param>
  /// <returns>The difference of <paramref name="right" /> subtracted from <paramref name="left" />.</returns>
  /// <exception cref="OverflowException">The difference of <paramref name="right" /> subtracted from <paramref name="left" /> is not representable by <typeparamref name="TResult" />.</exception>
  static virtual TResult operator checked -(TSelf left, TOther right) => left - right;


  /// <summary>Multiplies two values together to compute their product.</summary>
  /// <param name="left">The value which <paramref name="right" /> multiplies.</param>
  /// <param name="right">The value which multiplies <paramref name="left" />.</param>
  /// <returns>The product of <paramref name="left" /> divided-by <paramref name="right" />.</returns>
  static abstract TResult operator *(TSelf left, TOther right);

  /// <summary>Multiplies two values together to compute their product.</summary>
  /// <param name="left">The value which <paramref name="right" /> multiplies.</param>
  /// <param name="right">The value which multiplies <paramref name="left" />.</param>
  /// <returns>The product of <paramref name="left" /> divided-by <paramref name="right" />.</returns>
  /// <exception cref="OverflowException">The product of <paramref name="left" /> multiplied-by <paramref name="right" /> is not representable by <typeparamref name="TResult" />.</exception>
  static virtual TResult operator checked *(TSelf left, TOther right) => left * right;


  /// <summary>Divides two values together to compute their quotient.</summary>
  /// <param name="left">The value which <paramref name="right" /> divides.</param>
  /// <param name="right">The value which divides <paramref name="left" />.</param>
  /// <returns>The quotient of <paramref name="left" /> divided-by <paramref name="right" />.</returns>
  static abstract TResult operator /(TSelf left, TOther right);

  /// <summary>Divides two values together to compute their quotient.</summary>
  /// <param name="left">The value which <paramref name="right" /> divides.</param>
  /// <param name="right">The value which divides <paramref name="left" />.</param>
  /// <returns>The quotient of <paramref name="left" /> divided-by <paramref name="right" />.</returns>
  /// <exception cref="OverflowException">The quotient of <paramref name="left" /> divided-by <paramref name="right" /> is not representable by <typeparamref name="TResult" />.</exception>
  static virtual TResult operator checked /(TSelf left, TOther right) => left / right;


  /// <summary>
  /// Divides two values together to compute their modulus or remainder.
  /// </summary>
  /// <param name="left">The value which right divides.</param>
  /// <param name="right">The value which divides left.</param>
  /// <returns>The modulus or remainder of left divided by right.</returns>
  static abstract TResult operator %(TSelf left, TOther right);


  /// <summary>
  /// Computes the ones-complement representation of a given value.
  /// </summary>
  /// <param name="value">The value for which to compute the ones-complement.</param>
  /// <returns>The ones-complement of value.</returns>
  static abstract TResult operator ~(TSelf value);


  /// <summary>
  /// Computes the bitwise-and of two values.
  /// </summary>
  /// <param name="left"> The value to and with right.</param>
  /// <param name="right">The value to and with left.</param>
  /// <returns>The bitwise-and of left and right.</returns>
  static abstract TResult operator &(TSelf left, TOther right);


  /// <summary>
  /// Computes the bitwise-or of two values.
  /// </summary>
  /// <param name="left">The value to or with right.</param>
  /// <param name="right">The value to or with left.</param>
  /// <returns>The bitwise-or of left and right.</returns>
  static abstract TResult operator |(TSelf left, TOther right);


  /// <summary>
  /// Computes the exclusive-or of two values.
  /// </summary>
  /// <param name="left">The value to xor with right.</param>
  /// <param name="right">The value to xor with left.</param>
  /// <returns>The exclusive-or of left and right.</returns>
  static abstract TResult operator ^(TSelf left, TOther right);



  /// <summary>
  /// Compares two values to determine equality.
  /// </summary>
  /// <param name="left">The value to compare with right.</param>
  /// <param name="right">The value to compare with left.</param>
  /// <returns>true if left is equal to right; otherwise, false.</returns>
  static abstract bool operator ==(TSelf left, TOther right);



  /// <summary>
  /// Compares two values to determine inequality.
  /// </summary>
  /// <param name="left">The value to compare with right.</param>
  /// <param name="right">The value to compare with left.</param>
  /// <returns>true if left is not equal to right; otherwise, false.</returns>
  static abstract bool operator !=(TSelf left, TOther right);


  /// <summary>
  /// Compares two values to determine which is less.
  /// </summary>
  /// <param name="left">The value to compare with right.</param>
  /// <param name="right">The value to compare with left.</param>
  /// <returns>true if left is less than right; otherwise, false.</returns>
  static abstract bool operator <(TSelf left, TOther right);


  /// <summary>
  /// Compares two values to determine which is greater.
  /// </summary>
  /// <param name="left">The value to compare with right.</param>
  /// <param name="right">The value to compare with left.</param>
  /// <returns>true if left is greater than right; otherwise, false.</returns>
  static abstract bool operator >(TSelf left, TOther right);

  /// <summary>
  /// Compares two values to determine which is less or equal.
  /// </summary>
  /// <param name="left">The value to compare with right.</param>
  /// <param name="right">The value to compare with left.</param>
  /// <returns>true if left is less than or equal to right; otherwise, false.</returns>
  static abstract bool operator <=(TSelf left, TOther right);


  /// <summary>
  /// Compares two values to determine which is greater or equal.
  /// </summary>
  /// <param name="left">The value to compare with right.</param>
  /// <param name="right">The value to compare with left.</param>
  /// <returns>true if left is greater than or equal to right; otherwise, false.</returns>
  static abstract bool operator >=(TSelf left, TOther right);

}