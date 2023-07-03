﻿

using michele.natale.Numbers;
using System.Runtime.InteropServices;

namespace TestUIntX;


using static Randomholder;


public class TestUInt256Ex
{
  public static void Start()
  { 

    TestSizeOf();
    TestInstance();
    TestConverts();

    TestMethodes();
    TestToString();
    TestParse();
    TestParseString();
    TestBitwise();

    TestOperation();
  }


  private static void TestBitwise()
  {
    TestBitwiseNot(); // OneComplement
    TestBitwiseAnd();
    TestBitwiseOr();
    TestBitwiseXor();
    TestBitwiseShift();
  }

  private static void TestOperation()
  {
    TestIsZeroOne();
    TestIsMinMax();
    TestEquals();
    TestGreatLessThan();
    TestIteration();

    TestNumericOperators();
  }

  private static void TestNumericOperators()
  {
    TestAddition();
    TestSubtraction();
    TestMultiplication();
    TestDivision();
    TestModulo();
    TestPow();
    TestNegate();
  }

  private unsafe static void TestSizeOf()
  {
    var size_of = sizeof(UInt256Ex);

    var type_size = Marshal.SizeOf<UInt256Ex>();
  }

  private static void TestInstance()
  {
    var instance = new UInt256Ex();

    //unsigned

    uint ui32 = 5;
    instance = new UInt256Ex(ui32);

    ulong ui64 = 5;
    instance = new UInt256Ex(ui64);

    //signed

    int i32 = 5;
    instance = new UInt256Ex(i32);

    var instance2 = new UInt256Ex(instance);
  }

  private static void TestConverts()
  {

    //unchecked

    ushort ui16 = 5;
    var instance = (UInt256Ex)(ui16);


    float flt = 5f;
    instance = (UInt256Ex)flt;

    flt = -flt;
    instance = (UInt256Ex)flt;

    double dbl = 5.0;
    instance = (UInt256Ex)dbl;

    decimal dec = -5m;
    instance = (UInt256Ex)dec;
  }

  private static void TestMethodes()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var bspan = instance.ToSpan();

    var bytes = instance.ToBytes();

    bytes = instance.ToBytes(false);

    var values = instance.ToValues();

    values = instance.ToValues(false);

    var ui128 = UInt256Ex.ToUInt256Ex(instance.ToBytes());

    ui128 = UInt256Ex.ToUInt256Ex(instance.ToValues());
  }

  private static void TestToString()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var ui128 = UInt256Ex.Parse(binstr,2);

    ui128 = UInt256Ex.Parse(octstr,8);

    ui128 = UInt256Ex.Parse(decstr,10);

    ui128 = UInt256Ex.Parse(hexstr,16);
  }

  private static void TestParse()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var ui = (uint)instance;
    var ll = (long)instance;

    if (ui != Convert.ToUInt32(instance)) throw new ArgumentException(null);
    if (ll != Convert.ToInt64(instance)) throw new ArgumentException(null);
  }

  private static void TestParseString()
  {

    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var binstr = instance.ToString(2);
    var octstr = instance.ToString(8);
    var decstr = instance.ToString(10);
    var hexstr = instance.ToString(16);

    var ui128_1 = UInt256Ex.Parse(binstr, 2);
    var ui128_2 = UInt256Ex.Parse(octstr, 8);
    var ui128_3 = UInt256Ex.Parse(decstr, 10);
    var ui128_4 = UInt256Ex.Parse(hexstr, 16);

    //bin
    var bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    var bits = string.Join("", bytes);
    var ui128 = UInt256Ex.Parse(bits, 2);
    var strbits = ui128.ToString(2);

    //Oct-Systeme können nicht frei gerandomt werden.
    bytes = Enumerable.Range(0, Rand.Next(2, 129)).Select(x => (byte)Rand.Next(0, 2)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    ui128 = UInt256Ex.Parse(bits, 2);

    var oct = ui128.ToString(8);
    bits = string.Join("", oct);
    ui128 = UInt256Ex.Parse(bits, 8);
    strbits = ui128.ToString(8);

    //dec
    bytes = Enumerable.Range(0, Rand.Next(2, 38))
      .Select(x => (byte)Rand.Next(0, 10)).ToArray();
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes);
    ui128 = UInt256Ex.Parse(bits, 10);
    strbits = ui128.ToString(10);

    //Hex
    bytes = Enumerable.Range(0, Rand.Next(2, 33))
      .Select(x => (byte)Rand.Next(0, 16)).ToArray();

    var hex = "0123456789ABCDEF";
    bytes = TrimFirstSetOneZero(bytes);
    bits = string.Join("", bytes.Select(s => hex[s]));
    ui128 = UInt256Ex.Parse(bits, 16);
    strbits = ui128.ToString(16);
  }

  private static void TestBitwiseNot()
  {

    //Complement
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += r;

    var result2 = ~instance;
  }

  private static void TestBitwiseAnd()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    instance &= r;
  }

  private static void TestBitwiseOr()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64()); 
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64()); 
    instance |= r;
  }

  private static void TestBitwiseXor()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64()); 
    instance += number;

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
 
    instance ^= r;
  }

  private static void TestBitwiseShift()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var number = (ulong)(Rand.NextInt64() * Rand.NextInt64()); 
    instance += number;

    var l = 1 + (int)double.Truncate(Math.Log10(Math.Pow(2, 256)));
    var r = Rand.Next(0, l);
 
    instance <<= r;


    r = Rand.Next(0, l);
 
    instance >>= r;


    r = Rand.Next(0, l);
 
    instance >>>= r;
  }

  private static void TestIsZeroOne()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    if (instance.IsZero) instance++;

    if (instance.IsOne) instance++;

    if (instance.IsMinusOne) instance--;

    instance = 0;
    var bool_1 = instance.IsZero;

    instance++;
    var bool_2 = instance.IsOne;

    instance--; instance--;
    var bool_3 = instance.IsMinusOne;
  }

  private static void TestIsMinMax()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    if (instance == UInt256Ex.MaxValue) instance++;

    if (instance == UInt256Ex.MinValue) instance++;

    instance = 0;
    instance--;

    if (instance == UInt256Ex.MaxValue) instance++;

    if (instance == UInt256Ex.MinValue) instance++;
  }

  private static void TestEquals()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance1 = new UInt256Ex(lo_hi);
    var instance2 = new UInt256Ex(lo_hi);

    if (!instance1.Equals(instance2))
      throw new ArgumentException(null);

    var ainstance1 = new UInt256Ex[]
    {
        (ulong)(Rand.NextInt64() * Rand.NextInt64()),
        (ulong)(Rand.NextInt64() * Rand.NextInt64()),
        (ulong)(Rand.NextInt64() * Rand.NextInt64()),
        (ulong)(Rand.NextInt64() * Rand.NextInt64()),
    };

    var ainstance2 = ainstance1.ToArray();

    if (!ainstance1.SequenceEqual(ainstance2))
      throw new ArgumentException(null);

    ainstance2[0] += 1;

    if (ainstance1.SequenceEqual(ainstance2))
      throw new ArgumentException(null);
  }

  private static void TestGreatLessThan()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance1 = new UInt256Ex(lo_hi);
    var instance2 = new UInt256Ex(lo_hi);

    if (instance1 != instance2)
      throw new ArgumentException(null);

    if (instance1++ >= instance2) ;
    else throw new ArgumentException(null);

    if (instance1-- >= instance2) ;
    else throw new ArgumentException(null);

    if (--instance1 <= instance2) ;
    else throw new ArgumentException(null);

    if (--instance1 <= instance2) ;
    else throw new ArgumentException(null);

    instance1 += 10;
    if (instance1 > instance2) ;
    else throw new ArgumentException(null);

    instance1 -= 20;
    if (instance1 < instance2) ;
    else throw new ArgumentException(null);
  }

  private static void TestIteration()
  {
    var instance = new UInt256Ex();

    instance++;
    instance--;
  }

  private static void TestAddition()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance += r;
  }

  private static void TestSubtraction()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    instance -= r;
  }

  private static void TestMultiplication()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var r = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    instance *= r;
  }

  private static void TestDivision()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var r = (ulong)Rand.NextInt64();
    instance /= r;

  }

  private static void TestModulo()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    var r = (ulong)Rand.NextInt64();
    instance %= r;
  }

  private static void TestPow()
  { 

    var instance = new UInt256Ex();

    var e = Rand.Next(0, 15);
    instance = UInt256Ex.Pow(instance, e);

    e = Rand.Next(0, 128);
    var p2 = UInt256Ex.PowerOfTwo(e, out var overflow);
    if (overflow) throw new ArgumentException(null);

    if (!UInt256Ex.IsPowerTwo(p2))
      throw new ArgumentException(null);

    e = Rand.Next(0, 39);
    var p10 = UInt256Ex.PowerOfTwo(e, out overflow);
    if (overflow) throw new ArgumentException(null);
  }

  private static void TestNegate()
  {
    var llo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var lhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rlo = (ulong)(Rand.NextInt64() * Rand.NextInt64());
    var rhi = (ulong)(Rand.NextInt64() * Rand.NextInt64());

    var lo_hi = new ulong[] { llo, lhi, rlo, rhi };
    var instance = new UInt256Ex(lo_hi);

    instance = -instance;
  }

  private static byte[] TrimFirstSetOneZero(ReadOnlySpan<byte> bytes)
  {
    if (bytes.Length < 3) return new byte[2] { 0, 1 };

    var count = 0;
    var length = bytes.Length;
    for (var i = 0; i < length; i++)
      if (bytes[i] == 0) { count++; }
      else break;

    if (count == bytes.Length) return new byte[2] { 0, 1 };
    if (count == 1) return bytes.ToArray();
    if (count == 0) return new byte[1].Concat(bytes.ToArray()).ToArray();
    return bytes.Slice(count - 1, bytes.Length - count + 1).ToArray();
  }
}



