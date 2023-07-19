
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace michele.natale.Numbers;

/// <summary>
/// Represends a 256-Bit unsigned integer
/// </summary>
/// <remarks>Created by © Michele Natale</remarks>
[StructLayout(LayoutKind.Explicit)]
public readonly struct UInt256Ex : IUIntXEx<UInt256Ex>, IUInt256Ex<UInt256Ex>
{

  #region Variables


  [FieldOffset(0)]
  private readonly ulong LLO = 0;

  [FieldOffset(8)]
  private readonly ulong LHI = 0;

  [FieldOffset(16)]
  private readonly ulong RLO = 0;

  [FieldOffset(24)]
  private readonly ulong RHI = 0;

  /// <summary>
  /// Current TypeSize of this Datatype
  /// </summary>
  public const int TypeSize = 32;

  public static UInt256Ex MaxValue => new(-1);

  public static UInt256Ex MinValue => new();

  public bool IsZero
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (this.RHI | this.RLO | this.LHI | this.LLO) == 0;
  }

  public bool IsOne
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (this.RHI | this.RLO | this.LHI | this.LLO ^ 1) == 0;
  }

  public bool IsMinusOne
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => this.RHI == ulong.MaxValue && this.RLO == ulong.MaxValue &&
           this.LHI == ulong.MaxValue && this.LLO == ulong.MaxValue;
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
  public UInt256Ex()
  {
    this.LLO = this.LHI = 0ul;
    this.RLO = this.RHI = 0ul;
  }

  /// <summary>
  /// Constructor - copy values.
  /// </summary>
  /// <param name="llo">Low low value bits</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt256Ex(long llo)
  {
    this.LLO = (ulong)llo;
    this.LHI = this.RLO = this.RHI = (ulong)(llo >> 63);
  }

  /// <summary>
  /// Constructor - copy values.
  /// </summary>
  /// <param name="llo">Low low value bits</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt256Ex(ulong llo)
  {
    this.LLO = llo;
    this.LHI = this.RLO = this.RHI = 0ul;
  }

  /// <summary>
  /// Constructor - copy values
  /// </summary>
  /// <param name="rhi">High high value bits.</param>
  /// <param name="rlo">High low value bits.</param>
  /// <param name="lhi">Low high value bits.</param>
  /// <param name="llo">Low low value bits.</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt256Ex(ulong rhi, ulong rlo, ulong lhi, ulong llo)
  {
    this.LLO = llo; this.LHI = lhi;
    this.RLO = rlo; this.RHI = rhi;
  }

  /// <summary>
  /// Constructor - copy values.
  /// </summary>
  /// <param name="lohis">value bits.</param>
  /// <param name="islittleendian">True, if is little endian, otherwise false.</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt256Ex(ReadOnlySpan<ulong> lohis, bool islittleendian = true)
  {
    if (islittleendian)
    {
      this.LLO = lohis[0]; this.LHI = lohis[1];
      this.RLO = lohis[2]; this.RHI = lohis[3];
      return;
    }
    this.LLO = lohis[3]; this.LHI = lohis[2];
    this.RLO = lohis[1]; this.RHI = lohis[0];
  }

  /// <summary>
  /// Constructor - copy values.
  /// </summary>
  /// <param name="number">UInt256Ex instance</param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt256Ex(in UInt256Ex number)
  {
    this.LLO = number.LLO; this.LHI = number.LHI;
    this.RLO = number.RLO; this.RHI = number.RHI;
  }

  /// <summary>
  /// Private Constructor - copy values.
  /// </summary>
  /// <param name="values"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private UInt256Ex(uint[] values)
  {
    var result = new ulong[TypeSize / 8];
    var length = Math.Min(values.Length, TypeSize / 4);
    Buffer.BlockCopy(values, 0, result, 0, length * 4);
    this.LLO = result[0]; this.LHI = result[1];
    this.RLO = result[2]; this.RHI = result[3];
  }

  #endregion

  #region Operators

  #region Bitwise

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator ~(UInt256Ex value)
  {
    return new(BitwiseNotUI(value.ToUInts()));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator &(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(BitwiseAnd(uil, uir, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator |(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(BitwiseOr(uil, uir, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator ^(UInt256Ex left, UInt256Ex right)
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
    var result = Subtract(mv, value, value.Length);
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

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator +(UInt256Ex value) => new(value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator -(UInt256Ex value) =>
    new(NegateUnsigned(value.ToValues(), TypeSize / 8));

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static ulong[] NegateUnsigned(in ulong[] value, in int size)
  {
    //=> MaxValue - ui + One;
    var r = 1ul;
    var result = new ulong[size];
    if (result.SequenceEqual(value))
      return value.ToArray();

    result[0] = (ulong)-((UInt128Ex)value[0]);
    for (var i = 1; i < size; i++)
      result[i] = (ulong)-(r + (UInt128Ex)value[i]);
    return result;
  }

  #endregion

  #region In- Decrement

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator ++(UInt256Ex value)
  {
    return value + 1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator --(UInt256Ex value)
  {
    return value - 1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator checked ++(UInt256Ex value)
  {
    if (value != MaxValue) return value + 1;
    throw new OverflowException($"++.Checked");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator checked --(UInt256Ex value)
  {
    if (value != MinValue) return value - 1;
    throw new OverflowException($"--.Checked");
  }

  #endregion

  #region Numeric Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator +(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Addition(uil, uir, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator -(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Subtract(uil, uir, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator *(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Multiplication(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator /(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(Division(uil, uir, TypeSize / 4, out _));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator %(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    _ = Division(uil, uir, TypeSize / 4, out var remainder);
    return new(remainder);
  }

  //Checked

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator checked +(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(AdditionChecked(uil, uir, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator checked -(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    return new(SubtractChecked(uil, uir, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator checked *(UInt256Ex left, UInt256Ex right)
  {
    var uil = left.ToUInts();
    var uir = right.ToUInts();
    var result = Multiplication(uil, uir, TypeSize / 4, out var over_flow);
    if (!over_flow) return new(result);
    throw new OverflowException($"{nameof(Multiplication)}.Checked");
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator checked /(UInt256Ex left, UInt256Ex right)
  {
    return left / right;
  }

  #region Internal Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] AdditionChecked(in uint[] left, in uint[] right, in int size)
  {
    uint r = 0U;
    var rshift = (8 * size) - 1;
    var result = new uint[size];
    for (var i = 0; i < size; i++)
    {
      result[i] = left[i] + right[i] + r;
      r = ((left[i] & right[i]) | ((left[i] | right[i]) & (~result[i]))) >> rshift;
    }
    if (r == 0)
      return result;

    throw new OverflowException(nameof(AdditionChecked));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Addition(in uint[] left, in uint[] right, in int size)
  {
    uint r = 0U;
    var rshift = (8 * size) - 1;
    var result = new uint[size];
    for (var i = 0; i < size; i++)
    {
      result[i] = left[i] + right[i] + r;
      r = ((left[i] & right[i]) | ((left[i] | right[i]) & (~result[i]))) >> rshift;
    }
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] SubtractChecked(in uint[] left, in uint[] right, in int size)
  {
    var r = 0U;
    var rshift = (8 * size) - 1;
    var result = new uint[size];
    for (var i = 0; i < size; i++)
    {
      result[i] = left[i] - right[i] - r;
      r = (((~left[i]) & right[i]) | (~(left[i] ^ right[i])) & result[i]) >> rshift;
    }
    if (r == 0)
      return result;
    throw new OverflowException(nameof(SubtractChecked));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Subtract(in uint[] left, in uint[] right, in int size)
  {
    var r = 0U;
    var rshift = (8 * size) - 1;
    var result = new uint[size];
    for (var i = 0; i < size; i++)
    {
      result[i] = left[i] - right[i] - r;
      r = (((~left[i]) & right[i]) | (~(left[i] ^ right[i])) & result[i]) >> rshift;
    }
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
        l = Subtract(l, r, typesize);
        result = Addition(result, one, typesize); // result.Lo |= 1;
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

  #region Shift Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator <<(UInt256Ex value, int shiftamount)
  {
    var shift = shiftamount &= 0xFF;
    if (shift == 0) return value;
    if (shiftamount < 0) return value >> shiftamount;
    return new(LeftShift(value.ToUInts(), shift, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator >>(UInt256Ex value, int shiftamount)
  {
    var shift = shiftamount &= 0xFF;
    if (shift == 0) return value;
    if (shiftamount < 0) return value << shiftamount;
    return new(RightShift(value.ToUInts(), shift, TypeSize / 4));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex operator >>>(UInt256Ex value, int shiftamount)
  {
    return value >> shiftamount;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] LeftShift(in UInt256Ex value, in int shiftl, in int typesize)
  {
    var uints = value.ToUInts();
    return LeftShift(uints, shiftl, typesize);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] RightShift(in UInt256Ex value, in int shiftl, in int typesize)
  {
    var uints = value.ToUInts();
    return RightShift(uints, shiftl, typesize);
  }

  #endregion

  #region Equality Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override bool Equals([NotNullWhen(true)] object? obj)
  {
    if (typeof(UInt256Ex) == obj!.GetType())
      return this.Equals((UInt256Ex)obj);
    return false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Equals(UInt256Ex other)
  {
    return this == other;
  }

  public static bool operator ==(UInt256Ex left, UInt256Ex right)
  {
    if (left.LLO != right.LLO) return false;
    if (left.LHI != right.LHI) return false;
    if (left.RLO != right.RLO) return false;
    if (left.RHI != right.RHI) return false;
    return true;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(UInt256Ex left, UInt256Ex right)
  {
    return !(left == right);
  }

  #endregion

  #region Comparison Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(UInt256Ex left, UInt256Ex right)
  {
    return LessThenLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(UInt256Ex left, UInt256Ex right)
  {
    return GreaterThenLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(UInt256Ex left, UInt256Ex right)
  {
    return LessThenEqualLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(UInt256Ex left, UInt256Ex right)
  {
    return GreaterThenEqualLE(left.ToUInts(), right.ToUInts(), TypeSize / 4);
  }

  #endregion

  #endregion

  #region Number Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex Pow(UInt256Ex value, int exp)
  {
    var uints = value.ToUInts();
    var result = Pow(uints, exp, TypeSize / 4);
    return new(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex PowerOfTwo(int exp, out bool overflow)
  {
    var uints = PowerOfTwo(exp, TypeSize / 4, out overflow);
    if (overflow) return new UInt256Ex();
    return new(uints);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex PowerOfTen(int exp, out bool overflow)
  {
    var uints = PowerOfTen(exp, TypeSize / 4, out overflow);
    if (overflow) return new UInt256Ex();
    return new(uints);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsPowerTwo(UInt256Ex value) => PopCount(value) == 1u;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt256Ex Copy() => new(this.ToValues());

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex Abs(UInt256Ex value) => value;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static UInt256Ex PopCount(UInt256Ex value)
  {
    var uints = value.ToUInts();
    var result = Zero;
    for (var i = 0; i < uints.Length; i++)
      result += ulong.PopCount(uints[i]);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Span<byte> ToSpan(bool littleendian = true)
  {
    return this.ToBytes(littleendian);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ulong[] ToValues(bool littleendian = true)
  {
    if (littleendian) return new[] { this.LLO, this.LHI, this.RLO, this.RHI };
    return new[] { this.RHI, this.RLO, this.LHI, this.LLO };
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public byte[] ToBytes(bool littleendian = true)
  {
    var lo_hi = this.ToValues();
    var result = new byte[TypeSize];
    Buffer.BlockCopy(lo_hi, 0, result, 0, TypeSize);
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
    var max = (int)double.Truncate(Math.Log10(Math.Pow(2, TypeSize * tsize)));
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
  public override string ToString()
  {
    return this.ToString(10);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public readonly unsafe string ToString(int radix)
  {
    if (!new[] { 2, 8, 10, 16 }.Contains(radix))
      throw new ArgumentOutOfRangeException(nameof(radix));

    ReadOnlySpan<byte> bytes;
    var tmp = new ulong[] { this.LLO, this.LHI, this.RLO, this.RHI };
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
  public static UInt256Ex ToUInt256Ex(ReadOnlySpan<byte> bytes, bool littleendian = true)
  {
    if (bytes.Length > TypeSize)
      throw new ArgumentOutOfRangeException(nameof(bytes));

    var bits = new byte[TypeSize];
    Buffer.BlockCopy(bytes.ToArray(), 0, bits, 0, bytes.Length);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new UInt256Ex(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt256Ex ToUInt256Ex(ReadOnlySpan<uint> uints, bool littleendian = true)
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
  public static UInt256Ex ToUInt256Ex(ReadOnlySpan<ulong> ulongs, bool littleendian = true)
  {
    if (ulongs.Length > TypeSize / 8) throw new ArgumentOutOfRangeException(nameof(ulongs));

    var bits = new ulong[TypeSize / 8];
    Array.Copy(ulongs.ToArray(), bits, TypeSize / 8);
    if (!littleendian) Array.Reverse(bits);

    return new(bits);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(object? value)
  {
    if (value is UInt256Ex other) return this.CompareTo(other);
    else if (value is null) return 1;
    else throw new ArgumentException($"data type is incorrect", nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(UInt256Ex value)
  {
    if (this < value) return -1;
    else if (this > value) return 1;
    else return 0;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public readonly override int GetHashCode()
  {
    return (int)(this.RHI ^ (2ul * this.RLO) ^ (3ul * this.RLO) ^ (4ul * this.LLO));
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

  #endregion

  #region Conversion and Parse

  #region Conversion to UInt256Ex

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

  #region Implicit Conversion to UInt256Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt256Ex(byte value) => new(0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt256Ex(char value) => new(0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt256Ex(ushort value) => new(0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt256Ex(uint value) => new(0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt256Ex(ulong value) => new(0, 0, 0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt256Ex(UInt128Ex value)
  {
    var v = value.ToValues();
    return new(0, 0, v[1], v[0]);
  }

  #endregion

  #region Explicit Conversion to UInt256Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(sbyte value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(sbyte value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(short value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(short value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(int value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(int value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(long value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(long value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(float value)
  {
    return (UInt256Ex)(double)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(float value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return (UInt256Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(decimal value)
  {
    var ulongs = new ulong[4];
    int[] bits = decimal.GetBits(decimal.Truncate(value));
    var uints = new[] { (uint)bits[0], (uint)bits[1], (uint)bits[2], 0u, 0u, 0u, 0u, 0u };
    Buffer.BlockCopy(uints, 0, ulongs, 0, TypeSize);

    var result = new UInt256Ex(ulongs);
    if (value >= 0) return result;
    return -result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(decimal value)
  {
    if (decimal.IsNegative(value)) throw new ArgumentOutOfRangeException(nameof(value));
    return (UInt256Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(double value)
  {
    if (double.IsInfinity(value) || double.IsNaN(value))
      throw new OverflowException(nameof(value));

    if (double.IsFinite(value))
      return ToUInt256Ex(value);

    throw new ArgumentOutOfRangeException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(double value)
  {
    const double pow_2_256 = 115792089237316195423570985008687907853269984665640564039457584007913129639936.0;

    if (value < 0.0) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsInfinity(value)) throw new OverflowException(nameof(value));
    if (value >= pow_2_256) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsNaN(value)) throw new OverflowException(nameof(value));

    if (double.IsFinite(value))
      return ToUInt256Ex(value);

    throw new ArgumentOutOfRangeException(nameof(value));
  }


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(Int128Ex value)
  {
    if (value.Sign == 0) return new();

    var v = value.ToValues();
    if (value.Sign == 1) return new(0, 0, v[1], v[0]);
    return new(ulong.MaxValue, ulong.MaxValue, v[1], v[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(Int128Ex value)
  {
    if (value.Sign == -1) throw new OverflowException(nameof(value));

    return (UInt256Ex)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt256Ex(Int256Ex value)
  {
    return new(value.ToValues());
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt256Ex(Int256Ex value)
  {
    if (value.Sign == -1) throw new OverflowException(nameof(value));
    return new(value.ToValues());
  }

  #region Internal Methode

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt256Ex ToUInt256Ex(double value)
  {
    UInt256Ex result;
    bool negate = false;
    if (value < 0)
    {
      negate = true;
      value = -value;
    }

    if (value <= ulong.MaxValue)
      result = new UInt256Ex(0, 0, 0, (ulong)value);
    else
    {
      int shift = Math.Max((int)Math.Ceiling(Math.Log(value, 2)) - 63, 0);
      result = new UInt256Ex(0, 0, 0, (ulong)(value / Math.Pow(2, shift)));
      result <<= shift;
    }

    if (negate) result = -result;

    return result;
  }

  #endregion

  #endregion

  #endregion

  #region Conversion from UInt256Ex

  #region Implicit Conversion from UInt256Ex
  //No Implicit Conversion
  #endregion

  #region Explicit Conversion from UInt256Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator byte(UInt256Ex value)
  {
    return (byte)value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ushort(UInt256Ex value)
  {
    return (ushort)value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator uint(UInt256Ex value)
  {
    return (uint)value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ulong(UInt256Ex value)
  {
    return value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator char(UInt256Ex value)
  {
    return (char)value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator sbyte(UInt256Ex value)
  {
    return (sbyte)value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator short(UInt256Ex value)
  {
    return (short)value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator int(UInt256Ex value)
  {
    return (int)value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator long(UInt256Ex value)
  {
    return (long)value.LLO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator double(UInt256Ex value)
  {
    double multiplier = ulong.MaxValue;
    var result = (((((value.RHI * multiplier) + value.RLO) * multiplier) + value.LHI) * multiplier) + value.LLO;
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator decimal(UInt256Ex value)
  {
    ulong lo64 = value.LLO;
    uint hi32 = (uint)value.LHI;
    return new decimal((int)lo64, (int)(lo64 >> 32), (int)hi32, isNegative: false, scale: 0);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator float(UInt256Ex value)
  {
    return (float)(double)value;
  }

  //checked

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked byte(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((byte)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ushort(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((ushort)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked uint(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((uint)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ulong(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((ulong)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked char(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((char)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked sbyte(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((sbyte)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked short(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((short)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked int(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((int)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked long(UInt256Ex value)
  {
    if ((value.RHI | value.RLO | value.LHI) == 0) return checked((long)value.LLO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked double(UInt256Ex value)
  {
    const double pow_2_256 = 115792089237316195423570985008687907853269984665640564039457584007913129639936.0;

    double multiplier = ulong.MaxValue;
    var result = (((((value.RHI * multiplier) + value.RLO) * multiplier) + value.LHI) * multiplier) + value.LLO;
    if (result < 0 || result >= pow_2_256)
      throw new OverflowException(nameof(value));
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked decimal(UInt256Ex value)
  {
    ulong lo64 = value.LLO;

    if (value.LHI <= uint.MaxValue)
    {
      uint hi32 = (uint)value.LHI;
      return new decimal((int)lo64, (int)(lo64 >> 32), (int)hi32, isNegative: false, scale: 0);
    }
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked float(UInt256Ex value)
  {
    return checked((float)(double)value);
  }


  #endregion

  #endregion

  #region Parsing

  #region Parse

  public static UInt256Ex Parse(ReadOnlySpan<char> value, int radix)
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
  private static UInt256Ex FromDecSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt256Ex();
    var cap = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, TypeSize * 8)));
    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new UInt256Ex();
    if (val.Length == 1 && val[0] == '0') return new UInt256Ex();
    if (val.Length > cap) throw new ArgumentOutOfRangeException(nameof(value));

    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 10, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);

    var bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new UInt256Ex(result);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt256Ex FromBinSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt256Ex();
    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new UInt256Ex();
    if (val.Length == 1 && val[0] == '0') return new UInt256Ex();
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
  private static UInt256Ex FromOctSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt256Ex();

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new UInt256Ex();
    if (val.Length == 1 && val[0] == '0') return new UInt256Ex();
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
  private static UInt256Ex FromHexSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt256Ex();

    var hex = "0123456789ABCDEF";
    var dict = new Dictionary<char, byte>();
    for (byte i = 0; i < hex.Length; i++)
      dict[hex[i]] = i;

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    if (val.Length == 0) return new UInt256Ex();
    if (val.Length == 1 && val[0] == '0') return new UInt256Ex();
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
  public static bool TryParse(ReadOnlySpan<char> value, out UInt256Ex ui256)
  {
    var str = string.Join("", value.ToArray());
    return TryParse(str, out ui256);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryParse([NotNullWhen(true)] string value, out UInt256Ex ui256)
  {
    ui256 = 0;
    var str = value.Replace("_", "");
    for (int i = 0; i < str.Length; i++)
    {
      if ("0123456789".Contains(str[i]))
        ui256 = ui256 * 10 + ulong.Parse(str[i].ToString());
      else
      {
        ui256 = 0;
        return false;
      }
    }
    return true;
  }

  #endregion

  #endregion

  #endregion

}
