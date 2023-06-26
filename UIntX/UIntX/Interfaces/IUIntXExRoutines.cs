

using System.Diagnostics.CodeAnalysis;

namespace michele.natale.Numbers;


/// <summary>Defines a mechanism for Operations.</summary>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
internal interface IUIntXExRoutines<TSelf> :
   IUIntExOperators<TSelf, TSelf, TSelf>, IUIntExOperators<TSelf, TSelf>,
   IUIntExOperators<TSelf>, IUIntExConversion<TSelf>
   where TSelf : IUIntXExRoutines<TSelf>
{

  /// <summary>
  /// Returns an instance of T with the given string.
  /// </summary>
  /// <param name="value">Desired string in the desired base system.</param>
  /// <param name="radix">Desired base value.</param>
  /// <returns>Yes, if the conversion is successful, otherwise no.</returns>
  public abstract static TSelf Parse(ReadOnlySpan<char> value, int radix);

  /// <summary>
  /// Convert a string to an instance of T.
  /// </summary>
  /// <param name="value">Desired string in the desired base system.</param>
  /// <param name="uix">Instance of T.</param>
  /// <returns>Yes, if the conversion is successful, otherwise no.</returns>
  public abstract static bool TryParse(ReadOnlySpan<char> value, out TSelf uix);

  /// <summary>
  /// Convert a string to an instance of T.
  /// </summary>
  /// <param name="value">Desired string in the desired base system.</param>
  /// <param name="uix">Instance of T.</param>
  /// <returns>Yes, if the conversion is successful, otherwise no.</returns>
  public abstract static bool TryParse([NotNullWhen(true)] string value, out TSelf uix);

}


