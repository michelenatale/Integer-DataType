


namespace michele.natale.Numbers;


/// <summary>
/// Interface for UIntExOfT
/// </summary>
/// <typeparam name="T">The type that implements this interface.</typeparam>
internal interface IUIntXEx<T>
  : IUIntXExRoutines<T>, IEquatable<T>,
    IConvertible, IComparable, IComparable<T>
  where T : IUIntXEx<T>
{

  /// <summary>
  /// TypeSize of struct
  /// </summary>
  public const int TypeSize = 0;

  /// <summary>
  /// Indicates if the current value is 0.
  /// </summary>
  bool IsZero { get; }

  /// <summary>
  /// Indicates if the current value is 1.
  /// </summary>
  bool IsOne { get; }

  /// <summary>
  /// Indicates if the current value is -1.
  /// </summary>
  bool IsMinusOne { get; }

  /// <summary>
  /// Represend the maximal value of this Datatype.
  /// </summary>
  public abstract static T MaxValue { get; }

  /// <summary>
  /// Represend the minimum value of this Datatype.
  /// </summary>
  public abstract static T MinValue { get; }

  /// <summary>
  /// Returns the current value as a string.
  /// </summary>
  /// <param name="radix">Decimal, Octal, Hex or Bit-Value</param>
  /// <returns>Returns the current value as a string.</returns>
  unsafe string ToString(in int radix);

  /// <summary>
  /// Returns the current value as a span<byte>.
  /// </summary>
  /// <param name="littleendian">Yes for littleendian, otherwise false.</param>
  /// <returns>Returns the current value as a span<byte>.</returns>
  Span<byte> ToSpan(in bool littleendian = true);

  /// <summary>
  /// Returns the current value as a array of byte.
  /// </summary>
  /// <param name="littleendian">Yes for littleendian, otherwise false.</param>
  /// <returns>Returns the current value as a array of byte.</returns>
  byte[] ToBytes(in bool littleendian = true);

  /// <summary> 
  /// Returns the current value as a array of uint.
  /// </summary>
  /// <param name="littleendian">Yes for littleendian, otherwise false.</param>
  /// <returns>Returns the current value as a array of ulong.</returns>
  ulong[] ToValues(in bool littleendian = true);

  /// <summary>
  /// Returns a copy from the current value.
  /// </summary>
  /// <returns>Returns a copy from the current value.</returns>
  T Copy();

}


