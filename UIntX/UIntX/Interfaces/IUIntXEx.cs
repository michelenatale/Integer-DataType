


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




//internal abstract class AUIntXEx<T> : IUIntXEx<T>
//{
//  public bool IsZero => throw new NotImplementedException();

//  public bool IsOne => throw new NotImplementedException();

//  public bool IsMinusOne => throw new NotImplementedException();

//  public T Copy() => throw new NotImplementedException();
//  public void CopyTo(Span<byte> bytes, in bool littleendian = true) => throw new NotImplementedException();
//  public byte[] ToBytes(in bool littleendian = true) => throw new NotImplementedException();
//  public Span<byte> ToSpan(in bool littleendian = true) => throw new NotImplementedException();
//  public string ToString(in int radix) => throw new NotImplementedException();
//  public ulong[] ToValues(in bool littleendian = true) => throw new NotImplementedException();




//}


//[StructLayout(LayoutKind.Explicit)]
//internal class UInt128E: AUIntXEx<UInt128E>
//{
//  [FieldOffset(0)]
//  private ulong HI = 0;

//  [FieldOffset(8)]
//  private ulong LO = 0;

//  public UInt128E()
//  {
//    this.HI = this.LO = 0;
//  }

//}

