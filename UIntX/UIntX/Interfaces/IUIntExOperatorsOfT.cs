

namespace michele.natale.Numbers;


/// <summary>Defines a mechanism for Operations.</summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
/// <remarks>
/// <see href="https://github.com/dotnet/designs/tree/main/accepted/2021/statics-in-interfaces"></see>
/// </remarks>
internal interface IUIntExOperators<TSelf> where TSelf : IUIntExOperators<TSelf>?
{

  /// <summary>Increments a value.</summary>
  /// <param name="value">The value to increment.</param>
  /// <returns>The result of incrementing <paramref name="value" />.</returns>
  static abstract TSelf operator ++(TSelf value);

  /// <summary>Increments a value.</summary>
  /// <param name="value">The value to increment.</param>
  /// <returns>The result of incrementing <paramref name="value" />.</returns>
  /// <exception cref="OverflowException">The result of incrementing 
  /// <paramref name="value" /> is not representable by <typeparamref name="TSelf" />.</exception>
  static virtual TSelf operator checked ++(TSelf value) => ++value;


  /// <summary>Decrements a value.</summary>
  /// <param name="value">The value to decrement.</param>
  /// <returns>The result of decrementing <paramref name="value" />.</returns>
  static abstract TSelf operator --(TSelf value);

  /// <summary>Decrements a value.</summary>
  /// <param name="value">The value to decrement.</param>
  /// <returns>The result of decrementing <paramref name="value" />.</returns>
  /// <exception cref="OverflowException">The result of decrementing 
  /// <paramref name="value" /> is not representable by <typeparamref name="TSelf" />.</exception>
  static virtual TSelf operator checked --(TSelf value) => --value;


  /// <summary>Computes the absolute of a value.</summary>
  /// <param name="value">The value for which to get its absolute.</param>
  /// <returns>The absolute of <paramref name="value" />.</returns>
  /// <exception cref="OverflowException">The absolute of 
  /// <paramref name="value" /> is not representable by <typeparamref name="TSelf" />.</exception>
  static abstract TSelf Abs(TSelf value);

}
