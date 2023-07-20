

using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace michele.natale.Numbers;


/// <summary>
/// Represends a 512-Bit signed integer
/// </summary>
/// <remarks>Created by © Michele Natale</remarks>
[StructLayout(LayoutKind.Explicit)]
public readonly struct Int512Ex : IUIntXEx<Int512Ex>, IInt512Ex<Int512Ex>
{

  #region Variables

  [FieldOffset(0)]
  private readonly UInt512Ex LOHI = 0;

  /// <summary>Current TypeSize of this Datatype</summary>
  public const int TypeSize = 64;

  public bool IsZero => this.LOHI.IsZero;

  public bool IsOne => this.LOHI.IsOne;

  public bool IsMinusOne => this.LOHI.IsMinusOne;

  public static Int512Ex MaxValue =>
    new(0x7FFF_FFFF_FFFF_FFFF, 0xFFFF_FFFF_FFFF_FFFF,
        0xFFFF_FFFF_FFFF_FFFF, 0xFFFF_FFFF_FFFF_FFFF,
        0xFFFF_FFFF_FFFF_FFFF, 0xFFFF_FFFF_FFFF_FFFF,
        0xFFFF_FFFF_FFFF_FFFF, 0xFFFF_FFFF_FFFF_FFFF);

  public static Int512Ex MinValue =>
    new(0x8000_0000_0000_0000, 0, 0, 0, 0, 0, 0, 0);

  /// <summary>Zero = 0</summary>  
  public readonly static Int512Ex Zero = new();

  /// <summary>One = 1</summary>
  public readonly static Int512Ex One = new(0, 0, 0, 0, 0, 0, 0, 1);

  public readonly int Sign
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
      if (this.LOHI.IsZero) return 0;
      var lohi = this.LOHI.ToValues();
      return lohi[7] < 0x8000_0000_0000_0000ul ? 1 : -1;
    }
  }

  #endregion

  #region Constructors

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int512Ex() => LOHI = new UInt512Ex();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int512Ex(long value) => LOHI = new(value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int512Ex(in Int512Ex value) => LOHI = value.LOHI;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int512Ex(ulong v7, ulong v6, ulong v5, ulong v4, ulong v3, ulong v2, ulong v1, ulong v0) =>
    LOHI = new UInt512Ex(v7, v6, v5, v4, v3, v2, v1, v0);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private Int512Ex(uint[] values_le)
  {
    var result = new ulong[TypeSize / 8];
    var length = Math.Min(values_le.Length, TypeSize / 4);
    Buffer.BlockCopy(values_le, 0, result, 0, length * 4);
    this.LOHI = new(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int512Ex(ReadOnlySpan<ulong> lohis, bool islittleendian = true) =>
    LOHI = new UInt512Ex(lohis, islittleendian);

  #endregion

  #region Operators

  #region Bitwise

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator ~(Int512Ex value) => new(BitwiseNot(value.ToUInts()));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator &(Int512Ex left, Int512Ex right) =>
    new(BitwiseAnd(left.ToValues(), right.ToValues(), TypeSize / 8)); //ULong-Version

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator |(Int512Ex left, Int512Ex right) =>
    new(BitwiseOr(left.ToUInts(), right.ToUInts(), TypeSize / 4));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator ^(Int512Ex left, Int512Ex right) =>
    new(BitwiseXor(left.ToUInts(), right.ToUInts(), TypeSize / 4));

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] BitwiseNot(in uint[] value)
  {
    //Complement 
    var result = value.ToArray();
    for (var i = 0; i < value.Length; i++)
      result[i] = ~result[i];
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static ulong[] BitwiseAnd(ulong[] left, in ulong[] right, in int typesize)
  {
    var result = new ulong[typesize];
    for (var i = 0; i < typesize; i++)
      result[i] = left[i] & right[i];
    return result;
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] BitwiseOr(uint[] left, uint[] right, int typesize)
  {
    var result = new uint[typesize];
    for (var i = 0; i < typesize; i++)
      result[i] = left[i] | right[i];
    return result;
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] BitwiseXor(uint[] left, uint[] right, int typesize)
  {
    var result = new uint[typesize];
    for (var i = 0; i < typesize; i++)
      result[i] = left[i] ^ right[i];
    return result;
  }

  #endregion

  #endregion

  #region Unary

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator +(Int512Ex value) => value;//copy

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator -(Int512Ex value) => Zero - value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator checked -(Int512Ex value) => checked(Zero - value);


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static ulong[] TwosComplement(ulong[] value)
  {
    var uints = new uint[TypeSize / 4];
    Buffer.BlockCopy(value, 0, uints, 0, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(TwosComplement(uints), 0, result, 0, TypeSize);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] TwosComplement(uint[] value)
  {
    //  https://www.exploringbinary.com/twos-complement-converter/
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

  #region In- Decrement

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator ++(Int512Ex value) => value + 1;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator --(Int512Ex value) => value - 1;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator checked ++(Int512Ex value)
  {
    if (value < MaxValue) return value + 1;
    throw new OverflowException($"++.checked !");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator checked --(Int512Ex value)
  {
    if (value > MinValue) return value - 1;
    throw new OverflowException($"--.checked !");
  }

  #endregion

  #region Numeric Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator +(Int512Ex left, Int512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Addition(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator -(Int512Ex left, Int512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Subtract(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator *(Int512Ex left, Int512Ex right)
  {
    if (left.Sign == 0 || right.Sign == 0) return new();

    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Multiplication(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator /(Int512Ex left, Int512Ex right)
  {
    if (right.Sign == 0) throw new DivideByZeroException(nameof(right));

    if (left.Sign == 0) return new();
    if (left == right) return 1;
    if (right == MinValue) return 0;
    if (right == MaxValue) return 0;

    var sign = left.Sign * right.Sign;
    Int512Ex l = Abs(left), r = Abs(right);

    if (l == r) return sign;
    if (r.IsOne) return left.Sign == sign ? left : -left;
    if (r > l) return 0;

    var uil = l.ToUInts();
    var uir = r.ToUInts();
    var result = new Int512Ex(Division(uil, uir, TypeSize / 4, out _));
    return result.Sign == sign ? result : -result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator %(Int512Ex left, Int512Ex right)
  {
    if (right.Sign == 0) throw new DivideByZeroException(nameof(right));

    if (left.Sign == 0) return 0;
    if (right.IsOne) return 0;
    if (right.IsMinusOne) return 0;

    if (left == right) return 0;
    if (left == -right) return 0;
    if (right == MinValue) return left;//rest here

    var sign = left.Sign * right.Sign;
    Int512Ex l = Abs(left), r = Abs(right);

    if (l == r) return sign;
    if (r.IsOne) return left.Sign == sign ? left : -left;
    if (r > l) return left; 

    var uil = l.ToUInts();
    var uir = r.ToUInts();
    _ = new Int512Ex(Division(uil, uir, TypeSize / 4, out var remainder));
    var result = new Int512Ex(remainder);
    return result.Sign == sign ? result : -result;
  }


  //checked

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator checked +(Int512Ex left, Int512Ex right)
  {
    var result = left + right;
    if (result.Sign == 0) return result;

    var sign = left.Sign * right.Sign;
    if (sign < 1) return result;
    if (result.Sign == left.Sign) return result;

    throw new OverflowException($"+.checked !");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator checked -(Int512Ex left, Int512Ex right)
  {
    var result = left - right;
    if (result.Sign == 0) return result;

    var sign = left.Sign * right.Sign;
    if (sign >= 0) return result;
    if (result.Sign == left.Sign) return result;

    throw new OverflowException($"-.checked !");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator checked *(Int512Ex left, Int512Ex right)
  {
    var result = left * right;
    if (result.Sign == 0) return result;

    var sign = left.Sign * right.Sign;
    if (result.Sign == sign) return result;

    throw new OverflowException($"*.checked !");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator checked /(Int512Ex left, Int512Ex right) => left / right;

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Addition(in uint[] left, in uint[] right, in int size, out bool over_flow)
  {
    uint r = 0U;
    over_flow = false;
    var rshift = (8 * size) - 1;
    var result = new uint[size];
    for (var i = 0; i < size; i++)
    {
      result[i] = left[i] + right[i] + r;
      r = ((left[i] & right[i]) | ((left[i] | right[i]) & (~result[i]))) >> rshift;
    }
    if (r != 0) over_flow = true;
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Subtract(in uint[] left, in uint[] right, in int size, out bool over_flow)
  {
    var r = 0U;
    over_flow = false;
    var rshift = (8 * size) - 1;
    var result = new uint[size];
    for (var i = 0; i < size; i++)
    {
      result[i] = left[i] - right[i] - r;
      r = (((~left[i]) & right[i]) | (~(left[i] ^ right[i])) & result[i]) >> rshift;
    }
    if (r != 0) over_flow = true;
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Multiplication(in uint[] left, in uint[] right, int typesize, out bool over_flow)
  {
    int index;
    ulong remainder;
    over_flow = false;
    var result = new uint[typesize];
    if (left.SequenceEqual(result)) return result;
    if (right.SequenceEqual(result)) return result;

    result[0] = 1;
    if (left.SequenceEqual(result)) return right.ToArray();
    if (right.SequenceEqual(result)) return left.ToArray();

    result = new uint[2 * typesize];
    for (int i = 0; i < typesize; i++)
    {
      index = i;
      remainder = 0;
      foreach (var uir in right)
      {
        remainder += (ulong)left[i] * uir + result[index];
        result[index++] = (uint)remainder;
        remainder >>= 32;
      }

      while (remainder != 0)
      {
        remainder += result[index];
        result[index++] = (uint)remainder;
        remainder >>= 32;
      }
    }
    over_flow = false;
    for (int i = typesize; i < result.Length; i++)
      if (result[i] != 0) { over_flow = true; break; }
    return result.Take(typesize).ToArray();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Division(in uint[] left, in uint[] right, in int typesize, out uint[] remainder)
  {
    var result = new uint[typesize];

    if (right.SequenceEqual(result))
      throw new DivideByZeroException($"{nameof(right)}  == 0");

    result[0] = 1;
    remainder = new uint[typesize];
    if (right.SequenceEqual(result)) return left.ToArray();

    if (left.SequenceEqual(right)) return result;

    result[0] = 0;
    if (LessThenLE(left, right, typesize))
    {
      remainder = left.ToArray();
      return result;
    }

    var l = left.ToArray();
    var one = new uint[typesize];
    one[0] = 1;
    var shift = LeadingZeros(right) - LeadingZeros(left);
    var r = LeftShift(right, shift++, typesize);

    while (shift-- != 0)
    {
      result = LeftShift(result, 1, typesize);
      if (GreaterThenEqualLE(l, r, typesize))
      {
        l = Subtract(l, r, typesize, out _);
        result = Addition(result, one, typesize, out _); // result.Lo |= 1;
      }
      r = RightShift(r, 1, typesize);
    }

    Array.Copy(l, remainder, typesize);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static int LeadingZeros(in uint[] number)
  {
    var zeros = 0;
    var sz = sizeof(uint);
    var size = number.Length;
    while (number[^(zeros++ + 1)] == 0) ;
    var additional = --zeros * 32;
    return LeadingZeros(number[size - zeros - 1], sz) + additional;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static int LeadingZeros<T>(in T number, in int _sizeof)
        where T : unmanaged, IComparable<T>
  {
    int i, result;
    for (i = (_sizeof * 8) - 1, result = 0; i >= 0; i--, result++)
      if (number.CompareTo((T)Convert.ChangeType(1ul << i, typeof(T))) >= 0)
        break;
    return result;
  }

  #endregion

  #endregion

  #region Shift Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator <<(Int512Ex value, int shiftamount)
  {
    if (shiftamount == 0) return value;
    if (value.Sign == 0) return value;
    if (shiftamount < 0) return value >> -shiftamount;

    var uints = LeftShift(value.ToUInts(), shiftamount, TypeSize / 4);
    return new(uints);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator >>(Int512Ex value, int shiftamount)
  {
    shiftamount %= TypeSize * 8;
    if (shiftamount == 0) return value;
    if (value.Sign == 0) return value;
    if (shiftamount < 0) return value << -shiftamount;
    if (value.IsMinusOne) return value; //rest here
 
    if (value.Sign < 0)
      return ~(new Int512Ex(RightShift((~value.LOHI).ToUInts(), shiftamount, TypeSize / 4)));
    return new(RightShift(value.ToUInts(), shiftamount, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex operator >>>(Int512Ex value, int shiftamount)
  {
    shiftamount %= TypeSize * 8;
    if (shiftamount == 0) return value;
    if (value.Sign == 0) return value;
    if (shiftamount < 0) return value << -shiftamount;
    return new(RightShift(value.ToUInts(), shiftamount, TypeSize / 4));
  }

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] LeftShift(in uint[] value, in int shiftl, in int typesize)
  {
    var tsize = typesize * 32 - 1;

    var shift = shiftl & tsize;
    if (shift == 0) return value.ToArray();

    shift = shiftl & 31;
    var offset = (shiftl & tsize) / 32;

    var r = 0ul;
    var size = typesize - offset;
    var result = new uint[typesize];
    var v = value.Select(Convert.ToUInt64).ToArray();

    for (var i = 0; i < size; i++)
    {
      result[i + offset] = (uint)((v[i] << shift) + r);
      r = ((v[i] << shift) + r) / 0x1_0000_0000ul;
    }
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] RightShift(in uint[] value, in int shiftr, in int typesize)
  {
    var tsize = typesize * 32;
    if (shiftr == 0) return value.ToArray();
    if (shiftr >= tsize) return new uint[typesize];

    var shift = shiftr & 31;
    var offset = (shiftr & (tsize - 1)) / 32;

    var r = 0ul;
    var size = typesize - offset;
    var result = new uint[typesize];
    ulong powertwo = 1ul << shift;
    var multiplikator = 0x1_0000_0000ul;
    var v = value.Select(Convert.ToUInt64).ToArray();

    for (var i = 0; i < size; i++)
    {
      result[size - i - 1] = (uint)((v[size - i - 1 + offset] + r * multiplikator) >> shift);
      r = v[size - i - 1 + offset] % powertwo;
      r += r * (multiplikator % powertwo) % powertwo;
    }
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] RightShift(in uint[] value, in int shiftr, in uint pad, in int typesize)
  {
    var leap = shiftr / 32;
    var tiny = shiftr % 32;

    var length = typesize - leap;
    var result = new uint[typesize];
    if (tiny == 0)
    {
      for (var i = 0; i < length; i++)
        result[i] = value[i + leap];
      return result;
    }
    for (var i = 0; i < length - 1; i++)
      result[i] = (value[i + leap] >> tiny) | (value[i + leap + 1] << (32 - tiny));
    result[length - 1] = (pad << (32 - tiny)) | (value[typesize - 1] >> tiny);
    return result;
  }

  #endregion

  #endregion

  #region Equality Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals([NotNullWhen(true)] object? obj)
  {
    if (obj?.GetType() == typeof(Int512Ex))
      this.Equals((Int512Ex)obj);
    return false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode()
  {
    return -this.LOHI.GetHashCode();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(Int512Ex other)
  {
    return this == other;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(Int512Ex left, Int512Ex right)
  {
    return left.LOHI == right.LOHI;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(Int512Ex left, Int512Ex right)
  {
    return !(left == right);
  }

  #endregion

  #region Comparison Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(object? obj)
  {
    if (obj is Int512Ex other) return CompareTo(other);
    else if (obj is null) return 1;
    throw new ArgumentException("Invalid datatype", nameof(obj));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(Int512Ex value)
  {
    if (this < value) return -1;
    else if (this > value) return 1;
    else return 0;
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(Int512Ex left, Int512Ex right) =>
    LessThenLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(Int512Ex left, Int512Ex right) =>
    GreaterThenLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(Int512Ex left, Int512Ex right) =>
     left.CompareTo(right) <= 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(Int512Ex left, Int512Ex right) =>
    left.CompareTo(right) >= 0;


  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool LessThenEqualLE(in uint[] left, in uint[] right, in int size)
  {
    if (left.SequenceEqual(right)) return true;
    if (LessThenLE(left, right, size)) return true;
    return false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool LessThenLE(in uint[] left, in uint[] right, in int size)
  {
    for (var i = 0; i < size; i++)
    {
      if (left[size - i - 1] < right[size - i - 1]) return true;
      if (size - i - 1 == 0) continue;
      if (left[size - i - 1] != right[size - i - 1]) return false;
    }
    return false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool GreaterThenEqualLE(in uint[] left, in uint[] right, in int size)
  {
    if (left.SequenceEqual(right)) return true;
    if (GreaterThenLE(left, right, size)) return true;
    return false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool GreaterThenLE(in uint[] left, in uint[] right, in int size)
  {
    for (var i = 0; i < size; i++)
    {
      if (left[size - i - 1] > right[size - i - 1]) return true;
      if (size - i - 1 == 0) continue;
      if (left[size - i - 1] != right[size - i - 1]) return false;
    }
    return false;
  }

  #endregion

  #endregion

  #endregion

  #region Number Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Int512Ex Copy() => new(this);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex Abs(Int512Ex value)
  {
    if (value.Sign == 0) return value;
    if (value.Sign == 1) return value;
    return -value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Span<byte> ToSpan(bool littleendian = true) => 
    ToBytes(littleendian);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ulong[] ToValues(bool littleendian = true) =>
    this.LOHI.ToValues(littleendian);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public byte[] ToBytes(bool littleendian = true)
  {
    var result = new byte[TypeSize];
    Buffer.BlockCopy(this.ToValues(), 0, result, 0, TypeSize);
    if (!littleendian) Array.Reverse(result);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public uint[] ToUInts(bool littleendian = true)
  {
    var result = new uint[TypeSize / 4];
    Buffer.BlockCopy(this.ToValues(), 0, result, 0, TypeSize);
    if (!littleendian) Array.Reverse(result);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex Pow(Int512Ex value, int exp)
  {
    if (exp < 0) throw new ArgumentException("Only positive exponent", nameof(exp));
    if (exp == 0) return One;
    if (exp == 1) return value;

    if (value.Sign < 0)
    {
      var ui512 = -value.LOHI;
      if ((exp & 1) == 0) return (Int512Ex)UInt512Ex.Pow(ui512, exp);
      else return -(Int512Ex)UInt512Ex.Pow(ui512, exp);
    }    
    return (Int512Ex)UInt512Ex.Pow(value.LOHI, exp);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex PowerOfTwo(int exp, out bool overflow)
  {
    return (Int512Ex)UInt512Ex.PowerOfTwo(exp, out overflow);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex PowerOfTen(int exp, out bool overflow)
  {
    return (Int512Ex)UInt512Ex.PowerOfTen(exp, out overflow);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsPowerTwo(Int512Ex value) =>
    UInt512Ex.PopCount((UInt512Ex)Abs(value)) == 1u;


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex ToInt512Ex(ReadOnlySpan<byte> bytes, bool littleendian = true)
  {
    if (bytes.Length > TypeSize) throw new ArgumentOutOfRangeException(nameof(bytes));

    var bits = new uint[TypeSize];
    Buffer.BlockCopy(bytes.ToArray(), 0, bits, 0, bytes.Length);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex ToInt512Ex(ReadOnlySpan<uint> uints, bool littleendian = true)
  {
    if (uints.Length > TypeSize / 4) throw new ArgumentOutOfRangeException(nameof(uints));

    var bits = new uint[TypeSize / 4];
    Buffer.BlockCopy(uints.ToArray(), 0, bits, 0, uints.Length * 4);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex ToInt512Ex(ReadOnlySpan<ulong> ulongs, bool littleendian = true)
  {
    if (ulongs.Length > TypeSize / 8) throw new ArgumentOutOfRangeException(nameof(ulongs));

    var bits = new ulong[TypeSize / 8];
    Array.Copy(ulongs.ToArray(), bits, ulongs.Length * 8);
    if (!littleendian) Array.Reverse(bits);
    return new(bits);
  }

  #endregion

  #region Formating Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString() => ToString(10);


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
  private unsafe static byte[] ToRealNumber(UInt512Ex uilohi, int sign, int radix)
  {
    ReadOnlySpan<byte> bytes;
    var lohi = uilohi.ToValues();
    if (sign == 0) return new byte[1];
    else if (sign == 1)
      lohi = BitwiseAnd(lohi, new ulong[]
        {
          0xFFFFFFFFFFFFFFFFul, 0xFFFFFFFFFFFFFFFFul, 0xFFFFFFFFFFFFFFFFul, 0xFFFFFFFFFFFFFFFFul,
          0xFFFFFFFFFFFFFFFFul, 0xFFFFFFFFFFFFFFFFul, 0xFFFFFFFFFFFFFFFFul, 0x7FFF_FFFF_FFFF_FFFFul
        }, TypeSize / 8);
    else if (radix == 10)
      lohi = TwosComplement(lohi);

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

  #endregion

  #region Conversion and Parse

  #region Conversion to Int512Ex

  #region Implizit Conversion to Int512Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(sbyte value) => new(value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(short value) => new(value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(int value) => new(value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(long value) => new(value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(byte value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(char value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(ushort value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(uint value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(ulong value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(UInt128Ex value)
  {
    var v = value.ToValues();
    return new(0, 0, 0, 0, 0, 0, v[1], v[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(Int128Ex value)
  {
    if (value.Sign == 0) return new();

    var v = value.ToValues();
    if (value.Sign == 1) return new(0, 0, 0, 0, 0, 0, v[1], v[0]);
    return new(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, 
               ulong.MaxValue, ulong.MaxValue, v[1], v[0]);
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(UInt256Ex value)
  {
    var v = value.ToValues();
    return new(0, 0, 0, 0, v[3], v[2], v[1], v[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator Int512Ex(Int256Ex value)
  {
    if (value.Sign == 0) return new();

    var v = value.ToValues();
    if (value.Sign == 1) return new(0, 0, 0, 0, v[3], v[2], v[1], v[0]);
    return new(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue,
               v[3], v[2], v[1], v[0]);
  }

  #endregion

  #region Explizit Conversion to Int512Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int512Ex(float value)
  {
    // -(2^128 - 2^104) to 2^128 - 2^104 - 1 >> Range ca. 2^129
    return (Int512Ex)(double)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int512Ex(float value)
  {
    // -(2^128 - 2^104) to 2^128 - 2^104 - 1 >> Range ca. 2^129
    return checked((Int512Ex)(double)value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int512Ex(double value)
  {
    var ulongs = ((UInt512Ex)value).ToValues();
    return new Int512Ex(ulongs);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int512Ex(double value)
  {
    const double pow_2_511 = 6703903964971298549787012499102923063739682910296196688861780721860882015036773488400937149083451713845015929093243025426876941405973284973216824503042048.0;

    if (value < -pow_2_511) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsInfinity(value)) throw new OverflowException(nameof(value));
    if (value >= pow_2_511) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsNaN(value)) throw new OverflowException(nameof(value));

    if (double.IsFinite(value))
      return (Int512Ex)value;

    throw new ArgumentOutOfRangeException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int512Ex(decimal value)
  {
    // -(2^96) to 2^96 - 1 >> Range 2^97
    var ulongs = ((UInt512Ex)value).ToValues();
    return new Int512Ex(ulongs);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int512Ex(decimal value)
  {
    // -(2^96) to 2^96 - 1 >> Range 2^97
    var ulongs = ((UInt512Ex)value).ToValues();
    return new Int512Ex(ulongs);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator Int512Ex(UInt512Ex value) => new(value.ToValues());

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked Int512Ex(UInt512Ex value)
  {
    if (value <= MaxValue.LOHI) return new(value.ToValues());
    throw new OverflowException($"{nameof(Int512Ex)}.checked !");
  }

  #endregion

  #endregion

  #region Conversion from Int512Ex

  #region Implicit Conversion from Int512Ex
  //No Implicit Conversion from Int512Ex
  #endregion

  #region Explicit Conversion from Int512Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator byte(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (byte)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ushort(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (ushort)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator uint(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (uint)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ulong(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator char(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (char)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator sbyte(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (sbyte)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator short(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (short)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator int(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (int)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator long(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    return (long)lohi[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator double(Int512Ex value)
  {
    if (value.Sign == -1)
    {
      value = -value;
      return -(double)(UInt512Ex)value;
    }
    return (double)(UInt512Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator decimal(Int512Ex value)
  {
    if (value.Sign == -1)
    {
      value = -value;
      return -(decimal)(UInt512Ex)value;
    }
    return (decimal)(UInt512Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator float(Int512Ex value)
  {
    if (value.Sign == -1)
    {
      value = -value;
      return -(float)(UInt512Ex)value;
    }
    return (float)(UInt512Ex)value;
  }


  //Checked

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked byte(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return checked((byte)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ushort(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return checked((ushort)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked uint(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return checked((uint)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ulong(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return lohi[0];
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked char(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (lohi[1] == 0) return checked((char)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked sbyte(Int512Ex value)
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
  public static explicit operator checked short(Int512Ex value)
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
  public static explicit operator checked int(Int512Ex value)
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
  public static explicit operator checked long(Int512Ex value)
  {
    var lohi = value.LOHI.ToValues();
    if (~lohi[1] == 0)
      return (long)lohi[0];

    if (lohi[1] == 0) return checked((long)lohi[0]);
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked double(Int512Ex value)
  {
    return (double)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked decimal(Int512Ex value)
  {
    double tmp;
    if (value.Sign == -1)
    {
      value = -value;
      tmp = -(double)(UInt512Ex)value;
      if (tmp >= (double)decimal.MinValue) return -(decimal)(UInt512Ex)value;
    }
    else
    {
      tmp = (double)(UInt512Ex)value;
      if (tmp <= (double)decimal.MaxValue) return (decimal)(UInt512Ex)value;
    }
    throw new NotImplementedException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked float(Int512Ex value)
  {
    double tmp;
    if (value.Sign == -1)
    {
      value = -value;
      tmp = -(double)(UInt512Ex)value;
      if (tmp >= float.MinValue) return -(float)(UInt512Ex)value;
    }
    else
    {
      tmp = (double)(UInt512Ex)value;
      if (tmp <= float.MaxValue) return (float)(UInt512Ex)value;
    }
    throw new NotImplementedException();
  }

  #region Conversion to Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public TypeCode GetTypeCode() => TypeCode.Object;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool ToBoolean(IFormatProvider? provider) => !this.IsZero;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public byte ToByte(IFormatProvider? provider) => (byte)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public char ToChar(IFormatProvider? provider) => (char)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public DateTime ToDateTime(IFormatProvider? provider) =>
    Convert.ToDateTime(this.ToDecimal(provider), provider);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public decimal ToDecimal(IFormatProvider? provider) => (decimal)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public double ToDouble(IFormatProvider? provider) => (double)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public short ToInt16(IFormatProvider? provider) => (short)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int ToInt32(IFormatProvider? provider) => (int)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public long ToInt64(IFormatProvider? provider) => (long)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public sbyte ToSByte(IFormatProvider? provider) => (sbyte)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public float ToSingle(IFormatProvider? provider) => (float)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(IFormatProvider? provider) => throw new NotImplementedException();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public object ToType(Type conversionType, IFormatProvider? provider) => throw new NotImplementedException();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ushort ToUInt16(IFormatProvider? provider) => (ushort)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public uint ToUInt32(IFormatProvider? provider) => (uint)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ulong ToUInt64(IFormatProvider? provider) => (ulong)this;

  #endregion

  #endregion

  #endregion

  #region Parsing

  #region Parse

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static Int512Ex Parse(ReadOnlySpan<char> value, int radix)
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
  private static Int512Ex FromDecSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new Int512Ex();

    var sign = value[0] == '-';
    var cap = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, TypeSize * 8)));
    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    val = val.Replace("-", string.Empty);

    if (val.Length == 0) return new Int512Ex();
    if (val.Length == 1 && val[0] == '0') return new Int512Ex();
    if (val.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var bytes = Converter(bytesvalue, 10, 256);
    Array.Reverse(bytes);
    Array.Resize(ref bytes, TypeSize);
    if (!sign) return ToInt512Ex(bytes);

    var uints = new uint[TypeSize / 4];
    Buffer.BlockCopy(bytes, 0, uints, 0, bytes.Length);
    return ToInt512Ex(TwosComplement(uints));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Int512Ex FromBinSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new Int512Ex();

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new Int512Ex();
    if (val.Length == 1 && val[0] == '0') return new Int512Ex();
    if (val.Length > TypeSize * 8 + 1) throw new ArgumentOutOfRangeException(nameof(value));

    var length = RealLength(val, TypeSize * 8) / 8;
    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 2, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, length);
    return ToInt512Ex(tmp);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Int512Ex FromOctSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new Int512Ex();

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new Int512Ex();
    if (val.Length == 1 && val[0] == '0') return new Int512Ex();
    int cap = Convert.ToInt32(TypeSize * Math.Log(256) / Math.Log(8)) + 1;
    if (value.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 8, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);
    return ToInt512Ex(tmp);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static Int512Ex FromHexSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new Int512Ex();

    var hex = "0123456789ABCDEF";
    var dict = new Dictionary<char, byte>();
    for (byte i = 0; i < hex.Length; i++)
      dict[hex[i]] = i;

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new Int512Ex();
    if (val.Length == 1 && val[0] == '0') return new Int512Ex(); 
    int cap = Convert.ToInt32(TypeSize * 2) + 1;
    if (value.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytes = TrimFirst(val).ToArray().Select(s => dict[s]).ToArray();
    var tmp = Converter(bytes, 16, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);
    return ToInt512Ex(tmp);
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

  #endregion

  #region TryParse

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryParse(ReadOnlySpan<char> value, out Int512Ex i512)
  {
    var str = string.Join("", value.ToArray());
    return TryParse(str, out i512);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryParse([NotNullWhen(true)] string value, out Int512Ex i512)
  {
    i512 = 0;
    for (int i = 0; i < value.Length; i++)
    {
      if ("0123456789".Contains(value[i]))
        i512 = i512 * 10 + uint.Parse(value[i].ToString());
      else
      {
        i512 = 0;
        return false;
      }
    }
    return true;
  }


  #endregion

  #endregion

  #endregion

}
