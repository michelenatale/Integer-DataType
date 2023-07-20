

using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace michele.natale.Numbers;

/// <summary>
/// Represends a 512-Bit unsigned integer
/// </summary>
/// <remarks>Created by © Michele Natale</remarks>
[StructLayout(LayoutKind.Explicit)]
public readonly struct UInt512Ex : IUIntXEx<UInt512Ex>, IUInt512Ex<UInt512Ex>
{

  #region Variables

  [FieldOffset(0)]
  private readonly ulong V0 = 0;

  [FieldOffset(8)]
  private readonly ulong V1 = 0;

  [FieldOffset(16)]
  private readonly ulong V2 = 0;

  [FieldOffset(24)]
  private readonly ulong V3 = 0;

  [FieldOffset(32)]
  private readonly ulong V4 = 0;

  [FieldOffset(40)]
  private readonly ulong V5 = 0;

  [FieldOffset(48)]
  private readonly ulong V6 = 0;

  [FieldOffset(56)]
  private readonly ulong V7 = 0;

  /// <summary>
  /// Current TypeSize of this Datatype
  /// </summary>
  public const int TypeSize = 64;
 
  public static UInt512Ex MinValue =>  new();
 
  public static UInt512Ex MaxValue =>  new(-1);

  public bool IsZero
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (this.V0 | this.V1 | this.V2 | this.V3 | this.V4 | this.V5 | this.V6 | this.V7) == 0;
  }

  public bool IsOne
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (this.V0 ^ 1 | this.V1 | this.V2 | this.V3 | this.V4 | this.V5 | this.V6 | this.V7) == 0;
  }

  public bool IsMinusOne
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => this.V0 == ulong.MaxValue && this.V1 == ulong.MaxValue && this.V2 == ulong.MaxValue && this.V3 == ulong.MaxValue &&
           this.V4 == ulong.MaxValue && this.V5 == ulong.MaxValue && this.V6 == ulong.MaxValue && this.V7 == ulong.MaxValue;
  } 

  /// <summary>One = 1</summary> 
  public readonly static UInt256Ex One = new(1);

  /// <summary>Zero = 0</summary> 
  public readonly static UInt256Ex Zero = new();
  #endregion

  #region Constructors

  /// <summary>
  /// Default Constructor
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt512Ex()
  {
    this.V0 = this.V1 = this.V2 = this.V3 = 0ul;
    this.V4 = this.V5 = this.V6 = this.V7 = 0ul;
  }

  /// <summary>
  /// Constructor - copy values.
  /// </summary>
  /// <param name="lo">Low low value bits</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt512Ex(long lo)
  {
    this.V0 = (ulong)lo;
    this.V1 = this.V2 = this.V3 = (ulong)(lo >> 63);
    this.V4 = this.V5 = this.V6 = this.V7 = (ulong)(lo >> 63);
  }

  /// <summary>
  /// Constructor - copy values.
  /// </summary>
  /// <param name="lo">low value bits</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt512Ex(ulong lo)
  {
    this.V0 = lo;
    this.V1 = this.V2 = this.V3 = 0;
    this.V4 = this.V5 = this.V6 = this.V7 = 0;
  }

  /// <summary>
  /// Constructor - copy values. 
  /// </summary>
  /// <param name="v0">Bits level 0</param>
  /// <param name="v1">Bits level 64</param>
  /// <param name="v2">Bits level 128</param>
  /// <param name="v3">Bits level 192</param>
  /// <param name="v4">Bits level 256</param>
  /// <param name="v5">Bits level 320</param>
  /// <param name="v6">Bits level 384</param>
  /// <param name="v7">Bits level 448</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt512Ex(
    ulong v7, ulong v6, ulong v5, ulong v4,
    ulong v3, ulong v2, ulong v1, ulong v0)
  {
    this.V0 = v0; this.V1 = v1; this.V2 = v2; this.V3 = v3;
    this.V4 = v4; this.V5 = v5; this.V6 = v6; this.V7 = v7;
  }

  /// <summary>
  /// Constructor - copy values.
  /// </summary>
  /// <param name="lohis">value bits.</param>
  /// <param name="islittleendian">True, if is little endian, otherwise false.</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt512Ex(ReadOnlySpan<ulong> lohis, bool islittleendian = true)
  {
    if (islittleendian)
    {
      this.V0 = lohis[0]; this.V1 = lohis[1]; this.V2 = lohis[2]; this.V3 = lohis[3];
      this.V4 = lohis[4]; this.V5 = lohis[5]; this.V6 = lohis[6]; this.V7 = lohis[7];
      return;
    }
    this.V0 = lohis[7]; this.V1 = lohis[6]; this.V2 = lohis[5]; this.V3 = lohis[4];
    this.V4 = lohis[3]; this.V5 = lohis[2]; this.V6 = lohis[1]; this.V7 = lohis[0];
  }

  /// <summary>
  /// Constructor - copy values.
  /// </summary>
  /// <param name="number">UInt256Ex instance</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt512Ex(in UInt512Ex number)
  {
    this.V0 = number.V0; this.V1 = number.V1; this.V2 = number.V2; this.V3 = number.V3;
    this.V4 = number.V4; this.V5 = number.V5; this.V6 = number.V6; this.V7 = number.V7;
  }

  /// <summary>
  /// Private Constructor - copy values.
  /// </summary>
  /// <param name="values"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private UInt512Ex(uint[] values)
  {
    var result = new ulong[TypeSize / 8];
    var length = Math.Min(values.Length, TypeSize / 4);
    Buffer.BlockCopy(values, 0, result, 0, length * 4);
    this.V0 = result[0]; this.V1 = result[1]; this.V2 = result[2]; this.V3 = result[3];
    this.V4 = result[4]; this.V5 = result[5]; this.V6 = result[6]; this.V7 = result[7];
  }

  #endregion

  #region Operators

  #region Bitwise

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator ~(UInt512Ex value) =>
    new(BitwiseNotUI(value.ToUInts()));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator &(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(BitwiseAnd(uil, uir, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator |(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(BitwiseOr(uil, uir, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator ^(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(BitwiseXor(uil, uir, TypeSize / 4));
  }

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] BitwiseNotUI(in uint[] value)
  {
    var one = new uint[value.Length];
    var mv = value.Select(x => uint.MaxValue).ToArray();
    if (value.SequenceEqual(one)) return mv;
    one[0] = 1;
    if (value.SequenceEqual(mv)) return new uint[value.Length];
    var result = Subtract(mv, value, value.Length,out _);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] BitwiseAnd(uint[] left, uint[] right, int typesize)
  {
    var bits = new uint[typesize];
    for (var i = 0; i < typesize; i++)
      bits[i] = left[i] & right[i];
    return bits;
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

  public static UInt512Ex operator +(UInt512Ex value)
  {
    return value;//copy
  }

  public static UInt512Ex operator -(UInt512Ex value)
  {
    //return Negate(value);
    return new( NegateUnsigned(value.ToUInts(), TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] NegateUnsigned(in uint[] value, in int size)
  {
    //=> MaxValue - ui + One;
    var r = 1U;
    var result = new uint[size];
    if (result.SequenceEqual(value))
      return value.ToArray();

    result[0] = (uint)-value[0];
    for (var i = 1; i < size; i++)
      result[i] = (uint)-(r + value[i]);
    return result;
  }

  #endregion

  #region In- Decrement

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator ++(UInt512Ex value) => value + 1;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator --(UInt512Ex value) => value - 1;


  //checked

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator checked ++(UInt512Ex value)
  {
    if (value != MaxValue) return value + 1;
    throw new OverflowException($"++.Checked");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator checked --(UInt512Ex value)
  {
    if (value != MinValue) return value - 1;
    throw new OverflowException($"--.Checked");
  }

  #endregion

  #region Numeric Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator +(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Addition(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator -(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Subtract(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator *(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Multiplication(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator /(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Division(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator %(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    _ = Division(uil, uir, TypeSize / 4, out var remainder);
    return new(remainder);
  }

  //checked
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator checked +(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    var result = new UInt512Ex(Addition(uil, uir, TypeSize / 4,out var isoverflow));
    if (!isoverflow) return result;
    throw new OverflowException($"{nameof(Addition)}.Checked");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator checked -(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    var result = new UInt512Ex(Subtract(uil, uir, TypeSize / 4, out var isoverflow));
    if (!isoverflow) return result;
    throw new OverflowException($"{nameof(Subtract)}.Checked");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator checked *(UInt512Ex left, UInt512Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    var result = Multiplication(uil, uir, TypeSize / 4, out var over_flow);
    if (!over_flow) return new(result);
    throw new OverflowException($"{nameof(Multiplication)}.Checked");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator checked /(UInt512Ex left, UInt512Ex right) => left / right;

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Addition(in uint[] left, in uint[] right, in int size, out bool isoverflow)
  {
    uint r = 0U;
    isoverflow = false;
    var rshift = (8 * size) - 1;
    var result = new uint[size];
    for (var i = 0; i < size; i++)
    {
      result[i] = left[i] + right[i] + r;
      r = ((left[i] & right[i]) | ((left[i] | right[i]) & (~result[i]))) >> rshift;
    }
    if (r != 0)
      isoverflow = true;
    return result;
  } 

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Subtract(in uint[] left, in uint[] right, in int size, out bool isoverflow)
  {
    var r = 0U;
    isoverflow = false;
    var rshift = (8 * size) - 1;
    var result = new uint[size];
    for (var i = 0; i < size; i++)
    {
      result[i] = left[i] - right[i] - r;
      r = (((~left[i]) & right[i]) | (~(left[i] ^ right[i])) & result[i]) >> rshift;
    }
    if (r != 0)
      isoverflow = true;
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
        l = Subtract(l, r, typesize,out _);
        result = Addition(result, one, typesize,out _); // result.Lo |= 1;
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
  public static UInt512Ex operator <<(UInt512Ex value, int shiftamount)
  {
    var shift = shiftamount &= 0x1FF;
    if (shift == 0) return value;
    if (shiftamount < 0) return value >> shiftamount;
    return new(LeftShift(value.ToUInts(), shift, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator >>(UInt512Ex value, int shiftamount)
  {
    var shift = shiftamount &= 0x1FF;
    if (shift == 0) return value;
    if (shiftamount < 0) return value << shiftamount;
    return new(RightShift(value.ToUInts(), shift, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex operator >>>(UInt512Ex value, int shiftamount)
  {
    return value >> shiftamount;
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
    var v = value.Select(x => Convert.ToUInt64(x)).ToArray();

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

  #endregion

  #endregion

  #region Equality Operators

  public override bool Equals([NotNullWhen(true)] object? obj)
  {
    if (typeof(UInt512Ex) == obj!.GetType())
      return this.Equals((UInt512Ex)obj);
    return false;
  }


  public bool Equals(UInt512Ex other) => this == other;
  public static bool operator ==(UInt512Ex left, UInt512Ex right)
  {
    if (left.V0 != right.V0) return false;
    if (left.V1 != right.V1) return false;
    if (left.V2 != right.V2) return false;
    if (left.V3 != right.V3) return false;
    if (left.V4 != right.V4) return false;
    if (left.V5 != right.V5) return false;
    if (left.V6 != right.V6) return false;
    if (left.V7 != right.V7) return false;
    return true;
  }

  public static bool operator !=(UInt512Ex left, UInt512Ex right)
  {
    return !(left == right);
  }

  #endregion

  #region Comparison Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(object? value)
  {
    if (value is UInt512Ex other) return this.CompareTo(other);
    else if (value is null) return 1;
    else throw new ArgumentException($"data type is incorrect", nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(UInt512Ex value)
  {
    if (this < value) return -1;
    else if (this > value) return 1;
    else return 0;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(UInt512Ex left, UInt512Ex right) =>
    LessThenLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(UInt512Ex left, UInt512Ex right) => 
    GreaterThenLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);
    
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(UInt512Ex left, UInt512Ex right) =>
    LessThenEqualLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(UInt512Ex left, UInt512Ex right) =>
    GreaterThenEqualLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);

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
  public static UInt512Ex Pow(UInt512Ex value, int exp)
  {
    var uints = value.ToUInts();
    var result = Pow(uints, exp, TypeSize / 4);
    return new(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex PowerOfTwo(int exp, out bool overflow)
  {
    var uints = PowerOfTwo(exp, TypeSize / 4, out overflow);
    if (overflow) return new UInt512Ex();
    return new(uints);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex PowerOfTen(int exp, out bool overflow)
  {
    var uints = PowerOfTen(exp, TypeSize / 4, out overflow);
    if (overflow) return new UInt512Ex();
    return new(uints);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsPowerTwo(UInt512Ex value) => PopCount(value) == 1u;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt512Ex Copy()
  {
    return new(this);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt512Ex Abs(UInt512Ex value) => value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public byte[] ToBytes(bool littleendian = true)
  {
    var result = new byte[TypeSize];
    Buffer.BlockCopy(this.ToValues(), 0, result, 0, TypeSize);
    if (!littleendian) Array.Reverse(result);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Span<byte> ToSpan(bool littleendian = true)
  {
    return ToBytes(littleendian);
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
  public ulong[] ToValues(bool littleendian = true)
  {
    var result = new ulong[]
    {
      this.V0, this.V1, this.V2, this.V3, this.V4, this.V5, this.V6, this.V7
    };
    if (!littleendian) Array.Reverse(result);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static UInt512Ex PopCount(UInt512Ex value)
  {
    var uints = value.ToUInts();
    var result = Zero;
    for (var i = 0; i < uints.Length; i++)
      result += ulong.PopCount(uints[i]);
    return result;
  }

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Pow(uint[] value, int power, int typesize)
  {
    if (power < 0)
      throw new ArgumentOutOfRangeException(nameof(power));

    uint[] result = new uint[value.Length];
    result[0] = 1;
    while (power != 0)
    {
      if ((power & 1) == 1)
        result = Multiplication(value, result, typesize, out _);
      value = Multiplication(value, value, typesize, out _);
      power >>= 1;
    }
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] PowerOfTwo(int exp, int tsize, out bool overflow)
  {
    overflow = true;
    var max = tsize * 32;
    if (exp >= max)
      return new uint[tsize];

    overflow = false;
    if (exp == 0) { var a = new uint[tsize]; a[0] = 1; return a; }
    if (exp == 1) { var a = new uint[tsize]; a[0] = 2; return a; }

    var result = new uint[tsize]; result[0] = 2;
    var expui = result.ToArray();
    for (var i = 1; i < exp; i++)
      result = Multiplication(result, expui, tsize, out overflow);
    if (exp >= max) overflow = true;
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] PowerOfTen(int exp, int tsize, out bool overflow)
  {
    overflow = true;
    var max = (int)double.Truncate(Math.Log10(Math.Pow(2, TypeSize * tsize / 2)));
    if (exp > max) return new uint[tsize];

    overflow = false;
    if (exp == 0) { var a = new uint[tsize]; a[0] = 1; return a; }
    if (exp == 1) { var a = new uint[tsize]; a[0] = 10; return a; }

    var result = new uint[tsize]; result[0] = 10;
    var expui = result.ToArray();
    for (var i = 1; i < exp; i++)
      result = Multiplication(result, expui, tsize, out overflow);
    if (exp > max) overflow = true;
    return result;
  }

  #endregion

  #endregion

  #region Formating Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override int GetHashCode()
  {
    return (int)(this.V7 ^ (2ul * this.V6) ^ (3ul * this.V5) ^ (4ul * this.V4) ^
                (5ul * this.V3) ^ (6ul * this.V2) ^ (7ul * this.V1) ^ (8ul * this.V0));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString() => this.ToString(10);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public readonly unsafe string ToString(int radix)
  {
    if (!new[] { 2, 8, 10, 16 }.Contains(radix))
      throw new ArgumentOutOfRangeException(nameof(radix));

    ReadOnlySpan<byte> bytes;
    var tmp = new ulong[] { this.V0, this.V1, this.V2, this.V3, this.V4, this.V5, this.V6, this.V7 };
    fixed (ulong* ptr = tmp)
      bytes = new Span<byte>(ptr, 8 * tmp.Length).ToArray();
    bytes = TrimLastReverse(bytes.ToArray());

    return radix switch
    {
      2 => ToDualSystem(bytes),
      8 => ToOctalSystem(bytes),
      10 => ToDecimalSystem(bytes),
      16 => ToHexSystem(bytes),
      _ => throw new ArgumentOutOfRangeException(nameof(radix)),
    };
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static string ToDualSystem(ReadOnlySpan<byte> bytes)
  {
    //Wenn es sich um eine positive Zahl handelt,
    //kriegen die Bits eine 0 vorne angehängt. 
    return '0' + string.Join("", Converter(bytes.ToArray(), 256, 2));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static string ToOctalSystem(ReadOnlySpan<byte> bytes)
  {
    return string.Join("", Converter(bytes.ToArray(), 256, 8));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static string ToDecimalSystem(ReadOnlySpan<byte> bytes)
  {
    return string.Join("", Converter(bytes.ToArray(), 256, 10));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static string ToHexSystem(ReadOnlySpan<byte> bytes)
  {
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

  public static UInt512Ex ToUInt512Ex(ReadOnlySpan<byte> bytes, bool littleendian = true)
  {
    if (bytes.Length > TypeSize) throw new ArgumentOutOfRangeException(nameof(bytes));

    var bits = new byte[TypeSize];
    Buffer.BlockCopy(bytes.ToArray(), 0, bits, 0, bytes.Length);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new UInt512Ex(result);
  }

  public static UInt512Ex ToUInt512Ex(ReadOnlySpan<uint> uints, bool littleendian = true)
  {
    if (uints.Length > TypeSize / 4) throw new ArgumentOutOfRangeException(nameof(uints));

    var bits = new uint[TypeSize / 4];
    Buffer.BlockCopy(uints.ToArray(), 0, bits, 0, uints.Length * 4);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new UInt512Ex(result);

  }

  public static UInt512Ex ToUInt512Ex(ReadOnlySpan<ulong> ulongs, bool littleendian = true)
  {
    if (ulongs.Length > TypeSize / 8) throw new ArgumentOutOfRangeException(nameof(ulongs));

    var bits = new ulong[TypeSize / 8];
    Array.Copy(ulongs.ToArray(), bits, TypeSize / 8);
    if (!littleendian) Array.Reverse(bits);

    return new UInt512Ex(bits);
  }

  #endregion

  #region Conversion and Parse

  #region Conversion to UI512Ex

  #region Implicit Conversion to UI512Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt512Ex(byte value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt512Ex(char value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt512Ex(ushort value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt512Ex(uint value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt512Ex(ulong value) => new(0, 0, 0, 0, 0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt512Ex(UInt128Ex value)
  {
    var v = value.ToValues();
    return new(0, 0, 0, 0, 0, 0, v[1], v[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt512Ex(UInt256Ex value)
  {
    var v = value.ToValues();
    return new(0, 0, 0, 0, v[3], v[2], v[1], v[0]);
  }

  #endregion

  #region Explicit Conversion to UI512Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(sbyte value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(sbyte value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(short value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(short value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(int value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(int value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(long value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(long value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(float value)
  {
    return (UInt512Ex)(double)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(float value)
  {
    if (value < 0f) throw new OverflowException(nameof(value));
    return (UInt512Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(decimal value)
  {
    var ulongs = new ulong[8];
    int[] bits = decimal.GetBits(decimal.Truncate(value));
    var uints = new[] { (uint)bits[0], (uint)bits[1], (uint)bits[2], 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u };
    Buffer.BlockCopy(uints, 0, ulongs, 0, TypeSize);

    var result = new UInt512Ex(ulongs);
    if (value >= 0) return result;
    return -result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(decimal value)
  {
    if (decimal.IsNegative(value)) 
      throw new ArgumentOutOfRangeException(nameof(value));
    return (UInt512Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(double value)
  {
    if (double.IsInfinity(value) || double.IsNaN(value))
      throw new OverflowException(nameof(value));

    if (double.IsFinite(value))
      return ToUInt512Ex(value);

    throw new ArgumentOutOfRangeException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(double value)
  {
    const double pow_2_512 = 13407807929942597099574024998205846127479365820592393377723561443721764030073546976801874298166903427690031858186486050853753882811946569946433649006084096.0;
 
    if (value < 0.0) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsInfinity(value)) throw new OverflowException(nameof(value));
    if (value >= pow_2_512) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsNaN(value)) throw new OverflowException(nameof(value));

    if (double.IsFinite(value))
      return ToUInt512Ex(value);

    throw new ArgumentOutOfRangeException(nameof(value));
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(Int128Ex value)
  {
    if (value.Sign == 0) return new();

    var v = value.ToValues();
    if (value.Sign == 1) return new(0, 0, 0, 0, 0, 0, v[1], v[0]);
    return new(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, v[1], v[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(Int128Ex value)
  {
    if (value.Sign == -1) throw new OverflowException(nameof(value));

    return (UInt512Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(Int256Ex value)
  {
    if (value.Sign == 0) return new();

    ulong[] result;
    var v = value.ToValues();
    if (value.Sign >= 0)
    {
      result = new ulong[TypeSize / 8];
      Array.Copy(v, result, v.Length);
      return new(result);
    }
    result = Enumerable.Repeat(ulong.MaxValue, TypeSize / 8).ToArray();
    Array.Copy(v, 0, result, 0, v.Length);
    return new(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(Int256Ex value)
  {
    if (value.Sign == -1) throw new OverflowException(nameof(value));
    return (UInt512Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt512Ex(Int512Ex value) => new(value.ToValues());

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt512Ex(Int512Ex value)
  {
    if (value.Sign == -1) throw new OverflowException(nameof(value)); 
    return new(value.ToValues());
  }

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt512Ex ToUInt512Ex(double value)
  {
    UInt512Ex result;
    bool negate = false;
    if (value < 0)
    {
      negate = true;
      value = -value;
    }

    if (value <= ulong.MaxValue)
      result = new UInt512Ex(0, 0, 0, 0, 0, 0, 0,(ulong)value);
    else
    {
      int shift = Math.Max((int)Math.Ceiling(Math.Log(value, 2)) - 63, 0);
      result = new UInt512Ex(0, 0, 0, 0, 0, 0, 0, (ulong)(value / Math.Pow(2, shift)));
      result <<= shift;
    }

    if (negate) result = -result;
    return result;
  }

  #endregion

  #endregion

  #endregion

  #region Conversion from UI512Ex

  #region Implicit Conversion from UI512Ex
  //No Implicit Conversion
  #endregion

  #region Explicit Conversion from UI512Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator byte(UInt512Ex value) => (byte)value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ushort(UInt512Ex value) =>  (ushort)value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator uint(UInt512Ex value) =>    (uint)value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ulong(UInt512Ex value) =>   value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator char(UInt512Ex value) =>    (char)value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator sbyte(UInt512Ex value) =>   (sbyte)value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator short(UInt512Ex value) =>   (short)value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator int(UInt512Ex value) =>     (int)value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator long(UInt512Ex value) =>    (long)value.V0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator double(UInt512Ex value)
  {
    double multiplier = ulong.MaxValue;
    var result = (((((((((((((value.V7 * multiplier) + value.V6) * multiplier) + value.V5) * multiplier) + value.V4) 
                 * multiplier) + value.V3) * multiplier) + value.V2) * multiplier) + value.V1) * multiplier) + value.V0;
    return result;
  }

  public static explicit operator decimal(UInt512Ex value)
  {
    ulong lo64 = value.V0;
    uint hi32 = (uint)value.V1;
    return new decimal((int)lo64, (int)(lo64 >> 32), (int)hi32, isNegative: false, scale: 0);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator float(UInt512Ex value) => (float)(double)value;

  //checked

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked byte(UInt512Ex value)
  {
    if ((value.V7 | value.V6 | value.V5 | value.V4 | value.V3 | value.V2 | value.V1) == 0) return checked((byte)value.V0);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ushort(UInt512Ex value)
  {
    if ((value.V7 | value.V6 | value.V5 | value.V4 | value.V3 | value.V2 | value.V1) == 0) return checked((ushort)value.V0);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked uint(UInt512Ex value)
  {
    if ((value.V7 | value.V6 | value.V5 | value.V4 | value.V3 | value.V2 | value.V1) == 0) return checked((uint)value.V0);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked char(UInt512Ex value)
  {
    if ((value.V7 | value.V6 | value.V5 | value.V4 | value.V3 | value.V2 | value.V1) == 0) return checked((char)value.V0);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked sbyte(UInt512Ex value)
  {
    if ((value.V7 | value.V6 | value.V5 | value.V4 | value.V3 | value.V2 | value.V1) == 0) return checked((sbyte)value.V0);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked short(UInt512Ex value)
  {
    if ((value.V7 | value.V6 | value.V5 | value.V4 | value.V3 | value.V2 | value.V1) == 0) return checked((short)value.V0);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked int(UInt512Ex value)
  {
    if ((value.V7 | value.V6 | value.V5 | value.V4 | value.V3 | value.V2 | value.V1) == 0) return checked((int)value.V0);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked long(UInt512Ex value)
  {
    if ((value.V7 | value.V6 | value.V5 | value.V4 | value.V3 | value.V2 | value.V1) == 0) return checked((long)value.V0);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked double(UInt512Ex value)
  {
    const double pow_2_512 = 13407807929942597099574024998205846127479365820592393377723561443721764030073546976801874298166903427690031858186486050853753882811946569946433649006084096.0;
 
    double multiplier = ulong.MaxValue;
    var result = (((((((((((((value.V7 * multiplier) + value.V6) * multiplier) + value.V5) * multiplier) + value.V4)
                 * multiplier) + value.V3) * multiplier) + value.V2) * multiplier) + value.V1) * multiplier) + value.V0;
    if (result < 0 || result >= pow_2_512)
      throw new OverflowException(nameof(value));
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked decimal(UInt512Ex value)
  {
    if (value.V1 <= uint.MaxValue)
    {
      ulong lo64 = value.V0;
      uint hi32 = (uint)value.V1;
      return new decimal((int)lo64, (int)(lo64 >> 32), (int)hi32, isNegative: false, scale: 0);
    }
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked float(UInt512Ex value)
  {
    var dbl = (double)value;
    if (dbl <= float.MaxValue) return (float)dbl;
    throw new OverflowException(nameof(value));
  }

  #endregion

  #region Conversion to Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public object ToType(Type conversionType, IFormatProvider? provider) =>
    throw new NotImplementedException();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(IFormatProvider? provider) =>
    throw new NotImplementedException();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public TypeCode GetTypeCode() => TypeCode.Object;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool ToBoolean(IFormatProvider? provider) => !IsZero;

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
  public ushort ToUInt16(IFormatProvider? provider) => (ushort)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public uint ToUInt32(IFormatProvider? provider) => (uint)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ulong ToUInt64(IFormatProvider? provider) => (ulong)this;

  #endregion

  #endregion

  #region Parsing

  #region Parse

  public static UInt512Ex Parse(ReadOnlySpan<char> value, int radix)
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
  private static UInt512Ex FromDecSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt512Ex();
    var cap = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, TypeSize * 8)));
    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new UInt512Ex();
    if (val.Length == 1 && val[0] == '0') return new UInt512Ex();
    if (val.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 10, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);

    var bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new UInt512Ex(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt512Ex FromBinSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt512Ex();
    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new UInt512Ex();
    if (val.Length == 1 && val[0] == '0') return new UInt512Ex();
    if (val.Length > TypeSize * 8 + 1) throw new ArgumentOutOfRangeException(nameof(value));

    var length = RealLength(val, TypeSize * 8) / 8;
    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 2, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, length);

    var bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt512Ex FromOctSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt512Ex();

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new UInt512Ex();
    if (val.Length == 1 && val[0] == '0') return new UInt512Ex();
    int cap = Convert.ToInt32(TypeSize * Math.Log(256) / Math.Log(8)) + 1;
    if (value.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 8, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);

    var bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt512Ex FromHexSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt512Ex();

    var hex = "0123456789ABCDEF";
    var dict = new Dictionary<char, byte>();
    for (byte i = 0; i < hex.Length; i++)
      dict[hex[i]] = i;

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new UInt512Ex();
    if (val.Length == 1 && val[0] == '0') return new UInt512Ex();
    //int cap = Convert.ToInt32(TypeSize * Math.Log(256) / Math.Log(16)) + 1;
    int cap = Convert.ToInt32(TypeSize * 2) + 1;
    if (value.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytes = TrimFirst(val).ToArray().Select(s => dict[s]).ToArray();
    var tmp = Converter(bytes, 16, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);

    bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new(result);
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
  public static bool TryParse(ReadOnlySpan<char> value, out UInt512Ex uix)
  {
    var str = string.Join("", value.ToArray());
    return TryParse(str, out uix);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryParse([NotNullWhen(true)] string value, out UInt512Ex ui512) 
  {
    ui512 = 0;
    var str = value.Replace("_", "");
    for (int i = 0; i < str.Length; i++)
    {
      if ("0123456789".Contains(str[i]))
        ui512 = ui512 * 10 + ulong.Parse(str[i].ToString());
      else
      {
        ui512 = 0;
        return false;
      }
    }
    return true;
  }
  #endregion

  #endregion

  #endregion

}
