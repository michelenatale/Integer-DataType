

using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace michele.natale.Numbers;


/// <summary>
/// Represends a 128-Bit unsigned integer
/// </summary>
/// <remarks>Created by © Michele Natale</remarks>
[StructLayout(LayoutKind.Explicit)]
public readonly struct UInt128Ex : IUIntXEx<UInt128Ex>, IUInt128Ex<UInt128Ex>
{

  #region Variables

  [FieldOffset(0)]
  private readonly ulong LO = 0;

  [FieldOffset(8)]
  private readonly ulong HI = 0;

  /// <summary>
  /// Current TypeSize of this Datatype
  /// </summary>
  public const int TypeSize = 16;

  public readonly bool IsZero
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (this.HI | this.LO) == 0;
  }

  public readonly bool IsOne
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => (this.HI | this.LO ^ 1ul) == 0;
  }

  public readonly bool IsMinusOne
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => this.HI == ulong.MaxValue && this.LO == ulong.MaxValue; //Equals maxvalue
  }

  public static UInt128Ex MaxValue
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => new(ulong.MaxValue, ulong.MaxValue);
  }

  public static UInt128Ex MinValue
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => Zero;
  }

  /// <summary>
  /// One = 1
  /// </summary> 
  public readonly static UInt128Ex One = new(0, 1);

  /// <summary>
  /// Zero = 0
  /// </summary> 
  public readonly static UInt128Ex Zero = new(0, 0);

  #endregion

  #region Constructors

  /// <summary>
  /// Default Constructor
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt128Ex()
  {
    this.HI = this.LO = 0;
  } 


  /// <summary>
  /// Copy values
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt128Ex(UInt128Ex number)
  {
    this.HI = number.HI;
    this.LO = number.LO;
  }

  /// <summary>
  /// Copy values
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt128Ex(in ulong hi, in ulong lo)
  {
    this.HI = hi;
    this.LO = lo;
  }

  /// <summary>
  /// Copy values
  /// </summary>
  /// <param name="number"></param>
  /// <remarks>Created by © Michele Natale</remarks>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt128Ex(in long lo)
  {
    this.LO = (ulong)lo;
    this.HI = (ulong)(lo >> 63);
  }

  #endregion

  #region Operators


  #region Bitwise

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator &(UInt128Ex left, UInt128Ex right)
  {
    return new UInt128Ex(left.HI & right.HI, left.LO & right.LO);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator |(UInt128Ex left, UInt128Ex right)
  {
    return new UInt128Ex(left.HI | right.HI, left.LO | right.LO);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator ^(UInt128Ex left, UInt128Ex right)
  {
    return new UInt128Ex(left.HI ^ right.HI, left.LO ^ right.LO);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator ~(UInt128Ex left)
  {
    //One-Complementare
    return new UInt128Ex(~left.HI, ~left.LO);
  }
  #endregion

  #region Unary

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator +(UInt128Ex value)
  {
    return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator -(UInt128Ex value)
  {
    return ~value + 1; //Muss genau zero - value ergeben.
  }

  #endregion

  #region In- Decrement

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator ++(UInt128Ex value)
  {
    return value + 1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator checked ++(UInt128Ex value)
  {
    return checked(value++);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator --(UInt128Ex value)
  {
    return value - 1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator checked --(UInt128Ex value)
  {
    return checked(value--);
  }

  #endregion

  #region Numeric Operation

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator -(UInt128Ex left, UInt128Ex right)
  {
    var lo = left.LO - right.LO;
    var c = (lo > left.LO) ? 1ul : 0ul;

    var hi = left.HI - right.HI - c;
    return new(hi, lo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator checked -(UInt128Ex left, UInt128Ex right)
  {
    var lo = left.LO - right.LO;
    var c = (lo > left.LO) ? 1ul : 0ul;

    var hi = checked(left.HI - right.HI - c);
    return new(hi, lo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator +(UInt128Ex left, UInt128Ex right)
  {
    var lo = left.LO + right.LO;
    var c = (lo < left.LO) ? 1ul : 0ul;

    var hi = left.HI + right.HI + c;
    return new(hi, lo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator checked +(UInt128Ex left, UInt128Ex right)
  {
    var lo = left.LO + right.LO;
    var c = (lo < left.LO) ? 1ul : 0ul;

    //If is overflow here, an exception is thrown.
    var hi = checked(left.HI + right.HI + c);
    return new(hi, lo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator *(UInt128Ex left, UInt128Ex right)
  {
    var uil = new uint[] { (uint)left.LO, (uint)(left.LO >> 32), (uint)left.HI, (uint)(left.HI >> 32) };
    var uir = new uint[] { (uint)right.LO, (uint)(right.LO >> 32), (uint)right.HI, (uint)(right.HI >> 32) };

    var result = new ulong[8];
    for (int i = 0; i < 4; i++)
      for (int j = 0; j < 4; j++)
      {
        result[i + j] += uir[i] * (ulong)uil[j];
        for (int k = i + j; k < 7; k++)
        {
          result[k + 1] += result[k] >> 32;
          result[k] &= 0xFFFFFFFFul;
        }
      }

    return (UInt128Ex)result[3] << 96 | (UInt128Ex)result[2] << 64 | (UInt128Ex)result[1] << 32 | result[0];
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator checked *(UInt128Ex left, UInt128Ex right)
  {
    //MulLOHI
    UInt128Ex al = left.LO, ah = left.HI, bl = right.LO, bh = right.HI;
    UInt128Ex ml = al * bl, t = ah * bl + ml.HI, tl = al * bh + t.LO;
    UInt128Ex hi = ah * bh + t.HI + tl.HI;
    if (hi == 0ul) return /* -lo- */ new(tl.LO, ml.LO);
    throw new OverflowException();
  } 

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator /(UInt128Ex left, UInt128Ex right)
  {
    if (right == 0)
      throw new DivideByZeroException(nameof(right));

    if (left == 0) return 0;
    if (right > left) return 0;

    ulong hi = 0, lo = 0;
    ulong rhi = 0, rlo = 0;
    int count = left.Length;

    for (int i = count - 1; i >= 0; i -= 1)
    {
      (rhi, rlo) = Shift_Left(rhi, rlo, 1);
      SetBit(0, ToBit(i, left.LO, left.HI), ref rlo, ref rhi);
      if (Greater_Then_Equal(rhi, rlo, right.HI, right.LO))
      {
        (rhi, rlo) = Minus(rhi, rlo, right.HI, right.LO);
        SetBit(i, 1, ref lo, ref hi);
      }
    }
    return new(hi, lo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator checked /(UInt128Ex left, UInt128Ex right) => left / right;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator %(UInt128Ex left, UInt128Ex right)
  {
    if (right == 0)
      throw new DivideByZeroException(nameof(right));

    if (right > left) return left;

    ulong hi = 0, lo = 0;
    ulong rhi = 0, rlo = 0;

    int count = left.Length;
    for (int i = count - 1; i >= 0; i -= 1)
    {
      (rhi, rlo) = Shift_Left(rhi, rlo, 1);
      SetBit(0, ToBit(i, left.LO, left.HI), ref rlo, ref rhi);
      if (Greater_Then_Equal(rhi, rlo, right.HI, right.LO))
      {
        (rhi, rlo) = Minus(rhi, rlo, right.HI, right.LO);
        SetBit(i, 1, ref lo, ref hi);
      }
    }
    return new(rhi, rlo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static int ToBit(int position, ulong lo, ulong hi)
  {
    if (position > 63)
      return (int)((hi >> (position - 64)) & 1UL);
    return (int)((lo >> position) & 1UL);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static void SetBit(int position, int value, ref ulong lo, ref ulong hi)
  {
    if (position > 63)
    {
      if (value != 0) hi |= 1UL << position - 64;
      else hi &= ~(1UL << position - 64);
    }
    else if (value != 0) lo |= 1UL << position;
    else lo &= ~(1UL << position);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal readonly int ToBit(int position)
  {
    if (position > 63)
      return (int)((this.HI >> (position - 64)) & 1UL);
    return (int)((this.LO >> position) & 1UL);
  } 

  internal int Length
  {
    //number of bits used (1-based)
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
      int result = 128;
      if (this.HI == 0)
      {
        if (this.LO == 0)
          return 0;
        result = 64;
      }
      while (this.ToBit(result - 1) != 1)
        result -= 1;
      return result;
    }
  }


  #region InternalMethodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool Less_Then(ulong lefthi, ulong leftlo, ulong righthi, ulong rightlo) =>
    lefthi < righthi || lefthi == righthi && leftlo < rightlo;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool Greater_Then(ulong lefthi, ulong leftlo, ulong righthi, ulong rightlo) =>
    lefthi > righthi || lefthi == righthi && leftlo > rightlo;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool Greater_Then_Equal(ulong lefthi, ulong leftlo, ulong righthi, ulong rightlo) =>
    !Less_Then(lefthi, leftlo, righthi, rightlo);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static bool Less_Then_Equal(ulong lefthi, ulong leftlo, ulong righthi, ulong rightlo) =>
    !Greater_Then(lefthi, leftlo, righthi, rightlo);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static (ulong hi, ulong lo) One_Complement(ulong valuehi, ulong valuelo) => (~valuehi, ~valuelo);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static (ulong hi, ulong lo) Unary_Minus(ulong valuehi, ulong valuelo)
  {
    (ulong vhi, ulong vlo) = One_Complement(valuehi, valuelo);
    return Plus(vhi, vlo, 0, 1);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static (ulong hi, ulong lo) Minus(ulong lefthi, ulong leftlo, ulong righthi, ulong rightlo)
  {
    (ulong vhi, ulong vlo) = Unary_Minus(righthi, rightlo);
    return Plus(lefthi, leftlo, vhi, vlo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static (ulong hi, ulong lo) Plus(ulong lefthi, ulong leftlo, ulong righthi, ulong rightlo)
  {
    ulong hi, lo;
    bool carry = false;

    if (leftlo > ulong.MaxValue - rightlo)
    {
      lo = leftlo - (ulong.MaxValue - rightlo + 1ul);
      carry = true;
    }
    else lo = leftlo + rightlo;

    if (lefthi > ulong.MaxValue - righthi)
      hi = lefthi - (ulong.MaxValue - righthi + 1ul);
    else hi = lefthi + righthi;

    if (carry)
    {
      if (hi == ulong.MaxValue) hi = 0;
      else hi += 1ul;
    }
    return new(hi, lo);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static (ulong hi, ulong lo) Shift_Left(ulong hi, ulong lo, int shiftamount)
  {
    int shift = shiftamount &= 0x7F;
    if (shift == 0) return (lo, hi);
    else if (shift < 64)
      return (hi << shift | lo >> 64 - shift, lo << shift);
    else return (lo << shift - 64, 0);
  }

  #endregion
  #endregion

  #region Shift Operations

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator >>(UInt128Ex value, int shiftamount)
  {
    int shift = shiftamount &= 0x7F;
    if (shiftamount == 0) return value;
    else if (shiftamount < 0) return value << -shiftamount;
    else if (shift < 64)
      return new UInt128Ex(value.HI >> shift, value.LO >> shift | value.HI << 64 - shift);
    else return value.HI >> shift - 64;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator <<(UInt128Ex value, int shiftamount)
  {
    int shift = shiftamount &= 0x7F;
    if (shift == 0) return value;
    else if (shiftamount < 0) return value >> -shiftamount;
    else if (shift < 64)
      return new UInt128Ex(value.HI << shift | value.LO >> 64 - shift, value.LO << shift);
    else return new UInt128Ex(value.LO << shift - 64, 0);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex operator >>>(UInt128Ex value, int shiftamount)
  {
    shiftamount &= 0x7F;

    if ((shiftamount & 0x40) != 0) return new(0, value.HI >> shiftamount);
    else if (shiftamount != 0)
    {
      ulong lo = (value.LO >> shiftamount) | (value.HI << (64 - shiftamount));
      ulong hi = value.HI >> shiftamount;
      return new(hi, lo);
    }

    return value;
  }

  #endregion

  #region Equality Operators


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override readonly bool Equals([NotNullWhen(true)] object? obj)
  {
    if (typeof(UInt128Ex) == obj!.GetType())
      return this.Equals((UInt128Ex)obj);
    return false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public readonly bool Equals(UInt128Ex other)
  {
    return this.HI == other.HI && this.LO == other.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator ==(UInt128Ex left, UInt128Ex right)
  {
    return left.HI == right.HI && left.LO == right.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator !=(UInt128Ex left, UInt128Ex right)
  {
    return !(left == right);
  }

  #endregion

  #region  Comparison Operators

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <(UInt128Ex left, UInt128Ex right)
  {
    return left.HI < right.HI || left.HI == right.HI && left.LO < right.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >(UInt128Ex left, UInt128Ex right)
  {
    return left.HI > right.HI || left.HI == right.HI && left.LO > right.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator >=(UInt128Ex left, UInt128Ex right)
  {
    return !(left < right);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool operator <=(UInt128Ex left, UInt128Ex right)
  {
    return !(left > right);
  }

  #endregion

  #endregion

  #region Number Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex Abs(UInt128Ex value)
  {
    return value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex Pow(UInt128Ex value, int exp)
  {
    var uivalue = new uint[] { (uint)value.LO, (uint)(value.LO >> 32), (uint)value.HI, (uint)(value.HI >> 32) };
    var uints = Pow(uivalue, exp, TypeSize / 4);

    var lohi = new ulong[TypeSize / 8];
    Buffer.BlockCopy(uints, 0, lohi, 0, TypeSize);
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex PowerOfTwo(int exp, out bool overflow)
  {
    var uints = PowerOfTwo(exp, TypeSize / 4, out overflow);
    if (overflow) return new UInt128Ex();

    var lohi = new ulong[TypeSize / 8];
    Buffer.BlockCopy(uints, 0, lohi, 0, TypeSize);
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex PowerOfTen(int exp, out bool overflow)
  {
    var uints = PowerOfTwo(exp, TypeSize / 4, out overflow);
    if (overflow) return new UInt128Ex();

    var lohi = new ulong[TypeSize / 8];
    Buffer.BlockCopy(uints, 0, lohi, 0, TypeSize);
    return new(lohi[1], lohi[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsPowerTwo(UInt128Ex value) => PopCount(value) == 1u;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public Span<byte> ToSpan(in bool littleendian = true)
  {
    return this.ToBytes(littleendian);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public byte[] ToBytes(in bool littleendian = true)
  {
    var lo_hi = new ulong[] { this.LO, this.HI };
    var result = new byte[TypeSize];
    Buffer.BlockCopy(lo_hi, 0, result, 0, TypeSize);
    if (!littleendian) Array.Reverse(result);
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public ulong[] ToValues(in bool littleendian = true)
  {
    if (littleendian) return new ulong[] { this.LO, this.HI };
    return new ulong[] { this.HI, this.LO };
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public UInt128Ex Copy()
  {
    return new UInt128Ex(this);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex ToUInt128Ex(ReadOnlySpan<byte> bytes, bool littleendian = true)
  {
    if (bytes.Length > TypeSize) throw new ArgumentOutOfRangeException(nameof(bytes));

    var bits = new byte[TypeSize];
    Buffer.BlockCopy(bytes.ToArray(), 0, bits, 0, bytes.Length);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new UInt128Ex(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex ToUInt128Ex(ReadOnlySpan<uint> uints, bool littleendian = true)
  {
    if (uints.Length > TypeSize / 4) throw new ArgumentOutOfRangeException(nameof(uints));

    var bits = new uint[TypeSize / 4];
    Buffer.BlockCopy(uints.ToArray(), 0, bits, 0, uints.Length * 4);
    if (!littleendian) Array.Reverse(bits);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bits, 0, result, 0, TypeSize);
    return new UInt128Ex(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex ToUInt128Ex(ReadOnlySpan<ulong> ulongs, bool littleendian = true)
  {
    if (ulongs.Length > TypeSize / 8) throw new ArgumentOutOfRangeException(nameof(ulongs));

    var bits = new ulong[TypeSize / 8];
    Array.Copy(ulongs.ToArray(), bits, TypeSize / 8); 
    if (!littleendian) Array.Reverse(bits);

    return new UInt128Ex(bits[1], bits[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(object? value)
  {
    if (value is UInt128Ex other) return this.CompareTo(other);
    else if (value is null) return 1;
    else throw new ArgumentException($"data type is incorrect", nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public int CompareTo(UInt128Ex value)
  {
    if (this < value) return -1;
    else if (this > value) return 1;
    else return 0;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public readonly override int GetHashCode()
  {
    return (int)(this.HI ^ (2 * this.LO));
  }


  [SkipLocalsInit]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] Pow(uint[] value, int exp, int tsize)
  {
    if (exp < 0)
      throw new ArgumentOutOfRangeException(nameof(exp));

    uint[] result = new uint[tsize];
    result[0] = 1;
    while (exp != 0)
    {
      if ((exp & 1) == 1)
        result = Multiplication(value, result, tsize, out _);
      value = Multiplication(value, value, tsize, out _);
      exp >>= 1;
    }
    return result;
  }

  [SkipLocalsInit]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] PowerOfTen(int exp, int tsize, out bool overflow)
  {
    overflow = true;
    var max = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, 4 * tsize)));
    if (exp >= max)
      return new uint[tsize];

    overflow = false;
    if (exp == 0) { var a = new uint[tsize]; a[0] = 1; return a; }
    if (exp == 1) { var a = new uint[tsize]; a[0] = 10; return a; }

    var result = new uint[tsize]; result[0] = 10;
    var expui = result.ToArray();
    for (var i = 1; i < exp; i++)
      result = Multiplication(result, expui, tsize, out overflow);
    if (exp >= (max - 1)) overflow = true;
    return result;
  }


  [SkipLocalsInit]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static uint[] PowerOfTwo(int exp, int tsize, out bool overflow)
  {
    overflow = true;
    var max = 4 * 32;
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

  [SkipLocalsInit]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static uint[] Multiplication(in uint[] left, in uint[] right, int tsize, out bool over_flow)
  {
    int index;
    ulong remainder;
    over_flow = false;
    var result = new uint[tsize];
    if (left.SequenceEqual(result)) return result;
    if (right.SequenceEqual(result)) return result;

    result[0] = 1;
    if (left.SequenceEqual(result)) return right.ToArray();
    if (right.SequenceEqual(result)) return left.ToArray();

    result = new uint[2 * tsize];
    for (int i = 0; i < tsize; i++)
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
    for (int i = tsize; i < result.Length; i++)
      if (result[i] != 0) { over_flow = true; break; }
    return result.Take(tsize).ToArray();
  }

  [SkipLocalsInit]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static UInt128Ex PopCount(UInt128Ex value) => ulong.PopCount(value.LO) + ulong.PopCount(value.HI);

  [SkipLocalsInit]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static UInt128Ex MulLOHI(UInt128Ex left, UInt128Ex right, out UInt128Ex lower)
  {
    UInt128Ex al = left.LO, ah = left.HI, bl = right.LO, bh = right.HI;
    UInt128Ex ml = al * bl, t = ah * bl + ml.HI, tl = al * bh + t.LO;
    UInt128Ex hi = ah * bh + t.HI + tl.HI, lo = new(tl.LO, ml.LO);
    UInt128Ex lo123 = tl << 64 | (ulong)ml;
    if (lo != lo123) Debugger.Break();
    lower = lo;
    return hi;
  }
  #endregion

  #region Formatting Methodes

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public override string ToString()
  {
    return this.ToString(10);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public readonly unsafe string ToString(in int radix)
  {
    if (!new[] { 2, 8, 10, 16 }.Contains(radix))
      throw new ArgumentOutOfRangeException(nameof(radix));

    ReadOnlySpan<byte> bytes;
    var tmp = new ulong[] { this.LO, this.HI };
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
  public static UInt128Ex FromDualSystem(ReadOnlySpan<char> binstr)
  {
    var bytes = binstr.ToArray().Skip(1).Select(c => byte.Parse(c.ToString()));

    return ToUInt128Ex(Converter(bytes.ToArray(), 2, 256).Reverse().ToArray());
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex FromOctalSystem(ReadOnlySpan<char> octalstr)
  {
    var bytes = octalstr.ToArray().Select(c => byte.Parse(c.ToString()));

    return ToUInt128Ex(Converter(bytes.ToArray(), 8, 256).Reverse().ToArray());
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex FromDecimalSystem(ReadOnlySpan<char> decimalstr)
  {
    var bytes = decimalstr.ToArray().Select(c => byte.Parse(c.ToString()));

    return ToUInt128Ex(Converter(bytes.ToArray(), 10, 256).Reverse().ToArray());
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex FromHexSystem(ReadOnlySpan<char> hexstr)
  {
    var h = "0123456789ABCDEF";
    var dict = new Dictionary<char, byte>();
    for (byte i = 0; i < h.Length; i++)
      dict[h[i]] = i;

    var bytes = hexstr.ToArray().Select(c => dict[c]);

    return ToUInt128Ex(Converter(bytes.ToArray(), 16, 256).Reverse().ToArray());
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
  #region Conversion to UInt128Ex

  #region Implicit Conversion to UInt128Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt128Ex(byte value) => new(0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt128Ex(char value) => new(0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt128Ex(ushort value) => new(0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt128Ex(uint value) => new(0, value);

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static implicit operator UInt128Ex(ulong value) => new(0, value);

  #endregion

  #region Explicit Conversion to UInt128Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt128Ex(sbyte value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt128Ex(sbyte value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt128Ex(short value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt128Ex(short value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt128Ex(int value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt128Ex(int value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt128Ex(long value)
  {
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt128Ex(long value)
  {
    if (value < 0) throw new OverflowException(nameof(value));
    return new(value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt128Ex(float value)
  {
    return (UInt128Ex)(double)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt128Ex(float value)
  {
    return checked((UInt128Ex)(double)value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt128Ex(double value)
  {
    if (double.IsInfinity(value) || double.IsNaN(value))
      //return MinValue;
      throw new OverflowException(nameof(value));

    if (double.IsFinite(value))
      return ToUInt128Ex(value);

    throw new ArgumentOutOfRangeException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt128Ex(double value)
  {
    const double pow_2_128 = 340282366920938463463374607431768211456.0;

    if (value < 0.0) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsInfinity(value)) throw new OverflowException(nameof(value));
    if (value >= pow_2_128) throw new ArgumentOutOfRangeException(nameof(value));
    if (double.IsNaN(value)) throw new OverflowException(nameof(value));

    if (double.IsFinite(value))
      return ToUInt128Ex(value);

    throw new ArgumentOutOfRangeException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt128Ex(decimal value)
  {
    var result = new ulong[2];
    int[] bits = decimal.GetBits(decimal.Truncate(value));
    var uints = new[] { (uint)bits[0], (uint)bits[1], (uint)bits[2], 0u };

    if (value < 0)
    {
      Buffer.BlockCopy(uints, 0, result, 0, TypeSize);

      //NegateUnsigned
      var lo = (ulong)(-(long)result[0]);
      var hi = ((0 == result[0]) ? (ulong)(-(long)result[1]) : (ulong)(-1 - (long)result[1]));
      return new(hi, lo);
    }

    Buffer.BlockCopy(uints, 0, result, 0, TypeSize);
    return new(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt128Ex(decimal value)
  {
    if (decimal.IsNegative(value)) throw new ArgumentOutOfRangeException(nameof(value));

    var result = new ulong[2];
    int[] bits = decimal.GetBits(decimal.Truncate(value));
    var uints = new[] { (uint)bits[0], (uint)bits[1], (uint)bits[2], 0u };

    Buffer.BlockCopy(uints, 0, result, 0, TypeSize);
    return new(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator UInt128Ex(Int128Ex value)
  {
    var values = value.ToValues();
    return new(values[1], values[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked UInt128Ex(Int128Ex value)
  {
    if (value < 0) throw new OverflowException(nameof(value));

    var values = value.ToValues();
    return new(values[1], values[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt128Ex ToUInt128Ex(double value)
  {
    UInt128Ex result;
    var nsign = false;

    if (value < 0)
    {
      nsign = true;
      value = -value;
    }

    if (value <= ulong.MaxValue)
      result = new UInt128Ex(0, (ulong)value);
    else
    {
      var shift = Math.Max((int)Math.Ceiling(Math.Log(value, 2)) - 63, 0);
      result = new UInt128Ex(0, (ulong)(value / Math.Pow(2, shift)));
      result <<= shift;
    }

    if (nsign)
      result = -result;

    return result;
  }

  #endregion

  #endregion

  #region Conversion To Methodes


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public string ToString(IFormatProvider? provider) => throw new NotImplementedException();

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public object ToType(Type conversionType, IFormatProvider? provider) => throw new NotImplementedException();


  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public TypeCode GetTypeCode() => TypeCode.Object;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool ToBoolean(IFormatProvider? provider) => !this.IsZero;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public byte ToByte(IFormatProvider? provider) => (byte)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public char ToChar(IFormatProvider? provider) => (char)this;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public DateTime ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(this.ToDecimal(provider), provider);

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

  #region Conversion from UInt128Ex

  #region Implicit Conversion from UInt128Ex
  //No Implicit Conversion from UInt128Ex
  #endregion

  #region Explicit Conversion from UInt128Ex

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator byte(UInt128Ex value)
  {
    return (byte)value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked byte(UInt128Ex value)
  {
    if (value.HI == 0) return checked((byte)value.LO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ushort(UInt128Ex value)
  {
    return (ushort)value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ushort(UInt128Ex value)
  {
    if (value.HI == 0) return checked((ushort)value.LO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator uint(UInt128Ex value)
  {
    return (uint)value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked uint(UInt128Ex value)
  {
    if (value.HI == 0) return checked((uint)value.LO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator ulong(UInt128Ex value)
  {
    return value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked ulong(UInt128Ex value)
  {
    if (value.HI == 0) return value.LO;
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator char(UInt128Ex value)
  {
    return (char)value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked char(UInt128Ex value)
  {
    if (value.HI == 0) return checked((char)value.LO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator sbyte(UInt128Ex value)
  {
    return (sbyte)value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked sbyte(UInt128Ex value)
  {
    if (value.HI == 0) return checked((sbyte)value.LO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator short(UInt128Ex value)
  {
    return (short)value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked short(UInt128Ex value)
  {
    if (value.HI == 0) return checked((short)value.LO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator int(UInt128Ex value)
  {
    return (int)value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked int(UInt128Ex value)
  {
    if (value.HI == 0) return checked((int)value.LO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator long(UInt128Ex value)
  {
    return (long)value.LO;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked long(UInt128Ex value)
  {
    if (value.HI == 0) return checked((long)value.LO);
    throw new OverflowException();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator double(UInt128Ex value)
  {
    double multiplier = ulong.MaxValue;
    var result = (value.HI * multiplier) + value.LO;
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked double(UInt128Ex value)
  {
    const double pow_2_128 = 340282366920938463463374607431768211456.0;

    double multiplier = ulong.MaxValue;
    var result = (value.HI * multiplier) + value.LO;
    if (result < 0 || result >= pow_2_128)
      throw new OverflowException(nameof(value));
    return result;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator decimal(UInt128Ex value)
  {
    ulong lo64 = value.LO;
    uint hi32 = (uint)value.HI;
    return new decimal((int)lo64, (int)(lo64 >> 32), (int)hi32, isNegative: false, scale: 0);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked decimal(UInt128Ex value)
  {

    ulong lo64 = value.LO;

    if (value.HI <= uint.MaxValue)
    {
      uint hi32 = (uint)value.HI;
      return new decimal((int)lo64, (int)(lo64 >> 32), (int)hi32, isNegative: false, scale: 0);
    }
    throw new OverflowException(nameof(value));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator float(UInt128Ex value)
  {
    return (float)(double)value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static explicit operator checked float(UInt128Ex value)
  {
    return checked((float)(double)value);
  }


  #endregion

  #endregion

  #region Parsing

  #region Parse

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static UInt128Ex Parse(ReadOnlySpan<char> value, int radix)
  {
    if (!new[] { 2, 8, 10, 16 }.Contains(radix))
      throw new ArgumentOutOfRangeException(nameof(radix));

    return radix switch
    {
      2 => ToBinSystem(value),
      8 => ToOctSystem(value),
      10 => ToDecSystem(value),
      16 => ToHexSystem(value),
      _ => throw new ArgumentException("radix 2, 8, 10, 16", nameof(radix)),
    };
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt128Ex ToDecSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt128Ex();
    var l = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, 128)));
    if (value.Length > l) throw new ArgumentOutOfRangeException(nameof(value));

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 10, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);

    var bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new UInt128Ex(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt128Ex ToBinSystem(ReadOnlySpan<char> value)
  {

    if (value.Length == 0) return new UInt128Ex();
    if (value.Length > TypeSize * 8 + 1)
      throw new ArgumentOutOfRangeException(nameof(value));

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    var length = RealLength(val, TypeSize * 8) / 8;
    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 2, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, length);

    var bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new UInt128Ex(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt128Ex ToOctSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt128Ex();
    if (value.Length > 44) throw new ArgumentOutOfRangeException(nameof(value));

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    var bytesvalue = TrimFirst(val).ToArray().Select(x => byte.Parse(x.ToString())).ToArray();
    var tmp = Converter(bytesvalue, 8, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);

    var bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new UInt128Ex(result[1], result[0]);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static UInt128Ex ToHexSystem(ReadOnlySpan<char> value)
  {
    if (value.Length == 0) return new UInt128Ex();
    if (value.Length > 33) throw new ArgumentOutOfRangeException(nameof(value));

    var hex = "0123456789ABCDEF";

    var dict = new Dictionary<char, byte>();
    for (byte i = 0; i < hex.Length; i++)
      dict[hex[i]] = i;

    var val = string.Join("", value.ToArray()).Replace("_", string.Empty);
    var bytes = TrimFirst(val).ToArray().Select(s => dict[s]).ToArray();
    var tmp = Converter(bytes, 16, 256);
    Array.Reverse(tmp);
    Array.Resize(ref tmp, TypeSize);

    bytes = new byte[TypeSize];
    Array.Copy(tmp, bytes, TypeSize);

    var result = new ulong[TypeSize / 8];
    Buffer.BlockCopy(bytes, 0, result, 0, TypeSize);
    return new UInt128Ex(result[1], result[0]);
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
  public static bool TryParse(ReadOnlySpan<char> value, out UInt128Ex ui128)
  {
    var str = string.Join("", value.ToArray());
    return TryParse(str, out ui128);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool TryParse([NotNullWhen(true)] string value, out UInt128Ex ui128)
  {
    ui128 = 0;
    for (int i = 0; i < value.Length; i++)
    {
      if ("0123456789".Contains(value[i]))
        ui128 = ui128 * 10 + Convert.ToUInt32(value[i]);
      else
      {
        ui128 = 0;
        return false;
      }
    }
    return true;
  }


  #endregion

  #endregion
  #endregion
}


