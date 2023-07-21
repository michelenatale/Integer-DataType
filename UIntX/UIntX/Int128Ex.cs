

using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace michele.natale.Numbers;

/// <summary>
/// Represends a 128-Bit signed integer
/// </summary>
/// <remarks>Created by © Michele Natale</remarks>
[StructLayout(LayoutKind.Explicit)]
public readonly struct Int128Ex : IUIntXEx<Int128Ex>, IInt128Ex<Int128Ex>
{

  #region Variables

  [FieldOffset(0)]
  private readonly UInt128Ex LOHI = 0;

  /// <summary>
  /// Current TypeSize of this Datatype
  /// </summary>
  public const int TypeSize = 16;

  public readonly bool IsZero
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => this.LOHI.IsZero;
  }

  public readonly bool IsOne
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => this.LOHI.IsOne;
  }

  public readonly bool IsMinusOne
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => this.LOHI .IsMinusOne;
  }

  public static Int128Ex MaxValue
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => new(0x7FFF_FFFF_FFFF_FFFF, 0xFFFF_FFFF_FFFF_FFFF);
  }

  public static Int128Ex MinValue
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => new(0x8000_0000_0000_0000, 0);
  }

  /// <summary>
  /// Returns 0 for the value 0. For a positive number the value 1, otherwise -1.
  /// </summary>
  public readonly int Sign
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
      if (this.LOHI.IsZero) return 0;
      var lohi = this.LOHI.ToValues();
      return lohi[1] < 0x8000_0000_0000_0000ul ? 1 : -1;
    }
  }

  /// <summary>One = 1</summary> 
  public readonly static Int128Ex One = new(0, 1);

  /// <summary>Zero = 0</summary> 
  public readonly static Int128Ex Zero = new(0, 0);

  #endregion

  #region Constructors


  /// <summary>
  /// Default Constructor
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int128Ex()
  { 
    this.LOHI = new UInt128Ex();
  }

  /// <summary>
  /// Copy values
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int128Ex(Int128Ex number)
  {
    this.LOHI = new(number.LOHI);
  }

  /// <summary>
  /// Copy values
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int128Ex(ulong hi, ulong lo)
  {
    this.LOHI = new(hi, lo);
  }

  /// <summary>
  /// Copy values
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int128Ex(long lo)
  {
    this.LOHI = new((ulong)(lo >> 63), (ulong)lo);
  }

  #endregion

  #region Operators

  #region Bitwise

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator ~(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return new(~lohi[1], ~lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator &(Int128Ex left, Int128Ex right)
  {
    var llohi = left.LOHI.ToValues();
    var rlohi = right.LOHI.ToValues();
    return new(llohi[1] & rlohi[1], llohi[0] & rlohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator |(Int128Ex left, Int128Ex right)
  {
    var llohi = left.LOHI.ToValues();
    var rlohi = right.LOHI.ToValues();
    return new(llohi[1] | rlohi[1], llohi[0] | rlohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator ^(Int128Ex left, Int128Ex right)
  {
    var llohi = left.LOHI.ToValues();
    var rlohi = right.LOHI.ToValues();
    return new(llohi[1] ^ rlohi[1], llohi[0] ^ rlohi[0]);
  }

  #endregion

  #region Unarys

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator +(Int128Ex value)
  {
    return value.Copy();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator -(Int128Ex value)
  {
    return Zero - value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator checked -(Int128Ex value)
  {
    return checked(Zero - value);
  }

  #endregion

  #region In- Decrement

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator ++(Int128Ex value)
  {
    return value + One;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator --(Int128Ex value)
  {
    return value - One;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator checked ++(Int128Ex value)
  {
    return checked(value + One);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator checked --(Int128Ex value)
  {
    return checked(value - One);
  }


  #endregion

  #region Numeric Operation

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator +(Int128Ex left, Int128Ex right)
  {
    var llohi = left.ToValues();
    var rlohi = right.ToValues();

    var lo = llohi[0] + rlohi[0];
    var c = (lo < llohi[0]) ? 1ul : 0ul;

    var hi = llohi[1] + rlohi[1] + c;
    return new(hi, lo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator checked +(Int128Ex left, Int128Ex right)
  {
    var result = left + right;
    var lhis = (uint)(left.ToValues()[1] >> 63);
    var rhis = (uint)(right.ToValues()[1] >> 63);
    var resulthis = (uint)(result.ToValues()[1] >> 63);
    if ((lhis == rhis) && (lhis != resulthis))
      throw new OverflowException(nameof(result));
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator -(Int128Ex left, Int128Ex right)
  {
    var llohi = left.ToValues();
    var rlohi = right.ToValues();

    var lo = llohi[0] - rlohi[0];
    var c = (lo > llohi[0]) ? 1ul : 0ul;

    var hi = llohi[1] - rlohi[1] - c;
    return new(hi, lo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator checked -(Int128Ex left, Int128Ex right)
  {
    var result = left - right;
    var lhis = (uint)(left.ToValues()[1] >> 63);
    var rhis = (uint)(right.ToValues()[1] >> 63);
    var resulthis = (uint)(result.ToValues()[1] >> 63);
    if ((lhis != rhis) && (lhis != resulthis))
      throw new OverflowException(nameof(result));
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator *(Int128Ex left, Int128Ex right)
  {
    var ui128 = left.LOHI * right.LOHI;
    return (Int128Ex)ui128;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator checked *(Int128Ex left, Int128Ex right)
  {
    var uhi = UInt128Ex.MulLOHI(left.LOHI, right.LOHI, out UInt128Ex ulo);
    Int128Ex lo = (Int128Ex)ulo, hi = (Int128Ex)uhi - ((left >> 127) & right) - ((right >> 127) & left);
    if ((hi != 0) || (lo < 0))
      if ((~hi != 0) || (lo >= 0))
        throw new OverflowException(nameof(UInt128Ex.MulLOHI));
    return lo;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator /(Int128Ex left, Int128Ex right)
  {
    if (right.IsZero) throw new DivideByZeroException(nameof(right));
    if (left == right) return One;
    if (left.IsZero) return Zero;
    if (right.IsOne) return left;

    var sign = left.Sign - right.Sign;
    UInt128Ex l = left.Sign == -1 ? (UInt128Ex)Abs(left) : (UInt128Ex)left;
    UInt128Ex r = right.Sign == -1 ? (UInt128Ex)Abs(right) : (UInt128Ex)right;
    if (r > l) return Zero;
    UInt128Ex lr = l / r;
    var result = (Int128Ex)lr;
    if (sign == 0) return result;
    return -result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator checked /(Int128Ex left, Int128Ex right)
  {
    return left / right;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator %(Int128Ex left, Int128Ex right)
  {
    if (right.IsZero) throw new DivideByZeroException(nameof(right));
    if (left == right) return Zero;
    if (left.IsZero) return Zero;
    if (right.IsOne || right.IsMinusOne) return Zero;

    UInt128Ex l = left.Sign == -1 ? (UInt128Ex)Abs(left) : (UInt128Ex)left;
    UInt128Ex r = right.Sign == -1 ? (UInt128Ex)Abs(right) : (UInt128Ex)right;
    UInt128Ex lr = l % r;

    var result = (Int128Ex)lr;
    if (left.Sign == 1) return result;
    return -result;
  }

  #region Internal Methodes

  #endregion

  #endregion

  #region Shift Operations

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator <<(Int128Ex value, int shiftamount)
  {
    shiftamount &= 0x7F;
    var lohi = value.LOHI.ToValues();
    if ((shiftamount & 0x40) != 0) return new(lohi[0] << shiftamount, 0);
    else if (shiftamount != 0)
      return new((lohi[1] << shiftamount) | (lohi[0] >> (64 - shiftamount)), lohi[0] << shiftamount);
    else return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator >>(Int128Ex value, int shiftamount)
  {
    shiftamount &= 0x7F;
    var lohi = value.LOHI.ToValues();
    if ((shiftamount & 0x40) != 0)
      return new((ulong)((long)lohi[1] >> 63), (ulong)((long)lohi[1] >> shiftamount));
    else if (shiftamount != 0)
      return new((ulong)((long)lohi[1] >> shiftamount), (lohi[0] >> shiftamount) | (lohi[1] << (64 - shiftamount)));
    else return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex operator >>>(Int128Ex value, int shiftamount)
  {
    shiftamount &= 0x7F;
    var lohi = value.LOHI.ToValues();
    if ((shiftamount & 0x40) != 0) return new(0, lohi[1] >> shiftamount);
    else if (shiftamount != 0) return new(lohi[1] >> shiftamount, (lohi[0] >> shiftamount) | (lohi[1] << (64 - shiftamount)));
    else return value;
  }

  #endregion

  #region Equality Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override readonly bool Equals([NotNullWhen(true)] object? obj)
  {
    if (typeof(Int128Ex) == obj!.GetType())
      return this.Equals((Int128Ex)obj);
    return false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public readonly bool Equals(Int128Ex other)
  {
    var slohi = this.ToValues();
    var olohi = other.ToValues();
    return slohi[0] == olohi[0] && slohi[1] == olohi[1];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(Int128Ex left, Int128Ex right)
  {
    var llohi = left.ToValues();
    var rlohi = right.ToValues();
    return llohi[0] == rlohi[0] && llohi[1] == rlohi[1];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(Int128Ex left, Int128Ex right)
  {
    return !(left == right);
  }

  #endregion

  #region  Comparison Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(object? obj)
  {
    if (obj is Int128Ex other) return CompareTo(other);
    else if (obj is null) return 1;
    throw new ArgumentException("Invalid datatype", nameof(obj));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(Int128Ex value)
  {
    if (this < value) return -1;
    else if (this > value) return 1;
    else return 0;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(Int128Ex left, Int128Ex right)
  {
    var llohi = left.ToValues();
    var rlohi = right.ToValues();
    var lsign = left.Sign == -1;
    var rsign = right.Sign == -1;
    if (lsign == rsign)
      return llohi[1] < rlohi[1] || llohi[1] == rlohi[1] && llohi[0] < rlohi[0];
    return lsign;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(Int128Ex left, Int128Ex right)
  {
    var llohi = left.ToValues();
    var rlohi = right.ToValues();
    var lsign = left.Sign == -1;
    var rsign = right.Sign == -1;
    if (lsign == rsign)
      return llohi[1] > rlohi[1] || llohi[1] == rlohi[1] && llohi[0] > rlohi[0];
    return rsign;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(Int128Ex left, Int128Ex right)
  {
    var llohi = left.ToValues();
    var rlohi = right.ToValues();
    var lsign = left.Sign == -1;
    var rsign = right.Sign == -1;
    if (lsign == rsign)
      return llohi[1] < rlohi[1] || llohi[1] == rlohi[1] && llohi[0] <= rlohi[0];
    return lsign;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(Int128Ex left, Int128Ex right)
  {
    var llohi = left.ToValues();
    var rlohi = right.ToValues();
    var lsign = left.Sign == -1;
    var rsign = right.Sign == -1;
    if (lsign == rsign)
      return llohi[1] > rlohi[1] || llohi[1] == rlohi[1] && llohi[0] >= rlohi[0];
    return rsign;
  }

  #endregion

  #endregion

  #region Number Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode()
  {
    return -this.LOHI.GetHashCode();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex Abs(Int128Ex value)
  {
    if (value.Sign == 0) return value;
    if (value.Sign == 1) return value;
    return -value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex Pow(Int128Ex value, int exp)
  {
    if (exp < 0) throw new ArgumentException("Only positive exponent", nameof(exp));
    if (exp == 0) return One;
    if (exp == 1) return value;

    if (value.Sign < 0)
    {
      var ui128 = -value.LOHI;
      if ((exp & 1) == 0) return (Int128Ex)UInt128Ex.Pow(ui128, exp);
      else return -(Int128Ex)UInt128Ex.Pow(ui128, exp);
    }
    return (Int128Ex)UInt128Ex.Pow(value.LOHI, exp);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex PowerOfTwo(int exp, out bool overflow)
  {
    return (Int128Ex)UInt128Ex.PowerOfTwo(exp, out overflow);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex PowerOfTen(int exp, out bool overflow)
  {
    return (Int128Ex)UInt128Ex.PowerOfTen(exp, out overflow);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsPowerTwo(Int128Ex value) =>
    UInt128Ex.PopCount((UInt128Ex)Abs(value)) == 1u;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int128Ex Copy()
  {
    return new Int128Ex(this);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Span<byte> ToSpan(bool littleendian = true)
  {
    return this.ToBytes(littleendian);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ulong[] ToValues(bool littleendian = true)
  {
    return this.LOHI.ToValues(littleendian);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public byte[] ToBytes(bool littleendian = true)
  {
    var lo_hi = this.ToValues(true);
    var result = new byte[TypeSize];
    Buffer.BlockCopy(lo_hi, 0, result, 0, TypeSize);
    if (!littleendian) Array.Reverse(result);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex ToInt128Ex(ReadOnlySpan<byte> bytes, bool littleendian = true)
  {
    if (bytes.Length > TypeSize) throw new ArgumentOutOfRangeException(nameof(bytes));

    var bits = new byte[TypeSize];
    Buffer.BlockCopy(bytes.ToArray(), 0, bits, 0, bytes.Length);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new Int128Ex(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex ToInt128Ex(ReadOnlySpan<uint> uints, bool littleendian = true)
  {
    if (uints.Length > TypeSize / 4) throw new ArgumentOutOfRangeException(nameof(uints));

    var bits = new uint[TypeSize / 4];
    Buffer.BlockCopy(uints.ToArray(), 0, bits, 0, uints.Length * 4);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new Int128Ex(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex ToInt128Ex(ReadOnlySpan<ulong> ulongs, bool littleendian = true)
  {
    if (ulongs.Length > TypeSize / 8) throw new ArgumentOutOfRangeException(nameof(ulongs));

    var bits = new ulong[TypeSize / 8];
    Array.Copy(ulongs.ToArray(),bits, ulongs.Length * 8); 
    if (!littleendian) Array.Reverse(bits);

    return new Int128Ex(bits[1], bits[0]);
  }

  #endregion

  #region Formating Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString()
  {
    return this.ToString(10);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public readonly string ToString(int radix)
  {
    if (!new[] { 2, 8, 10, 16 }.Contains(radix))
      throw new ArgumentOutOfRangeException(nameof(radix));

    var bytes = Array.Empty<byte>();
    if (this.Sign != 0) bytes = ToRealNumber(this.LOHI, this.Sign, radix);

    return radix switch
    {
      2 => ToBinSystem(bytes, this.Sign),
      8 => ToOctalSystem(bytes, this.Sign),
      10 => ToDecimalSystem(bytes, this.Sign),
      16 => ToHexSystem(bytes, this.Sign),
      _ => throw new ArgumentOutOfRangeException(nameof(radix)),
    };
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private unsafe static byte[] ToRealNumber(UInt128Ex uilohi, int sign, int radix)
  {
    ReadOnlySpan<byte> bytes;
    var lohi = uilohi.ToValues();
    if (sign == 0) return new byte[1];
    else if (sign == 1)
      lohi = BitwiseAnd(lohi, new ulong[] { 0xFFFFFFFFFFFFFFFFul, 0x7FFF_FFFF_FFFF_FFFFul }, TypeSize / 8);
    else if (radix == 10)
      lohi = TwosComplement(uilohi.ToValues());

    fixed (ulong* ptr = lohi)
      bytes = new Span<byte>(ptr, 8 * lohi.Length).ToArray();
    return TrimLastReverse(bytes.ToArray());
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static string ToBinSystem(ReadOnlySpan<byte> bytes, int sign)
  {
    if (sign == 0) return "0";
    //Wenn es sich um eine positive Zahl handelt,
    //kriegen die Bits eine 0 vorne angehängt. 
    var binstr = string.Join("", Converter(bytes.ToArray(), 256, 2));
    if (sign == 1) return '0' + binstr;
    return binstr;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static string ToOctalSystem(ReadOnlySpan<byte> bytes, int sign)
  {
    if (sign == 0) return "0";
    var result = string.Join("", Converter(bytes.ToArray(), 256, 8));
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static string ToDecimalSystem(ReadOnlySpan<byte> bytes, int sign)
  {
    if (sign == 0) return "0";
    var result = string.Join("", Converter(bytes.ToArray(), 256, 10));
    if (sign == 1) return result;
    return "-" + result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static string ToHexSystem(ReadOnlySpan<byte> bytes, int sign)
  {
    if (sign == 0) return "0";

    var h = "0123456789ABCDEF";
    var str = new StringBuilder();
    var hex = Converter(bytes.ToArray(), 256, 16);
    for (var i = 0; i < hex.Length; i++)
      str.Append(h[hex[i]]);
    return str.ToString();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static byte[] Converter(byte[] data, int startbase, int targetbase)
  {
    if (data.Length == 0) return new byte[1];
    int cap = Convert.ToInt32(data.Length * Math.Log(startbase) / Math.Log(targetbase)) + 1;
    var result = new Stack<byte>(cap);

    byte remainder;
    bool ext = true;
    byte accumulator;
    var input = data.ToArray();
    while (ext)
    {
      remainder = 0; ext = false;
      for (int i = 0; i < input.Length; i++)
      {
        accumulator = (byte)(((startbase * remainder) + input[i]) % targetbase);
        input[i] = (byte)(((startbase * remainder) + input[i]) / targetbase);
        remainder = accumulator;
        if (input[i] > 0) ext = true;
      }
      result.Push(remainder);
    }
    return result.ToArray();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static byte[] TrimLastReverse(byte[] data)
  {
    var count = 0;
    var length = data.Length;
    for (var i = length - 1; i >= 0; i--)
      if (data[i] == 0) { count++; }
      else break;

    return data.Take(length - count).Reverse().ToArray();
  }

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static ulong[] BitwiseAnd(ulong[] left, in ulong[] right, in int typesize)
  {
    var result = new ulong[typesize];
    for (var i = 0; i < typesize; i++)
      result[i] = left[i] & right[i];
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static ulong[] TwosComplement(ulong[] value)
  {
    //https://www.exploringbinary.com/twos-complement-converter/
    UInt128Ex c = 1ul, d;
    var length = value.Length;
    var result = new ulong[length];
    for (var i = 0; i < length; i++)
    {
      d = ~value[i] + c;
      result[i] = (ulong)d;
      c = d >> 64;
    }
    if (c != 0)
    {
      result = new ulong[length + 1];
      result[length] = 1;
    }
    return result;
  }

  #endregion

  #endregion

  #region Conversion and Parse

  #region Conversion to Int128Ex

  #region Implicit Conversion to Int128Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(sbyte value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(short value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(int value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(long value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(byte value) => new(0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(char value) => new(0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(ushort value) => new(0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(uint value) => new(0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int128Ex(ulong value) => new(0, value);

  #endregion

  #region Explicit Conversion to Int128Ex


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int128Ex(float value)
  {
    // -(2^128 - 2^104) to 2^128 - 2^104 - 1 >> Range ca. 2^129
    return (Int128Ex)(double)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int128Ex(float value)
  {
    // -(2^128 - 2^104) to 2^128 - 2^104 - 1 >> Range ca. 2^129
    return checked((Int128Ex)(double)value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int128Ex(double value)
  {
    var ui128 = ((UInt128Ex)value).ToValues();
    return new Int128Ex(ui128[1], ui128[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int128Ex(double value)
  {
    const double pow_2_127 = 170141183460469231731687303715884105728.0;
    const double pow_2_127n = -170141183460469231731687303715884105728.0;

    if (value < pow_2_127n) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsInfinity(value)) throw new OverflowException(nameof(value));
    if (value >= pow_2_127) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsNaN(value)) throw new OverflowException(nameof(value));

    if (double.IsFinite(value))
      return (Int128Ex)value;

    throw new ArgumentOutOfRangeException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int128Ex(decimal value)
  {
    // -(2^96) to 2^96 - 1 >> Range 2^97
    var ui128 = ((UInt128Ex)value).ToValues();
    return new Int128Ex(ui128[1], ui128[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int128Ex(decimal value)
  {
    // -(2^96) to 2^96 - 1 >> Range 2^97
    var ui128 = ((UInt128Ex)value).ToValues();
    return new Int128Ex(ui128[1], ui128[0]);
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int128Ex(UInt128Ex value)
  {
    var lohi = value.ToValues();
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int128Ex(UInt128Ex value)
  {
    var lohi = value.ToValues();
    if (lohi[1] >= 0x8000_0000_0000_0000ul)
      throw new OverflowException(nameof(value));
    return new(lohi[1], lohi[0]);
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int128Ex(Int256Ex value)
  {
    var lohi = value.ToValues();
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int128Ex(Int256Ex value)
  {
    if (value.Sign == 0) return new();
    if (value > MaxValue) throw new OverflowException(nameof(value));
    if (value < MinValue) throw new OverflowException(nameof(value));

    var v = value.ToValues();
    if(value.Sign == 1) return new(v[1], v[0]);
    return new(v[3], v[2]);
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int128Ex(UInt256Ex value)
  {
    var lohi = value.ToValues();
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int128Ex(UInt256Ex value)
  {
    if (value.IsZero) return new();
    if (value > MaxValue.LOHI) throw new OverflowException(nameof(value));

    var lohi = value.ToValues();
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int128Ex(Int512Ex value)
  {
    var lohi = value.ToValues();
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int128Ex(Int512Ex value)
  {
    if (value.Sign == 0) return new();
    if (value > MaxValue) throw new OverflowException(nameof(value));
    if (value < MinValue) throw new OverflowException(nameof(value));

    var v = value.ToValues();
    if (value.Sign == 1) return new(v[1], v[0]);
    return new(v[3], v[2]);
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int128Ex(UInt512Ex value)
  {
    var lohi = value.ToValues();
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int128Ex(UInt512Ex value)
  {
    if (value.IsZero) return new();
    if (value > MaxValue.LOHI) throw new OverflowException(nameof(value));

    var lohi = value.ToValues();
    return new(lohi[1], lohi[0]);
  }

  #endregion

  #endregion

  #region Conversion from Int128Ex

  #region Implicit Conversion from Int128Ex
  #endregion

  #region Explicit Conversion from Int128Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator byte(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (byte)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ushort(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (ushort)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator uint(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (uint)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ulong(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator char(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (char)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator sbyte(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (sbyte)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator short(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (short)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator int(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (int)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator long(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (long)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator double(Int128Ex value)
  {
    if (value.Sign == -1)
    {
      value = -value;
      return -(double)(UInt128Ex)value;
    }
    return (double)(UInt128Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator decimal(Int128Ex value)
  {
    if (value.Sign == -1)
    {
      value = -value;
      return -(decimal)(UInt128Ex)value;
    }
    return (decimal)(UInt128Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator float(Int128Ex value)
  {
    if (value.Sign == -1)
    {
      value = -value;
      return -(float)(UInt128Ex)value;
    }
    return (float)(UInt128Ex)value;
  }


  //Checked

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked byte(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return checked((byte)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ushort(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return checked((ushort)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked uint(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return checked((uint)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ulong(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return lohi[0];
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked char(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return checked((char)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked sbyte(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (~lohi[1] == 0)
    {
      var lo = (long)lohi[0];
      return checked((sbyte)lo);
    }

    if (lohi[1] == 0) return checked((sbyte)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked short(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (~lohi[1] == 0)
    {
      var lo = (long)lohi[0];
      return checked((short)lo);
    }

    if (lohi[1] == 0) return checked((short)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked int(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (~lohi[1] == 0)
    {
      var lo = (long)lohi[0];
      return checked((int)lo);
    }

    if (lohi[1] == 0) return checked((int)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked long(Int128Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (~lohi[1] == 0)
      return (long)lohi[0];

    if (lohi[1] == 0) return checked((long)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked double(Int128Ex value)
  {
    return (double)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked decimal(Int128Ex value)
  {
    double tmp;
    if (value.Sign == -1)
    {
      value = -value;
      tmp = -(double)(UInt128Ex)value;
      if (tmp >= (double)decimal.MinValue) return -(decimal)(UInt128Ex)value;
    }
    else
    {
      tmp = (double)(UInt128Ex)value;
      if (tmp <= (double)decimal.MaxValue) return (decimal)(UInt128Ex)value;
    }
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked float(Int128Ex value)
  { 
    double tmp;
    if (value.Sign == -1)
    {
      value = -value;
      tmp = -(double)(UInt128Ex)value;
      if (tmp >= float.MinValue) return -(float)(UInt128Ex)value;
    }
    else
    {
      tmp = (double)(UInt128Ex)value;
      if (tmp <= float.MaxValue) return (float)(UInt128Ex)value;
    }
    throw new NotImplementedException();
  }


  #endregion

  #region Conversion to Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public TypeCode GetTypeCode()
  {
    return TypeCode.Object;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool ToBoolean(IFormatProvider? provider)
  {
    return !this.IsZero;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public byte ToByte(IFormatProvider? provider)
  {
    return (byte)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public char ToChar(IFormatProvider? provider)
  {
    return (char)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public DateTime ToDateTime(IFormatProvider? provider)
  {
    return Convert.ToDateTime(this.ToDecimal(provider), provider);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public decimal ToDecimal(IFormatProvider? provider)
  {
    return (decimal)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public double ToDouble(IFormatProvider? provider)
  {
    return (double)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public short ToInt16(IFormatProvider? provider)
  {
    return (short)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int ToInt32(IFormatProvider? provider)
  {
    return (int)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public long ToInt64(IFormatProvider? provider)
  {
    return (long)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public sbyte ToSByte(IFormatProvider? provider)
  {
    return (sbyte)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public float ToSingle(IFormatProvider? provider)
  {
    return (float)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(IFormatProvider? provider)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public object ToType(Type conversionType, IFormatProvider? provider)
  {
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ushort ToUInt16(IFormatProvider? provider)
  {
    return (ushort)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public uint ToUInt32(IFormatProvider? provider)
  {
    return (uint)this;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ulong ToUInt64(IFormatProvider? provider)
  {
    return (ulong)this;
  }

  #endregion

  #endregion

  #region Parsing

  #region Parsing

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int128Ex Parse(ReadOnlySpan<char> value, int radix)
  {

    if (!new[] { 2, 8, 10, 16 }.Contains(radix))
      throw new ArgumentOutOfRangeException(nameof(radix));

    return radix switch
    {
      2 => FromBinSystem(value),
      8 => FromOctSystem(value),
      10 => FromDecSystem(value),
      16 => FromHexSystem(value),
      _ => throw new ArgumentException("radix 2, 8, 10, 16", nameof(radix)),
    };
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Int128Ex FromDecSystem(ReadOnlySpan<char> value)
  {
    var sign = value[0] == '-';
    if (value.Length == 0) return new Int128Ex();
    var cap = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, TypeSize * 8)));
    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    val = val.Replace("-", string.Empty);

    if (val.Length == 0) return new Int128Ex();
    if (val.Length == 1 && val[0] == '0') return new Int128Ex();
    if (val.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var bytes = Converter(bytesvalue, 10, 256);
    Array.Reverse(bytes);
    Array.Resize(ref bytes, TypeSize);
    if (!sign) return ToInt128Ex(bytes);

    var uints = new uint[TypeSize / 4];
    Buffer.BlockCopy(bytes, 0, uints, 0, bytes.Length);
    return ToInt128Ex(TwosComplement(uints));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Int128Ex FromBinSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new Int128Ex();
    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new Int128Ex();
    if (val.Length == 1 && val[0] == '0') return new Int128Ex();
    if (val.Length > TypeSize * 8 + 1) throw new ArgumentOutOfRangeException(nameof(value));

    var length = RealLength(val, TypeSize * 8) / 8;
    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var bytes = Converter(bytesvalue, 2, 256);
    Array.Reverse(bytes);
    Array.Resize(ref bytes, length);
    return ToInt128Ex(bytes);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Int128Ex FromOctSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new Int128Ex();

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new Int128Ex();
    if (val.Length == 1 && val[0] == '0') return new Int128Ex();
    int cap = Convert.ToInt32(TypeSize * Math.Log(256) / Math.Log(8)) + 1;
    if (value.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var bytes = Converter(bytesvalue, 8, 256);
    Array.Reverse(bytes);
    Array.Resize(ref bytes, TypeSize);
    return ToInt128Ex(bytes);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Int128Ex FromHexSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new Int128Ex();

    var hex = "0123456789ABCDEF";
    var dict = new Dictionary<char, byte>();
    for (byte i = 0; i < hex.Length; i++)
      dict[hex[i]] = i;

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new Int128Ex();
    if (val.Length == 1 && val[0] == '0') return new Int128Ex();
    int cap = Convert.ToInt32(TypeSize * 2) + 1;
    if (value.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytesvalue = TrimFirst(val).ToArray().Select(s => dict[s]).ToArray();
    var bytes = Converter(bytesvalue, 16, 256);
    Array.Reverse(bytes);
    Array.Resize(ref bytes, TypeSize);
    return ToInt128Ex(bytes);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static ReadOnlySpan<char> TrimFirst(ReadOnlySpan<char> data)
  {
    var count = 0;
    var length = data.Length;
    for (var i = 0; i < length; i++)
      if (data[i] == '0') { count++; }
      else break;

    return data[count..length].ToArray();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static int CountZerosInFirst(ReadOnlySpan<char> data)
  {
    var count = 0;
    var length = data.Length;
    for (var i = 0; i < length; i++)
      if (data[i] == '0') { count++; }
      else break;
    return count;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static int RealLength(ReadOnlySpan<char> data, int typesize)
  {
    var cz = CountZerosInFirst(data);
    var length = data.Length - cz;
    while (length++ % typesize != 0) ;
    return length - 1;
  }

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] TwosComplement(uint[] value)
  {
    //https://www.exploringbinary.com/twos-complement-converter/
    var length = value.Length;
    var result = new uint[length];

    var carry = 1ul;
    for (var i = 0; i < length; i++)
    {
      var digit = ~value[i] + carry;
      result[i] = (uint)digit;
      carry = digit >> 32;
    }
    if (carry != 0)
    {
      result = new uint[length + 1];
      result[length] = 1;
    }

    return result;
  }

  #endregion

  #endregion

  #region TryParsing

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryParse(ReadOnlySpan<char> value, out Int128Ex i128)
  {
    var str = string.Join("", value.ToArray());
    return TryParse(str, out i128);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryParse([NotNullWhen(true)] string value, out Int128Ex i128)
  {
    i128 = 0;
    for (int i = 0; i < value.Length; i++)
    {
      if ("0123456789".Contains(value[i]))
        i128 = i128 * 10 + uint.Parse(value[i].ToString());
      else
      {
        i128 = 0;
        return false;
      }
    }
    return true;
  }


  #endregion

  #endregion

  #endregion 

}
